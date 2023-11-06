namespace Regwizard.Models;

public class Province
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
}