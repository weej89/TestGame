#region Using
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace NightmareWonderlandGame
{
    abstract class Sprite
    {
        #region Protected Variables
        protected Texture2D image;

        protected Vector2 position;
        protected Vector2 speed;

        protected float scale;

        protected Color hitChange = Color.Red;

        protected bool colorChange = false;

        protected int collisionOffset;
        #endregion

        #region Public Variables
        public virtual Vector2 GetPosition
        {
            get { return position; }
        }
        #endregion

        #region Constructor
        public Sprite(Texture2D image, Vector2 position, float scale, int collisionOffset, Vector2 speed)
        {
            this.image = image;
            this.position = position;
            this.scale = scale;
            this.collisionOffset = collisionOffset;
            this.speed = speed;
        }
        #endregion

        #region Update and Draw
        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
        #endregion

        #region CollsionRect
        /// <summary>
        /// Returns the collision rectangle around the sprite
        /// </summary>
        protected virtual Rectangle collisionRect
        {
            get
            {
                return new Rectangle((int)position.X + collisionOffset, (int)position.Y + collisionOffset, image.Width - (collisionOffset * 2), image.Height - (collisionOffset * 2));
            }
        }
        #endregion

        #region CollidesWith
        /// <summary>
        /// Takes the rectange of the object and checks to see if it is intersecting with another given rectangle
        /// </summary>
        /// <param name="intersectingRect">The rectangle of the intersecting object</param>
        /// <returns></returns>
        public bool CollidesWith(Rectangle intersectingRect)
        {
            if ((this.collisionRect.Intersects(intersectingRect)))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
