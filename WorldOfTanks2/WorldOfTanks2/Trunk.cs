using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfTanks2
{
    /// <summary>
    /// Компонент, описывающий ствол танка.
    /// Колличество патрон 20, урон 25.
    /// </summary>
    public class Trunk : Weapon
    {
        public int ammunition = 20;
        public override int Damage => 25;

        public override float AmoSpeed => 0.05f;

        public override float AmoSize => 0.05f;

        public override int Ammunition()
        {
            return ammunition;
        }
        public override void AmmunitionMinusMinus()
        {
            ammunition--;
        }
    }
}
