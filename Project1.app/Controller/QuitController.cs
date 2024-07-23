using Project1.app.Repository.Entities;
using Project1.app.Utility;

namespace Project1.app.Controller;

public static class QuitController
{
    public static void Quit()
    {
        Console.WriteLine("Quitting...");
        State.StateRunning = false;
        State.StateAccount = new Account();
    }
}