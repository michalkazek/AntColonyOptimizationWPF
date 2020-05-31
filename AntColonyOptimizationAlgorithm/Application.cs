using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace AntColonyOptimizationAlgorithm
{
    public class Application
    {
        public static void Run(Dictionary<string, List<int>> inputParameters, ProgressBar progressBar, TextBlock txtCurrentProgress)
        {
            Random randomGenerator = new Random();
            var item = inputParameters.First();
            var currentRun = new Alghoritm(item.Value[0], item.Value[1], 0.005f, 0.0000000010f, randomGenerator);
            for (int i = 1; i < item.Value[4]+1; i++)
            {               
                progressBar.Dispatcher.Invoke(() => progressBar.Value = (Math.Round(i*100/(float)item.Value[4], 0, MidpointRounding.AwayFromZero)), DispatcherPriority.Background);
                txtCurrentProgress.Text = i.ToString();
                currentRun.Run(item.Value[2], item.Value[3], item.Key);
            }                   
        }     
    }
}
