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
    public class Asteroids
    {
        public Vector2 position;
        private Texture2D texture;
        private float speed;


        public Asteroids()
        {
            Random rnd = new Random();
            int y = rnd.Next(20, 880);
            int x = rnd.Next(1900, 2680);
            position = new Vector2(x, y);

            Random rndS = new Random();
            speed = rndS.Next(8, 12);    

            texture = null;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("spriteMeteor");
        }
        public void Update()
        {
            Random rnd = new Random();
            int y = rnd.Next(80,880);
            if (position.X <= 0-texture.Width)
            {
                position.X += 1900+texture.Width;
                position.Y = y;

                Random rndS = new Random();
                speed = rndS.Next(8, 12);
            }
            position.X -= speed;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, position, Color.White);
        }
    }

}
