using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WorldOfTanks2
{
    /// <summary>
    /// Класс, описывающий танк.
    /// </summary>
    public class Tank : GameObject // 1, 2
    {
        private string direction = "U";
        private float speed = 0.007f;
        private int hp = 100;
        private int fuelReserve = 1500;
        private double trunkColdown = 0;
        private int[] ammunition = { 12, 100 };


        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public int Fuel
        {
            get { return fuelReserve; }
        }
        public double TrunkColdown 
        { 
            get { return trunkColdown; }
            set { trunkColdown = value; }
        }
        public int this[int index]
        {
            get { return ammunition[index]; }
        }

        public Tank(float x, float y, float height, float width, int objectType) : base(x, y, height, width, objectType)
        {
            
        }

        public override void Draw()
        {
            base.Draw();
        }

        public void Move(string newDirection)
        {
            if (fuelReserve > 0)
            {
                switch (newDirection)
                {
                    case "U":
                        y += speed;
                        break;
                    case "D":
                        y -= speed;
                        break;
                    case "R":
                        x += speed;
                        break;
                    case "L":
                        x -= speed;
                        break;
                }
                fuelReserve -= 1;
            }
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
                    amo_y += width / 2;
                    break;
                case "R":
                    amo_x += width / 2;
                    break;
                case "L":
                    amo_x -= width / 2;
                    break;
                case "D":
                    amo_y -= width / 2;
                    break;
            }
            return new Amo(amo_x, amo_y, weapon.AmoSize, weapon.AmoSize, objectType, weapon.AmoSpeed, weapon.Damage, direction);
        }

        /// <summary>
        /// Проверяет боезапас орудия.
        /// </summary>
        public bool CheckAmmoCount(Weapon weapon)
        {
            if (weapon is Trunk && trunkColdown == 0)
            {
                if (ammunition[0] == 0) return false;
                ammunition[0]--;
            }
            if (weapon is Machinegun)
            {
                if (ammunition[1] == 0) return false;
                ammunition[1]--;
            }
            return true;
        }
    }
}
