using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GD12_1133_Assignment2_MaddieLi.People
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;
    using GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces;

    internal class Combatant : Character, I_Container<Item>, IInfo
    {
        
        // CONSTRUCTOR
        public CharacterSetup(string Name, string Glance, string Look, List<Thing> Contents) : base()
        {
            this.Name = Name;
            this.Glance = Glance;
            this.Look = Look;
            this.Contents = Contents;

        }

        public List<Item>? Contents { get; set ; }
    }


}
