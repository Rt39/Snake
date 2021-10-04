using Snake.Controllers;
using Snake.Entities;
using Snake.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace Snake.Views {
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page {
        #region 字段
        private readonly EditViewModel _editViewModel;
        // 当前的指针状态
        private enum EditStatus {
            Cursor,
            SnakeHead,
            Brick,
            Erasor,
        }
        private EditStatus _editstatus = EditStatus.Cursor;
        #endregion

        public EditPage() {
            InitializeComponent();
            DataContext = _editViewModel = new EditViewModel();
            rbt_mouse.IsChecked = true;
        }
        #region 事件

        private void SnakeDirectionButton_Click(object sender, RoutedEventArgs e) {
            switch (_editViewModel.SnakeDirection) {
                case SnakeController.SnakeDirection.Left:
                    _editViewModel.SnakeDirection = SnakeController.SnakeDirection.Down;
                    break;
                case SnakeController.SnakeDirection.Up:
                    _editViewModel.SnakeDirection = SnakeController.SnakeDirection.Left;
                    break;
                case SnakeController.SnakeDirection.Right:
                    _editViewModel.SnakeDirection = SnakeController.SnakeDirection.Up;
                    break;
                case SnakeController.SnakeDirection.Down:
                    _editViewModel.SnakeDirection = SnakeController.SnakeDirection.Right;
                    break;
            }
        }

        private void DrawArea_MouseDown(object sender, MouseButtonEventArgs e) {
            //Point point = e.GetPosition(grid);
            //Debug.WriteLine(point);
            //Debug.WriteLine((GridPosition)point);
        }

        private void DrawArea_MouseMove(object sender, MouseEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                Point point = e.GetPosition(drawArea);
                Debug.WriteLine(point);
                Debug.WriteLine((GridPosition)point);
            }
        }
        #endregion
        /*尝试了从ItemsControl获取Canvas，结果失败了*/
        /*最后使用的方法是在ItemsControl外部套上一层Grid，通过Grid获取鼠标事件*/
        //public static T FindVisualChild<T>(DependencyObject depObj) where T : DependencyObject {
        //    if (depObj != null) {
        //        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++) {
        //            DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
        //            if (child != null && child is T) {
        //                return (T)child;
        //            }

        //            T childItem = FindVisualChild<T>(child);
        //            if (childItem != null) return childItem;
        //        }
        //    }
        //    return null;
        //}
    }
}