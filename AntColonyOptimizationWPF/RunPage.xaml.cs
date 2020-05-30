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

namespace AntColonyOptimizationWPF
{
    /// <summary>
    /// Interaction logic for RunPage.xaml
    /// </summary>
    public partial class RunPage : Page
    {
        public RunPage(ItemCollection taskCollection)
        {
            InitializeComponent();
            ParseItemCollectionIntoDictionary(taskCollection);
        }
        private void ParseItemCollectionIntoDictionary(ItemCollection taskCollection)
        {
            foreach (var task in taskCollection)
            {
                var apllicationParametersDictionary = new Dictionary<string, List<int>>();
                var propertyList = task.GetType().GetProperties();
                var numericValuesList = new List<int>();

                for (int i = 1; i < propertyList.Length; i++)
                {
                    numericValuesList.Add(Convert.ToInt32(propertyList[i].GetValue(task, null)));
                }
                apllicationParametersDictionary.Add(propertyList[0].GetValue(task, null).ToString(), numericValuesList);
                AntColonyOptimizationAlgorithm.Application.Run(apllicationParametersDictionary);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //AntColonyOptimizationAlgorithm.Application.Run(collection);
        }
    }
}
