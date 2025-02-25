using Terrandom.Content.Items.Weapons.Melee;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;

namespace Terrandom.Common.Systems
{
	class VanillaDropsNPC : GlobalNPC{
		
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
			if (npc.type == NPCID.SkeletronHead) {
				LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
				notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SkullSmasher>(), 2));;
				npcLoot.Add(notExpertRule);
			}

			if (npc.type == NPCID.KingSlime) {
				LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
				notExpertRule.OnSuccess(ItemDropRule.Common(ItemID.SlimeStaff, 3));;
				npcLoot.Add(notExpertRule);
			}

			if (npc.type == NPCID.Crimera || npc.type == NPCID.BigCrimera || npc.type == NPCID.BigCrimera || npc.type == NPCID.FaceMonster || npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall) {
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Drumstick>(), 33));
			}

			if (npc.type == NPCID.Golem) {
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Monolith>(), 7));
			}
			// more items go here
		}
	}
}