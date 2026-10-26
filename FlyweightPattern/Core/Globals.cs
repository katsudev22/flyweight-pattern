using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public static class Globals {	
	public static float Time { get; set; }
	public static ContentManager ContentManager { get; set; }
	public static SpriteBatch SpriteBatch { get; set; }
	public static GraphicsDevice GraphicsDevice { get; set; }
	public static Point GameWindow { get; set; } = new(800, 600);

	public static void Update(GameTime gt) {
		Time = (float)gt.ElapsedGameTime.TotalSeconds;
	}
}
