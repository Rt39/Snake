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
using System.Windows.Input;

namespace Snake.ViewModels {
    public class EditViewModel : AbstructViewModel {
        // canvas所绑定的属性
        public ObservableCollection<AbstructEntity> Entities { get; } = new ObservableCollection<AbstructEntity>();

        #region 控制器
        private readonly NewGameEnvironmentViewModel _newGameEnvironmentViewModel;
        private readonly BackgroundGridController _backgroundGridController;
        // 手动绘制砖块
        private readonly List<Brick> _bricks = new List<Brick>();
        #endregion

        #region 属性
        private readonly SnakeController _snakeController;
        /// <summary>
        /// 设置蛇头的初始位置
        /// </summary>
        public GridPosition SnakeHeadPosition {
            get { return _snakeController.InitialHeadPosition; }
            set { _snakeController.InitialHeadPosition = value; }
        }

        public enum EditStatus {
            Cursor,
            SetSnakeHeadPosition,
            AddBricks,
            EraseBricks,
        }
        private EditStatus _status;
        /// <summary>
        /// 获取和设置当前的编辑状态
        /// </summary>
        public EditStatus Status {
            get { return _status; }
            set {
                _status = value;
                OnPropertyChanged("Cursor");
            }
        }
        public Cursor Cursor {
            get {
                switch (Status) {
                    case EditStatus.Cursor:
                        return Cursors.Arrow;
                    case EditStatus.SetSnakeHeadPosition:
                        return Cursors.Pen;
                    case EditStatus.AddBricks:
                        return Cursors.Pen;
                    case EditStatus.EraseBricks:
                        return Cursors.Hand;
                    default:
                        return DependencyProperty.UnsetValue as Cursor;
                }
            }
        }
        #endregion

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

        #region 绘制砖块相关函数
        public void AddBrick(GridPosition position) {
            if (_bricks.Exists(t => Equals(t.Position, position))) return;
            Brick b = new Brick(position, _newGameEnvironmentViewModel.BrickFill, _newGameEnvironmentViewModel.BrickStroke, _newGameEnvironmentViewModel.BrickStrokeThickness);
            _bricks.Add(b);
            Entities.Add(b);
        }

        public void EraseBrick(GridPosition position) {
            Brick b = _bricks.FirstOrDefault(t => Equals(t.Position, position));
            if (b == null) return;
            Entities.Remove(b);
            _bricks.Remove(b);
        }
        #endregion
    }
}
