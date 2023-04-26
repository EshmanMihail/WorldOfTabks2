using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfTanks2
{
    public class Machinegun : Weapon
    {
        public override int Damage => 5;

        public override void Shoot()
        {
            MessageBox.Show("it is Machinegun!");
        }
    }
}
