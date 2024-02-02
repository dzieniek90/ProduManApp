using System.Runtime.CompilerServices;

namespace ProduManWPF.DataAccess.Model;

public static class Settings
{
    public static MyColor Data
    {
        get
        {
            return Settings.Load();
        }
        set
        {
            Settings.Save(value);
        }
    }
    private static MyColor Load()
    {
        Properties.Settings settings = Properties.Settings.Default;
        return new MyColor(r: settings.R, g: settings.G, b: settings.B);
    }

    private static void Save(MyColor myColor)
    {
        Properties.Settings settings = Properties.Settings.Default;
        settings.R = myColor.R;
        settings.G = myColor.G;
        settings.B = myColor.B;
        settings.Save();
    }
}