
namespace GymApp.Models {
    public class Treino {
        public int Id { get; set; }
        public string Dia { get; set; }
        public string Nome { get; set; }
        public int Serie { get; set; }
        public int Repeticoes { get; set; }
        public List<Exercicio> exercicio { get; set; }   
    }
}
