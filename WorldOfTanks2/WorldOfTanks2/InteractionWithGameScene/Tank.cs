using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2.InteractionWithGameScene
{
    /// <summary>
    /// Класс, описывающий танк.
    /// </summary>
    public abstract class Tank : GameObject
    {
        protected Tank(float x, float y, float height, float width, int objectType) : base(x, y, height, width, objectType)
        {
            
        }
        public Tank() { }

        /// <summary>
        /// Направление стовола танка.
        /// </summary>
        public abstract string Direction { get; set; }
        /// <summary>
        /// Скорость танка.
        /// </summary>
        public abstract float Speed { get; }
        /// <summary>
        /// Тип орудия.
        /// </summary>
        public abstract int GunType { get; }
        /// <summary>
        /// Перезарядка ствола танка.
        /// </summary>
        public abstract double TrunkColdown { get; set; }
        /// <summary>
        /// Броня танка.
        /// </summary>
        public abstract int Hp { get; set; }
        /// <summary>
        /// Запас топлива.
        /// </summary>
        public abstract int Fuel { get; set; }
        /// <summary>
        /// Переменная отвечающая за нахождение танка в тумане.
        /// </summary>
        public abstract bool InMist { get; set; }
        /// <summary>
        /// Переменная отвечающая за нахождение танка в грязи.
        /// </summary>
        public abstract bool InMud { get; set; }
        /// <summary>
        /// Количество патрон орудия танка.
        /// </summary>
        public abstract int TrunkAmmunition { get; set; }
        /// <summary>
        /// Количество патрон пулемёта танка.
        /// </summary>
        public abstract int MachinegunAmmunition { get; set; }

        /// <summary>
        /// Метод, отвечающий за передвижение танка.
        /// </summary>
        public abstract void Move(string derection, float speed);
        /// <summary>
        /// Стреляет из выбранного орудия.
        /// </summary>
        public abstract GameObject Fire();
        /// <summary>
        /// Меняет орудие танка.
        /// </summary>
        public abstract void ChangeGun();
        /// <summary>
        /// Проверяет боезапас орудия.
        /// </summary>
        public abstract bool CheckAmmoCount();
        /// <summary>
        /// Проверяет перезарядился ли ствол танка.
        /// </summary>
        /// <returns></returns>
        public abstract double CheckTrunkColdown();
    }
}
