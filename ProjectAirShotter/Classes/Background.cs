using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirShotter.Classes
{
    public class Background
    {
        private Texture2D texture;
        private Vector2 position1;
        private Vector2 position2;

        private float speed;

        public Background()
        {
            texture = null;
            position1 = new Vector2(0, 0);
            position2 = new Vector2(1900, 0);
            speed = 1;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("sprite space");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position1, Color.White);
            spriteBatch.Draw(texture, position2, Color.White);
        }

        public void Update()
        {
            position1.X -= speed;
            position2.X -= speed;

            if (position2.X <= 0)
            {
                position1.X = 0;
                position2.X = 1900;
            }
        }
    }
}