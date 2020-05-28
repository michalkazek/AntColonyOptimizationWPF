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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            mainMenuPage.dgTaskList.Items.Add(new { FileName = "berlin" });
        }
    }
    
}
