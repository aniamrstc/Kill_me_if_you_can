/* Auteur : Ania Marostica, Liliana Santos
 * Date : 22/12/2022
 * Version : 1.0
 * Projet :  Kill me if you can   
 */
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
        //list de composant 
        private List<Component> _components;

        //constructeur qui herite de la classe state il va definir la texture qu'on va utiliser,la police et le nombre de button dans notre menu ainsi que le texte ecrit dedans
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

            _components = new List<Component>(){
                newGameButton,
     
                quitGameButton,
            };
        }

        // dessine tout les composant
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
          
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);
        }
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }
        public override void PostUpdate(GameTime gameTime)
        {
           //throw new NotImplementedException();
        }

        //methode du button lancer le jeu 
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game1.ChangeState(new GameState(_game1, _graphicsDevice, _content));
        }

        //met a jour les composant
        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }
        //methode du button quitter le jeu 
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game1.Exit();
        }

    }
}
