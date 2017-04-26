using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArtConverter
{
    internal static class ExtentionMethods
    {
        private static object lockObject = new object();
        public static char[,] ToGrayScaleRGBMatrix(this Bitmap bitmap)
        {
            char[,] pixelMatrix = new char[bitmap.Width, bitmap.Height];
            for (int x = 0; x < bitmap.Width; ++x)
            {
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    pixelMatrix[x, y] = GrayToAscii((pixel.R + pixel.G + pixel.B) / 3);
                }
            }
            return pixelMatrix;
        }

        public static char[,] ToGrayScaleRGBMatrixAsync(this Bitmap bitmap, int threadCount)
        {
            char[,] pixelMatrix = new char[bitmap.Width, bitmap.Height];
            int indexMod = bitmap.Height / threadCount;
            var tasks = new List<Task>(threadCount);
            
            for (int i = 0; i != threadCount;++i)
            {
                int startIndex  = i == 0 ? 0 : i * indexMod;
                int endIndex    = i == threadCount - 1 ? bitmap.Height : startIndex + indexMod;
                int width = bitmap.Width;
                
                tasks.Add(Task.Factory.StartNew(() => 
                {
                    Bitmap localMap;
                    lock(lockObject)
                    {
                        localMap = (Bitmap)bitmap.Clone();
                    }
                    for (int x = 0; x < width; ++x)
                    {
                        for (int y = startIndex; y < endIndex; ++y)
                        {
                            var pixel = localMap.GetPixel(x, y);
                            pixelMatrix[x, y] = GrayToAscii((pixel.R + pixel.G + pixel.B) / 3);
                        }
                    }
                    localMap.Dispose();
                }));
            }
            Task.WaitAll(tasks.ToArray());

            return pixelMatrix;
        }

        public static bool IsBlack(this Color pixel)
        {
            return pixel.GetBrightness() < 0.02;
        }

        private static char GrayToAscii(int RGB)
        {
            // .:-=+*#%@
            int x = RGB / 25;
            switch (x)
            {
                case 0:
                    return '@';
                case 1:
                    return '%';
                case 2:
                    return '#';
                case 3:
                    return '*';
                case 4:
                    return '+';
                case 5:
                    return '=';
                case 6:
                    return '-';
                case 7:
                    return ':';
                case 8:
                    return '.';
                case 9:
                    return ' ';
                case 10:
                    return ' ';
            }
            return ' ';
        }


    }
}
