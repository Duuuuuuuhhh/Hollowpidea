using System.Text.Json;
using Hollowpidea.Models;

namespace Hollowpidea.services;

public class hollowservice : IHollowService
{
    private readonly IHttpContextAccessor _session;
    private readonly string PersonagemFile = @"Data\Personagens.json";
    private readonly string TribosFile = @"Data\Tribos.json";

    public hollowservice(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }
    public List<Personagem> GetPersonagens()
    {
        PopularSessao();
        var Personagens = JsonSerializer.Deserialize<list<Personagem>>
            (_session.HttpContext.session.getstring("Personagens"));
            return Personagens;
    }

public list<Tribo> GetTribos()
{
    Popularsessao();
    var Tribos = jsonserializer.Deserialize<list<Tribo>>
    (_session.HttpContext.session.getstring("Tribos"));
    return Tribos;
}

public Personagem GetPersonagem (int numero)
{
    var Personagens = GetPersonagens();
    return Personagens.where(p => p.Numero == Numero).FirstOrDefault();
}
public hollowpideaDto GetHollowpideaDto()
{
    var Hollows = new hollowpideaDto()
    {
        Personagens = GetPersonagens(),
        Tribos = GetTribos()
    };
    return Hollows;
}
public DetailsDto GetDetailedPersonagem (int Numero)
{
    var Personagens = GetPersonagens();
    var Hollow = new DetailsDto()
    {
        Current = Personagens.where(p => p.Numero == Numero)
            .FirstOrDefault(),
        Prior = Personagens.OrderByDescending(p => p.Numero)
            .FirstOrDefault(p => p.Numero < Numero),
        Next = Personagens.OrderBy(p => p.Numero)
            .FirstOrDefault(p => p.Numero > Numero),
    };
    return Hollow;
}

public Tribo GetTribo(string Nome)
{
    var Tribos = GetTribos();
    return Tribos.where(t => t.Nome == Nome).FirstOrDefault();
}

private void PopularSessao()
{
    if (string.IsNullOrEmpty(_session.HttpContext.session.getstring("Tribos")))
    {
        _session.HttpContext.session
            .Setstring("Personagens", LerArquivo(PersonagemFile));
        _session.HttpContext.session
            .Setstring("Tribos", LerArquivo(TribosFile));
    }
}
