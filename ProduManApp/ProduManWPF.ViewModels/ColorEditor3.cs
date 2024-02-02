using System.Windows.Media;
using ProduManWPF.DataAccess.Model;

namespace ProduManWPF.ViewModels;

public class ColorEditor3 : IColorEditor
{
    private readonly MyColor _myColor = Settings.Data;

    private MyColor MyColor
    {
        get
        {
            return _myColor;
        }
    }
    
    public Color Color
    {
        get
        {
            return _myColor.ToColor();
        }
    }

    public void Save()
    {
        Settings.Data = MyColor;
    }
}
