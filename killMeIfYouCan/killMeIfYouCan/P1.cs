/* Auteur : Ania Marostica, Liliana Santos
 * Date : 22/12/2022
 * Version : 1.0
 * Projet :  Kill me if you can   
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace killMeIfYouCan
{
    public class P1 : Sprite, ICollidable
    {
        //initialisation variable
        public Bullet Bullet;
        private Keys toucheTir;
        private Keys DeplacementGauche;
        private Keys DeplacementDroite;
        private Keys DeplacementHaut;
        private Keys DeplacementBas;

        public double Health;
        public float Speed { get; set; }
        public int Score;

        //bool de mort
        public bool isDead
        {
            get
            {
                return Health <= 0;
            }
        }
        //constructeur
        public P1(Texture2D newtexture, Keys toucheTir, Keys DeplacementGauche, Keys DeplacementDroite, Keys DeplacementHaut, Keys DeplacementBas)
         : base(newtexture)
        {
            this.toucheTir = toucheTir;
            this.DeplacementGauche = DeplacementGauche;
            this.DeplacementDroite = DeplacementDroite;
            this.DeplacementBas = DeplacementBas;
            this.DeplacementHaut = DeplacementHaut;
            
        }



        public override void Update(GameTime gameTime, List<Sprite> sprites,P1 p1,P2 p2)
        {
            //appelle fonction de deplacement
            Move();

            //si on appuye sur la touche espace sa ajoute une balle a la liste des sprites
            if (_currentKey.IsKeyDown(toucheTir) &&
             _previousKey.IsKeyUp(toucheTir))
            {
                AddBullet(sprites);
            }

            if (isDead)
                return;

            foreach (var sprite in sprites)
            {
                if (sprite is P1)
                    continue;

                if (sprite.Rectangle.Intersects(this.Rectangle))
                {
                    Speed++;
                    sprite.IsRemoved = true;
                }
            }

        }

        //deplacement du personnage
        public void Move()
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            Direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));

            if (Keyboard.GetState().IsKeyDown(DeplacementHaut))
                Position.Y -= 3;
            else if (Keyboard.GetState().IsKeyDown(DeplacementBas))
                Position.Y += 3;
            Position = Vector2.Clamp(Position, new Vector2(0, 0), new Vector2(Game1.ScreenWidth - this.Rectangle.Width, Game1.ScreenHeight - this.Rectangle.Height));
        }

        //ajoute des bullet a la liste de sprite
        private void AddBullet(List<Sprite> sprites)
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Direction = this.Direction;
            bullet.Position = this.Position;
            bullet.LinearVelocity = this.LinearVelocity * 2;
            bullet.LifeSpan = 2f;
            bullet.Parent = this;

            sprites.Add(bullet);
        }
        //collision
        public virtual void OnCollide(Sprite sprite)
        {
            throw new NotImplementedException();
        }
        public Rectangle boite
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }

        }
    }
}
