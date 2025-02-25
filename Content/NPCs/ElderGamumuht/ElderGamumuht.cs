using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terrandom.Content.Items.Placeable.Furniture;
using Terrandom.Content.Items.BossBags;
using Terrandom.Content.Items.Armor.Vanity;
using Terrandom.Content.Items.Accessories;
using Terrandom.Content.Items.Weapons.Ranged;
using Terrandom.Content.Items.Weapons.Magic;
using Terrandom.Content.Items.Weapons.Melee;
using Terrandom.Content.Items.Weapons.Summon;
// using Terrandom.Content.Items.Misc;
using Terrandom.Content.NPCs;
using Terrandom.Common.Systems;
using Terrandom;
using System;
using System.Collections.Generic;
using Terraria.GameContent.Bestiary;
using Terraria.Graphics.CameraModifiers;

namespace Terrandom.Content.NPCs.ElderGamumuht
{
    [AutoloadBossHead]
    public class ElderGamumuht : ModNPC
    {
        float axeThrowTimer
        {
            get => NPC.ai[0];
            set => NPC.ai[0] = value; 
        } // btw axeThrowTimer isnt just for throwing axes its for literally anything but i couldnt be bothered to change it

        public override void SetStaticDefaults()
        {
            NPCID.Sets.MPAllowedEnemies[Type] = true;
			NPCID.Sets.BossBestiaryPriority.Add(Type);
            
            Main.npcFrameCount[NPC.type] = 4;

			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Shimmer] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 60;
            NPC.height = 60;
            NPC.damage = 30;
            NPC.defense = 20;
            NPC.lifeMax = 4500;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 50000f;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = 3;
            AIType = NPCID.GoblinScout;
            AnimationType = NPCID.Zombie;

            NPC.boss = true;

            if (!Main.dedServ) {
				Music = MusicID.Boss4;
			}
        }

        public override void HitEffect(NPC.HitInfo hit) {
			if (Main.netMode == NetmodeID.Server) {
				return;
			}

			if (NPC.life <= 0) {
				for (int i = 0; i < 1; i++) {
					Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>($"{Name}_Gore_Hair").Type, NPC.scale);
					Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>($"{Name}_Gore_Head").Type, NPC.scale);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>($"{Name}_Gore_Leg").Type, NPC.scale);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>($"{Name}_Gore_Leg").Type, NPC.scale);
				}

				SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
			}
		}

        public override void AI()
        {
            axeThrowTimer++;

            Player target = Main.player[NPC.target];

            if (target.dead) {
                NPC.velocity.Y -= 0.04f;
                NPC.EncourageDespawn(10);
                return;
            }

            if (target != null && !target.dead && NPC.HasValidTarget && NPC.Distance(target.Center) < 500f)
            {
                if (axeThrowTimer % 60 == 0)
                {
                    Vector2 direction = NPC.DirectionTo(target.Center);
                    direction.Normalize();
                    if(Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        int projectile = Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, direction * 10, ModContent.ProjectileType<Projectiles.Hostile.ElderGamumuhtAxe>(), 15, 1f, Main.myPlayer);
                    }
                    SoundEngine.PlaySound(SoundID.Item1, NPC.position);
                }
            }

            if (NPC.life < NPC.lifeMax * 0.7f) {
                if (axeThrowTimer % 150 == 0)
                {
                    int[] npcTypes = {
                        ModContent.NPCType<Jamumuht>(), 
                        ModContent.NPCType<Gamumuht>(), 
                        ModContent.NPCType<Finmoot>()
                    };

                    int npcToSpawn = npcTypes[Main.rand.Next(npcTypes.Length)];
                    NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.position.X,(int)NPC.position.Y, npcToSpawn);
                    SoundEngine.PlaySound(SoundID.NPCHit9, NPC.position);
                    SoundEngine.PlaySound(SoundID.NPCDeath13, NPC.position);
                }
            }

            if (NPC.life < NPC.lifeMax * 0.5f) {
                if (axeThrowTimer % 60 == 30)
                {
                    Vector2 direction = NPC.DirectionTo(target.Center);
                    direction.Normalize();
                    if(Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        int projectile = Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, direction * 10, ModContent.ProjectileType<Projectiles.Hostile.ElderGamumuhtAxe>(), 15, 1f, Main.myPlayer);
                    }
                    SoundEngine.PlaySound(SoundID.Item1, NPC.position);
                }
            }

            if (Main.expertMode) {
                if (axeThrowTimer % 60 == 0) {
                    NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.position.X,(int)NPC.position.Y, ModContent.NPCType<Minimuht>());
                }
            }

            if (axeThrowTimer >= 300) {
                axeThrowTimer = 0;
            }
        }

        public override bool CheckActive() {
                return false;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange([
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				new FlavorTextBestiaryInfoElement("This one Gamumuht has figured out that the key to longevity is simply not dying.")
			]);
		}

        public override void OnKill() {
            NPC.SetEventFlagCleared(ref DownedBossSystem.downedElderGamumuht, -1);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot) {

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Placeable.Furniture.ElderGamumuhtTrophy>(), 10));

            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<ElderGamumuhtMask>(), 7));
            notExpertRule.OnSuccess(ItemDropRule.OneFromOptions(1, ModContent.ItemType<ThrowingAxe>(), ModContent.ItemType<RuneBlaster>(), ModContent.ItemType<EldersEdge>(), ModContent.ItemType<AeromuhtStaff>()));
            notExpertRule.OnSuccess(ItemDropRule.OneFromOptions(1, ModContent.ItemType<GuardianHeart>(), ModContent.ItemType<ArchaeologistsCharm>()));
            // notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<TranslatedRunes>(), 1));

            npcLoot.Add(notExpertRule);

            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<ElderGamumuhtBag>()));

            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Placeable.Furniture.ElderGamumuhtRelic>()));
        }
    }
}