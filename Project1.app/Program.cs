using Project1.app.Controller;
using Project1.app.Repository;
using Project1.app.Utility;

namespace Project1.app;

class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        using var context = new ApplicationDbContext();
        MainController mainController = new(context);

        mainController.LoginStart();

        while (State.StateRunning)
        {
            mainController.LoginStart();
        }
    }
}