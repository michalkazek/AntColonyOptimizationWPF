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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AntColonyOptimizationWPF
{
    public partial class MainMenuPage : Page
    {
        public List<DataRow> myList { get; set; }
        public MainMenuPage()
        {
            InitializeComponent();
            myList = new List<DataRow>();
            dgTaskList.ItemsSource = myList;
        }

        private void btnAddNewTask_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewTaskWindow(this);
            window.Show();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RunPage(dgTaskList.Items));
        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            myList.Remove((DataRow)dgTaskList.SelectedItem);
            dgTaskList.Items.Refresh();
        }

        private void btnAddTasksFromFile_Click(object sender, RoutedEventArgs e)
        {
            var dialogBox = new Microsoft.Win32.OpenFileDialog();
            dialogBox.Filter = "Text documents (.txt)|*.txt";

            var openingResult = dialogBox.ShowDialog();
            if (openingResult == true)
            {
                ReadInputParamteres(dialogBox.FileName);
            }
        }

        private void ReadInputParamteres(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string currentLine;
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        var splittedLine = currentLine.Split(',');
                        myList.Add(new DataRow
                        {
                            FileName = splittedLine[0],
                            Alfa = Convert.ToInt32(splittedLine[1]),
                            Beta = Convert.ToInt32(splittedLine[2]),
                            NumberOfAnts = Convert.ToInt32(splittedLine[3]),
                            NumberOfIterations = Convert.ToInt32(splittedLine[4]),
                            NumberOfRepetitions = Convert.ToInt32(splittedLine[5])
                        });
                        dgTaskList.Items.Refresh();
                    }
                }
            } catch (Exception) { }     
        }
    }

    public class DataRow
    {
        public string FileName { get; set; }
        public int Alfa { get; set; }
        public int Beta { get; set; }
        public int NumberOfAnts { get; set; }
        public int NumberOfIterations { get; set; }
        public int NumberOfRepetitions { get; set; }
    }
}
