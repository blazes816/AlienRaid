using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MyEngine
{
    class Sprite : Component
    {
        public Texture2D spriteTexture;
        string filename;

        Vector2 position = Vector2.Zero;

        public Vector2 Position 
        { 
            get { return position; }
            set { position = value; }
        }

        public int Width { get { return spriteTexture.Width; } }
        public int Height { get { return spriteTexture.Height; } }

        public Sprite(float x, float y, string filename)
        {
            this.position = new Vector2(x, y);
            this.filename = filename;
        }

        protected override void Load()
        {
            spriteTexture = Parent.Engine.Content.Load<Texture2D>(filename);
        }

        public override void Draw()
        {
            
            Parent.Engine.SpriteBatch.Begin(SpriteSortMode.Immediate,BlendState.Additive);
            Parent.Engine.SpriteBatch.Draw(spriteTexture, position, Color.White);
            Parent.Engine.SpriteBatch.End();
        }
    }
}
