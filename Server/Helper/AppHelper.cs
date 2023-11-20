using AutoMapper;
using UranusAdmin.Models;
using UranusWeb.Server.Dtos;

namespace UranusWeb.Server.Helper
{
    public class AppHelper : Profile
    {
        public AppHelper()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<Doc, DocDto>();
            CreateMap<DocDto, Doc>();
            CreateMap<Homework, HomeworkDto>();
            CreateMap<HomeworkDto, Homework>();
            CreateMap<Lesson, LessonDto>();
            CreateMap<LessonDto, Lesson>();
            CreateMap<Material, MaterialDto>();
            CreateMap<MaterialDto, Material>();
            CreateMap<Test, TestDto>();
            CreateMap<TestDto, Test>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Video, VideoDto>();
            CreateMap<VideoDto, Video>();
        }
    }
}
