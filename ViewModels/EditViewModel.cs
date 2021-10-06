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

        private readonly NewGameEnvironmentViewModel _newGameEnvironmentViewModel;
        private readonly BackgroundGridController _backgroundGridController;

        #region 绘制字段
        // 手动绘制砖块
        private readonly List<Brick> _bricks = new List<Brick>();
        // 无法使用SnakeController来绘制，只能手动绘制SnakePart
        private readonly List<SnakePart> _snakeBody = new List<SnakePart>();
        private SnakePart _snakeHead;
        #endregion

        #region 属性
        private GridPosition _snakeHeadPosition = GameEnvironment.initialSnakeHeadPosition;
        /// <summary>
        /// 设置蛇头的初始位置
        /// </summary>
        public GridPosition SnakeHeadPosition {
            get { return _snakeHeadPosition; }
            set {
                if (Equals(_snakeHeadPosition, value)) return;
                _snakeHeadPosition = value;
                DeleteSnake();
                InitialSnake();
            }
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

        private SnakeController.SnakeDirection _direction = SnakeController.SnakeDirection.Right;
        /// <summary>
        /// 设置蛇头的朝向
        /// </summary>
        public SnakeController.SnakeDirection Direction {
            get { return _direction; }
            set {
                if (Equals(_direction, value)) return;
                _direction = value;
                DeleteSnake();
                InitialSnake();
                OnPropertyChanged("DirectionButtonIcon");
            }
        }

        #region 图标
        public BitmapImage DirectionButtonIcon {
            get {
                switch (Direction) {
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

        public EditViewModel(NewGameEnvironmentViewModel viewModel) {
            _newGameEnvironmentViewModel = viewModel;
            _backgroundGridController = new BackgroundGridController(Entities, _newGameEnvironmentViewModel.Grid1Fill, _newGameEnvironmentViewModel.Grid2Fill);
            _backgroundGridController.GenerateBackgroundGrid();

            InitialSnake();
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
        private void InitialSnake() {
            _snakeHead = new SnakePart(SnakeHeadPosition, _newGameEnvironmentViewModel.SnakeHeadFill, null, 0);

            Entities.Add(_snakeHead);
            for (uint i = (uint)_newGameEnvironmentViewModel.InitialBodyCount; i > 0; --i) {
                switch (Direction) {
                    case SnakeController.SnakeDirection.Left:
                        _snakeBody.Add(new SnakePart(_snakeHead.Position.row,
                            (_snakeHead.Position.column + i) % GameEnvironment.columnCount,
                        _newGameEnvironmentViewModel.SnakeBodyFill, null, 0));
                        break;
                    case SnakeController.SnakeDirection.Up:
                        _snakeBody.Add(new SnakePart((_snakeHead.Position.row + i) % GameEnvironment.rowCount, _snakeHead.Position.column, _newGameEnvironmentViewModel.SnakeBodyFill, null, 0));
                        break;
                    case SnakeController.SnakeDirection.Right:
                        _snakeBody.Add(new SnakePart(_snakeHead.Position.row, (_snakeHead.Position.column + GameEnvironment.columnCount - i) % GameEnvironment.columnCount, _newGameEnvironmentViewModel.SnakeBodyFill, null, 0));
                        break;
                    case SnakeController.SnakeDirection.Down:
                        _snakeBody.Add(new SnakePart((_snakeHead.Position.row + GameEnvironment.rowCount - i) % GameEnvironment.rowCount, _snakeHead.Position.column, _newGameEnvironmentViewModel.SnakeBodyFill, null, 0));
                        break;
                }
            }
            foreach (SnakePart s in _snakeBody)
                Entities.Add(s);
        }

        private void DeleteSnake() {
            Entities.Remove(_snakeHead);
            _snakeHead = null;
            foreach (var v in _snakeBody)
                Entities.Remove(v);
            _snakeBody.Clear();
        }

        public void Submit() {
            _newGameEnvironmentViewModel.Submit();
            GameEnvironment.initialSnakeHeadPosition = SnakeHeadPosition;
            GameEnvironment.initialDirection = Direction;
            GameEnvironment.brickPositions = _bricks.Select(t => t.Position).ToList();
        }
    }
}
