using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Terrandom.Content.Projectiles.Friendly
{
	public class MechaSkullSmasherProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 344f;
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
	}
}