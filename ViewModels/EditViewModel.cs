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
        private readonly BackgroundGridController _backgroundGridController;
        private readonly SnakeController _snakeController;
        public GridPosition SnakeHeadPosition {
            get { return _snakeController.InitialHeadPosition; }
            set { _snakeController.InitialHeadPosition = value; }
        }

        // 蛇的方向
        public SnakeController.SnakeDirection SnakeDirection {
            get { return _snakeController.Direction; }
            set {
                _snakeController.Direction = value;
                // 指示wpf重新获取DirectionButtonIcon
                OnPropertyChanged("DirectionButtonIcon");
            }
        }

        #region 图标
        public BitmapImage DirectionButtonIcon {
            get {
                switch (SnakeDirection) {
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
        public BitmapImage CursorIcon { get { return Properties.Resources.cursor.ToBitmapImage(); } }
        public BitmapImage SnakeHeadIcon { get { return Properties.Resources.snake.ToBitmapImage(); } }
        public BitmapImage BrickIcon { get { return Properties.Resources.brick_wall.ToBitmapImage(); } }
        public BitmapImage EraserIcon { get { return Properties.Resources.eraser.ToBitmapImage(); } }
        public BitmapImage TickIcon { get { return Properties.Resources.check.ToBitmapImage(); } }
        public BitmapImage CrossIcon { get { return Properties.Resources.close.ToBitmapImage(); } }
        #endregion

        public EditViewModel(/*TODO: 传递NewGameEnviromnmentViewModel*/) {
            _newGameEnvironmentViewModel = new NewGameEnvironmentViewModel();// TODO
            _backgroundGridController = new BackgroundGridController(Entities, _newGameEnvironmentViewModel.Grid1Fill, _newGameEnvironmentViewModel.Grid2Fill);
            _snakeController = new SnakeController(Entities, _newGameEnvironmentViewModel.SnakeHeadFill, _newGameEnvironmentViewModel.SnakeBodyFill, _newGameEnvironmentViewModel.InitialBodyCount, GameEnvironment.initialSnakeHead, GameEnvironment.initialDirection);
            _backgroundGridController.GenerateBackgroundGrid();
            _snakeController.InitialSnake();
        }

        public void SetSnakeDirection(GridPosition gridPosition) {
            _snakeController.InitialHeadPosition = gridPosition;
        }
    }
}
