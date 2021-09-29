using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Snake.Views {
    /// <summary>
    /// Interaction logic for NewGameEnvironmentView.xaml
    /// </summary>
    public partial class NewGameEnvironmentView : Window {
        public NewGameEnvironmentView() {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            //DataContext = this;
        }

        private void Grid1Color_Click(object sender, RoutedEventArgs e) {
            //Debug.WriteLine("click");
        }
    }
}
