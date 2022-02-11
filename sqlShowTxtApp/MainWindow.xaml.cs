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
using System.Windows;

namespace sqlShowTxtApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataAccess.InitializeDatabase();

            
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            List<string> data = DataAccess.GetData();
            string allData="All data from textEntry field : ";
            foreach (string AData in data) 
            {
                allData = allData + "\n   " + AData;
            }
            MessageBox.Show(allData);
        }
    }
}
