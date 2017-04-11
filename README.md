# Description
This repository is the source for our final project for Dr. Zoppetti's Parallel Programming course at Millersville University for the Spring 2017 semester. The project seeks to convert a bitmap image to a black/white ASCII representation. 

# Purpose
The purpose of this project is to solve a non-trivial programming problem using a parallel solution. In this project, we aim to implement our conversion using an elegant and efficient parallel algorithm that partitions the pixels of the image into even solution spaces, and then generates that portion of the overall image's ascii art. 

# Specification
We will attempt to meet the following specifications for the project:
  * Generate an ascii image from a source bitmap using a parallel algorithm
  * Allow users to specify the number of threads/processes that will be used in the algorithm
  * Allow the generated asci image to be exported to a text file
  * Display processing speeds for the algorithm
  * Allow users to clear and re-run the algorithm
  
# Technologies
Project will be done using the latest .NET framework (.NET 4.5.2 at time of initial commit), C#, and the native .NET drawing/threading libraries. 
