namespace VeterinaryClinic.Domain;

/// <summary>
/// Посещение клиники
/// </summary>
public class Visit
{
    /// <summary>
    /// Филиал 
    /// </summary>
    public required Office Office { get; set; }

    /// <summary>
    /// Клиент
    /// </summary>
    public required Client Client { get; set; }

    /// <summary>
    /// Дата посещения
    /// </summary>
    public required DateTime Date { get; set; }

    /// <summary>
    /// Цель визита
    /// </summary>
    public required string Reason { get; set; }

    public double Cost
    {
        get
        {
            return Reason switch
            {
                "Vaccination" => 1000,
                "Surgery" => 5000,
                "Dental Cleaning" => 500,
                _ => 200
            };
        }
    }
}