using System.Windows.Media;

namespace ProduManWPF.ViewModels;

public interface IColorEditor
{
     Color Color { get;}

     void Save();
}