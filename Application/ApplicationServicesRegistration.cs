using Application.TaskLists.Commands.CreateTaskList;
using Application.TaskLists.Commands.DeleteTaskList;
using Application.TaskLists.Commands.EditTaskList;
using Application.TaskLists.Commands.ShareTaskListCommand;
using Application.TaskLists.Commands.UnshareTaskListCommand;
using Application.TaskLists.Queries.GetTaskListById;
using Application.TaskLists.Queries.GetTaskListsByUser;
using Application.TaskLists.Queries.GetTaskListSharedWith;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<ICreateTaskListCommandHandler, CreateTaskListCommandHandler>();
        services.AddTransient<IDeleteTaskListCommandHandler, DeleteTaskListCommandHandler>();
        services.AddTransient<IEditTaskListCommandHandler, EditTaskListCommandHandler>();
        services.AddTransient<IShareTaskListCommandHandler, ShareTaskListCommandHandler>();
        services.AddTransient<IUnshareTaskListCommandHandler, UnshareTaskListCommandHandler>();
        
        services.AddTransient<IGetTaskListByIdQueryHandler, GetTaskListByIdQueryHandler>();
        services.AddTransient<IGetTaskListsByUserQueryHandler, GetTaskListsByUserQueryHandler>();
        services.AddTransient<IGetTaskListSharedWithQueryHandler, GetTaskListSharedWithQueryHandler>();

        return services;
    }
}