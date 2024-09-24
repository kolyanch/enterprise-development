namespace VeterinaryClinic.Domain;

/// <summary>
/// Клиент
/// </summary>
public abstract class Client
{
    /// <summary>
    /// Полное имя
    /// </summary>
    public abstract string FullName { get; } 

    /// <summary>
    /// Кличка питомца
    /// </summary>
    public required string PetName { get; set; }

    public List<Visit> Visits { get; set; } = [];
}