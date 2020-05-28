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
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void btnAddNewTask_Click(object sender, RoutedEventArgs e)
        {
           // var test = new Task { FileName= = };
           // dgTaskList.Items.Add(test);
        }
    }
    public class Task
    {
        public string FileName { get; set; }
        public int Alfa { get; set; }
        public int Beta { get; set; }
        public int NumberOfAnts { get; set; }
        public int NumberOfIterations { get; set; }
    }

}
