using Terrandom.Content.Projectiles.Friendly;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Content.Items.Weapons.Melee
{
	public class EnchantedYoyo : ModItem
	{
		public override void SetStaticDefaults() {
			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[Item.type] = true; // Used to increase the gamepad range when using Strings.
			ItemID.Sets.GamepadExtraRange[Item.type] = 6; // Increases the gamepad range. Some vanilla values: 4 (Wood), 10 (Valor), 13 (Yelets), 18 (The Eye of Cthulhu), 21 (Terrarian).
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true; // Unused, but weapons that require aiming on the screen are in this set.
		}

		public override void SetDefaults() {
			Item.width = 24; // The width of the item's hitbox.
			Item.height = 24; // The height of the item's hitbox.

			Item.useStyle = ItemUseStyleID.Shoot; // The way the item is used (e.g. swinging, throwing, etc.)
			Item.useTime = 25; // All vanilla yoyos have a useTime of 25.
			Item.useAnimation = 25; // All vanilla yoyos have a useAnimation of 25.
			Item.noMelee = true; // This makes it so the item doesn't do damage to enemies (the projectile does that).
			Item.noUseGraphic = true; // Makes the item invisible while using it (the projectile is the visible part).
			Item.UseSound = SoundID.Item1; // The sound that will play when the item is used.

			Item.damage = 16; // The amount of damage the item does to an enemy or player.
			Item.DamageType = DamageClass.MeleeNoSpeed; // The type of damage the weapon does. MeleeNoSpeed means the item will not scale with attack speed.
			Item.knockBack = 3.5f; // The amount of knockback the item inflicts.
			Item.crit = 4; // The percent chance for the weapon to deal a critical strike. Defaults to 4.
			Item.channel = true; // Set to true for items that require the attack button to be held out (e.g. yoyos and magic missile weapons)
			Item.value = Item.buyPrice(silver: 95); // The amount of money that the item is can be bought for.

			Item.shoot = ModContent.ProjectileType<EnchantedYoyoProjectile>(); // Which projectile this item will shoot. We set this to our corresponding projectile.
			Item.shootSpeed = 16f; // The velocity of the shot projectile.			
		}

		public override bool AllowPrefix(int pre) {
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SilverBar, 8)
				.AddIngredient(ItemID.WoodYoyo, 1)
				.AddIngredient(ItemID.FallenStar, 1)
				.AddTile(TileID.Anvils)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.TungstenBar, 8)
				.AddIngredient(ItemID.WoodYoyo, 1)
				.AddIngredient(ItemID.FallenStar, 1)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}