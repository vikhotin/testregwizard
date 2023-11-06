namespace Regwizard.Models;

public class SaveUserRequest
{
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public bool IsAgree { get; set; }
    public int ProvinceId { get; set; }
}