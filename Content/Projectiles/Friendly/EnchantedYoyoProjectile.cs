using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terrandom.Content.Projectiles.Friendly
{
	public class EnchantedYoyoProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 6f;
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 200f;
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 15.5f;
		}

		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;

			Projectile.aiStyle = ProjAIStyleID.Yoyo;

			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.MeleeNoSpeed;
			Projectile.penetrate = -1;
		}

		public override void AI() {
			Lighting.AddLight(Projectile.Center, 0.1f, 0.1f, 0.5f);
		}

		public override Color? GetAlpha(Color newColor)
		{
			return Color.White;
		}
	}
}