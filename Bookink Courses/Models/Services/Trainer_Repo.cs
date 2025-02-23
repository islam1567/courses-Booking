using AutoMapper;
using Bookink_Courses.Models.Context;
using Bookink_Courses.Models.DTOs;
using Bookink_Courses.Models.Entities;
using Bookink_Courses.Models.Interfaces;

namespace Bookink_Courses.Models.Repository
{
    public class Trainer_Repo : IRepository<TrainerDto>
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper map;

        public Trainer_Repo(ApplicationDbContext context, IMapper map)
        {
            this.context = context;
            this.map = map;
        }

        public void AddItem(TrainerDto entity)
        {
            var mapping = map.Map<Trainers>(entity);
            context.Trainers.Add(mapping);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var course = context.Trainers.FirstOrDefault(e => e.ID == id);
            context.Trainers.Remove(course);
            context.SaveChanges();
        }

        public List<TrainerDto> GetAll()
        {
            var courses = context.Trainers.ToList();
            var mapping = map.Map<List<TrainerDto>>(courses);
            return mapping;
        }

        public TrainerDto GetById(int id)
        {
            var trainer = context.Trainers.FirstOrDefault(e => e.ID == id);
            var mapping = map.Map<TrainerDto>(trainer);
            return mapping;
        }

        public void Update(TrainerDto entity)
        {
            var mapping = map.Map<Trainers>(entity);
            context.Trainers.Update(mapping);
            context.SaveChanges();
        }
    }
}
