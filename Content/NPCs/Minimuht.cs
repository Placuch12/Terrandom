using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terrandom.Content.Items.Materials;
using Terraria.GameContent.Bestiary;
using Terraria.DataStructures;
using System;

namespace Terrandom.Content.NPCs
{
    public class Minimuht : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers() {
				Hide = true
			};
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifiers);

            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 15;
            NPC.height = 15;
            NPC.damage = 2;
            NPC.defense = 0;
            NPC.lifeMax = 25;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 2f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 3;
            AIType = NPCID.GoblinScout;
            AnimationType = NPCID.Zombie;
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
			}
		}
    }
}