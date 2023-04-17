=-using Hollowpidea.Models;
namespace Hollowpidea.services;
{
    public interface IHollowService
    {
        List<Personagem> GetPersonagens();
        List<Tribo> GetTribos();
        personagem GetPersonagem(int Numero);
        hollowpideaDto GetHollowpideaDto ();
        DatailsDto GetDetailedPersonagem (int numero);*/
        tribo GetTribo (string nome);
    }
}