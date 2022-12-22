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

namespace killMeIfYouCan
{
    public abstract class State
    {
        #region Fields
        //initialisation variable
        protected ContentManager _content;

        protected GraphicsDevice _graphicsDevice;

        protected Game1 _game1;
       

        #endregion

        #region Methods

        public abstract void Draw(GameTime gameTime,SpriteBatch spriteBatch);

        public abstract void PostUpdate(GameTime gameTime);

        //constructeur
        public State(Game1 game,GraphicsDevice graphicsDevice,ContentManager content)
        {
            _content = content;
            _graphicsDevice = graphicsDevice;
            _game1 = game;
        }

        public abstract void Update(GameTime gameTime);

        #endregion
    }
}
