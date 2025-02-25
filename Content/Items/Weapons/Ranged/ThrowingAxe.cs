using Terrandom.Content.Projectiles.Friendly;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Content.Items.Weapons.Ranged
{
	public class ThrowingAxe : ModItem
	{
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.scale = 0.75f;
			Item.rare = ItemRarityID.Green;

			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.autoReuse = true;

			Item.UseSound = SoundID.Item1;

			Item.DamageType = DamageClass.Ranged;
			Item.damage = 60;
			Item.knockBack = 5f;
			Item.noMelee = true;

			Item.shoot = ModContent.ProjectileType<ThrowingAxeProjectile>();
			Item.shootSpeed = 9f;
			Item.value = 2500;
		}

		public override bool RangedPrefix() {
			return true;
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(2f, -2f);
		}
	}
}