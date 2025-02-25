using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terrandom.Content.Projectiles.Friendly
{
	public class PricklerProjectile : ModProjectile
	{
		private int prickleCooldown = 0;

		public override void SetStaticDefaults() {
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 16f;
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 270f;
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 16.5f;
		}

		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;

			Projectile.aiStyle = ProjAIStyleID.Yoyo;

			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.MeleeNoSpeed;
			Projectile.penetrate = -1;
		}

		public override void AI()
        {
			prickleCooldown++;
            if (prickleCooldown >= 160)
            {
                prickleCooldown = 0;

				Vector2 projectilePosition = Projectile.Center;
				Vector2 projectileVelocity = Vector2.Normalize(Main.MouseWorld - projectilePosition) * 2.5f;
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, projectileVelocity, ModContent.ProjectileType<Prickle>(), 20, Projectile.knockBack, Projectile.owner);
				SoundEngine.PlaySound(SoundID.Item17, Projectile.position);
            }
		}
	}
}