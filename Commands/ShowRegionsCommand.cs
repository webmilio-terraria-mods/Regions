using Regions.Worlds;
using Terraria.ModLoader;

namespace Regions.Commands
{
    public class ShowRegionsCommand : RegionsCommand
    {
        public ShowRegionsCommand() : base("showregion", "[*/index/name]", "Shows all regions owned by the player.")
        {
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            if (args.Length == 0)
                throw new UsageException();

            //if (args[0][0] == '*')
            //    mod.GetModWorld<RegionsWorld>().ShowAllRegions(caller.Player);
        }


        public override CommandType Type { get; } = CommandType.Chat;
    }
}