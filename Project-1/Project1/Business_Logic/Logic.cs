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

        public Details Add(Details trainer)
        {
            return Mapper.TrainerMap(_data.Add(Mapper.TrainerMap(trainer)));
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

        public Details UpdateTrainer(string name, Details trainer)
        {
            var train = (from rst in _data.GetAllTrainers()
                              where rst.FullName == name &&
                              rst.UserId == trainer.user_id
                              select rst).FirstOrDefault();
            if (train != null)
            {
                train.Email = trainer.Email;
                train.FullName = trainer.Full_name;
                train.Gender = trainer.Gender;
                train.Age = trainer.Age;
                train.MobileNumber = trainer.Mobile_number;
                train.Website = trainer.Website;
                train.Password = trainer.PASSWORD;


                train = _data.UpdateTrainer(train);
            }

            return Mapper.TrainerMap(train);
        }
    }
}