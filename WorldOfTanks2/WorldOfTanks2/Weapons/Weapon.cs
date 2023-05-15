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
        /// <summary>
        /// Урон оружия.
        /// </summary>
        public abstract int Damage { get; }
        /// <summary>
        /// Скорость пули.
        /// </summary>
        public abstract float AmoSpeed { get; }
        /// <summary>
        /// Размер пули.
        /// </summary>
        public abstract float AmoSize { get; }
    }
}
