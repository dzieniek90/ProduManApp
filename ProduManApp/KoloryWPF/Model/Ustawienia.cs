namespace KoloryWPF.Model;

public static class Ustawienia
{
    public static Kolor Load()
    {
        Properties.Settings ustawienia = Properties.Settings.Default;
        Kolor kolor = new Kolor()
        {
            R = settings.R,
            G = settings.G,
            B = settings.B
        };
        return color;
    }

    public static void Save(Color color)
    {
        Properties.Settings settings = Properties.Settings.Default;
        settings.R = color.R;
        settings.G = color.G;
        settings.B = color.B;
        settings.Save();
    }
}