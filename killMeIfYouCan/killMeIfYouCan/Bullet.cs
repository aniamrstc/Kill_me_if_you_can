/*
 * Auteur : Ania Marostica, Liliana Santos
 * Date : 22/12/2022
 * Version : 1.0
 * Projet :  Kill me if you can   
 */
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

        public override void Update(GameTime gameTime, List<Sprite> sprites,P1 p1,P2 p2)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer >= LifeSpan)
                IsRemoved = true;
            //defini la direction de la balle
            Position += Direction * LinearVelocity;


            foreach (var sprite in sprites)
            {
                //si la balle touche le sprite et qu'il est un p1 alors on baisse sa vie et on retire la balle
                if (Rectangle.Intersects(sprite.Rectangle))
                {
                    if (sprite is P2)
                    {
                        
                        sprite.Health -= 10;
                        Debug.Print(sprite.Health.ToString());
                        if (sprite is Bullet)
                        {
                            sprite.IsRemoved = true;
                        }
                        if (sprite.Health == 0 || sprite.Health < 0)
                        {

                            Debug.Print("mort");
                        }

                    }
                }
            }
        }
    }
}


