using AutoMapper;
using Bookink_Courses.Models.Context;
using Bookink_Courses.Models.DTOs;
using Bookink_Courses.Models.Entities;
using Bookink_Courses.Models.Interfaces;
using Bookink_Courses.Models.Mapping;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bookink_Courses.Models.Repository
{
    public class Course_Repo : IRepository<CourseDto>
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper map;

        public Course_Repo(ApplicationDbContext context, IMapper map)
        {
            this.context = context;
            this.map = map;
        }

        public void AddItem(CourseDto entity)
        {
            var mapping = map.Map<Courses>(entity);
            context.Courses.Add(mapping);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var course = context.Courses.FirstOrDefault(e => e.ID == id);
            context.Courses.Remove(course);
            context.SaveChanges();
        }

        public List<CourseDto> GetAll()
        {
            var courses = context.Courses.ToList();
            var mapping = map.Map<List<CourseDto>>(courses);
            return mapping;
        }

        public CourseDto GetById(int id)
        {
            var courses = context.Courses.FirstOrDefault(e => e.ID == id);
            var mapping = map.Map<CourseDto>(courses);
            return mapping;
        }

        public void Update(CourseDto entity)
        {
            var mapping = map.Map<Courses>(entity);
            context.Courses.Update(mapping);
            context.SaveChanges();
        }
    }
}
