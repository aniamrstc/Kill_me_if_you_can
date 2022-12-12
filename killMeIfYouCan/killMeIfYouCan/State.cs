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
        protected ContentManager _content;

        protected GraphicsDevice _graphicsDevice;

        protected Game1 _game1;
       

        #endregion

        #region Methods

        public abstract void Draw(GameTime gameTime,SpriteBatch spriteBatch);

        public abstract void PostUpdate(GameTime gameTime);

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
