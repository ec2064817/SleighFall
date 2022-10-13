using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SleighFall
{
    internal class Background
    {
        private Rectangle _rect;
        private Texture2D _txr;

        public Background(Texture2D txr, int width, int height)
        {
            _txr = txr;
            _rect = new Rectangle(0, 0, width, height);   
        }

        public Background(Texture2D txr)
        {
            _txr = txr;
            _rect = new Rectangle(0, 0, txr.Width, txr.Height);
        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(_txr, _rect, Color.White);
        }
    }
}
