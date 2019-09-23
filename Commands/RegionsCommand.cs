using Terraria.ModLoader;

namespace Regions.Commands
{
    public abstract class RegionsCommand : ModCommand
    {
        protected RegionsCommand(string command, string usage = "", string description = "")
        {
            Command = '/' + command;
            Usage = '/' + Command + ' ' + usage;
            Description = description;
        }


        public override string Command { get; }
        public override string Usage { get; }
        public override string Description { get; }
    }
}