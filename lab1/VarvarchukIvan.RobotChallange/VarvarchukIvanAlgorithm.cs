using Robot.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarvarchukIvan.RobotChallange
{
    class VarvarchukIvanAlgorithm : IRobotAlgorithm
    {
        public string Author => "Ivan Varvarchuk";

        public RobotCommand DoStep(IList<Robot.Common.Robot> robots, int robotToMoveIndex, Map map)
        {
            Robot.Common.Robot movingRobot = robots[robotToMoveIndex];
            if ((movingRobot.Energy > 500) && (robots.Count < map.Stations.Count))
            {
                return new CreateNewRobotCommand();
            }

            Position stationPosition = new DistanceHelper().FindNearestFreeStation(robots[robotToMoveIndex], map, robots);
            
             if (stationPosition == null)
                return null;
            if (stationPosition == movingRobot.Position)
                return new CollectEnergyCommand();
            else
            {

                return new MoveCommand() { NewPosition = stationPosition };
            }
        }

    }
}
