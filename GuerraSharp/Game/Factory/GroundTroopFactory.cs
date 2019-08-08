using Game.Cosmos;
using Game.Troops;
using Game.Weapon;
using System.Collections.Generic;

namespace Game.Factory
{
    class GroundTroopFactory : ITroopFactory
    {
        public Troop make(Gamer gamer, string name, List<IWeapon> weapons)
        {
            Troop troop = new GroundTroop(gamer);
            troop.Name = name;
            foreach (IWeapon weapon in weapons)
                troop.recharge(weapon);

            return troop;
        }
    }
}
