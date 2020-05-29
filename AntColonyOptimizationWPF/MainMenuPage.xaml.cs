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
