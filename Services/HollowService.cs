using System.Text.Json;
using Hollowpidea.Models;

namespace Hollowpidea.services;

public class hollowservice : IHollowService
{
    private readonly IHttpContextAccessor _session;
    private readonly string personagensFile = @"Data\personagens.json";
    private readonly string tribosFile = @"Data\tribos.json";

    public hollowservice(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }
    public List<personagens> getpersonagens()
    {
        PopularSessao();
        var personagens = JsonSerializer.Deserialize<list<personagens>>
            (_session.HttpContext.session.getstring("personagens"));
            return personagens;
    }

public list<tribos> gettribos()
{
    Popularsessao();
    var tribos = jsonserializer.Deserialize<list<tribos>>
    (_session.HttpContext.session.getstring("Tribos"));
    return tribos;
}

public personagens GetPersonagens (int numero)
{
    var tr
}
}
