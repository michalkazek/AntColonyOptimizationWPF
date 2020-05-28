using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AntColonyOptimizationWPF
{
    public partial class NewTaskWindow : Window
    {
        private MainMenuPage mainMenuPage;
        public NewTaskWindow(MainMenuPage mainMenuPage)
        {
            InitializeComponent();
            this.mainMenuPage = mainMenuPage;
        }

        private void btnAddNewTask_Click(object sender, RoutedEventArgs e)
        {
            var collection = new List<TextBox>() {txtAlfa, txtBeta, txtNumberOfAnts, txtNumberOfIterations, txtNumberOfRepetitions};
            var intCollection = new List<int>();
            int output;

            foreach (var item in collection)
            {                
                if (int.TryParse(item.Text, out output) && output > 0)
                {
                    item.BorderBrush = Brushes.Black;
                    intCollection.Add(output);
                }
                else
                {
                    item.BorderBrush = Brushes.Red;
                }
            }

            if (intCollection.Count == 5)
            {
                mainMenuPage.dgTaskList.Items.Add(new
                {
                    Alfa = intCollection[0],
                    Beta = intCollection[1],
                    NumberOfAnts = intCollection[2],
                    NumberOfIterations = intCollection[3],
                    NumberOfRepetitons = intCollection[4]
                });
            }            
        }
    }    
}
