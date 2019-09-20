using System;
using System.IO;
using On.Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Networking;

namespace Regions
{
	public sealed class RegionsMod : Mod
	{
		public RegionsMod()
        {
            Instance = this;
        }


        public override void Load()
        {
            

            base.Load();
        }

        public override void Unload()
        {
            Instance = null;
        }


        public override void HandlePacket(BinaryReader reader, int whoAmI) =>
            NetworkPacketLoader.Instance.HandlePacket(reader, whoAmI);


        public static RegionsMod Instance { get; private set; }
	}
}