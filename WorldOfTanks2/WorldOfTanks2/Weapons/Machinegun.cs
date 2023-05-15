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
        /// <summary>
        /// Урон пулемёта.
        /// </summary>
        public override int Damage => 2;
        /// <summary>
        /// Размер пули.
        /// </summary>
        public override float AmoSize => 0.03f;
        /// <summary>
        /// Скорость пули.
        /// </summary>
        public override float AmoSpeed => 0;
    }
}
