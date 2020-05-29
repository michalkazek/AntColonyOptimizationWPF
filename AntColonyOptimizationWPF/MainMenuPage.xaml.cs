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
            var x = new NewTaskWindow(this);
            x.Show();
        }

        private void dgTaskList_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RunPage(dgTaskList.Items));
        }

        private void dgTaskList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            IList<DataGridCellInfo> selectedcells = e.AddedCells;

            //Get the value of each newly selected cell
            foreach (DataGridCellInfo di in selectedcells)
            {
                var pi = di.Item.GetType().GetProperty("Alfa");
                lblIntroduction.Text = pi.GetValue(di, null).ToString();
            }
        }
    }
}
