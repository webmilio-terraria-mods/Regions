using Terraria.UI;

namespace Regions.UI
{
    public class RegionsInterface : GameInterfaceLayer
    {
        public RegionsInterface() : base(nameof(RegionsInterface), InterfaceScaleType.Game)
        {
        }


        protected override bool DrawSelf()
        {
            

            return true;
        }
    }
}