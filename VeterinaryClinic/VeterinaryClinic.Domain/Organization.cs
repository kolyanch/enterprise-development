namespace VeterinaryClinic.Domain;

/// <summary>
/// Клиент: Организация, юридическое лицо
/// </summary>
public class Organization : Client
{
    /// <summary>
    /// Наименование
    /// </summary>
    public required string Name { get; set; }

    /// <inheritdoc />
    public override string FullName => Name;
}