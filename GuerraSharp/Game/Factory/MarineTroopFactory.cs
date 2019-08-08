using Game.Cosmos;
using Game.Troops;
using Game.Weapon;
using System.Collections.Generic;

namespace Game.Factory
{
    class MarineTroopFactory : ITroopFactory
    {
        public Troop make(Gamer gamer, string name, List<IWeapon> weapons)
        {
            Troop troop = new MarineTroop(gamer);
            troop.Name = name;
            foreach (IWeapon weapon in weapons)
                troop.recharge(weapon);

            return troop;
        }
    }
}
