
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace killMeIfYouCan
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
      
        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;
   

        private List<Sprite> _sprites;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {


            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            var P1Texture = Content.Load<Texture2D>("fireeeeee");
            var P2Texture = Content.Load<Texture2D>("fireeeeee");
         
             _sprites = new List<Sprite>()
      {
               new P1(P2Texture,Keys.RightControl,Keys.Left,Keys.Right,Keys.Up,Keys.Down)
        {
          Position = new Vector2(1150, 100),
          Bullet = new Bullet(Content.Load<Texture2D>("FireBullet")),
        },
       new P1(P1Texture,Keys.Space,Keys.A,Keys.D,Keys.W,Keys.S)
        {
           
          Position = new Vector2(100, 100),
          Bullet = new Bullet(Content.Load<Texture2D>("FireBullet")),
        },
      };
          
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites.ToArray())
                sprite.Update(gameTime, _sprites);
          
            PostUpdate();
          
           
            base.Update(gameTime);
        }

        private void PostUpdate()
        {
            for (int i = 0; i < _sprites.Count; i++)
            {
                var sprite = _sprites[i];
                if (sprite.IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }
                if(sprite is Player)
                {
                    var player = sprite as Player;

                    if (player.HasDied)
                    {
                        Exit();
                    }
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SlateGray);
            spriteBatch.Begin(samplerState: SamplerState.PointWrap);
            
            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}