using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MyEngine;
using AlienRaid.Sprites;

namespace AlienRaid.Screens
{
    class Play : GameScreen
    {
        // Player stuff
        private Player player = null;
        private List<Sprite> missiles = new List<Sprite>();

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
            Sprite missile = new Sprite(player.Position, "Content/Images/missile");
            missile.Velocity = new Vector2(0, -10);
            missiles.Add(missile);
            AddComponent(missile);
        }
    }
}
