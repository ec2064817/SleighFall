using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SleighFall
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Background background;
        Sleigh p1Sleigh;

        GamePadState pad1_curr;

        Rectangle screenSize;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferHeight = 720;
            _graphics.PreferredBackBufferWidth = 1280;
        }

        protected override void Initialize()
        {
            screenSize = GraphicsDevice.Viewport.Bounds;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            background = new Background(Content.Load<Texture2D>("nightbackground"));
            p1Sleigh = new Sleigh(Content.Load<Texture2D>("sleigh"), 400, 600);
        }

        protected override void Update(GameTime gameTime)
        {
           

            pad1_curr = GamePad.GetState(PlayerIndex.One);

            if (pad1_curr.Buttons.Back == ButtonState.Pressed)
            {
                Exit();
            }

            p1Sleigh.UpdateMe(pad1_curr, screenSize.Width);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            background.DrawMe(_spriteBatch);
            p1Sleigh.DrawMe(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}