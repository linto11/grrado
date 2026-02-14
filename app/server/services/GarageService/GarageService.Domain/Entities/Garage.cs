using GRRADO.Shared.Domain;

namespace GarageService.Domain.Entities;

public class Garage : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string GarageType { get; set; } = string.Empty;
    public bool EvSupported { get; set; }
    public double Rating { get; set; }
    public string OperatingHours { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }

    public ICollection<Service> Services { get; set; } = new List<Service>();
}
