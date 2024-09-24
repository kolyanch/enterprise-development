namespace VeterinaryClinic.Domain;

/// <summary>
/// Клиент: Физическое лицо
/// </summary>
public class Individual : Client
{
    /// <summary>
    /// Имя
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public required string LastName { get; set; }

    /// <inheritdoc/>
    public override string FullName => $"{FirstName} {LastName}";
}