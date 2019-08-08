using Game.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Cosmos
{
    interface IRangeable
    {
        double getRange();
        Point3D getLocation();
    }
}
