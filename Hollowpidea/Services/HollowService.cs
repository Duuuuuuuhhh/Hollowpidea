using System.Text.Json;
using Hollowpidea.Models;

namespace Hollowpidea.Services;

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
        var Personagens = JsonSerializer.Deserialize<List<Personagem>>
            (_session.HttpContext.Session.GetString("Personagens"));
        return Personagens;
    }

    public List<Tribo> GetTribos()
    {
        PopularSessao();
        var Tribos = JsonSerializer.Deserialize<List<Tribo>>
        (_session.HttpContext.Session.GetString("Tribos"));
        return Tribos;
    }

    public Personagem GetPersonagem(int Numero)
    {
        var Personagens = GetPersonagens();
        return Personagens.Where(p => p.Numero == Numero).FirstOrDefault();
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
    public DetailsDto GetDetailedPersonagem(int Numero)
    {
        var Personagens = GetPersonagens();
        var Hollow = new DetailsDto()
        {
            Current = Personagens.Where(p => p.Numero == Numero)
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
        return Tribos.Where(t => t.Nome == Nome).FirstOrDefault();
    }

    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Tribos")))
        {
            _session.HttpContext.Session
                .SetString("Personagens", LerArquivo(PersonagemFile));
            _session.HttpContext.Session
                .SetString("Tribos", LerArquivo(TribosFile));
        }
    }

    private string LerArquivo(string fileName)
    {
        using (StreamReader leitor = new StreamReader(fileName))
        {
            string dados = leitor.ReadToEnd();
            return dados;
        }
    }
}
