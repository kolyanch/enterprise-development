using VeterinaryClinic.Domain;

namespace VeterinaryClinic.Tests;

public class ClinicFixture
{
    private List<Visit>? _visitList;

    public List<Visit> GetData()
    {
        if (_visitList != null) return _visitList;

        using var visitsReader = new ClinicFileReader("vet.csv");        
        _visitList = visitsReader.ReadVisits();        
        return _visitList;
    }

    public Dictionary<string, string> BlackList = new()
    {
        ["Ivan Ivanov"] = "Неоплата",
        ["Sergey Sidorov"] = "Конфликтный"
    };
}