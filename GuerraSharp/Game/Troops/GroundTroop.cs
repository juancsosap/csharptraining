using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Weapon;
using Game.Communications;
using Game.Cosmos;

namespace Game.Troops
{
    class GroundTroop : Troop
    {
        List<IMisileWeapon> misile = new List<IMisileWeapon>();

        public GroundTroop(Gamer gamer) : base(gamer)
        {
            this.type = TroopType.GROUND;
        }

        public override void update(ICommand command)
        {
            
        }

        public override void recharge(IWeapon weapon)
        {
            if (weapon is TypeAMisileWeapon)
                if (misile.Count <= 5)
                    misile.Add((IMisileWeapon)weapon);
        }

        public static long BASICCOST = 200;
        public override long getUpdateCost() => BASICCOST * getLevel();
        public static long getCost(uint level) => BASICCOST * level;

        public override double getRange() => 2 * getLevel();

    }
}
