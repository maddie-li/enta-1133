using GD12_1133_Assignment2_MaddieLi;
using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Characters;
using GD12_1133_Assignment2_MaddieLi.Nav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Rooms
{
    internal class CombatRoom : Room // CombatRoom has a random chance of spawning enemy to begin combat
    {
        Combat combat = new Combat();
        Roller r = new Roller();

        string _enemyName;
        int _enemyHealth;
        int _oddsOfCombat = 3;

        public override void OnRoomEnter()
        {
            base.OnRoomEnter();

            if (this.Name == "Observation deck")
            {
                if (!GameManager.HasDefeatedChief)
                {
                    _enemyName = "Security Chief";
                    _enemyHealth = 35;
                    CombatantCPU _enemy = new CombatantCPU(_enemyName, _enemyHealth);
                    combat.CombatSetup(_enemy);
                    GameManager.HasDefeatedChief = true;
                }
                
            }
            else if (this.Name == "Office")
            {
                if (!GameManager.HasDefeatedDirector)
                {
                    _enemyName = "Executive Director";
                    _enemyHealth = 50;
                    CombatantCPU _enemy = new CombatantCPU(_enemyName, _enemyHealth);
                    combat.CombatSetup(_enemy);
                    GameManager.HasDefeatedDirector = true;

                }
                
            }
            else
            {
                if (r.Roll(_oddsOfCombat) == _oddsOfCombat) // if combat is to begin
                {
                    _enemyName = "Security Guard";
                    _enemyHealth = 25;
                    CombatantCPU _enemy = new CombatantCPU(_enemyName, _enemyHealth);
                    combat.CombatSetup(_enemy);
                }
            }
            
        }

        public CombatRoom(int x, int y, string name, string glance, string look)
        : base(x, y, name, glance, look) { }

    }
}
