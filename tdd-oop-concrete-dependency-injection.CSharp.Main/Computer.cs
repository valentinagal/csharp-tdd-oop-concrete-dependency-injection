using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer {

        //private
        private PowerSupply _powerSupply;
        private List<Game> _installedGames = new List<Game>() ;






        //constructor
        public Computer(PowerSupply powerSupply) {
            this._powerSupply = powerSupply;
        }

        public Computer(PowerSupply powerSupply, List<Game> preInstalledGames)
        {
            this._powerSupply = powerSupply;
            this._installedGames.AddRange(preInstalledGames);
        }

        //methods
        public void turnOn() {
            _powerSupply.turnOn();
        }



        //public properties
        public void installGame(Game game) {
            this._installedGames.Add(game);
        }

        

        public String playGame(string name) {
            foreach (Game g in this._installedGames) {
                if (g.name.Equals(name)) {
                    return g.start();
                }
            }

            return "Game not installed";
        }
        public List<Game> InstalledGames { get => _installedGames; set => _installedGames = value; }
    }
}
