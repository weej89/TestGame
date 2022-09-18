#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TestGame;
#endregion

namespace NightmareWonderlandGame
{
    internal class SpriteManager
    {
        #region Private
        private Player player;
        #endregion

        #region Constructor
        public SpriteManager()
        {
        }
        #endregion

        public void Load(Game game)
        {
            this.player = player = new Player(
                game.Content.Load<Texture2D>("Sprites/spritesheets/1idle"), 
                new Vector2(game.Window.ClientBounds.Width / 2, game.Window.ClientBounds.Height / 2), 
                10,
                new Vector2(15, 15), 
                new Point(0, 0),
                new Point(3, 2), 
                2.0f
                );
        }

        #region Update and Draw
        public void Update(GameTime gameTime, Rectangle clientBounds)
        {
            player.Update(gameTime, clientBounds);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            player.Draw(gameTime, spriteBatch);
        }
        #endregion
    }
}
