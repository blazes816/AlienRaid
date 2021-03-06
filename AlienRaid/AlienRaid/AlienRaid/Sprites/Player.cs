﻿using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Xanx;
using Xanx.Components;

namespace AlienRaid.Sprites
{
    class Player : Sprite
    {
        private Vector2 strafeVelocity;
        private TimeSpan lastFire = new TimeSpan(0,0,0);
        private bool canFire = true;
        private Timer shootTimer;

        // Constructor inheriting from parent. 
        public Player(int x, int y, string filename) : base(x, y, filename)
        {
            
        }

        protected override void Load()
        {
            base.Load();
        }

        public override void Update()
        {
            // Handle strafing
            if (Parent.keyboardState.IsKeyDown(Keys.Right))
                this.Position += strafeVelocity;
            else if (Parent.keyboardState.IsKeyDown(Keys.Left))
                this.Position -= strafeVelocity;

            // Handle missile firing
            if (Parent.keyboardState.IsKeyDown(Keys.Space) && this.canFire)
                fireMissile();

            // Handle bounds checking
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

        public void fireMissile()
        {
            Screens.Play sc = (Screens.Play)Parent;
            sc.fireMissile();

            this.canFire = false;
        }

        public int resetCanFire()
        {
            this.canFire = true;
            return 0;
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
