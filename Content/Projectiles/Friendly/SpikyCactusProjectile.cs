using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Content.Projectiles.Friendly
{
	public class SpikyCactusProjectile : ModProjectile
	{
		private const int DefaultWidthHeight = 22;
		private const int ExplosionWidthHeight = 250;

		public override void SetDefaults() {
			Projectile.width = DefaultWidthHeight;
			Projectile.height = DefaultWidthHeight;
			Projectile.friendly = true;
			Projectile.penetrate = -1;

			Projectile.timeLeft = 200;

			DrawOffsetX = -2;
			DrawOriginOffsetY = -5;
		}

		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
			if (Main.expertMode) {
				if (target.type >= NPCID.EaterofWorldsHead && target.type <= NPCID.EaterofWorldsTail) {
					modifiers.FinalDamage /= 5;
				}
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
			if (Projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f) {
				Projectile.velocity.X = oldVelocity.X * -0.5f;
			}
			if (Projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f) {
				Projectile.velocity.Y = oldVelocity.Y * -0.5f;
			}
			return false;
		}

		public override void AI() {
			if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3) {
				Projectile.tileCollide = false;
				Projectile.alpha = 255;

				Projectile.Resize(ExplosionWidthHeight, ExplosionWidthHeight);

				Projectile.damage = 50;
				Projectile.knockBack = 1f;
			}
			else {
				if (Main.rand.NextBool()) {
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_Cactus, 0f, 0f, 100, default, 1f);
					dust.scale = 0.1f + Main.rand.Next(5) * 0.1f;
					dust.fadeIn = 1.5f + Main.rand.Next(5) * 0.1f;
					dust.noGravity = true;
					dust.position = Projectile.Center + new Vector2(1, 0).RotatedBy(Projectile.rotation - 2.1f, default) * 10f;

					dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_Cactus, 0f, 0f, 100, default, 1f);
					dust.scale = 1f + Main.rand.Next(5) * 0.1f;
					dust.noGravity = true;
					dust.position = Projectile.Center + new Vector2(1, 0).RotatedBy(Projectile.rotation - 2.1f, default) * 10f;
				}
			}
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] > 10f) {
				Projectile.ai[0] = 10f;
				if (Projectile.velocity.Y == 0f && Projectile.velocity.X != 0f) {
					Projectile.velocity.X = Projectile.velocity.X * 0.96f;

					if (Projectile.velocity.X > -0.01 && Projectile.velocity.X < 0.01) {
						Projectile.velocity.X = 0f;
						Projectile.netUpdate = true;
					}
				}
				Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
			}
			Projectile.rotation += Projectile.velocity.X * 0.1f;
		}

		public override void Kill(int timeLeft) {
			if (Projectile.owner == Main.myPlayer) {
				for (int i = 0; i < 8; i++)
				{
					Projectile.NewProjectile(
					Projectile.GetSource_FromThis(), 
					Projectile.Center,
					Vector2.UnitY.RotatedBy(i * MathHelper.TwoPi / 8) * 5,
					ModContent.ProjectileType<CactusSpike>(),
					15,
					0.5f
					);
				}
			}

			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			for (int i = 0; i < 50; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_Cactus, 0f, 0f, 100, default, 2f);
				dust.velocity *= 1.4f;
			}

			for (int i = 0; i < 80; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_Cactus, 0f, 0f, 100, default, 3f);
				dust.noGravity = true;
				dust.velocity *= 5f;
				dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_Cactus, 0f, 0f, 100, default, 2f);
				dust.velocity *= 3f;
			}

			for (int g = 0; g < 2; g++) {
				var goreSpawnPosition = new Vector2(Projectile.position.X + Projectile.width / 2 - 24f, Projectile.position.Y + Projectile.height / 2 - 24f);
				Gore gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
				gore.scale = 1.5f;
				gore.velocity.X += 1.5f;
				gore.velocity.Y += 1.5f;
				gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
				gore.scale = 1.5f;
				gore.velocity.X -= 1.5f;
				gore.velocity.Y += 1.5f;
				gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
				gore.scale = 1.5f;
				gore.velocity.X += 1.5f;
				gore.velocity.Y -= 1.5f;
				gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
				gore.scale = 1.5f;
				gore.velocity.X -= 1.5f;
				gore.velocity.Y -= 1.5f;
			}
			Projectile.Resize(DefaultWidthHeight, DefaultWidthHeight);

			if (Projectile.owner == Main.myPlayer) {
				int explosionRadius = 7;
				int minTileX = (int)(Projectile.Center.X / 16f - explosionRadius);
				int maxTileX = (int)(Projectile.Center.X / 16f + explosionRadius);
				int minTileY = (int)(Projectile.Center.Y / 16f - explosionRadius);
				int maxTileY = (int)(Projectile.Center.Y / 16f + explosionRadius);

				Utils.ClampWithinWorld(ref minTileX, ref minTileY, ref maxTileX, ref maxTileY);
			}
		}
	}
}