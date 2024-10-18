namespace GD12_1133_Assignment2_MaddieLi
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();

            Console.WriteLine(ProjectText.AssignmentText);
            gameManager.SetUp();
        }
    }
}
