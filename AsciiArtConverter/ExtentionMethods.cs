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
                    pixelMatrix[x, y] = GrayToAscii70((pixel.R + pixel.G + pixel.B) / 3);
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

        private static char GrayToAscii70(int RGB)
        {
            //$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\|()1{}[]?-_+~<>i!lI;:,"^`'. 
            int x = RGB / 3;
            switch (x)
            {
                case 0:
                    return '$';
                case 1:
                    return '@';
                case 2:
                    return 'B';
                case 3:
                    return '%';
                case 4:
                    return '8';
                case 5:
                    return '&';
                case 6:
                    return 'W';
                case 7:
                    return 'M';
                case 8:
                    return '#';
                case 9:
                    return '*';
                case 10:
                    return 'o';
                case 11:
                    return 'a';
                case 12:
                    return 'h';
                case 13:
                    return 'k';
                case 14:
                    return 'b';
                case 15:
                    return 'd';
                case 16:
                    return 'p';
                case 17:
                    return 'q';
                case 18:
                    return 'w';
                case 19:
                    return 'm';
                case 20:
                    return 'Z';
                case 21:
                    return 'O';
                case 22:
                    return '0';
                case 23:
                    return 'Q';
                case 24:
                    return 'L';
                case 25:
                    return 'C';
                case 26:
                    return 'J';
                case 27:
                    return 'U';
                case 28:
                    return 'Y';
                case 29:
                    return 'X';
                case 30:
                    return 'z';
                case 31:
                    return 'c';
                case 32:
                    return 'v';
                case 33:
                    return 'u';
                case 34:
                    return 'n';
                case 35:
                    return 'x';
                case 36:
                    return 'r';
                case 37:
                    return 'j';
                case 38:
                    return 'f';
                case 39:
                    return 't';
                case 40:
                    return '/';
                case 41:
                    return '\\';
                case 42:
                    return '|';
                case 43:
                    return '(';
                case 44:
                    return ')';
                case 45:
                    return '1';
                case 46:
                    return '{';
                case 47:
                    return '}';
                case 48:
                    return '[';
                case 49:
                    return ']';
                case 50:
                    return '?';
                case 51:
                    return '-';
                case 52:
                    return '_';
                case 53:
                    return '+';
                case 54:
                    return '~';
                case 55:
                    return '<';
                case 56:
                    return '>';
                case 57:
                    return 'i';
                case 58:
                    return '!';
                case 59:
                    return 'l';
                case 60:
                    return 'I';
                case 61:
                    return ';';
                case 62:
                    return ':';
                case 63:
                    return ',';
                case 64:
                    return '"';
                case 65:
                    return ' ';
                case 66:
                    return '^';
                case 67:
                    return '`';
                case 68:
                    return '\'';
                case 69:
                    return '.';
                case 70:
                    return ' ';
            }
            return ' ';
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
