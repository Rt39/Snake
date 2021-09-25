using Snake.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public IEnumerable<Point> SnakeBodyPositions {
            get {
                return _snakeBody.Select(e => e.Position);
            }
        }
        /// <summary>
        /// 蛇头的位置
        /// </summary>
        public Point SnakeHeadPosition { get { return _snakeHead.Position; } }

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
            for (uint i = 1; i <= _initialBodyCount; ++i) {
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
        /// <param name="eat">是否吃到食物（删除蛇尾）</param>
        public void MoveSnake(bool eat) {
            if (!eat) {
                // 没有吃到食物，删除蛇尾
                SnakePart snakeTail = _snakeBody[_snakeBody.Count - 1];
                _snakeBody.Remove(snakeTail);
                _entities.Remove(snakeTail);
            }
            // 添加一节头部身子
            SnakePart frontBody = new SnakePart(_snakeHead.GridPos, _bodyBrush, null, 0);
            _snakeBody.Add(frontBody);
            _entities.Add(frontBody);
            // 更新蛇头位置
            _entities.Remove(_snakeHead);
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
            _entities.Add(_snakeHead);
        }
    }
}
