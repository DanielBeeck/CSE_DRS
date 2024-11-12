﻿using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using GameStateManagementSample.Models.Entities;
using GameStateManagementSample.Models.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameStateManagementSample.Models.Items
{
    public abstract class Weapon : Item
    {

        #region attributes, fields and properties
        private float weaponDamage; // Der Schaden, den jeder Schwerthieb oder jeder Pfeilschuss verursacht.
        public float WeaponDamage
        {
            get
            {
                return this.weaponDamage;
            }
            set
            {
                this.weaponDamage = value;
            }
        }
        private float attackSpeed; // Wieviele Schwerthiebe oder Pfeilschüsse pro Zeiteinheit erfolgen können.
        public float AttackSpeed
        {
            get
            {
                return this.attackSpeed;
            }
            set
            {
                this.attackSpeed = value;
            }
        }
        private float weaponRange; // Wie weit der Schwerthieb reicht, oder wie weit Pfeile fliegen können.
        public float WeaponRange
        {
            get
            {
                return this.weaponRange;
            }
            set
            {
                this.weaponRange = value;
            }
        }
        /*
        Die Überlegung ist an dieser Stelle, wie kompliziert wir die Waffenlogik machen wollen.
        Um eine Art Balance zu haben sollten Nahkampf und Fernkampf sich ausgleichende Vor-, und Nachteile haben. Gleichzeitig soll keines davon den sicheren Tod bedeuten (Man sollte vielleicht mit dem Schwert angreifend außer Reichweite bleiben können).
        Eine Möglichkeit wäre es, dafür zu sorgen, dass das Schwert eine Art "Area of Effect" hat, während Pfeile eher für "Single-Target-Combat" geeignet sind.

        Soll es verschiedene Munition geben, oder einfach eine feste Munition, die an die jeweilige Fernkampfwaffe gebunden ist? Munition als endlicher Item-Stack, oder einfach v"unendlich Pfeile"? Haltbarkeit?

        Der momentane Plan ist zunächst die Implementierung eines relativ einfachen Systems, in welchem jede Waffe einen Schaden, eine Angriffsgeschwindigkeit und eine Reichweite hat. Dies trifft sowohl für Nahkampf als auch für Fernkampf zu.
        */
        #endregion

        public Weapon (String itemName, Texture2D itemTexture, Entity itemOwner, float weaponDamage, float attackSpeed, float weaponRange) : base (itemName, itemTexture, itemOwner) {
            this.weaponDamage = weaponDamage;
            this.attackSpeed = attackSpeed;
            this.weaponRange = weaponRange;
        }

        public override void use()
        {
            throw new System.NotImplementedException();
        }

        public abstract void attack(Entity owner, Level level);

        public int distance(Vector2 first, Vector2 second) {
            Vector2 combined = new Vector2(first.X-second.X, first.Y-second.Y);
            int distance = (int) Math.Sqrt(combined.X*combined.X + combined.Y*combined.Y);
            if (distance >= 0) {
                return distance;
            } else {
                Console.WriteLine("Rückgabewert der Funktion distance ist negativ!");
                return -1;
            }
        }
    }
}
