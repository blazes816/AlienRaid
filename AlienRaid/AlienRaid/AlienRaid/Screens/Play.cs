using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MyEngine;

namespace AlienRaid.Screens
{
    class Play : GameScreen
    {
        // Player stuff
        Sprite player = null;
        Vector2 strafeVelocity = new Vector2(5, 0);

        private HUD hud;
        private int windowWidth;
        private int windowHeight;

        public Play(int width, int height)
        {
            // Window size
            this.windowWidth = width;
            this.windowHeight = height;
        }

        protected override void Load()
        {
            player = new Sprite(400, 530, "Content/Images/ship");
            AddComponent(player);
        }

        public override void Update()
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Right))
                player.Position += strafeVelocity;
            else if (ks.IsKeyDown(Keys.Left))
                player.Position -= strafeVelocity;

            if (player.Position.X < 0) player.Position = new Vector2(0, player.Position.Y);
            else if (player.Position.X > this.windowWidth - player.Width)
                player.Position = new Vector2(this.windowWidth - player.Width, player.Position.Y);
            base.Update();
        }
    }
}
