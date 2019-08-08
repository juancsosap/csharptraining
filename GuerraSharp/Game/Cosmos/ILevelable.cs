using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Cosmos
{
    interface ILevelable
    {
        uint getLevel();
        void setLevel(uint level);

        void updateLevel();
    }
}
