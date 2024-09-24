namespace VeterinaryClinic.Domain;

/// <summary>
/// Филиал клиники
/// </summary>
public class Office
{
    /// <summary>
    /// Название
    /// </summary>
    public required string Name { get; set; }

    public List<Visit> Visits { get; set; } = [];
}