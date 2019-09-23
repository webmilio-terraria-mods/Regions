using System.Collections.Generic;
using Regions.Worlds;
using Terraria;
using Terraria.ModLoader;

namespace Regions.Commands
{
    public class CurrentRegion : RegionsCommand
    {
        public CurrentRegion() : base("current", description: "Displays the information for the current region the player is standing in (first found).")
        {
        }


        public override void Action(CommandCaller caller, string input, string[] args)
        {
            RegionsWorld regionWorld = mod.GetModWorld<RegionsWorld>();
            List<Region> regions = regionWorld.GetRegions(caller.Player);

            foreach (Region region in regions)
            {
                Main.NewTextMultiline($"Region Index: {regionWorld.IndexOfRegion(region)}\n" + 
                                      $"Region UUID: {region.UUID.ToString()}\n" + 
                                      $"Points: ({region.FirstPoint.X}, {region.FirstPoint.Y}), ({region.SecondPoint.X}, {region.SecondPoint.Y})" +
                                      $"Width: {region.Surface.Width}; Height: {region.Surface.Height}");
            }
        }


        public override CommandType Type { get; } = CommandType.Chat;
    }
}