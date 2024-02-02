using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using ProduManWPF.DataAccess.Model;

namespace ProduManWPF.ViewModels;

public class ColorEditor : BaseViewModel
{
    private readonly MyColor _myColor = Settings.Data;

    public byte R
    {
        get => _myColor.R;
        set
        {
            _myColor.R = value;
            OnPropertyChanged("R", "Color");
        }
    }

    public byte G
    {
        get => _myColor.G;
        set
        {
            _myColor.G = value;
            OnPropertyChanged("G", "Color");
        }
    }

    public byte B
    {
        get => _myColor.B;
        set
        {
            _myColor.B = value;
            OnPropertyChanged("Color");
        }
    }

    public Color Color
    {
        get { return _myColor.ToColor(); }
    }

    public void Save()
    {
        Settings.Data = _myColor;
    }
}

public static class Extensions
{
    public static Color ToColor(this MyColor myColor)
    {
        return new Color()
        {
            A = 255,
            R = myColor.R,
            G = myColor.G,
            B = myColor.B
        };
    }
}