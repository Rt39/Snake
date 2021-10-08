using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using Snake.Controllers;
using Snake.Entities;
using Snake.ViewModels;
using Snake.Views;

namespace Snake {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        #region 字段
        private WelcomePage _welcomePage = new WelcomePage();
        private NewGameEnvironmentView _newGameEnvironmentView;
        private EditPage _editPage;
        private GamePage _gamePage;
        #endregion

        public MainWindow() {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            // 导向欢迎界面
            frame.Navigate(_welcomePage);
            _welcomePage.btn_newGame.Click += NewGame;
            _welcomePage.btn_exit.Click += ExitMenuItem_Click;
        }
        #region 事件处理
        private void NewGame(object sender, EventArgs e) {
            _newGameEnvironmentView = new NewGameEnvironmentView();
            NewGameEnvironmentViewModel viewModel = _newGameEnvironmentView.ShowDialog();
            if (viewModel == null) return;
            _editPage = new EditPage(viewModel);
            frame.Navigate(_editPage);
            _editPage.btn_submit.Click += RunGame;
            _editPage.btn_cancel.Click += GoBackToWelcomePage;
        }

        private void RunGame(object sender, EventArgs e) {
            _gamePage = new GamePage();
            frame.Navigate(_gamePage);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            // TODO: Dao层完成确认是否保存
            //if (MessageBox.Show("", "", MessageBoxButton.YesNoCancel) == MessageBoxResult.Cancel)
            //    e.Cancel = true;
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void NewGameMenuItem_Click(object sender, RoutedEventArgs e) {
            if (_gamePage != null) _gamePage.StopGame();
            NewGame(sender, e);
        }

        private void GoBackToWelcomePage(object sender, EventArgs e) {
            frame.Navigate(_welcomePage);
        }
        #endregion
    }
}
