using Game.Location;
using Game.Troops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Communications
{
    class ReturnCommand : ICommand
    {
        private Troop troop;

        public ReturnCommand(Troop troop)
        {
            this.troop = troop;
        }

        public void execute()
        {
            troop.Location = new Point3D();
        }
    }
}
