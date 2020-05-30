using System;
using System.Collections.Generic;
using System.IO;
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
            ReadAllFileNamesInDataFolder();
        }

        private void ReadAllFileNamesInDataFolder()
        {
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory() + $@"\Data\");
            var fileListInDirectory = di.GetFiles("*.txt");
            fileListInDirectory.ToList().ForEach(item => cbFileNameList.Items.Add(item));
        }

        private void btnAddNewTask_Click(object sender, RoutedEventArgs e)
        {
            var textBoxCollection = new List<TextBox>() {txtAlfa, txtBeta, txtNumberOfAnts, txtNumberOfIterations, txtNumberOfRepetitions};
            var inputValuesCollection = new List<int>();
            int output;

            foreach (var item in textBoxCollection)
            {                
                if (int.TryParse(item.Text, out output) && output > 0)
                {
                    item.BorderBrush = Brushes.Black;
                    inputValuesCollection.Add(output);                    
                }
                else
                {
                    item.BorderBrush = Brushes.Red;
                    txtAddingResultMessage.Text = "Dodawanie nie powiodło się.";
                    txtAddingResultMessage.Foreground = Brushes.Red;
                }
            }

            if (inputValuesCollection.Count == 5)
            {
                mainMenuPage.myList.Add(new DataRow
                {
                    FileName = cbFileNameList.SelectedItem.ToString(),
                    Alfa = inputValuesCollection[0],
                    Beta = inputValuesCollection[1],
                    NumberOfAnts = inputValuesCollection[2],
                    NumberOfIterations = inputValuesCollection[3],
                    NumberOfRepetitions = inputValuesCollection[4]
                });
                mainMenuPage.dgTaskList.Items.Refresh();
                mainMenuPage.CheckIfThereIsAtLeastOneRowInDataGrid();
                txtAddingResultMessage.Text = "Dodawanie zakończone powodzeniem!";
                txtAddingResultMessage.Foreground = Brushes.Green;
            }            
        }

        private void cbFileNameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnAddNewTask.IsEnabled = true;
        }
    }    
}
