using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terrandom.Content.Projectiles.Friendly;

namespace Terrandom.Content.Items.Weapons.Melee
{
	public class EldersEdge : ModItem
	{
		int swingCounter = 0;

		public override void SetDefaults()
		{
			Item.damage = 35;
			Item.DamageType = DamageClass.Melee;
			Item.width = 60;
			Item.height = 60;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 2500;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<EldersEdgeProjectile>();
			Item.autoReuse = true;
			Item.useTurn = true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			swingCounter++;

			if (swingCounter >= 3)
			{
				swingCounter = 0;

				Vector2 projectilePosition = player.Center;
				Vector2 projectileVelocity = Vector2.Normalize(Main.MouseWorld - projectilePosition) * 10f;
				
				Projectile.NewProjectile(
					source,
					position,
					projectileVelocity,
					ModContent.ProjectileType<EldersEdgeProjectile>(),
					16,
					0,
					player.whoAmI
				);

				SoundEngine.PlaySound(SoundID.Item4, player.position);
			}

			return false;
		}
	}
}
