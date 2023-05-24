using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorldOfTanks2;
using WorldOfTanks2.InteractionWithGameScene;
using WorldOfTanks2.Scenes;
using WorldOfTanks2.Debuffs;

namespace TestTank
{
    [TestClass]
    public class TestTextures
    {
        [TestMethod]
        [DataRow(1, "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player1.png")]
        [DataRow(2, "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player2.png")]
        [DataRow(1, "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player1.png")]
        [DataRow(1, "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player1.png")]
        [DataRow(2, "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player2.png")]
        [DataRow(1, "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player1.png")]
        [DataRow(2, "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player2.png")]
        [DataRow(1, "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player1.png")]
        [DataRow(1, "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player1.png")]
        [DataRow(2, "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player2.png")]
        [DataRow(1, "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player1.png")]
        [DataRow(2, "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player2.png")]
        [DataRow(1, "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player1.png")]
        [DataRow(1, "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player1.png")]
        [DataRow(2, "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player2.png")]
        public void TestCheckAmmoCount(int objType, string expected)
        {
            ObjectsTextures objectsTextures = new ObjectsTextures();
            string actual = objectsTextures.SetTexture(objType);
            Assert.AreEqual(expected, actual);
        }
    }
}
