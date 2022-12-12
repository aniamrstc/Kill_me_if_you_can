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
    public class Bullet2 : Sprite
    {
        private float _timer;
        private bool _estmort=false;
       // public Game1 game =new Game1();

        public Bullet2(Texture2D texture)
          : base(texture)
        {

        }

        public bool Estmort { get => _estmort; set => _estmort = value; }

        public override void Update(GameTime gameTime, List<Sprite> sprites, P1 p1, P2 p2)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer >= LifeSpan)
                IsRemoved = true;

            Position -= Direction * LinearVelocity;


            foreach (var sprite in sprites)
            {

                if (Rectangle.Intersects(sprite.Rectangle))
                {
                    if (sprite is P1)
                    {

                        sprite.Health -= 10;
                        Debug.Print("P1: " + sprite.Health.ToString());
                        if (sprite is Bullet)
                        {
                            sprite.IsRemoved = true;
                        }
                        if (sprite.Health == 0 || sprite.Health < 0)
                        {
                           Environment.Exit(0);
                            Debug.Print("mort");
                        }

                    }
                }
            }
        }
    }
}


