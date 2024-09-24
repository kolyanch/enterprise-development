using System.Globalization;
using VeterinaryClinic.Domain;

namespace VeterinaryClinic.Tests;

internal class ClinicFileReader(string fileName) : IDisposable
{
    private StreamReader _streamReader = new(fileName);    

    public List<Visit> ReadVisits()
    {
        var visits = new List<Visit>();
        
        while (!_streamReader.EndOfStream) 
        {
            var visitsLine = _streamReader.ReadLine();
            if (visitsLine == null || !visitsLine.Contains('"')) continue;
            var tokens = visitsLine.Split(',');
            for (var i = 0; i < tokens.Length; i++)
            {
                tokens[i] = tokens[i].Trim('"');
            }

            var office = new Office
            {
                Name = tokens[0]
            };

            var clientType = tokens.Last();
            Client client;
            if (clientType == "Individual")
            {
                var names = tokens[1].Split(' ');
                client = new Individual
                {
                    FirstName = names[0],
                    LastName = names[1],
                    PetName = tokens[2]
                };
            }
            else
            {
                client = new Organization
                {
                    Name = tokens[1],
                    PetName = tokens[2]
                };
            }

            var visit = new Visit
            {
                Client = client,
                Office = office,
                Date = DateTime.ParseExact(tokens[4], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Reason = tokens[5]
            };

            visits.Add(visit);
        }        

        return visits;
    }

    public void Dispose()
    {
        _streamReader.Dispose();
    }
}
