/* Auteur : Ania Marostica, Liliana Santos
 * Date : 22/12/2022
 * Version : 1.0
 * Projet :  Kill me if you can   
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace killMeIfYouCan
{
    public class Player : Sprite
    {
        public bool HasDied = false;

        public Player(Texture2D texture)
          : base(texture)
        {
            
        }

        //update des joueur
        public override void Update(GameTime gameTime, List<Sprite> sprites, P1 p1,P2 p2)
        {
            Move();
            Move2();

            foreach (var sprite in sprites)
            {
                if (sprite is Player)
                    continue;

                if (sprite.Rectangle.Intersects(this.Rectangle))
                {
                    this.HasDied = true;
                }
            }

            Position += Velocity;

            //garde le sprite dans l'ecran
            Position.X = MathHelper.Clamp(Position.X, 0, Game1.ScreenWidth - Rectangle.Width);

            Velocity = Vector2.Zero;
        }


        //deplacement p1
        private void Move()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Position.Y -= 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Position.Y += 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Position.X -= 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Position.X += 3;
            }
        }

        //deplacement p2
        private void Move2()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Position.Y -= 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Position.Y += 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Position.X -= 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Position.X += 3;
            }
        }
    }
}
