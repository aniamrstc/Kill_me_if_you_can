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
using System.Text;
using System.Threading.Tasks;

namespace killMeIfYouCan
{
    public class Sprite : ICloneable
    {
        //initialisation variable
        protected Texture2D _texture;
        protected float _rotation;

        public Vector2 Position;
        public Vector2 Origin;
        public Vector2 Direction;
        public Vector2 Velocity;
        public float RotationVelocity = 3f;
        public float LinearVelocity = 4f;
        public SpriteEffect spriteEffects;      
        public Sprite Parent;
        public float LifeSpan = 0f;
        public bool IsRemoved = false;
        public int Health;

        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;

        //constructeur definie une texture, une vie et une taille
        public Sprite(Texture2D texture)
        {
            _texture = texture;
            Health = 200;
            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
        }

        //sa definie un contour autour du sprite selon son hauteur et sa largeur
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }
        public float Rotation
        {
            get { return _rotation; }
            set
            {
                _rotation = value;
            }
        }
        public Matrix Transform
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(-Origin, 0)) * Matrix.CreateRotationZ(_rotation) * Matrix.CreateTranslation(new Vector3(Position, 0));
            }
        }

        //met a jour les sprites
        public virtual void Update(GameTime gameTime, List<Sprite> sprites,P1 p1,P2 p2)
        {
           
        }

        //dessine les sprites
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, _rotation,_texture.Bounds.Center.ToVector2(),2
                ,0,0);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
