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
    public class P2 : Sprite,ICollidable
    {
        public Bullet Bullet;

        public int Health { get; set; }
        public float Speed { get; set; }
        public int Score;
        public bool isDead
        {
            get
            {
                return Health <= 0;
            }
        }

        public P2(Texture2D texture)
          : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            if (_currentKey.IsKeyDown(Keys.RightControl) &&
                _previousKey.IsKeyUp(Keys.RightControl))
            {
                AddBullet(sprites);
            }

            if (isDead)
                return;

            foreach (var sprite in sprites)
            {
                if (sprite is P2)
                    continue;

                if (sprite.Rectangle.Intersects(this.Rectangle))
                {
                    Speed++;
                    sprite.IsRemoved = true;
                }
            }

        }

        public void Move()
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                Position.X -= 3;
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                Position.X += 3;

            Direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                Position.Y -= 3;
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                Position.Y += 3;
            Position = Vector2.Clamp(Position, new Vector2(0, 0), new Vector2(Game1.ScreenWidth - this.Rectangle.Width, Game1.ScreenHeight - this.Rectangle.Height));
        }

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
        public virtual void OnCollide(Sprite sprite)
        {
            throw new NotImplementedException();
        }
    }
}
