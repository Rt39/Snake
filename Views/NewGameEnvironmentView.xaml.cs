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
        private NewGameEnvironmentViewModel _newGameEnvironmentViewModel;
        public NewGameEnvironmentView() {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            //DataContext = this;
            DataContext = _newGameEnvironmentViewModel = new NewGameEnvironmentViewModel();
        }
        #region 事件
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

        private void Confirm_Click(object sender, RoutedEventArgs e) {
            _success = true;
            this.Close();
        }
        #endregion

        // 是否确认
        private bool _success = false;
        // 抑制原先的Show方法
        public new void Show() { throw new Exception("不允许调用本方法"); }
        /// <summary>
        /// 阻塞显示，若用户点击确认则返回当前的newGameEnvironmentViewModel，否则返回null
        /// </summary>
        /// <returns>用户设定的数值</returns>
        public new NewGameEnvironmentViewModel ShowDialog() {
            base.ShowDialog();
            return _success ? _newGameEnvironmentViewModel : null;
        }
    }
}
