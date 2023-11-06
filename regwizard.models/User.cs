namespace Regwizard.Models;

public class User
{
    public int Id { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
    public bool IsAgree { get; set; }
    public int ProvinceId { get; set; }
    public Province Province { get; set; }
}
