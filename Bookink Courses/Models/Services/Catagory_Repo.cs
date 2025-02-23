using AutoMapper;
using Bookink_Courses.Models.Context;
using Bookink_Courses.Models.DTOs;
using Bookink_Courses.Models.Entities;
using Bookink_Courses.Models.Interfaces;

namespace Bookink_Courses.Models.Repository
{
    public class Catagory_Repo : IRepository<CatagoryDto>
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper map;

        public Catagory_Repo(ApplicationDbContext context, IMapper map)
        {
            this.context = context;
            this.map = map;
        }

        public void AddItem(CatagoryDto entity)
        {
            var mapping = map.Map<Catagory>(entity);
            context.Catagories.Add(mapping);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var catagory = context.Catagories.FirstOrDefault(e => e.ID == id);
            context.Catagories.Remove(catagory);
            context.SaveChanges();
        }

        public List<CatagoryDto> GetAll()
        {
            var catagory = context.Catagories.ToList();
            var mapping = map.Map<List<CatagoryDto>>(catagory);
            return mapping;
        }

        public CatagoryDto GetById(int id)
        {
            var catagory = context.Catagories.FirstOrDefault(e => e.ID == id);
            var mapping = map.Map<CatagoryDto>(catagory);
            return mapping;
        }

        public void Update(CatagoryDto entity)
        {
            var mapping = map.Map<Catagory>(entity);
            context.Catagories.Update(mapping);
            context.SaveChanges();
        }
    }
}
