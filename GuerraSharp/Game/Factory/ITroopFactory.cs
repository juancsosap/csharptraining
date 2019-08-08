using Game.Cosmos;
using Game.Troops;
using System.Collections.Generic;

using Game.Weapon;

namespace Game.Factory
{
    interface ITroopFactory
    {
        Troop make(Gamer gamer, string name, List<IWeapon> weapon);
    }
}
