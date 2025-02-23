using AutoMapper;
using Bookink_Courses.Models.DTOs;
using Bookink_Courses.Models.Entities;

namespace Bookink_Courses.Models.Mapping
{
    public class Map : Profile
    {
        public Map()
        {
            CoursesMap();
            TrainerMap();
            LessonMap();
            CatagoryMap();
            Course_TrainerMap();
        }

        private void CoursesMap()
        {
            CreateMap<Courses, CourseDto>().ReverseMap();
        }

        private void CatagoryMap()
        {
            CreateMap<Catagory, CatagoryDto>().ReverseMap();
        }

        private void LessonMap()
        {
            CreateMap<Lessons, LessonDto>().ReverseMap();
        }

        private void TrainerMap()
        {
            CreateMap<Trainers, TrainerDto>().ReverseMap();
        }

        private void Course_TrainerMap()
        {
            CreateMap<Course_Trainer, Course_Trainer_Dto>().ReverseMap();
        }
    }
}
