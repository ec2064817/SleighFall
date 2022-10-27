using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SleighFall
{
    internal class Bauble
    {
        enum BaubleState
        {
            Falling,
            Crashed
        }

        BaubleState _currState;

        private Texture2D _txr;
        Rectangle _rect;

        Vector2 _pos;
        Vector2 _vel;
     

        public Bauble(Texture2D txr, int maxX)
        {
            _currState = BaubleState.Falling;

            _txr = txr;

            _pos = new Vector2(Game1.RNG.Next(0, maxX), 0);
            _rect = new Rectangle(_pos.ToPoint(), txr.Bounds.Size);

            _vel = new Vector2(0, (float)Game1.RNG.NextDouble()*2 + 0.5f);
        }

        public void UpdateMe(int maxY)
        {
            _pos += _vel;
            

            if (_pos.Y > maxY)
            {
                _currState = BaubleState.Crashed;
                
            }

            _rect.Location = _pos.ToPoint();

        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(_txr, _rect, Color.White);
        }
    }
}
