﻿using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStateManagementSample.Models.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameStateManagementSample.Models.Entities
{
    internal class EnemyWarrior : Enemy
    {

        public EnemyWarrior(int healthPoints, float movementSpeed, Vector2 playerPosition, Texture2D texture, SpriteFont spriteFont, List<Item> items)
            : base(healthPoints, movementSpeed, playerPosition, texture, spriteFont, items)
        {
        }
        public override void LoadContent(ContentManager content)
        {
            for (int i = 0; i <= 6; i++)
                animManager.walk.addFrame(content.Load<Texture2D>("Skeleton_Warrior/walk_frames/walk" + i.ToString() ));
            for (int i = 0; i <= 4; i++)
                animManager.attack.addFrame(content.Load<Texture2D>("Skeleton_Warrior/attack_frames/attack" + i.ToString()));
            for (int i = 0; i <= 6; i++)
                animManager.idle.addFrame(content.Load<Texture2D>("Skeleton_Warrior/idle_frames/idle" + i.ToString()));
            for (int i = 0; i <= 3; i++)
                animManager.death.addFrame(content.Load<Texture2D>("Skeleton_Warrior/death_frames/death" + i.ToString()));
            Texture = animManager.IdleAnimation();
            Position += Vector2.Zero;
        }
    }
}
