using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SleighFall
{
    internal class Snowflake
    {
        private Texture2D _txr;

        Vector2 _pos;
        Vector2 _vel;
        float _rot;
        float _rotSpeed;

        public Snowflake(Texture2D txr, int maxX)
        {
            _txr = txr;
            _pos = new Vector2(Game1.RNG.Next(0, maxX), 0);
            _vel = new Vector2(0, (float) Game1.RNG.NextDouble() + 0.25f);
            _rot = 0;
            _rotSpeed = (float) (Game1.RNG.NextDouble() - 0.5f) / 4;  

            
        }

        public void UpdateMe(int maxX, int maxY)
        {
            _pos = _pos + _vel;

            if (_pos.Y > maxY)
            {
                _pos.X = 150;
                _pos.Y = 0;
            }
            

        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(_txr, _pos, null, Color.White * 0.75f, 0, Vector2.Zero, _vel.Y, SpriteEffects.None, 0);
        }
    }
}
