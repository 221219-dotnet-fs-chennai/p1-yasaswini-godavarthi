using FluentApi.Entities;
using Models;

namespace FluentApi
{
    public class EfRepo : IData<Entities.TrainerDetaile>
    {
        private readonly TrainerDbContext _context;
        public EfRepo(TrainerDbContext context)
        {
            _context = context;
        }
        public Entities.TrainerDetaile Add(Entities.TrainerDetaile details)
        {
            _context.Add(details);
            _context.SaveChanges();
            return details;
        }

       /* public void DeleteTrainer(string col, string table, int user)
        {
            throw new NotImplementedException();
        }

        public void droptrainer(int i)
        {
            throw new NotImplementedException();
        }

        public Entities.TrainerDetaile GetAllTrainer(string email)
        {
            throw new NotImplementedException();
        }*/

        public List<Entities.TrainerDetaile> GetAllTrainers()
        {
            return _context.TrainerDetailes.ToList();
        }

        /*public bool login(string email)
        {
            throw new NotImplementedException();
        }

        public Entities.TrainerDetaile SearchByEmail()
        {
            return context.TrainerDetailes;
            
        }
        
        public void UpdateTrainer(string tableName, string columnName, string newValue, int user_id)
        {
            context.Update(user_id, tableName, columnName, newValue);
            
            throw new NotImplementedException();
        }*/
    }
}