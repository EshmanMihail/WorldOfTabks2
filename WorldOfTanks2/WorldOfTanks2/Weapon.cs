using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2
{
    public abstract class Weapon
    {
        public abstract int Damage { get; }
        public abstract void Shoot();
    }
}
