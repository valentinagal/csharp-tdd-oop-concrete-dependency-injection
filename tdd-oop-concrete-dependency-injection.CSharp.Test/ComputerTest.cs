using tdd_oop_concrete_dependency_injection.CSharp.Main;
using NUnit.Framework;

namespace tdd_oop_concrete_dependency_injection.CSharp.Test
{
    class ComputerTest
    {
        [Test]
        public void shouldTurnOn()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            myPc.turnOn();

            Assert.IsTrue(myPsu.isOn);
        }

        [Test]
        public void shouldInstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);

            Game game = new Game("Final Fantasy XI");
            myPc.installGame(game);

            Assert.AreEqual(1, myPc.InstalledGames.Count());
            Assert.AreEqual("Final Fantasy XI", myPc.InstalledGames[0].name);
        }

        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            Game game1 = new Game("Duck Game");
            Game game2 = new Game("Dragon's Dogma: Dark Arisen");

            myPc.installGame(game1);
            myPc.installGame(game2);

            Assert.AreEqual("Playing Duck Game", myPc.playGame("Duck Game"));
            Assert.AreEqual("Playing Dragon's Dogma: Dark Arisen", myPc.playGame("Dragon's Dogma: Dark Arisen"));
            Assert.AreEqual("Game not installed", myPc.playGame("Morrowind"));
        }
        
        [Test]
        public void canPreinstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> preInstalled = new List<Game>();
            preInstalled.Add(new Game("Dwarf Fortress"));
            preInstalled.Add(new Game("Baldur's Gate"));


            Computer myPc = new Computer(myPsu, preInstalled);

            Assert.AreEqual(2, myPc.InstalledGames.Count());
            Assert.AreEqual("Dwarf Fortress", myPc.InstalledGames[0].name);
            Assert.AreEqual("Baldur's Gate", myPc.InstalledGames[1].name);
        }
    }
}