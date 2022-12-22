
/*
 * Auteur : Ania Marostica, Liliana Santos
 * Date : 22/12/2022
 * Version : 1.0
 * Projet :  Kill me if you can   
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

using MonoGame.Extended.Content;
using MonoGame.Extended;
using System.Reflection.Emit;

namespace killMeIfYouCan
{
    public class Game1 : Game
    {
        //variable graphic
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //taille ecran
        public static int ScreenWidth = 1297;
        public static int ScreenHeight = 780;

        private Texture2D _texture;
        private Vector2 _position;
        private Texture2D _texture2;
        private Vector2 _position2;
        
        //variable barre de vie
        private Texture2D _textureHealth1;
        private Vector2 _positionHealth1;
        private Vector2 _positionHealth2;
        private Texture2D _textureHealth2;
       
        private Texture2D _textureHealth3;
       
        private Texture2D _textureHealth4;
        
        private Texture2D _textureHealth5;
        
        private Texture2D _textureHealth6;
       
        private Texture2D _textureHealth7;
       
        private Texture2D _textureHealth8;
       
        private Texture2D _textureHealth9;

        private Texture2D _textureHealth10;
        private Texture2D _textureHealth11;

        //variable des sprites
        private List<Sprite> _sprites;
        private P1 _p1;
        private P2 _p2;
        private Bullet2 bullet;

        //variable d'etat
        private State _currentState;
        private State _nextState;
        bool visible = false;
        bool estmort = false;
        bool estmortP2 = false;
        bool barredevie = true;
        bool barredevie2 = true;

        //methode de changment d'etat pour le menu 
        public void ChangeState(State state)
        {
            _nextState = state;
            visible = !visible;

        }
        public Game1()
        {
            //definie le dossier ou on va chercher les assets
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //applique la taille de l'ecran defini plus haut
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            //player = new Players();
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            //tout les composant graphics avec leur position
            var P1Texture = Content.Load<Texture2D>("fireeeeee");
            var P2Texture = Content.Load<Texture2D>("WaterPerso");
            _texture = Content.Load<Texture2D>("endGame2");
            _position = new Vector2(0, 0);
            _texture2 = Content.Load<Texture2D>("endGame1");
            _position2 = new Vector2(0, 0);

            _textureHealth1 = Content.Load<Texture2D>("health/pixil-layer-0");
            _positionHealth1 = new Vector2(0, 10);
            _positionHealth2 = new Vector2(790, 10);
            _textureHealth2 = Content.Load<Texture2D>("health/pixil-layer-1");
            _textureHealth3 = Content.Load<Texture2D>("health/pixil-layer-2");
            _textureHealth4 = Content.Load<Texture2D>("health/pixil-layer-3");
            _textureHealth5 = Content.Load<Texture2D>("health/pixil-layer-4");
            _textureHealth6 = Content.Load<Texture2D>("health/pixil-layer-5");
            _textureHealth7 = Content.Load<Texture2D>("health/pixil-layer-6");
            _textureHealth8 = Content.Load<Texture2D>("health/pixil-layer-7");
            _textureHealth9 = Content.Load<Texture2D>("health/pixil-layer-8");
            _textureHealth10 = Content.Load<Texture2D>("health/pixil-layer-9");
            _textureHealth11 = Content.Load<Texture2D>("health/pixil-layer-10");

            bullet = new Bullet2(_texture);
            //initialisation des deux perso avec leur mouvement et leur tire
            _sprites = new List<Sprite>(){
               new P2(P2Texture,Keys.RightControl,Keys.Left,Keys.Right,Keys.Up,Keys.Down){
                  Position = new Vector2(1150, 800),
                  Bullet = new Bullet2(Content.Load<Texture2D>("bulletWater")),
               },
               new P1(P1Texture,Keys.Space,Keys.A,Keys.D,Keys.W,Keys.S){

                  Position = new Vector2(100, 100),
                  Bullet = new Bullet(Content.Load<Texture2D>("FireBullet")),
               },
            };
            _currentState = new MenuState(this, graphics.GraphicsDevice, Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            //pour tout les sprite si leur vie arrive a 0 il sont mort
            foreach (var sprite in _sprites.ToArray())
            {
                if (sprite is P1)
                {
                    if (sprite.Health == 0 || sprite.Health < 0)
                    {
                        estmort = true;
                    }
                    
                }
                if (sprite is P2)
                {
                    if (sprite.Health == 0 || sprite.Health < 0)
                    {
                        estmortP2 = true;
                    }
                }

                //update les sprites
                sprite.Update(gameTime, _sprites, _p1, _p2);
            }

            PostUpdate();
            //change l'etat du menu
            if (_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;

            }

            //update les etat
            _currentState.Update(gameTime);
            _currentState.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        private void PostUpdate()
        {
            //retire toute les bullets quand elle touche le perso
            for (int i = 0; i < _sprites.Count; i++)
            {
                var sprite = _sprites[i];
                if (sprite.IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }
                if (sprite is Player)
                {
                    var player = sprite as Player;

                    if (player.HasDied)
                    {
                        Exit();
                    }
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SlateGray);
            spriteBatch.Begin(samplerState: SamplerState.PointWrap);

            //si P1 est mort on affiche l'ecran de victoire de p2            
            if (estmort == true)
            {
                visible = false;
                spriteBatch.Draw(_texture, _position, null, Color.White, 0, new Vector2(0, 0), 1 , 0, 0);
            }
            //si P2 est mort on affiche l'ecran de victoire de p1
            if (estmortP2 == true)
            {
                visible = false;
                spriteBatch.Draw(_texture2, _position2, null, Color.White, 0, new Vector2(0, 0), 1, 0, 0);
            }
            //si le joueur a cliquer sur new game  
            if (visible == true)
            {
                //on affiche tout les sprites      
                foreach (var sprite in _sprites)
                {
                    sprite.Draw(spriteBatch);
                    //si le sprite est un p1 on affiche sa barre de vie et elle change selon le niveau de sa vie
                    if (sprite is P1)
                    {
                        if (barredevie == true)
                        {
                            spriteBatch.Draw(_textureHealth1, _positionHealth1, null, Color.White, 0, new Vector2(520, 500), 0.125f, 0, 0);
                        }
                        if (sprite.Health == 180)
                        {
                            barredevie = false;
                            spriteBatch.Draw(_textureHealth2, _positionHealth1, null, Color.White, 0, new Vector2(520, 500), 0.125f, 0, 0);
                        }
                        if (sprite.Health == 160)
                        {
                            spriteBatch.Draw(_textureHealth3, _positionHealth1, null, Color.White, 0, new Vector2(520, 500), 0.125f, 0, 0);
                        }
                        if (sprite.Health == 140)
                        {
                            spriteBatch.Draw(_textureHealth4, _positionHealth1, null, Color.White, 0, new Vector2(520, 500), 0.125f, 0, 0);
                        }
                        if (sprite.Health == 120)
                        {
                            spriteBatch.Draw(_textureHealth5, _positionHealth1, null, Color.White, 0, new Vector2(520, 500), 0.125f, 0, 0);
                        }
                        if (sprite.Health == 100)
                        {
                            spriteBatch.Draw(_textureHealth6, _positionHealth1, null, Color.White, 0, new Vector2(520, 500), 0.125f, 0, 0);
                        }
                        if (sprite.Health == 80)
                        {
                            spriteBatch.Draw(_textureHealth7, _positionHealth1, null, Color.White, 0, new Vector2(520, 500), 0.125f, 0, 0);
                        }
                        if (sprite.Health == 60)
                        {
                            spriteBatch.Draw(_textureHealth8, _positionHealth1, null, Color.White, 0, new Vector2(520, 500), 0.125f, 0, 0);
                        }
                        if (sprite.Health == 40)
                        {
                            spriteBatch.Draw(_textureHealth9, _positionHealth1, null, Color.White, 0, new Vector2(520, 500), 0.125f, 0, 0);
                        }
                        if (sprite.Health == 20)
                        {
                            spriteBatch.Draw(_textureHealth10, _positionHealth1, null, Color.White, 0, new Vector2(520, 500), 0.125f, 0, 0);
                        }
                        if (sprite.Health == 0)
                        {
                            spriteBatch.Draw(_textureHealth11, _positionHealth1, null, Color.White, 0, new Vector2(520, 500), 0.125f, 0, 0);
                        }
                    }
                    //si le sprite est un p2 on affiche sa barre de vie et elle change selon le niveau de sa vie
                    if (sprite is P2)
                    {
                        if (barredevie2 == true)
                        {
                            spriteBatch.Draw(_textureHealth1, _positionHealth2, null, Color.White, 0, new Vector2(520, 500), 0.125f, SpriteEffects.FlipHorizontally, 0);
                        }
                        if (sprite.Health == 180)
                        {
                            barredevie2 = false;
                            spriteBatch.Draw(_textureHealth2, _positionHealth2, null, Color.White, 0, new Vector2(520, 500), 0.125f, SpriteEffects.FlipHorizontally, 0);
                        }
                        if (sprite.Health == 160)
                        {
                            spriteBatch.Draw(_textureHealth3, _positionHealth2, null, Color.White, 0, new Vector2(520, 500), 0.125f, SpriteEffects.FlipHorizontally, 0);
                        }
                        if (sprite.Health == 140)
                        {
                            spriteBatch.Draw(_textureHealth4, _positionHealth2, null, Color.White, 0, new Vector2(520, 500), 0.125f, SpriteEffects.FlipHorizontally, 0);
                        }
                        if (sprite.Health == 120)
                        {
                            spriteBatch.Draw(_textureHealth5, _positionHealth2, null, Color.White, 0, new Vector2(520, 500), 0.125f, SpriteEffects.FlipHorizontally, 0);
                        }
                        if (sprite.Health == 100)
                        {
                            spriteBatch.Draw(_textureHealth6, _positionHealth2, null, Color.White, 0, new Vector2(520, 500), 0.125f, SpriteEffects.FlipHorizontally, 0);
                        }
                        if (sprite.Health == 80)
                        {
                            spriteBatch.Draw(_textureHealth7, _positionHealth2, null, Color.White, 0, new Vector2(520, 500), 0.125f, SpriteEffects.FlipHorizontally, 0);
                        }
                        if (sprite.Health == 60)
                        {
                            spriteBatch.Draw(_textureHealth8, _positionHealth2, null, Color.White, 0, new Vector2(520, 500), 0.125f, SpriteEffects.FlipHorizontally, 0);
                        }
                        if (sprite.Health == 40)
                        {
                            spriteBatch.Draw(_textureHealth9, _positionHealth2, null, Color.White, 0, new Vector2(520, 500), 0.125f, SpriteEffects.FlipHorizontally, 0);
                        }
                        if (sprite.Health == 20)
                        {
                            spriteBatch.Draw(_textureHealth10, _positionHealth2, null, Color.White, 0, new Vector2(520, 500), 0.125f, SpriteEffects.FlipHorizontally, 0);
                        }
                        if (sprite.Health == 0)
                        {
                            spriteBatch.Draw(_textureHealth11, _positionHealth2, null, Color.White, 0, new Vector2(520, 500), 0.125f, SpriteEffects.FlipHorizontally, 0);
                        }

                    }

                    
                }
            }
            else
            {

            }
            //on afficher le menu
            _currentState.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}