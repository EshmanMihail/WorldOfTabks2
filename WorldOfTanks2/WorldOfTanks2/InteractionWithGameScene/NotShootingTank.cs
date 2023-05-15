using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfTanks2.InteractionWithGameScene
{
    /// <summary>
    /// Танка, который не может стреляет.
    /// </summary>
    public class NotShootingTank : TankDecorator
    {
        public NotShootingTank(Tank tank) : base(tank)
        {
            x = tank.Get_X();
            y = tank.Get_Y();
            width = tank.Get_Width();
            height = tank.Get_Width();
            objectType = tank.Get_ObjectType();
        }

        /// <summary>
        /// Изменённый метод Стрельбы.
        /// </summary>
        public override GameObject Fire()
        {
            return null;
        }

        public override string Direction { get { return tank.Direction; } set { tank.Direction = value; } }
        public override float Speed { get { return tank.Speed; } }
        public override int GunType => tank.GunType;
        public override double TrunkColdown { get { return tank.TrunkColdown; } set { tank.TrunkColdown = value; } }
        public override int Hp { get { return tank.Hp; } set { tank.Hp = value; } }
        public override int Fuel  { get { return tank.Fuel; } set { tank.Fuel = value; } }
        public override bool InMist { get { return tank.InMist; } set { tank.InMist = value; } }
        public override bool InMud { get { return tank.InMud; } set { tank.InMud = value; } }
        public override int TrunkAmmunition { get { return tank.TrunkAmmunition; } set { tank.TrunkAmmunition = value; } }
        public override int MachinegunAmmunition { get { return tank.MachinegunAmmunition; } set { tank.MachinegunAmmunition = value; } }

        public override void ChangeGun()
        {
            tank.ChangeGun();
        }
        public override double CheckTrunkColdown()
        {
            return tank.CheckTrunkColdown();
        }
        public override bool CheckAmmoCount()
        {
            return true;
        }
        public override void Draw()
        {
            tank.Draw();
        }
        public override float Get_X()
        {
            return tank.Get_X();
        }
        public override float Get_Y()
        {
            return tank.Get_Y();
        }
        public override float Get_Width()
        {
            return tank.Get_Width();
        }
        public override void Move(string derection, float speed)
        {
            tank.Move(derection, speed);
        }
    }
}
