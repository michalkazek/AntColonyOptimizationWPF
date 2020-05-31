using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AntColonyOptimizationWPF
{
    public partial class RunPage : Page
    {
        public ItemCollection taskCollection { get; set; }
        public RunPage(ItemCollection taskCollection)
        {
            InitializeComponent();
            this.taskCollection = taskCollection;       
        }
        private void RunAlghorithm()
        {
            txtMaxFullProgress.Text = $"/{taskCollection.Count.ToString()}";
            int taskCounter = 1;

            foreach (var task in taskCollection)
            {
                txtCurrentFullProgress.Text = taskCounter.ToString();              

                var apllicationParametersDictionary = new Dictionary<string, List<int>>();
                var propertyList = task.GetType().GetProperties();
                var numericValuesList = new List<int>();

                for (int i = 1; i < propertyList.Length; i++)
                {
                    numericValuesList.Add(Convert.ToInt32(propertyList[i].GetValue(task, null)));
                }
                apllicationParametersDictionary.Add(propertyList[0].GetValue(task, null).ToString(), numericValuesList);
                txtMaxPartialProgress.Text = $"/{apllicationParametersDictionary.First().Value[4].ToString()}";

                try
                {
                    AntColonyOptimizationAlgorithm.Application.Run(apllicationParametersDictionary, prgCurrentIteration, txtCurrentPartialProgress);
                    prgCurrentTask.Dispatcher.Invoke(() => prgCurrentTask.Value = (taskCounter * 100 / (double)taskCollection.Count), DispatcherPriority.Background);
                    taskCounter++;
                } 
                catch (Exception ex)
                {
                    
                }               
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            RunAlghorithm();
        }
    }
}
