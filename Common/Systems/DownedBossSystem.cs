using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Terrandom.Common.Systems
{
	public class DownedBossSystem : ModSystem
	{
		public static bool downedElderGamumuht = false;
		// public static bool downedOtherBoss = false;

		public override void ClearWorld() {
			downedElderGamumuht = false;
			// downedOtherBoss = false;
		}

		public override void SaveWorldData(TagCompound tag) {
			if (downedElderGamumuht) {
				tag["downedElderGamumuht"] = true;
			}

			// if (downedOtherBoss) {
			//	tag["downedOtherBoss"] = true;
			// }
		}

		public override void LoadWorldData(TagCompound tag) {
			downedElderGamumuht = tag.ContainsKey("downedElderGamumuht");
			// downedOtherBoss = tag.ContainsKey("downedOtherBoss");
		}

		public override void NetSend(BinaryWriter writer) {
			var flags = new BitsByte();
			flags[0] = downedElderGamumuht;
			// flags[1] = downedOtherBoss;
			writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader) {
			BitsByte flags = reader.ReadByte();
			downedElderGamumuht = flags[0];
			// downedOtherBoss = flags[1];
		}
	}
}