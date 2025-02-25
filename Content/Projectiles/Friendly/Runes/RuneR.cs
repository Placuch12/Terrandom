using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terrandom.Content.Projectiles.Friendly.Runes
{
    public class RuneR : ModProjectile
    {
        private float timeToLive;
        private int timeAlive;

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = false;
            Projectile.penetrate = 2;

            timeToLive = Main.rand.NextFloat(3.5f, 5f) * 60f;
            timeAlive = 0;
        }

        public override void AI()
        {
            Projectile.rotation += 0.1f * (float)Projectile.direction;

            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.HallowSpray, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 150, default, 1.2f);
            }

            timeAlive++;

            if (timeAlive >= timeToLive)
            {
                SoundEngine.PlaySound(SoundID.Item4, Projectile.position);
                for (int i = 0; i < 10; i++)
                    {
                        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.HallowSpray, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 150, default, 1.2f);
                    }
                Projectile.Kill();
            }
        }

        public override Color? GetAlpha(Color newColor)
        {
            return Color.White * Projectile.Opacity;
        }
    }
}
