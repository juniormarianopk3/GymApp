using GymApp.Models;
using LiteDB;

namespace GymApp.Data {
    public class ExercicicioRepository : IExercicioRepository {

        private readonly LiteDatabase _database;
        private readonly string collectionName = "exercicios";

        public ExercicicioRepository(LiteDatabase database) {
            _database = database;
        }

        public List<Exercicio> GetAll() {
            return _database
                .GetCollection<Exercicio>(collectionName)
                .Query()
                .OrderByDescending(a => a.Id)
                .ToList();

        }


        public void Add(Exercicio exercicios) {
            var col = _database.GetCollection<Exercicio>(collectionName);
            col.Insert(exercicios);
            col.EnsureIndex(a => a.Id);
        }

        public void Update(Exercicio exercicios) {
            var col = _database.GetCollection<Exercicio>(collectionName);
            col.Update(exercicios);
        }

        public void Delete(Exercicio exercicios) {
            var col = _database.GetCollection<Exercicio>(collectionName);
            col.Delete(exercicios.Id);
        }

        public List<Exercicio> GetByParametro(List<string> parametros) {

            List<Exercicio> novaLista = new List<Exercicio>();

            foreach(var item in parametros) {
                var col = _database.GetCollection<Exercicio>(collectionName);
                var query = Query.Contains("Nome", item); // Filtra pelo parâmetro no campo "Nome"
                novaLista.AddRange(col.Find(query).ToList());
            }

            return novaLista;
        }
    }
}

