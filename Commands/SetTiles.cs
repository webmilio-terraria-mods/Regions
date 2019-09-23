using Terraria.ModLoader;

namespace Regions.Commands
{
    public class SetTiles : RegionsCommand
    {
        public SetTiles() : base("set", "<tile id>", "Sets all tiles within a region to a certain tile.")
        {
        }


        public override void Action(CommandCaller caller, string input, string[] args)
        {
            
        }


        public override CommandType Type => CommandType.Chat;
    }
}