namespace GD12_1133_Assignment2_MaddieLi.Items
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;
    using GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces;

    class Rock : Item, IIsPortable
    {
        public override void Use(Item? target = null)
        {

        }

        // CONSTRUCTOR
        public Rock(string Name, string Glance, string Look, bool IsPortable) : base()
        {
            this.Name = Name;
            this.Glance = Glance;
            this.Look = Look;
            this.IsPortable = IsPortable;

        }

    }

}
