using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
    public class Shot
    {
        public Texture2D texture2D;
        public Vector2 position;
        
        public Shot(ContentManager manager, Vector2 _position)
        {
            position = _position;
            texture2D = manager.Load<Texture2D>("NewShotPng");
            position.X += 300;
            position.Y += 50;
        }
        public void Draw(SpriteBatch spriteBatch)
        {   
            spriteBatch.Draw(texture2D, position, Color.White);
        }
        public void Update()
        {
            position.X += 15;
        }
    }
}
