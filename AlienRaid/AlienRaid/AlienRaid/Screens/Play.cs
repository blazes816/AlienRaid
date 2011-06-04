using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Xanx;
using Xanx.Components;

using AlienRaid.Sprites;

namespace AlienRaid.Screens
{
    class Play : GameScreen
    {
        // Player stuff
        private Player player = null;
        private List<Sprite> missiles = new List<Sprite>();
        private Timer shotTimer;

        //private HUD hud;

        public Play(int width, int height) : base(width, height)
        {

        }

        protected override void Load()
        {
            player = new Player(400, 530, "Content/Images/ship");
            player.StrafeVelocity = new Vector2(5, 0);
            AddComponent(player);
        }

        public override void Update()
        {
            this.keyboardState = Keyboard.GetState();

            for (int i = 0; i < missiles.Count; i++)
            {
                missiles[i].Position += missiles[i].Velocity;
                if ((missiles[i].Position.Y + missiles[i].Height) < 0)
                {
                    RemoveComponent(missiles[i]);
                    missiles.Remove(missiles[i]);
                }
            }

            base.Update();
            this.lastKeyboardState = this.keyboardState;
        }

        public void fireMissile()
        {
            // Create the missle sprite and set it's velocity
            Sprite missile = new Sprite(player.Position, "Content/Images/missile");
            missile.Velocity = new Vector2(0, -10);
            this.missiles.Add(missile);

            // Create the timer to reset when the player can shoot
            Func<int> trigger = player.resetCanFire;
            this.shotTimer = new Timer();

            // Add the components
            AddComponent(missile);
            AddComponent(shotTimer);

            // Set the timer now that it has access to the engine
            this.shotTimer.SetTimer(new TimeSpan(0, 0, 0, 0, 500), trigger);
        }
    }
}
