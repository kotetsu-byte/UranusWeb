﻿using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface IVideoRepository
    {
        Task<ICollection<VideoDto>> GetAllVideos(int courseId, int lessonId);
        Task<VideoDto> GetVideoById(int courseId, int lessonId, int id);
        Task<string> Create(int courseId, int lessonId, VideoDto videoDto);
        Task<string> Update(VideoDto videoDto);
        Task<string> Delete(int id);
    }
}
