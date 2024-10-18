using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Items
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;
    using System.Xml.Linq;

    public class Knife : Item
    {
        public override string Name { get; set; } // name
        public override string Glance { get; set; } // short description (known room description, object in inventory or location)
        public override string Look { get; set; } // long description (new room description, examining object)

        public override void Use(Item? target = null)
        {

        }

        // CONSTRUCTOR
        public Knife(string Name, string Glance, string Look) : base()
        {
            this.Name = Name;
            this.Glance = Glance;
            this.Look = Look;

        }
    }

}
