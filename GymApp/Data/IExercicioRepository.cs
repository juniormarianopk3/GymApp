using GymApp.Models;

namespace GymApp.Data {
    public interface IExercicioRepository {

        void Add(Exercicio exercicios);
        void Delete(Exercicio exercicios);
        List<Exercicio> GetAll();
        void Update(Exercicio exercicios);
        List<Exercicio> GetByParametro(List<string> parametros); 

        }
    }