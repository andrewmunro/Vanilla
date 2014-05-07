using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using Microsoft.Xna.Framework;

using Vanilla.Core.IO;
using Vanilla.World.Components.Entity.packets.Outgoing;
using Vanilla.World.Database;
using Vanilla.World.Network;

namespace Vanilla.World.Game.Entity.Object.Creature
{
    public class AiBrain
    {
        private readonly CreatureEntity entity;

        private readonly List<Waypoint> waypoints = new List<Waypoint>();

        private Waypoint currentWaypoint;

        private IRepository<creature_movement_template> CreatureMovementTemplates { get { return entity.VanillaWorld.WorldDatabase.GetRepository<creature_movement_template>(); } }
        private IRepository<creature_movement> CreatureMovements { get { return entity.VanillaWorld.WorldDatabase.GetRepository<creature_movement>(); } }

        public AiBrain(CreatureEntity entity)
        {
            this.entity = entity;

            var moveTemplates = CreatureMovementTemplates.Where(ways => ways.entry == entity.Template.entry).ToList();
            if (moveTemplates.Count != 0)
            {
                moveTemplates.ForEach(way => waypoints.Add(new Waypoint() { PointIndex = way.point, Point = new Vector3(way.position_x, way.position_y, way.position_z) }));
            }
            else
            {
                var creatureMovements = CreatureMovements.Where(ways => ways.id == entity.Creature.id).ToList();
                creatureMovements.ForEach(way => waypoints.Add(new Waypoint() { PointIndex = way.point, Point = new Vector3(way.position_x, way.position_y, way.position_z) }));
            }

            SetNextWaypoint();
        }

        private List<Vector3> GeneratePath()
        {
            //order waypoints starting with currentwaypoint e.g 456..123
            var sortedWaypoints =
                waypoints.SkipWhile(w => w.PointIndex != currentWaypoint.PointIndex)
                    .Concat(waypoints.TakeWhile(w => w.PointIndex != currentWaypoint.PointIndex))
                    .ToList();

            return sortedWaypoints.Select(waypoint => new Vector3(waypoint.Point.X, waypoint.Point.Y, waypoint.Point.Z)).ToList();
        }

        private void SetNextWaypoint()
        {
            if(waypoints.Count == 0) return;

            var currentPoint = entity.Creature.currentwaypoint;
            var maxPoint = waypoints.Max(ways => ways.PointIndex);
            var nextPoint = currentPoint == maxPoint || currentPoint == 0 ? 1 : currentPoint;

            entity.Creature.currentwaypoint = nextPoint;

            this.currentWaypoint = waypoints.SingleOrDefault(way => way.PointIndex == nextPoint);
        }

        public void StartDatabasePathMovement(WorldSession session)
        {
            if (waypoints.Count == 0) return;
            this.Move(session, GeneratePath());
        }

        public void Move(WorldSession session, List<Vector3> path)
        {
            session.SendPacket(new PSMonsterMove(entity, path));
        }
    }
}
