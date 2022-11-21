using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace killMeIfYouCan
{
    public class Bullet : Sprite
    {
        private float _timer;

        public Bullet(Texture2D texture)
          : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer >= LifeSpan)
                IsRemoved = true;

            Position += Direction * LinearVelocity;


            foreach (var sprite in sprites)
            {

                if (Rectangle.Intersects(sprite.Rectangle))
                {
                    if (sprite is P1)
                    {
                        
                        sprite.Health -= 10;
                        Debug.Print(sprite.Health.ToString());
                        if (sprite is Bullet)
                        {
                            sprite.IsRemoved = true;
                        }

                    }
                }
            }
        }
    }
}


