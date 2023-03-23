using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer {
        public List<Game> installedGames = new List<Game>();

        public void turnOn() {
            PowerSupply psu = new PowerSupply();
            psu.turnOn();
        }

        public void installGame() {
            Game game = new Game("Morrowind");
            this.installedGames.Add(game);
        }

        public String playGame() {
            foreach (Game g in this.installedGames) {
                if (g.name.Equals("Morrowind")) {
                    return g.start();
                }
            }

            return "Game not installed";
        }
    }
}
