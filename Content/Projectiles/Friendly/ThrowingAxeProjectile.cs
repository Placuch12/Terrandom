using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terrandom.Content.Projectiles.Friendly
{
    public class ThrowingAxeProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
        }

        public override void AI()
		{
			Projectile.ai[0]++;

			if (Projectile.ai[0] > 60f)
			{
				Projectile.velocity.Y += 0.4f;
				if (Projectile.velocity.Y > 24f) Projectile.velocity.Y = 24f;
			}

			Projectile.rotation += (float)Projectile.direction * 0.25f;
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.Kill();
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            return false;
        }
    }
}
