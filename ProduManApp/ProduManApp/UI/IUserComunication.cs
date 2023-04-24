using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.UI
{
    public interface IUserComunication
    {
        void Closure();
        void Introduce();
        void ResetCustomerBase();
        void ResetOrderBase();
        void SelectAction();
    }
}
