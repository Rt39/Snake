using Snake.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Snake.Controllers {
    public class SnakeController : AbstructController {
        #region 蛇的方向
        public enum SnakeDirection {
            Left,
            Up,
            Right,
            Down,
        }
        #endregion

        private readonly List<SnakePart> _snakeBody;
        private SnakePart _snakeHead;
        /// <summary>
        /// 所有蛇身的位置
        /// </summary>
        public IEnumerable<GridPosition> SnakeBodyPositions {
            get {
                return _snakeBody.Select(e => e.GridPos);
            }
        }
        /// <summary>
        /// 蛇头的位置
        /// </summary>
        public GridPosition SnakeHeadPosition { get { return _snakeHead.GridPos; } }

        private readonly Brush _headBrush;
        private readonly Brush _bodyBrush;

        private readonly int _initialBodyCount;
        private readonly GridPosition _initialHeadPosition;
        /// <summary>
        /// 蛇的方向
        /// </summary>
        public SnakeDirection Direction { get; set; }

        public SnakeController(ICollection<AbstructEntity> entities, Brush headBrush, Brush bodyBrush, int initialBodyCount, GridPosition initialHeadPosition, SnakeDirection direction) {
            _entities = entities;
            _snakeBody = new List<SnakePart>();
            _headBrush = headBrush;
            _bodyBrush = bodyBrush;
            _initialBodyCount = initialBodyCount;
            _initialHeadPosition = initialHeadPosition;
            Direction = direction;
        }
        /// <summary>
        /// 初始化蛇
        /// </summary>
        public void InitialSnake() {
            // 初始化蛇头
            _snakeHead = new SnakePart(_initialHeadPosition, _headBrush, null, 0);
            _entities.Add(_snakeHead);
            // 根据蛇的朝向添加蛇身子
            for (uint i = (uint)_initialBodyCount; i > 0; --i) {
                switch (Direction) {
                    case SnakeDirection.Left:
                        _snakeBody.Add(new SnakePart(_initialHeadPosition.row,
                            (_initialHeadPosition.column + i) % GameEnvironment.columnCount,
                        _bodyBrush, null, 0));
                        break;
                    case SnakeDirection.Up:
                        _snakeBody.Add(new SnakePart((_initialHeadPosition.row + i) % GameEnvironment.rowCount, _initialHeadPosition.column, _bodyBrush, null, 0));
                        break;
                    case SnakeDirection.Right:
                        _snakeBody.Add(new SnakePart(_initialHeadPosition.row, (_initialHeadPosition.column + GameEnvironment.columnCount - i) % GameEnvironment.columnCount, _bodyBrush, null, 0));
                        break;
                    case SnakeDirection.Down:
                        _snakeBody.Add(new SnakePart((_initialHeadPosition.row + GameEnvironment.rowCount - i) % GameEnvironment.rowCount, _initialHeadPosition.column, _bodyBrush, null, 0));
                        break;
                }
            }
            foreach (SnakePart s in _snakeBody)
                _entities.Add(s);
        }

        /// <summary>
        /// 移动蛇
        /// </summary>
        public void MoveSnake() {
            // 没有吃到食物，删除蛇尾
            SnakePart snakeTail = _snakeBody[0];
            _snakeBody.Remove(snakeTail);
            //if (System.Windows.Application.Current == null) { new System.Windows.Application { ShutdownMode = ShutdownMode.OnExplicitShutdown }; }
            Application.Current.Dispatcher.Invoke(new Action(() => _entities.Remove(snakeTail)));
            MoveSnakeRetainTail();
        }
        /// <summary>
        /// 移动蛇，保留尾部一节
        /// </summary>
        public void MoveSnakeRetainTail() {
            // 添加一节头部身子
            SnakePart frontBody = new SnakePart(_snakeHead.GridPos, _bodyBrush, null, 0);
            _snakeBody.Add(frontBody);
            //if (System.Windows.Application.Current == null) { new System.Windows.Application { ShutdownMode = ShutdownMode.OnExplicitShutdown }; }
            Application.Current.Dispatcher.Invoke(new Action(() => _entities.Add(frontBody)));
            //// 我不知道为什么要这样做
            //if (System.Windows.Application.Current == null) { new System.Windows.Application { ShutdownMode = ShutdownMode.OnExplicitShutdown }; }
            Application.Current.Dispatcher.Invoke(new Action(() => _entities.Remove(_snakeHead)));
            // 更新蛇头位置
            switch (Direction) {
                case SnakeDirection.Left:
                    _snakeHead = new SnakePart(_snakeHead.Row, (_snakeHead.Column + GameEnvironment.columnCount - 1) % GameEnvironment.columnCount, _headBrush, null, 0);
                    break;
                case SnakeDirection.Up:
                    _snakeHead = new SnakePart((_snakeHead.Row + GameEnvironment.rowCount - 1) % GameEnvironment.rowCount, _snakeHead.Column, _headBrush, null, 0);
                    break;
                case SnakeDirection.Right:
                    _snakeHead = new SnakePart(_snakeHead.Row, (_snakeHead.Column + 1) % GameEnvironment.columnCount, _headBrush, null, 0);
                    break;
                case SnakeDirection.Down:
                    _snakeHead = new SnakePart((_snakeHead.Row + 1) % GameEnvironment.rowCount, _snakeHead.Column, _headBrush, null, 0);
                    break;
            }
            Application.Current.Dispatcher.Invoke(new Action(() => _entities.Add(_snakeHead)));
        }
    }
}
