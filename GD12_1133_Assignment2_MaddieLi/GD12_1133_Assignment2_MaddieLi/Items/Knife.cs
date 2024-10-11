using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Assignment2_MaddieLi.Items
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;
    using System.Xml.Linq;

    internal class Knife : Item
    {
        public override void Use(Item? target = null)
        {

        }

        // CONSTRUCTOR
        public Knife(string Name, string Glance, string Look, bool IsPortable) : base()
        {
            this.Name = Name;
            this.Glance = Glance;
            this.Look = Look;
            this.IsPortable = IsPortable;

        }
    }

}
