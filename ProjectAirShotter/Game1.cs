using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectAirShotter.Classes;
using System;
using System.Collections.Generic;
using System.Threading;




namespace ProjectAirShotter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        private Player player;
        private Background background; //нужно сделать движение фона. Легче добавить второй и тпхать его, когда первый уезжает
        private List<Shot> shots; //по идеи нужно поменять на лист, чтобы при каждом нажатии создавалась новая пуля, а так же если она выходит за пределы экрана или поподала по метеориту, то проподала
        private List<Asteroids> asteroids;

        int time = 0;
        int maxTime = 20;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1900;
            _graphics.PreferredBackBufferHeight = 1000;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            player = new Player();
            background = new Background();
            shots = new List<Shot>();
            asteroids= new List<Asteroids>();
            for (int i = 0; i < 10; i++)
            {
                asteroids.Add(new Asteroids());
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            player.LoadContent(Content);
            background.LoadContent(Content);
            foreach (Asteroids asteroid in asteroids)
            {
                asteroid.LoadContent(Content);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            time++;
            // TODO: Add your update logic here
            if (time >= maxTime)
            {
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.F))
                {
                    shots.Add(new Shot(Content, player.position));
                }
                time = 0;
            }
                foreach (Shot shot in shots)
            {
                shot.Update();
            }
            player.Update();
            foreach (Asteroids asteroid in asteroids)
            {
                asteroid.Update();
            }
            //реализовать движение метеоритов через лист
            background.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            _spriteBatch.Begin();
            background.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            foreach (Shot shot in shots)
            {
                shot.Draw(_spriteBatch);
            }
            foreach (Asteroids asteroid in asteroids)
            {
                asteroid.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
       
    }
}