using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Common.Systems
{
	public class ChestLootSystem : ModSystem
	{
		public override void PostWorldGen()
		{
			//Water Chest
			for (int chestIndex = 0; chestIndex < 1000; chestIndex ++)
			{
				Chest chest = Main.chest[chestIndex];
				int[] itemsToPlaceInChests = { Mod.Find<ModItem>("BoldAndBrash").Type };

				if (chest != null && Main.rand.NextBool(3) && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 17 * 36)
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == 0)
						{
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInChests[0]);
							break;							
						}
					}
				}
			}
		}
	}
}