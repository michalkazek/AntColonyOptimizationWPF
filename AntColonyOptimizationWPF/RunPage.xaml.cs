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
            ShowFullCollection(taskCollection);
        }

        private void ShowFullCollection(ItemCollection taskCollection)
        {
            
            string fullText = "";
            for (int i = 0; i < 2; i++)
            {
                var item = taskCollection[i];
                var pi = item.GetType().GetProperties();
                foreach (var item2 in pi)
                {
                    fullText += item2.GetValue(item, null);
                }
                
            }
            txtTest.Text = fullText;
        }
    }
}
