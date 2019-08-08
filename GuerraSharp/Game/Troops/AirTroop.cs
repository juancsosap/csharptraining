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
    class AirTroop : Troop
    {
        List<IMisileWeapon> misile = new List<IMisileWeapon>();
        List<IBombWeapon> bomb = new List<IBombWeapon>();

        public AirTroop(Gamer gamer) : base(gamer)
        {
            this.type = TroopType.AIR;
        }

        public override void update(ICommand command)
        {
            
        }

        public override void recharge(IWeapon weapon)
        {
            if (weapon is IMisileWeapon)
                if (misile.Count <= 5)
                    misile.Add((IMisileWeapon) weapon);

            if (weapon is IBombWeapon)
                if (bomb.Count <= 8)
                    bomb.Add((IBombWeapon) weapon);
        }

        public static long BASICCOST = 300;
        public override long getUpdateCost() => BASICCOST * getLevel();
        public static long getCost(uint level) => BASICCOST * level;

        public override double getRange() => 10 * getLevel();
        
    }
}
