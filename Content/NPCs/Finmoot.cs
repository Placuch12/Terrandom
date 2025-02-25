using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;
using Terrandom.Content.Items.Materials;
using Terrandom.Content.Items.Placeable.Banners;
using System;

namespace Terrandom.Content.NPCs
{
    public class Finmoot : ModNPC
    {
        float axeThrowTimer
        {
            get => NPC.ai[0]; 
            set => NPC.ai[0] = value; 
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;
        }

        public override void SetDefaults()
        {
            NPC.width = 30;
            NPC.height = 30;
            NPC.damage = 10;
            NPC.defense = 5;
            NPC.lifeMax = 60;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 60f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 3;
            AIType = NPCID.GoblinScout;
            AnimationType = NPCID.Zombie;
            axeThrowTimer = 0;

            Banner = NPC.type;
            BannerItem = ModContent.ItemType<FinmootBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneSnow)
            {
                return 0.15f;
            }
            return 0f;
        }

        public override void HitEffect(NPC.HitInfo hit) {

            if (Main.netMode == NetmodeID.Server) {
				return;
			}

			if (NPC.life <= 0) {
				for (int i = 0; i < 24; i++) {
					Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.Blood, 2 * hit.HitDirection, -2f);
					if (Main.rand.NextBool(2)) {
						dust.noGravity = true;
						dust.scale = 2.1f * NPC.scale;
					}
					else {
						dust.scale = 1.6f * NPC.scale;
					}
				}
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>($"{Name}_Gore_Hair").Type, NPC.scale);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>($"{Name}_Gore_Head").Type, NPC.scale);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>($"{Name}_Gore_Leg").Type, NPC.scale);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>($"{Name}_Gore_Leg").Type, NPC.scale);
			}
		}

        public override void AI()
        {
            axeThrowTimer++;

            Player target = Main.player[NPC.target];
            if (target != null && !target.dead && NPC.HasValidTarget && NPC.Distance(target.Center) < 500f)
            {
                if (axeThrowTimer >= 90)
                {

                    axeThrowTimer = 0;

                    Vector2 direction = NPC.DirectionTo(target.Center);
                    direction.Normalize();
                    if(Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        int projectile = Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, direction * 10, ModContent.ProjectileType<Projectiles.Hostile.FinmootSnowball>(), 10, 1f, Main.myPlayer);
                    }
                    SoundEngine.PlaySound(SoundID.Item1, NPC.position);
                }
            }
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange([
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,

				new FlavorTextBestiaryInfoElement("A lot of Gamumuhts have emigrated to colder climates and have adapted to them.")
			]);
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrozenDroplet>(), 1, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ItemID.PlatinumWatch, 50));
            npcLoot.Add(ItemDropRule.Common(ItemID.SnowballCannon, 20));
            npcLoot.Add(ItemDropRule.Common(ItemID.Snowball, 1, 15, 20));
		}
    }
}
