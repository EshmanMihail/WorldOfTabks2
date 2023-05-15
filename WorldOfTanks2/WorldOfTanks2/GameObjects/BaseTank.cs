using coursework;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldOfTanks2.InteractionWithGameScene;
using WorldOfTanks2.Scenes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WorldOfTanks2
{
    /// <summary>
    /// Класс, описывающий стандартный танк.
    /// </summary>
    public class BaseTank : Tank // 1, 2
    {
        private string direction;
        private float speed = 0.006f;

        private int gunType = 0;
        private Weapon[] weapons = { new Trunk(), new Machinegun() };

        private int hp;
        private int fuelReserve;
        private double trunkColdown;

        private int trunkAmmunition;
        private int machinegunAmmunition;

        ObjectsTextures objectsTextures = new ObjectsTextures();
        /// <summary>
        /// Направление стовола танка.
        /// </summary>
        public override string Direction { get { return direction; } set { direction = value; } }
        /// <summary>
        /// Броня танка.
        /// </summary>
        public override int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        /// <summary>
        /// Запас топлива.
        /// </summary>
        public override int Fuel
        {
            get { return fuelReserve; }
            set { fuelReserve = value; }
        }
        /// <summary>
        /// Перезарядка ствола танка.
        /// </summary>
        public override double TrunkColdown 
        { 
            get { return trunkColdown; }
            set { trunkColdown = value; }
        }
        /// <summary>
        /// Тип орудия.
        /// </summary>
        public override int GunType
        {
            get { return gunType; }
        }
        /// <summary>
        /// Скорость танка.
        /// </summary>
        public override float Speed => speed;
        /// <summary>
        /// Переменная отвечающая за нахождение танка в тумане.
        /// </summary>
        public override bool InMist { get; set; }
        /// <summary>
        /// Переменная отвечающая за нахождение танка в грязи.
        /// </summary>
        public override bool InMud { get; set ; }
        /// <summary>
        /// Количество патрон орудия танка.
        /// </summary>
        public override int TrunkAmmunition { get { return trunkAmmunition; } set { value = trunkAmmunition; } }
        /// <summary>
        /// Количество патрон пулемёта танка.
        /// </summary>
        public override int MachinegunAmmunition { get { return machinegunAmmunition; } set { value = machinegunAmmunition; } }


        /// <summary>
        /// Создание танка.
        /// </summary>
        /// <param name="x">X координата</param>
        /// <param name="y">Y координата</param>
        /// <param name="height">Высота</param>
        /// <param name="width">Ширина</param>
        /// <param name="hp">Броня</param>
        /// <param name="direction">Направление</param>
        /// <param name="fuelReserve">Запас топлива</param>
        /// <param name="trunkColdown">Перезарядка ствола</param>
        /// <param name="trunkAmmunition">Количество патрон ствола</param>
        /// <param name="machinegunAmmunition">Количество патрон пулемёта</param>
        /// <param name="objectType">Тип объекта</param>
        public BaseTank(float x, float y, float height, float width, int hp, string direction,
            int fuelReserve, double trunkColdown, int trunkAmmunition, int machinegunAmmunition, int gunType, int objectType) : base(x, y, height, width, objectType)
        {
            this.hp = hp;
            this.direction = direction;
            this.fuelReserve = fuelReserve;
            this.trunkColdown = trunkColdown;
            this.trunkAmmunition = trunkAmmunition;
            this.machinegunAmmunition = machinegunAmmunition;
            this.gunType = gunType;
            texture = Textures.LoadTexture(objectsTextures.SetTexture(objectType));
        }

        /// <summary>
        /// Переопределённый метод отрисовки танка.
        /// </summary>
        public override void Draw()
        {
            float xLeft, xRight, yUpper, yLower;

            xLeft = x - (float)width / 2;
            xRight = x + (float)width / 2;
            yUpper = y + (float)height / 2;
            yLower = y - (float)height / 2;

            if (direction == "U")
            {
                GL.BindTexture(TextureTarget.Texture2D, texture.Id);
                GL.Begin(PrimitiveType.Quads);

                GL.TexCoord2(0, 0);
                GL.Vertex2(xLeft, yUpper);
                GL.TexCoord2(1, 0);
                GL.Vertex2(xRight, yUpper);
                GL.TexCoord2(1, 1);
                GL.Vertex2(xRight, yLower);
                GL.TexCoord2(0, 1);
                GL.Vertex2(xLeft, yLower);

                GL.End();
            }
            if (direction == "R")
            {
                GL.BindTexture(TextureTarget.Texture2D, texture.Id);
                GL.Begin(PrimitiveType.Quads);

                GL.TexCoord2(0, 0);
                GL.Vertex2(xRight, yUpper);
                GL.TexCoord2(1, 0);
                GL.Vertex2(xRight, yLower);
                GL.TexCoord2(1, 1);
                GL.Vertex2(xLeft, yLower);
                GL.TexCoord2(0, 1);
                GL.Vertex2(xLeft, yUpper);

                GL.End();
            }
            if (direction == "D")
            {
                GL.BindTexture(TextureTarget.Texture2D, texture.Id);
                GL.Begin(PrimitiveType.Quads);

                GL.TexCoord2(0, 0);
                GL.Vertex2(xLeft, yLower);
                GL.TexCoord2(1, 0);
                GL.Vertex2(xRight, yLower);
                GL.TexCoord2(1, 1);
                GL.Vertex2(xRight, yUpper);
                GL.TexCoord2(0, 1);
                GL.Vertex2(xLeft, yUpper);

                GL.End();
            }
            if (direction == "L")
            {
                GL.BindTexture(TextureTarget.Texture2D, texture.Id);
                GL.Begin(PrimitiveType.Quads);

                GL.TexCoord2(0, 0);
                GL.Vertex2(xLeft, yLower);
                GL.TexCoord2(1, 0);
                GL.Vertex2(xLeft, yUpper);
                GL.TexCoord2(1, 1);
                GL.Vertex2(xRight, yUpper);
                GL.TexCoord2(0, 1);
                GL.Vertex2(xRight, yLower);

                GL.End();
            }
        }

        /// <summary>
        /// Метод, отвечающий за передвижение танка.
        /// </summary>
        public override void Move(string newDirection, float speed)
        {
            if (fuelReserve > 0)
            {
                fuelReserve -= 1;
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
            }
            direction = newDirection;
        } 

        /// <summary>
        /// Стреляет из выбранного орудия.
        /// </summary>
        public override GameObject Fire()
        {
            if (gunType == 0) trunkColdown = 3000;
            float amo_x = x, amo_y = y;
            switch (direction)
            {
                case "U":
                    amo_y += width / 2 + weapons[gunType].AmoSize / 2;
                    break;
                case "R":
                    amo_x += width / 2 + weapons[gunType].AmoSize / 2;
                    break;
                case "L":
                    amo_x -= width / 2 + weapons[gunType].AmoSize / 2;
                    break;
                case "D":
                    amo_y -= width / 2 + weapons[gunType].AmoSize / 2;
                    break;
            }
            return new Amo(amo_x, amo_y, weapons[gunType].AmoSize, weapons[gunType].AmoSize, objectType, weapons[gunType].AmoSpeed, weapons[gunType].Damage, direction);
        }

        /// <summary>
        /// Проверяет боезапас орудия.
        /// </summary>
        public override bool CheckAmmoCount()
        {
            if (weapons[gunType] is Trunk && trunkColdown == 0)
            {
                if (trunkAmmunition == 0) return false;
                trunkAmmunition--;
            }
            if (weapons[gunType] is Machinegun)
            {
                if (machinegunAmmunition == 0) return false;
                machinegunAmmunition--;
            }
            return true;
        }

        /// <summary>
        /// Меняет орудие танка.
        /// </summary>
        public override void ChangeGun()
        {
            if (gunType == 0) gunType = 1;
            else gunType = 0;
        }

        /// <summary>
        /// Проверяет перезарядился ли ствол танка.
        /// </summary>
        /// <returns></returns>
        public override double CheckTrunkColdown()
        {
            if (trunkColdown > 0)
            {
                trunkColdown -= 15;
                return trunkColdown;
            }
            return 0;
        }
    }
}
