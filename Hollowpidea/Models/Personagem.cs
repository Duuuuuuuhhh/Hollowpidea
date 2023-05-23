namespace Hollowpidea.Models
{
    public class Personagem
    {
        public int Numero {get; set;}
        public string Nome {get; set;}

        public string Imagem { get; set; }

        public List<string> Tribo { get; set; }
    }
}