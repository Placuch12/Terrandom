using Terrandom.Common.Systems;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Terrandom
{
	partial class Terrandom
	{
		public override object Call(params object[] args) {
			if (args is null) {
				throw new ArgumentNullException(nameof(args), "Arguments cannot be null!");
			}

			if (args.Length == 0) {
				throw new ArgumentException("Arguments cannot be empty!");
			}
			if (args[0] is string content) {
				switch (content) {
					case "downedElderGamumuht":
						return DownedBossSystem.downedElderGamumuht;

						return true;
				}
			}
			return false;
		}
	}
}