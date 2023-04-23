using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2
{
    public class Tank : GameObject
    {
        private string direction = "U";

        public string gunType = "bigPushka"; 
        private int numberToChangeGunType = 1; 

        public Tank(float x, float y, float height, float width) : base(x, y, height, width)
        {
            
        }
        public void Move(float goX, float goY, string newDirection)
        {
            x += goX;
            y += goY;
            direction = newDirection;
        }

        public void ChangeGun()
        {
            numberToChangeGunType++;
            if (numberToChangeGunType % 2 == 0) { gunType = "Пулемёт"; }
            else gunType = "Ствол";
        }
        /// <summary>
        /// Создаёт снаряд.
        /// </summary>
        public GameObject Shoot()
        {
            GameObject objAmo = new Amo(x, y, 0.065f, 0.065f, direction);
            return objAmo;
        }
    }
}
