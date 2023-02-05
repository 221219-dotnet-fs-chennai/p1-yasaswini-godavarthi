using Microsoft.EntityFrameworkCore;
using Models;
using FluentApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApi.Entities;
using FluentApi;

namespace FluentApi
{
    public class Arepo : IAdd<TrainerData>
    {
        private readonly TrainerDbContext _context;
        public Arepo(TrainerDbContext context)
        {
            _context = context;
        }
       /* public AllDetails AddTrainer(Entities.TrainerDetaile detaile, Entities.Skill skill, Entities.EducationDetail educationDetail, Entities.Company company)
        {
            _context.Add(detaile);
           // _context.SaveChanges();
            _context.Add(skill);
           // _context.SaveChanges();
            _context.Add(company);
           // _context.SaveChanges();
            _context.Add(educationDetail);
            _context.SaveChanges();

            return new AllDetails();

        }*/

        public AllDetails AddTrainer(AllDetails trainer)
        {
            _context.Add(trainer);
            _context.SaveChanges();


            return new AllDetails();

        }
    }
}
