using AutoMapper;
using UranusAdmin.Models;
using UranusWeb.Server.Models;
using UranusWeb.Shared.Dtos;

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
            CreateMap<UserCourse, UserCourseDto>();
            CreateMap<UserCourseDto, UserCourse>();
            CreateMap<About, AboutDto>();
            CreateMap<AboutDto, About>();
            CreateMap<FAQ, FAQDto>();
            CreateMap<FAQDto, FAQ>();
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
            CreateMap<Result, ResultDto>();
            CreateMap<ResultDto, Result>();
            CreateMap<PartVideo, PartVideoDto>();
            CreateMap<PartVideoDto, PartVideo>();
        }
    }
}
