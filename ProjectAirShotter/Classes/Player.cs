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
    public class Player : Game1
    {
        public Vector2 position;
        private Texture2D texture;
        private float speed;

        public Player()
        {
            position = new Vector2(50, 450);
            speed = 15;
            texture = null;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("sprite rocket");
        }
        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.W))
            {
                position.Y -= speed;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                position.Y += speed;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                position.X -= speed;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                position.X += speed;
            }


            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }

            if (position.X + texture.Width > 1900)
            {
                position.X = 1900 - texture.Width;
            }

            if (position.Y + texture.Height > 1000)
            {
                position.Y = 1000 - texture.Height;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, position, Color.White);
        }
    }

}
