using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MyEngine;

namespace AlienRaid.Sprites
{
    class Player : Sprite
    {
        private Vector2 strafeVelocity;

        // Constructor inheriting from parent. 
        public Player(int x, int y, string filename) : base(x, y, filename)
        {
        }

        public override void Update()
        {
            if (Parent.keyboardState.IsKeyDown(Keys.Right))
                this.Position += strafeVelocity;
            else if (Parent.keyboardState.IsKeyDown(Keys.Left))
                this.Position -= strafeVelocity;

            if (this.Position.X < 0) this.Position = new Vector2(0, this.Position.Y);
            else if (this.Position.X > Parent.windowWidth - this.Width)
                this.Position = new Vector2(Parent.windowWidth - this.Width, this.Position.Y);

            base.Update();
        }

        public override void Draw()
        {
            Parent.Engine.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            Parent.Engine.SpriteBatch.Draw(this.SpriteTexture, this.Position, Color.White);
            Parent.Engine.SpriteBatch.End();
        }

        #region Getters & Setters


        public Vector2 StrafeVelocity
        {
            get { return strafeVelocity; }
            set { strafeVelocity = value; }
        }
        #endregion
    }
}
