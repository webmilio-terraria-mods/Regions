using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using WebmilioCommons.Players;

namespace Regions.Worlds
{
    public class RegionsWorld : ModWorld
    {
        private const string REGIONS_TAG_KEY = "Regions";
        private List<Region> _regions;


        public void AddRegion(Region region) => _regions.Add(region);


        public int IndexOfRegion(Region region) => _regions.IndexOf(region);
        public int FindRegionIndex(Predicate<Region> match) => _regions.FindIndex(match);

        public Region GetFirstRegion(Player player) => GetFirstRegion(player.position);
        public Region GetFirstRegion(Vector2 position)
        {
            for (int i = 0; i < _regions.Count; i++)
                if (_regions[i].Contains((int) position.X, (int) position.Y))
                    return _regions[i];

            return null;
        }


        public List<Region> GetRegions() => new List<Region>(_regions);

        public List<Region> GetRegionsForPlayer(Player player) => GetRegionsForPlayer(WCPlayer.Get(player));
        public List<Region> GetRegionsForPlayer(ModPlayer modPlayer) => GetRegionsForPlayer(WCPlayer.Get(modPlayer));

        public List<Region> GetRegionsForPlayer(WCPlayer wcPlayer)
        {
            List<Region> regions = new List<Region>(_regions.Capacity);

            for (int i = 0; i < _regions.Count; i++)
                if (_regions[i].CanContribute(wcPlayer.UniqueID))
                    regions.Add(_regions[i]);

            return regions;
        }

        public List<Region> GetRegionsAtPosition(Player player) => GetRegionsAtPosition(player.position);
        public List<Region> GetRegionsAtPosition(Vector2 position)
        {
            List<Region> regions = new List<Region>(_regions.Capacity);

            for (int i = 0; i < _regions.Count; i++)
                if (_regions[i].Contains(position))
                    regions.Add(_regions[i]);

            return regions;
        }


        public List<Region> GetRegionsAtPositionForPlayer(Player player)
        {
            List<Region> regions = new List<Region>();

            for (int i = 0; i < _regions.Count; i++)
                if (_regions[i].Contains((int)(player.position.X / 16), (int)(player.position.Y / 16)) && _regions[i].CanContribute(player))
                    regions.Add(_regions[i]);

            return regions;
        }


        public override void Initialize()
        {
            _regions = new List<Region>();
        }

        public override void Load(TagCompound tag)
        {
            _regions = new List<Region>();

            IList<TagCompound> tags = tag.GetList<TagCompound>(REGIONS_TAG_KEY);

            for (int i = 0; i < tags.Count; i++)
                _regions.Add(Region.Parse(tags[i]));
        }

        public override TagCompound Save()
        {
            List<TagCompound> regions = new List<TagCompound>();

            for (int i = 0; i < _regions.Count; i++)
                regions.Add(_regions[i].Save());


            TagCompound tag = new TagCompound()
            {
                { REGIONS_TAG_KEY, regions }
            };

            return tag;
        }
    }
}