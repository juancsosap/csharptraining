using Game.Communications;
using Game.Cosmos;
using Game.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Troops
{
    class MarineTroop : Troop
    {
        List<IMisileWeapon> misile = new List<IMisileWeapon>(); 

        public MarineTroop(Gamer gamer) : base(gamer)
        {
            this.type = TroopType.MARINE;
        }

        public override void update(ICommand command)
        {
            
        }

        public override void recharge(IWeapon weapon)
        {
            if (weapon is IMisileWeapon)
                if (misile.Count <= 20)
                    misile.Add((IMisileWeapon)weapon);
        }

        public static long BASICCOST = 250;
        public override long getUpdateCost() => BASICCOST * getLevel();
        public static long getCost(uint level) => BASICCOST * level;

        public override double getRange() => 20 * getLevel();

    }
}
