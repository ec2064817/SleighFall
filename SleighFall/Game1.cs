using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

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

        List<Bauble> baubles;

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

            baubles = new List<Bauble>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            background = new Background(Content.Load<Texture2D>("nightbackground"));
            p1Sleigh = new Sleigh(Content.Load<Texture2D>("sleigh"), 400, 600);
            debugFont = Content.Load<SpriteFont>("Arial07");

            for (int i = 0; i < 8; i++)
            {
                Content.Load<Texture2D>("bauble"+i);
            }

            for (int i = 0; i < SNOWFLAKES; i++)
            {
                snow[i] = new Snowflake(Content.Load<Texture2D>("snowflake"), _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            }
        }

        protected override void Update(GameTime gameTime)
        {


            pad1_curr = GamePad.GetState(PlayerIndex.One);

            if (pad1_curr.Buttons.Back == ButtonState.Pressed)
            {
                Exit();
            }

            baubles.Add(new Bauble(Content.Load<Texture2D>("bauble" + RNG.Next(0, 8)),
                                    _graphics.PreferredBackBufferWidth));

            p1Sleigh.UpdateMe(pad1_curr, screenSize.Width);

            for (int i = 0; i < snow.Length; i++)
            {
                snow[i].UpdateMe(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            }

            for (int i = 0; i < baubles.Count; i++)
            {
                baubles[i].UpdateMe(_graphics.PreferredBackBufferHeight);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            background.DrawMe(_spriteBatch);
            p1Sleigh.DrawMe(_spriteBatch);

            for (int i = 0; i < baubles.Count; i++)
            {
                baubles[i].DrawMe(_spriteBatch);
            }
            
            
            for (int i = 0; i < snow.Length; i++)
            {
                snow[i].DrawMe(_spriteBatch);
            }

            if (pad1_curr.Buttons.A == ButtonState.Pressed)
            {
                _spriteBatch.DrawString(debugFont, "Res: " + _graphics.PreferredBackBufferWidth + " x " + _graphics.PreferredBackBufferHeight, Vector2.Zero, Color.White);
                _spriteBatch.DrawString(debugFont, "Sleigh: " + p1Sleigh.Rect, new Vector2(0, 12), Color.White);
            }
            

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
