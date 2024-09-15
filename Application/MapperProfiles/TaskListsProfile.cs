using Application.DTOs.TaskLists;
using Application.TaskLists.Commands.CreateTaskList;
using Application.TaskLists.Commands.EditTaskList;
using Application.TaskLists.Commands.ShareTaskListCommand;
using Application.TaskLists.Commands.UnshareTaskListCommand;
using Application.TaskLists.Queries.GetTaskListsByUser;
using AutoMapper;
using Domain.Entities;

namespace Application.MapperProfiles
{
    public class TaskListsProfile : Profile
    {
        public TaskListsProfile()
        {
            CreateMap<CreateTaskListDTO, CreateTaskListCommand>();
            CreateMap<CreateTaskListCommand, TaskList>();
            
            CreateMap<EditTaskListDTO, EditTaskListCommand>();
            CreateMap<EditTaskListCommand, TaskList>();
            
            CreateMap<ShareUnshareTaskListDTO, ShareTaskListCommand>();
            CreateMap<ShareUnshareTaskListDTO, UnshareTaskListCommand>();

            CreateMap<GetTaskListDTO, GetTaskListsByUserQuery>();
        }
    }
}
