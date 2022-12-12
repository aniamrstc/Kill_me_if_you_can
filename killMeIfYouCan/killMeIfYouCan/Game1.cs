
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

using MonoGame.Extended.Content;
using MonoGame.Extended;

namespace killMeIfYouCan
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //private Players player;

        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;

        private Texture2D _texture;
        private Vector2 _position;
        private List<Sprite> _sprites;
        private P1 _p1;
        private P2 _p2;
        private Bullet2 bullet;

        private State _currentState;
        private State _nextState;
       bool visible=false;
        
        public void ChangeState(State state)
        {
            _nextState = state;
            visible = !visible;
        }
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
            //player = new Players();
            IsMouseVisible = true;
          
            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            var P1Texture = Content.Load<Texture2D>("fireeeeee");
            var P2Texture = Content.Load<Texture2D>("fireeeeee2");
            _texture = Content.Load<Texture2D>("unnamed");
            _position = new Vector2(0, 0);
            bullet = new Bullet2(_texture);
            _sprites = new List<Sprite>()
      {
               new P2(P2Texture,Keys.RightControl,Keys.Left,Keys.Right,Keys.Up,Keys.Down)
        {
          Position = new Vector2(1150, 100),
          Bullet = new Bullet2(Content.Load<Texture2D>("FireBullet")),
        },
       new P1(P1Texture,Keys.Space,Keys.A,Keys.D,Keys.W,Keys.S)
        {

          Position = new Vector2(100, 100),
          Bullet = new Bullet(Content.Load<Texture2D>("FireBullet")),
        },
      };
            _currentState = new MenuState(this, graphics.GraphicsDevice, Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites.ToArray())
                sprite.Update(gameTime, _sprites,_p1,_p2);
           
            PostUpdate();
            if(_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
                
            }
            _currentState.Update(gameTime);
            _currentState.PostUpdate(gameTime);

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
                if (sprite is Player)
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
            if (bullet.Estmort == true)
            {
                spriteBatch.Draw(_texture, _position, null, Color.White, 0, _texture.Bounds.Center.ToVector2(), 0.125f, 0, 0);
            }
            if(visible==true)
            {
                foreach (var sprite in _sprites)
                    sprite.Draw(spriteBatch);
            }
            else
            {

            }

            
          
           

            _currentState.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}