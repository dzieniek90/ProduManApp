using ProduManApp.Data;
using ProduManApp.Entities;
using ProduManApp.Helpers;
using ProduManApp.Repositories;
using ProduManApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp
{
    public class App : IApp
    {
        IUserComunication _userComunication;

        public App(IUserComunication userComunication)
        {
            _userComunication = userComunication; 
        }
        public void Run()
        {
            _userComunication.Introduce();
            _userComunication.SelectAction();
            _userComunication.Closure();
        }
    }
}
