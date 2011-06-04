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
        private Vector2 velocity;

        // Constructor inheriting from parent. 
        public Star(int x, int y, string filename) : base(x, y, filename)
        {
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            Parent.Engine.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            Parent.Engine.SpriteBatch.Draw(spriteTexture, this.Position, null, this.Color, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 1.0f);
            Parent.Engine.SpriteBatch.End();
        }
    }
}
