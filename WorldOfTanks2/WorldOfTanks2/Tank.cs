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
        /// Стреляет из выбранного оружия.
        /// </summary>
        public void Shoot(Weapon weapon)
        {
            weapon.Shoot();
        }
    }
}
