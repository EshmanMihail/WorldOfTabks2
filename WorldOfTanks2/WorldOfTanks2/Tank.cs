using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfTanks2
{
    /// <summary>
    /// Класс, описывающий танк.
    /// </summary>
    public class Tank : GameObject
    {
        private int objectType; // 1, 2
        private string direction = "U";
        public int hp = 100;
        private int fuelReserve = 100;
        public bool destroied = false;

        public Tank(float x, float y, float height, float width, int objectType) : base(x, y, height, width)
        {
            this.objectType = objectType;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public void Move(float goX, float goY, string newDirection)
        {
            x += goX;
            y += goY;
            direction = newDirection;
        } 

        /// <summary>
        /// Стреляет из выбранного орудия.
        /// </summary>
        public GameObject Fire(Weapon weapon)
        {
            float amo_x = x, amo_y = y;
            switch (direction)
            {
                case "U":
                    amo_y += width / 2 + weapon.AmoSize / 2;
                    break;
                case "R":
                    amo_x += width / 2 + weapon.AmoSize / 2;
                    break;
                case "L":
                    amo_x -= width / 2 + weapon.AmoSize / 2;
                    break;
                case "D":
                    amo_y -= width / 2 + weapon.AmoSize / 2;
                    break;
            }
            weapon.AmmunitionMinusMinus();
            return new Amo(amo_x, amo_y, weapon.AmoSize, weapon.AmoSize, 3, weapon.AmoSpeed, weapon.Damage, direction);
        }

        /// <summary>
        /// Проверяет боезапас орудия.
        /// </summary>
        public bool CheckAmmoCount(Weapon weapon)
        {
            if(weapon.Ammunition() == 0)
            {
                return false;
            }
            return true;
        }
    }
}
