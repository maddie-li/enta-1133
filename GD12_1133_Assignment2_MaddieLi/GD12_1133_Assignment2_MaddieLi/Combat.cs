using GD12_1133_Assignment2_MaddieLi.Characters;
using GD12_1133_Assignment2_MaddieLi.Abstract;
using GD12_1133_Assignment2_MaddieLi.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi
{
    public class Combat
    {

        public Weapon _rocket = new Weapon("Rocket launcher", 20);
        public Weapon _pistol = new Weapon("Pistol", 15);
        public Weapon _knife = new Weapon("Knife", 10);

        public void CombatSetup()
        {
            // PLAYER SETUP
            CombatantPlayer _player = new CombatantPlayer(new List<BaseItem> { });

            if (GameManager.HasPickedUpRocket)
            {
                _player.Contents.Add(_rocket);
            }

            // ENEMY SETUP
            CombatantCPU _enemy = new CombatantCPU(new List<BaseItem> { });

            // BEGIN COMBAT
            CombatBegin(_player, _enemy);

        }

        public void CombatBegin(CombatantPlayer player, CombatantCPU enemy)
        {
            Console.WriteLine($"{player.Name} vs. {enemy.Name}");

            // set up player weapons
            List<BaseItem> _playerWeapons = new List<BaseItem>();
            foreach (BaseItem i in player.Contents)
            {
                if (i is Weapon)
                {
                    _playerWeapons.Add(i);
                }
            }

            // set up player weapons
            List<BaseItem> _enemyWeapons = new List<BaseItem>();
            foreach (BaseItem i in enemy.Contents)
            {
                if (i is Weapon)
                {
                    _enemyWeapons.Add(i);
                }
            }

            // TEST PRINT STATS
            DisplayList(_enemyWeapons);
            DisplayList(_playerWeapons);

            // while 
        }

        public void DisplayList(List<BaseItem> list)
        {
            foreach (BaseItem i in list)
            {
                Console.WriteLine(i.Name.ToString());
            }
        }

        
    }
}
