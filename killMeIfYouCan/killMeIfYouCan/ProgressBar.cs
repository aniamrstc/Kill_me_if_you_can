//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using MonoGame.Extended.Serialization;
//using MonoGame.Extended.Sprites;
//using System;
//using System.Collections.Generic;
//using System.Runtime.ConstrainedExecution;
//using System.Security.Cryptography;

//using MonoGame.Extended.Content;
//using MonoGame.Extended;
//namespace killMeIfYouCan
//{
//    public class ProgressBar
//    {
//        protected readonly Texture2D background;
//        protected readonly Texture2D foreground;
//        protected readonly Vector2 position;
//        protected readonly float maxValue;
//        protected float currentValue;
//        protected Rectangle part;
//        SpriteBatch spriteBatch;
//        public ProgressBar(Texture2D bg, Texture2D fg, float max, Vector2 pos)
//        {
//            background = bg;
//            foreground = fg;
//            maxValue = max;
//            currentValue = max;
//            position = pos;
//            part = new(0, 0, foreground.Width, foreground.Height);
//        }

//        public virtual void Update(float value)
//        {
//            currentValue = value;
//            part.Width = (int)(currentValue / maxValue * foreground.Width);
//        }

//        public virtual void Draw()
//        {
//            spriteBatch.Draw(background, position, Color.White);
//            spriteBatch.Draw(foreground, position, part, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
//        }
//    }
//}
