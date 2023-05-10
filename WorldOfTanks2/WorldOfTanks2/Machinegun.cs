using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfTanks2
{
    /// <summary>
    /// Компонент, описывающий пулемёт танка.
    /// Колличество патрон 100, урон 2.
    /// </summary>
    public class Machinegun : Weapon
    {
        public override int Damage => 2;

        public override float AmoSize => 0.03f;

        public override float AmoSpeed => 0;
    }
}
