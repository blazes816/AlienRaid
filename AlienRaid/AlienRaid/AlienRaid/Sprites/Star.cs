using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MyEngine;

namespace AlienRaid.Sprites
{
    class Star : Sprite
    {
        private Color color;
        private Random random = new Random();

        // Constructor inheriting from parent. 
        public Star(int x, int y, string filename) : base(x, y, filename)
        {

        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            Parent.Engine.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            Parent.Engine.SpriteBatch.Draw(this.SpriteTexture, new Vector2(this.Position.X, this.Position.Y - 200), null, this.Color, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 1.0f);
            Parent.Engine.SpriteBatch.End();
            base.Draw();
        }

        #region Getters & Setters
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        #endregion
    }
}
