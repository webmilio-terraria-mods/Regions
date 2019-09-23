using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Regions.Players;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using WebmilioCommons.Players;

namespace Regions.Worlds
{
    public class Region
    {
        private readonly List<Guid> _owners = new List<Guid>();
        private readonly List<Guid> _contributors = new List<Guid>();


        public Region(Point first, Point second) : this(Guid.NewGuid(), first, second)
        {
        }

        public Region(Guid uuid, Point firstPoint, Point secondPoint)
        {
            UUID = uuid;

            FirstPoint = firstPoint;
            SecondPoint = secondPoint;

            int
                lowestX = firstPoint.X < secondPoint.X ? firstPoint.X : secondPoint.X,
                lowestY = firstPoint.Y > secondPoint.Y ? firstPoint.Y : secondPoint.Y, // The further down you go, the higher the Y.

                highestX = secondPoint.X > firstPoint.X ? secondPoint.X : firstPoint.X,
                highestY = secondPoint.Y < firstPoint.Y ? secondPoint.Y : firstPoint.Y;

            Surface = new Rectangle(lowestX, highestY, highestX - lowestX, lowestY - highestY);
        }


        public bool IsOwner(Player player) => IsOwner(WCPlayer.Get(player).UniqueID);
        public bool IsOwner(Guid guid) => _owners.Contains(guid);

        public bool IsContributor(Player player) => IsContributor(WCPlayer.Get(player).UniqueID);
        public bool IsContributor(Guid guid) => _contributors.Contains(guid);

        public bool CanContribute(Player player) => CanContribute(WCPlayer.Get(player).UniqueID);
        public bool CanContribute(Guid guid) => IsOwner(guid) || IsContributor(guid);


        public bool Contains(Vector2 position) => Contains(position.ToPoint());
        public bool Contains(Point point) => Surface.Contains(point);
        public bool Contains(int x, int y) => Surface.Contains(x, y);



        public static Region Parse(TagCompound tag) =>
            new Region(Guid.Parse(tag.GetString(nameof(UUID))),
                tag.Get<Point>(nameof(FirstPoint)), tag.Get<Point>(nameof(SecondPoint)));

        public TagCompound Save() =>
            new TagCompound()
            {
                { nameof(UUID), UUID },

                { nameof(FirstPoint), FirstPoint },
                { nameof(SecondPoint), SecondPoint }
            };


        public Guid UUID { get; }

        public Point FirstPoint { get; }
        public Point SecondPoint { get; }

        public Rectangle Surface { get; }
    }
}