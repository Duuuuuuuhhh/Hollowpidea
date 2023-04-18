using Hollowpidea.Models;

namespace Hollowpidea.Services;

public interface IHollowService
{
    List<Personagem> GetPersonagens();
    List<Tribo> GetTribos();
    Personagem GetPersonagem(int Numero);
    hollowpideaDto GetHollowpideaDto();
    DetailsDto GetDetailedPersonagem(int Numero);
    Tribo GetTribo(string Nome);
}
