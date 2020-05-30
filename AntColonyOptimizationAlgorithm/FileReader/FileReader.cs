using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyOptimizationAlgorithm
{
    class FileReader
    {
        public string FileName { get; set; }
        private int matrixSize;

        public FileReader(string fileName)
        {
            FileName = fileName;
        }       

        public int[,] CreateDistanceMatrix()
        {
            string currentLine;
            int[,] distanceMatrix = null;
            bool isFileSymetric = true;

            List<string> splittedLine = new List<string>();

            string filePath = Directory.GetCurrentDirectory() + $@"\Data\{FileName}";

            using (StreamReader reader = new StreamReader(filePath))
            {
                matrixSize = int.Parse(reader.ReadLine());
                distanceMatrix = new int[matrixSize, matrixSize];

                for (int rowId = 0; rowId < matrixSize; rowId++)
                {
                    currentLine = reader.ReadLine();
                    splittedLine.AddRange(currentLine.Trim().Split(' '));
                    if(rowId == 0 && splittedLine.Count == matrixSize)
                    {
                        isFileSymetric = false;
                    }
                    for (int columnId = 0; columnId < splittedLine.Count; columnId++)
                    {
                        distanceMatrix[rowId, columnId] = int.Parse(splittedLine[columnId]);
                        if (isFileSymetric)
                        {
                            distanceMatrix[columnId, rowId] = int.Parse(splittedLine[columnId]);
                        }    
                    }
                    splittedLine.Clear();
                }
            }            
            return distanceMatrix;
        }

        public int GetMatrixSize()
        {
            return matrixSize;
        }
    }
}
