namespace GD12_1133_Assignment2_MaddieLi.Items
{
    using GD12_1133_Assignment2_MaddieLi.Abstract;
    using GD12_1133_Assignment2_MaddieLi.Abstract.Interfaces;
    public class Item : BaseItem
    {
        public override string Name { get; set; } // name
        public override string Glance { get; set; } // short description (known room description, object in inventory or location)
        public override string Look { get; set; } // long description (new room description, examining object)

        public override BaseRoom CurrentRoom { get; set; } // long description (new room description, examining object)

        // CONSTRUCTOR
        public Item(string Name, string Glance, string Look, BaseRoom CurrentRoom) : base(Name, Glance, Look, CurrentRoom)
        {
            this.Name = Name;
            this.Glance = Glance;
            this.Look = Look;
            this.CurrentRoom = CurrentRoom;

        }

    }

}
