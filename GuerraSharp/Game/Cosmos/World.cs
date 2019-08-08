using Game.Communications;
using Game.Troops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Cosmos
{
    class World : ISubject
    {
        private List<Troop> troops = new List<Troop>();

        private String name;

        public World(String name)
        {
            this.name = name;
        }

        public void notifyAll(ICommand command)
        {
            throw new NotImplementedException();
        }

        public void notifyOne(IObserver ob, ICommand command)
        {
            throw new NotImplementedException();
        }

        public void register(IObserver ob)
        {
            Troop troop = (Troop) ob;
            if (!troops.Contains(troop))
                troops.Add(troop);
        }

        public void unregister(IObserver ob)
        {
            Troop troop = (Troop)ob;
            if (troops.Contains(troop))
                troops.Remove(troop);
        }

        public void update(IObserver ob, IInformation info)
        {
            throw new NotImplementedException();
        }
    }
}
