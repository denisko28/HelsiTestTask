using Application.Extensions;
using Application.Interfaces.Repositories;
using Application.Utils;
using AutoMapper;
using Domain.Entities;

namespace Application.TaskLists.Commands.CreateTaskList;

public class CreateTaskListCommandHandler(ITaskListsRepository repository, IMapper mapper) : ICreateTaskListCommandHandler
{
    public async Task<Result<TaskList>> HandleAsync(CreateTaskListCommand command)
    {
        var taskList = mapper.Map<TaskList>(command);
        taskList.RegisterCreation(command.CurrentUserId);
        await repository.AddAsync(taskList);
        return Result<TaskList>.Success(taskList);
    }
}