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
    /// Колличество патрон 12, урон 25.
    /// </summary>
    public class Trunk : Weapon
    {
        /// <summary>
        /// Урон пулемёта.
        /// </summary>
        public override int Damage => 25;
        /// <summary>
        /// Размер пули.
        /// </summary>
        public override float AmoSpeed => 0.03f;
        /// <summary>
        /// Скорость пули.
        /// </summary>
        public override float AmoSize => 0.05f;

    }
}
