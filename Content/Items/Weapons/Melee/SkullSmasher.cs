using Terrandom.Content.Projectiles.Friendly;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Content.Items.Weapons.Melee
{
	public class SkullSmasher : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 11;
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
			Item.rare = ItemRarityID.Green;

			Item.damage = 25;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.knockBack = 3.7f;
			Item.crit = 5;
			Item.channel = true;
			Item.value = Item.buyPrice(gold: 2);

			Item.shoot = ModContent.ProjectileType<SkullSmasherProjectile>();
			Item.shootSpeed = 16f;
		}

		public override bool AllowPrefix(int pre) {
			return true;
		}
	}
}