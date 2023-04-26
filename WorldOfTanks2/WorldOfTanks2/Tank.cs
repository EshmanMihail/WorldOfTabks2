using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfTanks2
{
    public class Tank : GameObject
    {
        private int objectType;
        private string direction = "U";
        public int hp = 100;
        public bool destroied = false;

        public string gunType = "trunk"; 
        private int numberToChangeGunType = 1; 

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

        public void ChangeGun()
        {
            numberToChangeGunType = 3 - numberToChangeGunType;
            if (numberToChangeGunType % 2 == 0) 
            { 
                gunType = "machinegun";
                numberToChangeGunType = 2;
            }
            else
            {
                gunType = "trunk";
                numberToChangeGunType = 1;
            }
        }

        /// <summary>
        /// Создаёт снаряд.
        /// </summary>
        public GameObject Shoot()
        {
            GameObject objAmo = new Amo(x, y, 0.05f, 0.05f, 3, direction);
            return objAmo;
        }
    }
}
