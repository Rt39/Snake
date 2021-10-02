using Snake.ViewModels;
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
            DataContext = new NewGameEnvironmentViewModel();
        }

        private void BrushButton_Click(object sender, RoutedEventArgs e) {
            //Debug.WriteLine("click");
            ContextMenu cm = (ContextMenu)FindResource("brushSettingMenu");
            Button b = (Button)sender;
            cm.PlacementTarget = b;
            cm.IsOpen = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void PureColorMenu_Click(object sender, RoutedEventArgs e) {
            // 获取调用菜单的按钮
            Button buttonSender = (Button)((ContextMenu)((MenuItem)sender).Parent).PlacementTarget;
            var colorDialog = new System.Windows.Forms.ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            colorDialog.ShowHelp = false;
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                var color = colorDialog.Color;
                buttonSender.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(color.R, color.G, color.B));
            }
        }

        private void PictureMenu_Click(object sender, RoutedEventArgs e) {
            Button buttonSender = (Button)((ContextMenu)((MenuItem)sender).Parent).PlacementTarget;
            BitmapImage image;
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "All Supported Formats|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff;*.ico|Joint Photographic Experts Group|*.jpg;*.jpeg|Portable Network Graphics|*.png|bitmap|*.bmp|Graphics Interchange Format|*.gif|Tagged Image File Format|*.tiff|icons|*.ico",
                Multiselect = false
            };
            if ((bool)openFileDialog.ShowDialog()) {
                image = new BitmapImage(new Uri(openFileDialog.FileName));
                ImageBrush imageBrush = new ImageBrush(image);
                buttonSender.Background = imageBrush;
            }
        }
    }
}
