using Game.Communications;
using Game.Cosmos;
using Game.Location;
using Game.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Troops
{
    abstract class Troop : IObserver, ICostable, IRangeable
    {
        private String name;
        public String Name
        {
            get => this.name;
            set => this.name = value;
        }

        private Point3D location = new Point3D();
        public Point3D Location
        {
            get => this.location;
            set => this.location = value;
        }

        private uint level;
        public uint Level
        {
            get => this.level;
            set => this.level = value;
        }

        protected TroopType type;
        protected Gamer gamer;

        public Troop(Gamer gamer)
        {
            this.gamer = gamer;
        }

        public abstract void recharge(IWeapon weapon);
        public abstract void update(ICommand command);

        public uint getLevel() => this.Level;
        public void setLevel(uint level) => this.Level = level;
        public void updateLevel() => setLevel(getLevel() + 1);

        public abstract long getUpdateCost();

        public abstract double getRange();
        public Point3D getLocation() => this.Location;
        
    }

}
