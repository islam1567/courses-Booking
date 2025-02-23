using AutoMapper;
using Bookink_Courses.Models.Context;
using Bookink_Courses.Models.DTOs;
using Bookink_Courses.Models.Entities;
using Bookink_Courses.Models.Interfaces;

namespace Bookink_Courses.Models.Repository
{
    public class Lesson_Repo : IRepository<LessonDto>
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper map;

        public Lesson_Repo(ApplicationDbContext context, IMapper map)
        {
            this.context = context;
            this.map = map;
        }

        public void AddItem(LessonDto entity)
        {
            var mapping = map.Map<Lessons>(entity);
            context.Lessons.Add(mapping);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var lesson = context.Lessons.FirstOrDefault(e => e.ID == id);
            context.Lessons.Remove(lesson);
            context.SaveChanges();
        }

        public List<LessonDto> GetAll()
        {
            var lesson = context.Lessons.ToList().OrderBy(e => e.Order_No);
            var mapping = map.Map<List<LessonDto>>(lesson);
            return mapping;
        }

        public LessonDto GetById(int id)
        {
            var lesson = context.Lessons.FirstOrDefault(e => e.ID == id);
            var mapping = map.Map<LessonDto>(lesson);
            return mapping;
        }

        public void Update(LessonDto entity)
        {
            var mapping = map.Map<Lessons>(entity);
            context.Lessons.Update(mapping);
            context.SaveChanges();
        }
    }
}
