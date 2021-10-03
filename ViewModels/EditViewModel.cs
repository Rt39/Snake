using Snake.Controllers;
using Snake.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Extenstions;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Snake.ViewModels {
    public class EditViewModel : AbstructViewModel {
        public ObservableCollection<AbstructEntity> Entities { get; } = new ObservableCollection<AbstructEntity>();
        private readonly NewGameEnvironmentViewModel _newGameEnvironmentViewModel;

        private SnakeController.SnakeDirection _snakeDirection = SnakeController.SnakeDirection.Right;
        public SnakeController.SnakeDirection SnakeDirection {
            get { return _snakeDirection; }
            set { SetProperty(ref _snakeDirection, value); }
        }
        public BitmapImage DirectionButtonIcon {
            get {
                switch (_snakeDirection) {
                    case SnakeController.SnakeDirection.Left:
                        return Properties.Resources.left_arrow.ToBitmapImage();
                    case SnakeController.SnakeDirection.Up:
                        return Properties.Resources.up_arrow.ToBitmapImage();
                    case SnakeController.SnakeDirection.Right:
                        return Properties.Resources.right_arrow.ToBitmapImage();
                    case SnakeController.SnakeDirection.Down:
                        return Properties.Resources.down_arrow.ToBitmapImage();
                    default:
                        return DependencyProperty.UnsetValue as BitmapImage;
                }
            }
        }
    }
}
