using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Terrandom.Content.Tiles
{
	public class TransmutationTable : ModTile
	{
		int animationFrame = 0;

		public override void SetStaticDefaults() {
			Main.tileLavaDeath[Type] = true;
			Main.tileFrameImportant[Type] = true;
			TileID.Sets.DisableSmartCursor[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16 };
			TileObjectData.addTile(Type);
			AnimationFrameHeight = 34;
		}

		public override void AnimateTile(ref int frame, ref int frameCounter) {
			frameCounter++;
			if (frameCounter >= 9) {
				animationFrame = frame;
				frameCounter = 0;
				if (++frame >= 4) {
					frame = 1;
				}
			}
		}
	}
}