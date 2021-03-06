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
        #endregion

        public EditPage(NewGameEnvironmentViewModel viewModel) {
            InitializeComponent();
            DataContext = _editViewModel = new EditViewModel(viewModel);
            rbt_mouse.IsChecked = true;
        }
        #region 事件
        private void SnakeDirectionButton_Click(object sender, RoutedEventArgs e) {
            switch (_editViewModel.Direction) {
                case SnakeController.SnakeDirection.Left:
                    _editViewModel.Direction = SnakeController.SnakeDirection.Down;
                    break;
                case SnakeController.SnakeDirection.Up:
                    _editViewModel.Direction = SnakeController.SnakeDirection.Left;
                    break;
                case SnakeController.SnakeDirection.Right:
                    _editViewModel.Direction = SnakeController.SnakeDirection.Up;
                    break;
                case SnakeController.SnakeDirection.Down:
                    _editViewModel.Direction = SnakeController.SnakeDirection.Right;
                    break;
            }
        }
        // 画布鼠标按下事件
        private void DrawArea_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.LeftButton != MouseButtonState.Pressed) return;
            switch (_editViewModel.Status) {
                case EditViewModel.EditStatus.Cursor:
                    return;
                case EditViewModel.EditStatus.SetSnakeHeadPosition:
                    _editViewModel.SnakeHeadPosition = (GridPosition)e.GetPosition(drawArea);
                    _editViewModel.Status = EditViewModel.EditStatus.Cursor;
                    rbt_mouse.IsChecked = true;
                    break;
                case EditViewModel.EditStatus.AddBricks:
                    _editViewModel.AddBrick((GridPosition)e.GetPosition(drawArea));
                    return;
                case EditViewModel.EditStatus.EraseBricks:
                    _editViewModel.EraseBrick((GridPosition)e.GetPosition(drawArea));
                    return;
                default:
                    return;
            }
        }
        // 画布鼠标拖动事件
        private void DrawArea_MouseMove(object sender, MouseEventArgs e) {
            if (e.LeftButton != MouseButtonState.Pressed) return;
            switch (_editViewModel.Status) {
                case EditViewModel.EditStatus.Cursor:
                    return;
                case EditViewModel.EditStatus.SetSnakeHeadPosition:
                    return;
                case EditViewModel.EditStatus.AddBricks:
                    _editViewModel.AddBrick((GridPosition)e.GetPosition(drawArea));
                    return;
                case EditViewModel.EditStatus.EraseBricks:
                    _editViewModel.EraseBrick((GridPosition)e.GetPosition(drawArea));
                    return;
                default:
                    return;
            }
        }

        private void SnakeHeadPositionRadioButton_Checked(object sender, RoutedEventArgs e) {
            _editViewModel.Status = EditViewModel.EditStatus.SetSnakeHeadPosition;
        }

        private void AddBrickRadioButton_Checked(object sender, RoutedEventArgs e) {
            _editViewModel.Status = EditViewModel.EditStatus.AddBricks;
        }

        private void EraseBrickRadioButton_Checked(object sender, RoutedEventArgs e) {
            _editViewModel.Status = EditViewModel.EditStatus.EraseBricks;
        }

        private void MouseRadioButton_Checked(object sender, RoutedEventArgs e) {
            _editViewModel.Status = EditViewModel.EditStatus.Cursor;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e) {
            _editViewModel.Submit();
        }

        private void btn_snakeDirection_MouseEnter(object sender, MouseEventArgs e) {
            tbk_statusBar.Text = "调整蛇头的方向";
        }

        private void btn_snakeDirection_MouseLeave(object sender, MouseEventArgs e) {
            tbk_statusBar.Text = "";
        }

        private void rbt_mouse_MouseEnter(object sender, MouseEventArgs e) {
            tbk_statusBar.Text = "鼠标指针";
        }

        private void rbt_snakeHeadPosition_MouseEnter(object sender, MouseEventArgs e) {
            tbk_statusBar.Text = "调整蛇头位置";
        }

        private void rbt_addBrick_MouseEnter(object sender, MouseEventArgs e) {
            tbk_statusBar.Text = "添加砖块";
        }

        private void rbt_eraseBrick_MouseEnter(object sender, MouseEventArgs e) {
            tbk_statusBar.Text = "擦除砖块";
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