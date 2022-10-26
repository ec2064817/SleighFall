using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SleighFall
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SpriteFont debugFont;

        Background background;
        Sleigh p1Sleigh;

        const int SNOWFLAKES = 64;
        Snowflake[] snow;

        public static readonly Random RNG = new Random();

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

            snow = new Snowflake[SNOWFLAKES];

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            background = new Background(Content.Load<Texture2D>("nightbackground"));
            p1Sleigh = new Sleigh(Content.Load<Texture2D>("sleigh"), 400, 600);
            debugFont = Content.Load<SpriteFont>("Arial07");

            for (int i = 0; i < SNOWFLAKES; i++)
            {
                snow[i] = new Snowflake(Content.Load<Texture2D>("snowflake"), _graphics.PreferredBackBufferWidth);
            }
        }

        protected override void Update(GameTime gameTime)
        {


            pad1_curr = GamePad.GetState(PlayerIndex.One);

            if (pad1_curr.Buttons.Back == ButtonState.Pressed)
            {
                Exit();
            }

            p1Sleigh.UpdateMe(pad1_curr, screenSize.Width);

            for (int i = 0; i < snow.Length; i++)
            {
                snow[i].UpdateMe(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            background.DrawMe(_spriteBatch);
            p1Sleigh.DrawMe(_spriteBatch);
            
            for (int i = 0; i < snow.Length; i++)
            {
                snow[i].DrawMe(_spriteBatch);
            }
            

            _spriteBatch.DrawString(debugFont, "Res: " + _graphics.PreferredBackBufferWidth + " x " + _graphics.PreferredBackBufferHeight, Vector2.Zero, Color.White);
            _spriteBatch.DrawString(debugFont, "Sleigh: " + p1Sleigh.Rect, new Vector2(0, 12), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
