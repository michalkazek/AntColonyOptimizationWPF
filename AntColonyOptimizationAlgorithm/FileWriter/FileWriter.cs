﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyOptimizationAlgorithm
{
    static class FileWriter
    {
        public static void SaveSummaryIntoFile(float firstFoundDistance, float bestFoundDistance, int bestFoundDistanceIteration, float alfa, float beta, int numberOfAnts, int numberOfIterations, string inputFileName)
        {
            var fileName = $"{inputFileName}-{alfa}_{beta}_{numberOfAnts}_{numberOfIterations}";
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + $@"\Results\{fileName}.csv";
            using (var outputFile = new StreamWriter(path, append: true))
            {
                outputFile.WriteLine($"{bestFoundDistance}; {bestFoundDistanceIteration}; {firstFoundDistance}");
            }
        }
    }
}
