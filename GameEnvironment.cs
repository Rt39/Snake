using Snake.Controllers;
using Snake.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Snake {
    public static class GameEnvironment {
        public static int gridSize = 40;
        public static Random rand = new Random();
        public static int interval = 200;
        public static uint rowCount = 16;
        public static uint columnCount = 32;
        public static double GameWidth { get { return columnCount * gridSize; } }
        public static double GameHeight { get { return rowCount * gridSize; } }

        public static Brush grid1Brush = Brushes.Gray;
        public static Brush grid2Brush = Brushes.White;
        public static Brush snakeBodyBrush = Brushes.Green;
        public static Brush snakeHeadBrush = Brushes.Red;
        public static GridPosition initialSnakeHead = new GridPosition(7, 10);
        public static SnakeController.SnakeDirection initialDirection = SnakeController.SnakeDirection.Right;
        public static int initialBodyCount = 3;
    }
}
