using Terrandom.Content.Projectiles.Friendly;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Content.Items.Weapons.Melee
{
	public class Prickler : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 16;
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
			Item.rare = ItemRarityID.LightRed;

			Item.damage = 40;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.knockBack = 3.5f;
			Item.crit = 4;
			Item.channel = true;
			Item.value = Item.buyPrice(gold: 4);

			Item.shoot = ModContent.ProjectileType<PricklerProjectile>();
			Item.shootSpeed = 16f;		
		}

		public override bool AllowPrefix(int pre) {
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Cactus, 25)
				.AddIngredient(ItemID.SoulofLight, 5)
				.AddIngredient(ItemID.SoulofNight, 5)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}