using VeterinaryClinic.Domain;

namespace VeterinaryClinic.Tests;

public class VeterinaryClinicTest(ClinicFixture fixture) : IClassFixture<ClinicFixture>
{
    [Fact]
    public void TestQuery()
    {
        var blackVisits =
            (from visit in fixture.GetData()
             join blackListEntry in fixture.BlackList on visit.Client.FullName equals blackListEntry.Key             
             select new
             {
                 Client = visit.Client.FullName,
                 visit.Office,
                 BlackListReason = blackListEntry.Value
             }).ToList();

        Assert.True(blackVisits.Count > 0);
        Assert.Equal("Ivan Ivanov", blackVisits[0].Client);
    }

    [Fact]
    public void Test()
    {
        var visits = fixture.GetData();
        foreach (var visit in visits)
        {
            if (visit.Client is Individual
                {
                    LastName: "Ivanov",
                    PetName: "Rex"
                } or Organization
                {
                    PetName: "Rex"
                })
            {
                // ...
            }
        }

        var bestClients =
            from visit in fixture.GetData()
            group visit by visit.Client.FullName
            into clients
            orderby clients.Sum(visit => visit.Cost) descending
            select new
            {
                Client = clients.Key,
                ClientType = clients.First().Client switch
                {
                    Individual => "Физическое лицо",
                    Organization => "Юридическое лицо",
                    _ => "Неизвестно"
                }
            };        
    }

    [Fact]
    public void Test2()
    {
        var i = 0;
        var sum = new Func<int, int, double>((x, y) => {
            i++;
            return x + y;
        });

        var sum1 = new Action<int, int>((x, y) => {
            i++;
        });

        var calcSum = sum.Invoke(1, 3);
    }
}