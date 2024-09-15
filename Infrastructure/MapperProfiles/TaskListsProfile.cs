using AutoMapper;
using Domain.Entities;
using Infrastructure.Entities.Mongo;

namespace Infrastructure.MapperProfiles
{
    public class TaskListsProfile : Profile
    {
        public TaskListsProfile()
        {
            CreateMap<MongoTaskList, TaskList>();
            CreateMap<MongoTaskList, TaskListShortInfo>();
            
            CreateMap<TaskList, MongoTaskList>();
        }
    }
}
