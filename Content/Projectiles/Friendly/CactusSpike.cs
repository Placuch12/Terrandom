using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Content.Projectiles.Friendly
{
    public class CactusSpike : ModProjectile
    {
        private bool hasStartedFalling = false;

        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.penetrate = 1;
        }

        public override void AI()
		{
			Projectile.ai[0]++;

			if (Projectile.ai[0] > 15f)
			{
				Projectile.velocity.Y += 0.2f;
				if (Projectile.velocity.Y > 16f) Projectile.velocity.Y = 16f;
			}

			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.Kill();
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            return false;
        }

        public override void OnKill(int timeLeft)
		{
			int particles = 8;
			for (int i = 0; i < particles; i++)
			{
				int particle = Dust.NewDust(
					new Vector2(Projectile.position.X, Projectile.position.Y),
					Projectile.width,
					Projectile.height,
					DustID.t_Cactus,
					new Vector2(0, 1).RotatedBy(Math.PI * 2 / particles).X * 3,
					new Vector2(0, 1).RotatedBy(Math.PI * 2 / particles).Y * 3
				);
				Main.dust[particle].noGravity = true;
			}
		}
    }
}
