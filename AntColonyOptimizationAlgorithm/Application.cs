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
                txtCurrentProgress.Text = i.ToString();
                progressBar.Dispatcher.Invoke(() => progressBar.Value = (i*100/(double)item.Value[4]), DispatcherPriority.Background);
                currentRun.Run(item.Value[2], item.Value[3], item.Key);
            }                   
        }     
    }
}
