using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terrandom.Content.Projectiles.Friendly;
using Terrandom.Content.Buffs;

namespace Terrandom.Content.Projectiles.Minions
{
    public class AeromuhtMinion : ModProjectile
    {
        private int attackCooldown = 60;

        public override void SetStaticDefaults()
        {
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.minion = true;
            Projectile.minionSlots = 1f;
            Projectile.penetrate = -1;
            Projectile.aiStyle = -1;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            
            // if player dead minion dead
            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<AeromuhtBuff>());
            }

            // if player has buff minion alive
            if (player.HasBuff(ModContent.BuffType<AeromuhtBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            // follow player
            Vector2 moveTo = player.Center - Projectile.Center;
            float distance = moveTo.Length();

            // when too far go towards player
            if (distance > 200f)
            {
                moveTo.Normalize();
                Projectile.velocity = moveTo * 8f;
            }
            else
            {
                // slow down when near player
                Projectile.velocity *= 0.98f;
            }

            // flip sprite based on player direction probably should change it so its looking where its attacking instead
            if (player.velocity.X > 0f)
            {
                Projectile.spriteDirection = -1; // face right 
            }
            else if (player.velocity.X < 0f)
            {
                Projectile.spriteDirection = 1; // face left 
            }

            // hover above player (make smoother later)
            Projectile.position.Y = player.position.Y - 50f;

            // throw axe
            attackCooldown--;
            if (attackCooldown <= 0)
            {
                attackCooldown = 60;
                NPC target = FindTarget();

                if (target != null)
                {
                    Vector2 direction = target.Center - Projectile.Center;
                    direction.Normalize();
                    direction *= 10f; // projectile speed

                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, direction, ModContent.ProjectileType<AeroAxe>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                }
            }
        }

        // find closest enemy
        private NPC FindTarget()
        {
            NPC closestNPC = null;
            float closestDistance = 400f; // range

            foreach (NPC npc in Main.npc)
            {
                if (npc.CanBeChasedBy(this))
                {
                    float distanceToNPC = Vector2.Distance(npc.Center, Projectile.Center);
                    if (distanceToNPC < closestDistance)
                    {
                        closestDistance = distanceToNPC;
                        closestNPC = npc;
                    }
                }
            }
            return closestNPC;
        }
    }
}
