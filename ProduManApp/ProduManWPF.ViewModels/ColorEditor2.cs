using System.Windows.Media;
using ProduManWPF.DataAccess.Model;

namespace ProduManWPF.ViewModels;

public class ColorEditor2 : IColorEditor
{
    public ColorEditor2()
    {
        MyColor color = Settings.Data;
        R = color.R;
        G = color.G;
        B = color.B; 
    }

    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public Color Color
    {
        get
        {
            return Color.FromRgb(R,G,B);
        }
    }

    public void Save()
    {
        Settings.Data = new MyColor(R,G,B);
    }
}
