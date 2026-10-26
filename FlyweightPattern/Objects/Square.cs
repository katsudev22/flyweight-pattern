using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace flyweight_pattern.FlyweightPattern.Objects;

public class Square
{
    public Vector2 Position;
    public Rectangle Bounds;
    public Vector2 Direction;
    public float Speed;
    
    public Texture2D Texture;
    public int[] memoryBreak;
    
    public Square(Vector2 position, Color color, Vector2 direction)
    {
        Position = position;
        Bounds = new((int)Position.X, (int)Position.Y, 50, 50);
        Direction = direction;
        Speed = 300f;
        
        Texture = new(Globals.GraphicsDevice, 1, 1);
        Texture.SetData([color]);   
        memoryBreak = new int[524288];
        
        for (int i = 0; i < memoryBreak.Length; i++)
        {
            memoryBreak[i] = i;
        }
    }

    public void Update()
    {
        UpdateBounds();
        Movement();
        VerifyCollision();
    }

    public void Draw() =>
        Globals.SpriteBatch.Draw(Texture, Position, Bounds, Color.White, 0f, new(25, 25), 1f, SpriteEffects.None, 0f);

    private void Movement()
    {
        Position += Direction * Speed * Globals.Time;
    }
    
    private void UpdateBounds()
    {
        int width = 50;
        int height = 50;

        Bounds = new Rectangle(
            (int)Position.X - width / 2,
            (int)Position.Y - height / 2,
            width,
            height
        );
    }

    private void VerifyCollision()
    {
        if (Position.X + Bounds.Width / 2 >= Globals.GameWindow.X) Direction.X = -Direction.X;
        if (Position.X - Bounds.Width / 2 <= 0) Direction.X = -Direction.X;
        if (Position.Y + Bounds.Height / 2 >= Globals.GameWindow.Y) Direction.Y = -Direction.Y;
        if (Position.Y - Bounds.Height / 2 <= 0) Direction.Y = -Direction.Y;
    }
}