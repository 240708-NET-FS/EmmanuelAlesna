using Project1.app.Repository.Entities;

namespace Project1.app.Utility;

public static class State
{
    public static bool StateRunning { get; set; } = true;
    public static Account StateAccount { get; set; } = new Account();

}