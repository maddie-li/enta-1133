using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Items
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;
    using System.Xml.Linq;

    public class Weapon : Item
    {
        public override string Name { get; set; }  // name

        // PROPERTIES
        public int Damage { get; set; }

        // CONSTRUCTOR
        public Weapon(string name, int damage)
       : base(name, "", "", null!) 
        {
            this.Name = name;
            this.Damage = damage;
        }
    }

}
