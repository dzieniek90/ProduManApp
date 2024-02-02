using ProduManUI.Core;
using ProduManUI.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProduManUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            // var mainView = new MainWindow();
            // mainView.Show();
            var loginView = new LoginWindow();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.Visibility != Visibility.Visible && loginView.IsLoaded)
                {
                    var mainView = new MainWindow();
                    mainView.Show();
                    //var mainView = new ProduManMainWindow();
                    //mainView.Show();
                    //loginView.Close();
                }
            };
        }
    }
}
