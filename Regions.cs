using System;
using System.IO;
using Terraria.ModLoader;
using WebmilioCommons.Networking;

namespace Regions
{
	public sealed class Regions : Mod
	{
		public Regions()
        {
            Instance = this;
        }


        public override void Unload()
        {
            Instance = null;
        }


        public override void HandlePacket(BinaryReader reader, int whoAmI) =>
            NetworkPacketLoader.Instance.HandlePacket(reader, whoAmI);


        public static Regions Instance { get; private set; }
	}
}