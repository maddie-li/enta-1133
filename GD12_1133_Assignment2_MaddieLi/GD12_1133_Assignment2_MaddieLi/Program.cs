namespace GD12_1133_Assignment2_MaddieLi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            ProjectText write = new ProjectText();

            Console.WriteLine(write.AssignmentText);
            gameManager.StartGame();
        }
    }
}
