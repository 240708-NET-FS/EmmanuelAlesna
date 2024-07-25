namespace Project1.app.Repository.Entities;

public class Password
{
    public int PasswordID { get; set; }
    public string Hash { get; set; }
    public byte[] Salt { get; set; }
    public Account? Account { get; set; }
}