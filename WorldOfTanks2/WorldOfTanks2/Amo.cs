using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfTanks2
{
    /// <summary>
    /// Класс, описывающий выпущенный патрон.
    /// </summary>
    public class Amo : GameObject // 3
    {
        private string direction;
        private float speedOfAmo;
        public int Damage { get; set; }

        public Amo(float x, float y, float height, float width, int objectType, float speedOfAmo, int damage, string direction) : base(x, y, height, width, objectType)
        {
            this.speedOfAmo = speedOfAmo;
            Damage = damage;
            this.direction = direction;
        }

        public override void Draw()
        {
            Move();
            base.Draw();
        }

        public void Move()
        {
            switch (direction)
            {
                case "U":
                    y += speedOfAmo;
                    break;
                case "D":
                    y -= speedOfAmo;
                    break;
                case "R":
                    x += speedOfAmo;
                    break;
                case "L":
                    x -= speedOfAmo;
                    break;
            }
        }

        public string GetAmoDerection()
        {
            return direction;
        }
    }
}
