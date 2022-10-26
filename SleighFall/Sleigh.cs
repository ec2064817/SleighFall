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
        public Rectangle Rect;
        private Texture2D _txr;


        private bool _travellingRight;

        public Sleigh(Texture2D txr, int xPos, int yPos)
        {
            _txr = txr;
            
            Rect = new Rectangle(xPos, yPos, _txr.Width, _txr.Height);
        }

        public void UpdateMe(GamePadState pad, int screenWidth)
        {
            if (pad.DPad.Left == ButtonState.Pressed)
            {
                _travellingRight = false;
                Rect.X -= 4;
            }
            else if (pad.DPad.Right == ButtonState.Pressed)
            {
                _travellingRight = true;
                Rect.X += 4;
            }

            if (Rect.X > screenWidth - _txr.Width)
            {
                Rect.X = screenWidth - _txr.Width;
            }

            if (Rect.X < 0)
            {
                Rect.X = 0;
            }
        }

        public void DrawMe(SpriteBatch sb)
        {
            if (_travellingRight)
            {
              sb.Draw(_txr, Rect, Color.White);
            }
            else
            {
              sb.Draw(_txr, Rect,null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }
            
        }
    }
}
