using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2
{
    /// <summary>
    /// Абстрактный класс, описывающий пушки танка в игре.
    /// </summary>
    public abstract class Weapon
    {
        public abstract int Damage { get; }
        public abstract float AmoSpeed { get; }
        public abstract float AmoSize { get; }
    }
}
