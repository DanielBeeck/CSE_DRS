﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateManagementSample.Models
{

    public class AnimationManager
    {
        public Animation walk;
        public Animation attack;
        public Animation idle;
        public Animation death;

        public AnimationManager(float movementSpeed)
        {
            
            walk = new Animation(movementSpeed);

            attack = new Animation(5);

            idle = new Animation(5);

            death = new Animation(5, false);
        }


        public void setAnimationSpeedBasedOnPictureCount()
        {

        }

        public Texture2D AttackAnimation()
        {
            return attack.GetCurrentFrame();
        }

        public Texture2D WalkAnimation()
        {
            return walk.GetCurrentFrame();
        }

        public Texture2D IdleAnimation()
        {
            return idle.GetCurrentFrame();
        }

        public Texture2D DeathAnimation()
        {
            return death.GetCurrentFrame();
        }

        public bool DeathAnimationFinished()
        {
            return death.GetCurrentFrame() == death.Textures.Last();
        }

        public bool AttackAnimationFinished()
        {
            return attack.IterationFinished();
        }
    }

}
