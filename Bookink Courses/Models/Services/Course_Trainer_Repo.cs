using AutoMapper;
using Bookink_Courses.Models.Context;
using Bookink_Courses.Models.DTOs;
using Bookink_Courses.Models.Entities;
using Bookink_Courses.Models.Interfaces;

namespace Bookink_Courses.Models.Repository
{
    public class Course_Trainer_Repo : IRepository<Course_Trainer_Dto>
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper map;

        public Course_Trainer_Repo(ApplicationDbContext context, IMapper map)
        {
            this.context = context;
            this.map = map;
        }

        public void AddItem(Course_Trainer_Dto entity)
        {
            var mapping = map.Map<Course_Trainer>(entity);
            context.Course_Trainers.Add(mapping);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var coursetrainer = context.Course_Trainers.FirstOrDefault(e => e.Course_Id == id);
            context.Course_Trainers.Remove(coursetrainer);
            context.SaveChanges();
        }

        public List<Course_Trainer_Dto> GetAll()
        {
            var coursestrainer = context.Course_Trainers.ToList();
            var mapping = map.Map<List<Course_Trainer_Dto>>(coursestrainer);
            return mapping;
        }

        public Course_Trainer_Dto GetById(int id)
        {
            var coursestrainer = context.Course_Trainers.FirstOrDefault(e => e.Course_Id == id);
            var mapping = map.Map<Course_Trainer_Dto>(coursestrainer);
            return mapping;
        }

        public void Update(Course_Trainer_Dto entity)
        {
            var mapping = map.Map<Course_Trainer>(entity);
            context.Course_Trainers.Update(mapping);
            context.SaveChanges();
        }
    }
}
