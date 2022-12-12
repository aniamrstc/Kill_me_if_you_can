using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace killMeIfYouCan
{
    public class MenuState : State
    {
        private List<Component> _components;
  
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Button");
            var buttonFont = _content.Load<SpriteFont>("Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(550, 200),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

        
         

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(550, 300),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
      {
        newGameButton,
     
        quitGameButton,
      };
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
           // spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            //spriteBatch.End();
        }
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }
        public override void PostUpdate(GameTime gameTime)
        {
           //throw new NotImplementedException();
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game1.ChangeState(new GameState(_game1, _graphicsDevice, _content));
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game1.Exit();
        }

    }
}
