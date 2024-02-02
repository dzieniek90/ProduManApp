using ProduManUI.Core.ViewModels;
using System.Windows;

namespace ProduManUI.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand ShutdownWindowCommand { get; set; }
        public RelayCommand MaximazeWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand ShowUserView { get; set; }
        public RelayCommand ShowSmtView { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public UserViewModel UserViewModel { get; set; }

        private SmtViewModel _smtViewModel;

        public SmtViewModel SmtViewModel
        {
            get
            {
                if (_smtViewModel == null)
                    _smtViewModel = new SmtViewModel();
                return _smtViewModel;
            }
            set
            {
                _smtViewModel = value;
            }
        }

        public MainViewModel()
        {
            UserViewModel = new UserViewModel();
            _currentView = UserViewModel;

            //Application.Current.MainWindow.MaxHeight = SystemParameters.MaximumWindowTrackHeight;

            MoveWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.DragMove(); });
            ShutdownWindowCommand = new RelayCommand(o => { Application.Current.Shutdown(); });
            MaximazeWindowCommand = new RelayCommand(o =>
            {
                if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                }
                else
                {
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                }
            });
            MinimizeWindowCommand = new RelayCommand(o =>
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            });

            ShowUserView = new RelayCommand(o => { CurrentView = UserViewModel; });
            ShowSmtView = new RelayCommand(o => { CurrentView = SmtViewModel; });
        }
    }
}