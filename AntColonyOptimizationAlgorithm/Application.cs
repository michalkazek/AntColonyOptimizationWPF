using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonyOptimizationAlgorithm
{
    public class Application
    {              
        public static void Run(Dictionary<string, List<int>> inputParameters)
        {
            Random randomGenerator = new Random();
            var item = inputParameters.First();
            var currentRun = new Alghoritm(item.Value[0], item.Value[1], 0.005f, 0.0000000010f, randomGenerator);
            for (int i = 0; i < item.Value[4]; i++)
            {
                currentRun.Run(item.Value[2], item.Value[3], item.Key);
            }                   
        }     
    }
}
