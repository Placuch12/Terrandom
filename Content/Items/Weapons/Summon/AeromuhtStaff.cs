using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terrandom.Content.Projectiles.Minions;
using Terrandom.Content.Buffs;
﻿using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace Terrandom.Content.Items.Weapons.Summon
{
    public class AeromuhtStaff : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.mana = 10;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
            Item.knockBack = 3f;
            Item.value = Item.sellPrice(0, 1, 50);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item44;
            Item.buffType = ModContent.BuffType<AeromuhtBuff>();
            Item.shoot = ModContent.ProjectileType<AeromuhtMinion>(); // Summons the minion
            Item.DamageType = DamageClass.Summon;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.AddBuff(Item.buffType, 2);
            return true;
		}
    }
}
