using ProduManApp.UI;

namespace ProduManApp
{
    public class App : IApp
    {
        private IUserComunication _userComunication;
        private ICarsUI _carsUI;

        public App(IUserComunication userComunication, ICarsUI carsUI)
        {
            _userComunication = userComunication;
            _carsUI = carsUI;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"Wybież co chcesz uruchomić:
1. ProduManApp
2. Testy z CarProvider i XML ");

                var choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        _userComunication.Introduce();
                        _userComunication.SelectAction();
                        _userComunication.Closure();
                        break;

                    case '2':
                        _carsUI.RunActions();
                        break;

                    default:
                        continue;
                }
                break;
            }
        }
    }
}