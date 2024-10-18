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
        Roller roller = new Roller();

        public Weapon _knife = new Weapon("Knife", 6);
        public Weapon _pistol = new Weapon("Pistol", 8);
        public Weapon _rifle = new Weapon("Rifle", 10);
        public Weapon _shotgun = new Weapon("Shotgun", 12);
        public Weapon _rocket = new Weapon("Rocket launcher", 20);

        List<Weapon> _playerWeapons = new List<Weapon>();
        List<Weapon> _enemyWeapons = new List<Weapon>();

        GameManager gameManager = new GameManager();

        public void CombatSetup(CombatantCPU _enemy)
        {
            _playerWeapons.Clear();
            _enemyWeapons.Clear();

            // PLAYER SETUP
            CombatantPlayer _player = new CombatantPlayer(GameManager.PlayerHealth);

            _playerWeapons.Add(_knife);
            if (GameManager.HasPickedUpRocket)
            {
                _playerWeapons.Add(_rocket);
            }

            // ENEMY SETUP

            switch (_enemy.Name.ToLower())
            {
                case "security chief":
                    _enemyWeapons.Add(_pistol);
                    _enemyWeapons.Add(_shotgun);
                    break;
                case "executive director":
                    _enemyWeapons.Add(_rocket);
                    _enemyWeapons.Add(_shotgun);
                    break;
                default:
                    _enemyWeapons.Add(_pistol);
                    _enemyWeapons.Add(_rifle);
                    break;

            }

            // BEGIN COMBAT
            CombatLoop(_player, _enemy);

            GameManager.PlayerHealth = _player.Health; // catch up on player health
            Console.WriteLine($"\nYou have defeated the {_enemy.Name}!");

        }

        public void CombatLoop(CombatantPlayer player, CombatantCPU enemy)
        {
            Console.WriteLine("You have been spotted by an enemy!!");

            Console.ReadKey();

            Console.WriteLine($"\n{player.Name.ToUpper()} vs. {enemy.Name.ToUpper()}");

           

            // TURN
            while (enemy.Health > 0)
            {
                Console.WriteLine($"\n{player.Name} | {player.Health}hp\n{enemy.Name} | {enemy.Health}hp");

                // enemy turn
                Weapon _enemySelection = ChooseWeapon(enemy);
                // player turn
                Weapon _playerSelection =  ChooseWeapon(player, _playerWeapons);

                // display choices
                Console.WriteLine($"\n{player.Name} chose to use {_playerSelection.Name}\n{enemy.Name} chose to use {_enemySelection.Name}");

                //roll
                int _enemyDamage = roller.Roll(_enemySelection.Damage);
                int _playerDamage = roller.Roll(_enemySelection.Damage);

                Console.ReadKey();

                // results
                Console.WriteLine($"\n{player.Name} did {_playerDamage} damage!\n{enemy.Name} did {_enemyDamage} damage!");

                player.Health -= _enemyDamage;
                enemy.Health -= _playerDamage;  

            }

        }

        public Weapon ChooseWeapon(CombatantPlayer player, List<Weapon> weaponslist)
        {

            Weapon _weapon = null!;

            // print weapon list
            Console.WriteLine("\n" +
                "WHAT WILL YOU DO?");

            foreach (BaseItem i in weaponslist)
            {
                Console.WriteLine("use " + i.Name.ToString());
            }


            // get input
            string _weaponSelection = GameManager.GetInput();

            // check if valid
            switch (_weaponSelection)
            {
                case "knife":
                case "use knife":
                    return _knife;
                case "use rocket":
                case "rocket":
                case "use rocket launcher":
                case "rocket launcher":
                    return _rocket;
                default:
                    Console.WriteLine("Invalid input! Try again.");
                    ChooseWeapon(player, weaponslist);
                    break;

            }
            
            return _weapon;

        }

        public Weapon ChooseWeapon(CombatantCPU enemy)
        {
            Weapon _weapon = null!;

            // get random
            int _weaponIndex = roller.Roll(_enemyWeapons.Count);

            // index
            Weapon _weaponSelection = _enemyWeapons[_weaponIndex-1];

            return _weaponSelection;
        }


    } }
