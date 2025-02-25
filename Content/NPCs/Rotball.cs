using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terrandom.Content.Items.Placeable.Banners;

namespace Terrandom.Content.NPCs
{
	public class Rotball : ModNPC
	{
		public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 2;
        }

		public override void SetDefaults()
		{
			NPC.width = 32;
			NPC.height = 32;
			NPC.damage = 22;
			NPC.defense = 8;
			NPC.lifeMax = 40;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 100;
			NPC.knockBackResist = 0.75f;
			NPC.aiStyle = NPCAIStyleID.Slime;

			Banner = NPC.type;
            BannerItem = ModContent.ItemType<RotballBanner>();
		}

		public override void AI()
        {
            if (Main.rand.NextBool(13))
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.CorruptGibs, NPC.velocity.X * 0.25f, NPC.velocity.Y * 0.25f, 150, default, 1.2f);
            }
        }

		public override void FindFrame(int frameHeight) {
			int startFrame = 0;
			int finalFrame = 0;

			if (NPC.velocity.Y != 0) {
				startFrame = 1;
				finalFrame = Main.npcFrameCount[NPC.type] - 1;

				if (NPC.frame.Y < startFrame * frameHeight) {
					
					NPC.frame.Y = startFrame * frameHeight;
				}
			}

			int frameSpeed = 1;
			NPC.frameCounter += 0.5f;
			if (NPC.frameCounter > frameSpeed) {
				NPC.frameCounter = 0;
				NPC.frame.Y += frameHeight;

				if (NPC.frame.Y > finalFrame * frameHeight) {
					NPC.frame.Y = startFrame * frameHeight;
				}
			}
		}

		public override void HitEffect(NPC.HitInfo hit) {

            if (Main.netMode == NetmodeID.Server) {
				return;
			}

			if (NPC.life <= 0) {
				for (int i = 0; i < 24; i++) {
					Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.CorruptGibs, 2 * hit.HitDirection, -2f);
					if (Main.rand.NextBool(2)) {
						dust.noGravity = true;
						dust.scale = 2.1f * NPC.scale;
					}
					else {
						dust.scale = 1.6f * NPC.scale;
					}
				}
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>($"{Name}_Gore_Back").Type, NPC.scale);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>($"{Name}_Gore_Front").Type, NPC.scale);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.Corruption.Chance * 0.5f;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ItemID.RottenChunk, 3));
			npcLoot.Add(ItemDropRule.Common(ItemID.TentacleSpike, 525));
			npcLoot.Add(ItemDropRule.Common(ItemID.PigPetItem, 1500));
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange([
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,

				new FlavorTextBestiaryInfoElement("A corrupted ball of... something.")
			]);
		}
	}
}