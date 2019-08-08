using Game.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Location;

namespace Game.Weapon
{
    class TypeABombWeapon : IBombWeapon
    {
        public const long BASICCOST = 75;
        public long getUpdateCost() => BASICCOST * getLevel();
        public static long getCost(uint level) => BASICCOST * level;

        private Point3D location = new Point3D();
        public Point3D Location
        {
            get => this.location;
            set => this.location = value;
        }
        public Point3D getLocation() => this.Location;

        public void release()
        {
            
        }

        private uint level = 1;
        public uint Level
        {
            get => this.level;
            set => this.level = value;
        }

        public uint getLevel() => this.Level;
        public void setLevel(uint level) => this.Level = level;
        public void updateLevel() => setLevel(getLevel() + 1);

        public double getRange() => 3 * getLevel();
        
    }

}
