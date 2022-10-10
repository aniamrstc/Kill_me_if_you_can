
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace killMeIfYouCan
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
   

        private Texture2D _texture;
        private Vector2 _position;
        private Texture2D _textureP2;
        private Vector2 _positionP2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _texture = Content.Load<Texture2D>("unnamed");
            _position=new Vector2(0,0);
            _textureP2 = Content.Load<Texture2D>("unnamed");
            _positionP2 = new Vector2(50, 50);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _position.Y -= 5;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _position.Y += 5;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _position.X -= 5;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _position.X += 5;

            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _positionP2.Y -= 5;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _positionP2.Y += 5;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _positionP2.X -= 5;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _positionP2.X += 5;

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SlateGray);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_texture, _position, null, Color.White, 0, _texture.Bounds.Center.ToVector2(), 0.125f, 0, 0);
            _spriteBatch.Draw(_textureP2, _positionP2, null, Color.White, 0, _texture.Bounds.Center.ToVector2(), 0.125f, 0, 0);
            _spriteBatch.End();
          

            base.Draw(gameTime);
        }
    }
}