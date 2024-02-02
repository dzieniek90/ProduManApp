namespace ProduManWPF.DataAccess.Model;

public class MyColor
{
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public MyColor(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }
}