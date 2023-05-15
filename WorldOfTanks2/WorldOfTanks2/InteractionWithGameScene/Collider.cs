using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldOfTanks2.Debuffs;
using WorldOfTanks2.InteractionWithGameScene;

namespace WorldOfTanks2
{
    public class Collider
    {
        /// <summary>
        /// Игровая сцена.
        /// </summary>
        private Scene scene;
        public Collider(Scene scene)
        {
            this.scene = scene; 
        }
        /// <summary>
        /// Проверяет коллизию с объектами.
        /// </summary>
        public bool CheckCollision(float x, float y, Tank player)
        {
            foreach (GameObject obj in scene.GetGameObjects())
            {
                float leftEdge = x - player.Get_Width() / 2;
                float rightEdge = x + player.Get_Width() / 2;
                float topEdge = y + player.Get_Width() / 2;
                float bottomEdge = y - player.Get_Width() / 2;

                float leftEdgeObj = obj.Get_X() - obj.Get_Width() / 2;
                float rightEdgeObj = obj.Get_X() + obj.Get_Width() / 2;
                float topEdgeObj = obj.Get_Y() + obj.Get_Width() / 2;
                float bottomEdgeObj = obj.Get_Y() - obj.Get_Width() / 2;

                if (player.Get_ObjectType() == obj.Get_ObjectType())
                {
                    continue;
                }
                if (!(leftEdge >= rightEdgeObj || rightEdge <= leftEdgeObj || topEdge <= bottomEdgeObj || bottomEdge >= topEdgeObj))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Проверка коллизии для пуль.
        /// </summary>
        public bool CheckCollisionWithAmmo(Tank player1, Tank player2)
        {
            foreach (GameObject ammo in scene.GetGameObjects())
            {
                if (ammo is Amo)
                {
                    if (ammo.Get_Width() != 0.03f)
                    {
                        foreach (GameObject obj in scene.GetGameObjects())
                        {
                            if (obj is Amo) continue;

                            if (obj.Get_ObjectType() == 1 && obj.Get_ObjectType() != ammo.Get_ObjectType() &&
                                obj.Get_X() - obj.Get_Width() / 2 <= ammo.Get_X() && obj.Get_X() + obj.Get_Width() / 2 >= ammo.Get_X()
                                && obj.Get_Y() - obj.Get_Width() / 2 <= ammo.Get_Y() && obj.Get_Y() + obj.Get_Width() / 2 >= ammo.Get_Y())
                            {
                                player1.Hp -= ((Amo)ammo).Damage;
                                scene.RemoveObject(ammo);
                            }
                            if (obj.Get_ObjectType() == 2 && obj.Get_ObjectType() != ammo.Get_ObjectType() &&
                                obj.Get_X() - obj.Get_Width() / 2 <= ammo.Get_X() && obj.Get_X() + obj.Get_Width() / 2 >= ammo.Get_X()
                                && obj.Get_Y() - obj.Get_Width() / 2 <= ammo.Get_Y() && obj.Get_Y() + obj.Get_Width() / 2 >= ammo.Get_Y())
                            {
                                player2.Hp -= ((Amo)ammo).Damage;
                                scene.RemoveObject(ammo);
                            }
                            if (obj.Get_ObjectType() == 4 && obj.Get_X() - obj.Get_Width() / 2 <= ammo.Get_X() &&
                                obj.Get_X() + obj.Get_Width() / 2 >= ammo.Get_X()
                               && obj.Get_Y() - obj.Get_Width() / 2 <= ammo.Get_Y() && obj.Get_Y() + obj.Get_Width() / 2 >= ammo.Get_Y())
                            {
                                scene.RemoveObject(ammo);
                            }
                        }
                    }
                    else
                    {
                        GameObject hitObj = null;
                        float minDistance = 10000f;

                        foreach (GameObject obj in scene.GetGameObjects())
                        {
                            if (obj == ammo) continue;
                            if (((Amo)ammo).GetAmoDerection() == "L")
                            {
                                if (obj.Get_Y() + obj.Get_Width() / 2 >= ammo.Get_Y() && obj.Get_Y() - obj.Get_Width() / 2 <= ammo.Get_Y() && ammo.Get_X() > obj.Get_X())
                                {
                                    if (minDistance > Math.Abs(obj.Get_X() - ammo.Get_X()))
                                    {
                                        minDistance = Math.Abs(obj.Get_X() - ammo.Get_X());
                                        hitObj = obj;
                                    }
                                }
                            }
                            if (((Amo)ammo).GetAmoDerection() == "R")
                            {
                                if (obj.Get_Y() + obj.Get_Width() / 2 >= ammo.Get_Y() && obj.Get_Y() - obj.Get_Width() / 2 <= ammo.Get_Y() && ammo.Get_X() < obj.Get_X())
                                {
                                    if (minDistance > Math.Abs(obj.Get_X() - ammo.Get_X()))
                                    {
                                        minDistance = Math.Abs(obj.Get_X() - ammo.Get_X());
                                        hitObj = obj;
                                    }
                                }
                            }
                            if (((Amo)ammo).GetAmoDerection() == "U")
                            {
                                if (obj.Get_X() + obj.Get_Width() / 2 >= ammo.Get_X() && obj.Get_X() - obj.Get_Width() / 2 <= ammo.Get_X() && ammo.Get_Y() < obj.Get_Y())
                                {
                                    if (minDistance > Math.Abs(obj.Get_Y() - ammo.Get_Y()))
                                    {
                                        minDistance = Math.Abs(obj.Get_Y() - ammo.Get_Y());
                                        hitObj = obj;
                                    }
                                }
                            }
                            if (((Amo)ammo).GetAmoDerection() == "D")
                            {
                                if (obj.Get_X() + obj.Get_Width() / 2 >= ammo.Get_X() && obj.Get_X() - obj.Get_Width() / 2 <= ammo.Get_X() && ammo.Get_Y() > obj.Get_Y())
                                {
                                    if (minDistance > Math.Abs(obj.Get_Y() - ammo.Get_Y()))
                                    {
                                        minDistance = Math.Abs(obj.Get_Y() - ammo.Get_Y());
                                        hitObj = obj;
                                    }
                                }
                            }

                        }
                        if (hitObj is Tank)
                        {
                            if (((Tank)hitObj).Get_ObjectType() == 1)
                            {
                                player1.Hp -= ((Amo)ammo).Damage;
                            }
                            else
                            {
                                player2.Hp -= ((Amo)ammo).Damage;
                            }
                        }
                        scene.RemoveObject(ammo);
                    }
                }
            }
            return false;
        }
    }
}
