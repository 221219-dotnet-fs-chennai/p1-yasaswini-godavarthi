using Models;
using FluentApi;
using FluentApi.Entities;

namespace Business_Logic
{
    public class Logic : ILog
    {
        IData<FluentApi.Entities.TrainerDetaile> _data;
        public Logic(IData<FluentApi.Entities.TrainerDetaile> data) 
        {
            _data = data;
        }

        public TrainerDetaile Add(TrainerDetaile trainer)
        {
            return _data.Add(trainer);
        }

        public IEnumerable<Details> GetAllTrainers()
        {
            return Mapper.TrainerMap(_data.GetAllTrainers());
        }


        public Details GetTrainerById(int id)
        {
            var search = _data.GetAllTrainers().Where(r => r.UserId == id).FirstOrDefault();
            return Mapper.TrainerMap(search);
        }
        

        public IEnumerable<Details> SearchByEmail(string email)
        {
            var Ema = _data.GetAllTrainers().Where(r => r.Email==email);
            return Mapper.TrainerMap(Ema);
        }
    }
}