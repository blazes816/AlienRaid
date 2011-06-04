using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MyEngine;
using AlienRaid.Sprites;

namespace AlienRaid.Screens
{
    class Play : GameScreen
    {
        // Player stuff
        Player player = null;

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
            base.Update();
            this.lastKeyboardState = this.keyboardState;
        }
    }
}
