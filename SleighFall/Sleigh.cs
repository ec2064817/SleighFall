using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SleighFall
{
    internal class Sleigh
    {
        private Rectangle _rect;
        private Texture2D _txr;


        private bool _travellingRight;

        public Sleigh(Texture2D txr, int xPos, int yPos)
        {
            _txr = txr;
            
            _rect = new Rectangle(xPos, yPos, _txr.Width, _txr.Height);
        }

        public void UpdateMe(GamePadState pad, int screenWidth)
        {
            if (pad.DPad.Left == ButtonState.Pressed)
            {
                _travellingRight = false;
                _rect.X -= 4;
            }
            else if (pad.DPad.Right == ButtonState.Pressed)
            {
                _travellingRight = true;
                _rect.X += 4;
            }

            if (_rect.X > screenWidth - _txr.Width)
            {
                _rect.X = screenWidth - _txr.Width;
            }

            if (_rect.X < 0)
            {
                _rect.X = 0;
            }
        }

        public void DrawMe(SpriteBatch sb)
        {
            if (_travellingRight)
            {
              sb.Draw(_txr, _rect, Color.White);
            }
            else
            {
              sb.Draw(_txr, _rect,null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }
            
        }
    }
}
