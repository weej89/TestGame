#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace NightmareWonderlandGame
{
    class Player : Sprite
    {
        #region Global Variables
        KeyboardState keyboardState;

        //Variables for Sprite animation
        protected Point frameSize;
        protected Point currentFrame;
        protected Point sheetSize;
        protected Vector2 playerOrigin;
        protected int timeSinceLastFrame = 0;
        protected int millisecondsPerFrame = 150;
        #endregion

        #region Constructor
        public Player(Texture2D image, Vector2 position, int collisionOffset, Vector2 speed, Point currentFrame, Point sheetSize, float scale)
            : base(image, position, scale, collisionOffset, speed)
        {
            this.frameSize = new Point(image.Width / sheetSize.X, image.Height / sheetSize.Y);
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;

            this.playerOrigin = new Vector2((frameSize.X * scale) / 2, (frameSize.Y * scale) / 2);
        }
        #endregion

        #region Update and Draw
        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            keyboardState = Keyboard.GetState();

            movingUpAndDown(clientBounds);

            base.Update(gameTime, clientBounds);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White, 0, playerOrigin, scale, SpriteEffects.None, 0);
            this.animateSprite(gameTime);
        }
        #endregion

        #region AnimateSprite
        /// <summary>
        /// Loops through sprite sheet back and forth by the millisecond
        /// </summary>
        /// <param name="gameTime">Used to get the current elapsed gametime</param>
        private void animateSprite(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;
                currentFrame.Y++;
                if (currentFrame.Y >= sheetSize.Y)
                {
                    currentFrame.Y = 0;
                }
            }
        }
        #endregion



        /// <summary>
        /// Gets the current keyState of the W and S keys to move the player up and down
        /// </summary>
        /// <param name="clientBounds"></param>
        private void movingUpAndDown(Rectangle clientBounds)
        {
            if (keyboardState.IsKeyDown(Keys.W))
            {
                position.Y -= speed.Y;

                if (position.Y < 0)
                    position.Y = 0;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                if (position.Y + (frameSize.Y * scale) < clientBounds.Height)
                    position.Y += speed.Y;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                if (position.X > 0)
                {
                    position.X -= speed.X;
                }
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                if (position.X + (frameSize.X * scale) < clientBounds.Width)
                {
                    position.X += speed.X;
                }
            }
        }
    }
}
