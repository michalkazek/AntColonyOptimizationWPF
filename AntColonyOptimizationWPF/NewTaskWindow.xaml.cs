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
            int alfa;
            int beta;
            int numberOfAnts;
            int numberOfIterations;
            int numberOfRepetitions;
            bool flag = true;

            if(!(int.TryParse(txtAlfa.Text, out alfa) && alfa > 0))
            {
                txtAlfa.BorderBrush = Brushes.Red;
                flag = false;
            }
            if (!(int.TryParse(txtBeta.Text, out beta) && beta > 0))
            {
                txtBeta.BorderBrush = Brushes.Red;
                flag = false;
            }
            if (!(int.TryParse(txtNumberOfAnts.Text, out numberOfAnts) && numberOfAnts > 0))
            {
                txtNumberOfAnts.BorderBrush = Brushes.Red;
                flag = false;
            }
            if (!(int.TryParse(txtNumberOfIterations.Text, out numberOfIterations) && alfa > 0))
            {
                txtNumberOfIterations.BorderBrush = Brushes.Red;
                flag = false;
            }
            if (!(int.TryParse(txtNumberOfRepetitions.Text, out numberOfRepetitions) && numberOfRepetitions > 0))
            {
                txtNumberOfRepetitions.BorderBrush = Brushes.Red;
                flag = false;
            }

            if (flag)
            {
                mainMenuPage.dgTaskList.Items.Add(new
                {
                    Alfa = alfa,
                    Beta = beta,
                });
            }            
        }
    }    
}
