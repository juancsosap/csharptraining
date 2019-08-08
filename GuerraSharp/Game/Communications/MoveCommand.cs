using Game.Location;
using Game.Troops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Communications
{
    class MoveCommand : ICommand
    {
        private Point3D delta;
        private Troop troop;

        public MoveCommand(Troop troop, Point3D delta)
        {
            this.delta = delta;
            this.troop = troop;
        }

        public void execute()
        {
            troop.Location = troop.Location + delta;
        }
    }
}
