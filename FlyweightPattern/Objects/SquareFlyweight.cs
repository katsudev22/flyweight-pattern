using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace flyweight_pattern.FlyweightPattern.Objects;

public class SquareFlyweight
{
    public Texture2D Texture { get; private set; }
    public int[] MemoryBreak { get; private set; }

    public SquareFlyweight(Color color)
    {
        Texture = new(Globals.GraphicsDevice, 1, 1);
        Texture.SetData([color]);

        MemoryBreak = new int[524288];
        for (int i = 0; i < MemoryBreak.Length; i++)
        {
            MemoryBreak[i] = i;
        }
    }
}