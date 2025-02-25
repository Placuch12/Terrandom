using Terrandom.Content.Projectiles.Friendly;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Content.Items.Weapons.Melee
{
	public class MechaSkullSmasher : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
		}

		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 24;

			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
			Item.rare = ItemRarityID.Pink;

			Item.damage = 80;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.knockBack = 4.6f;
			Item.crit = 4;
			Item.channel = true;
			Item.value = Item.buyPrice(gold: 14);

			Item.shoot = ModContent.ProjectileType<MechaSkullSmasherProjectile>();
			Item.shootSpeed = 16f;
		}

		public override bool AllowPrefix(int pre) {
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<SkullSmasher>(1)
				.AddIngredient(ItemID.SoulofFright, 10)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}