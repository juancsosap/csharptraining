using Game.Communications;
using Game.Factory;
using Game.Troops;
using Game.Weapon;
using System;
using System.Collections.Generic;

namespace Game.Cosmos
{
    class Gamer : ISubject, IObserver, ILevelable
    {
        private World world;

        private String name;
        private ulong money;
        private List<IWeapon> stock;

        List<IObserver> troops = new List<IObserver>();

        public Gamer(World world, String name)
        {
            this.world = world;
            this.name = name;
            this.money = 1000;
        }

        private uint level;
        public uint Level
        {
            get => this.level;
            set => this.level = value;
        }

        public void addTroop(TroopType type, String name, List<IWeapon> weapons)
        {
            ITroopFactory factory = null;

            if (type.Equals(TroopType.AIR))
                factory = new AirTroopFactory();
            if (type.Equals(TroopType.MARINE))
                factory = new MarineTroopFactory();
            if (type.Equals(TroopType.GROUND))
                factory = new GroundTroopFactory();

            Troop troop = factory.make(this, name, weapons);

            register(troop);
        }

        public void update(IObserver ob, IInformation info)
        {
            
        }

        public void notifyAll(ICommand command)
        {
            foreach(IObserver ob in troops)
                ob.update(command);
        }

        public void notifyOne(IObserver ob, ICommand command)
        {
            ob.update(command);
        }

        public void register(IObserver ob)
        {
            if (!troops.Contains(ob))
            {
                world.register(ob);
                troops.Add(ob);
            }
                
        }

        public void unregister(IObserver ob)
        {
            if (troops.Contains(ob))
            {
                world.unregister(ob);
                troops.Remove(ob);
            }
                
        }
        
        public void update(ICommand command)
        {
            throw new NotImplementedException();
        }

        public uint getLevel() => this.Level;
        public void setLevel(uint level) => this.Level = level;
        public void updateLevel() => setLevel(getLevel() + 1);
        
    }
}
