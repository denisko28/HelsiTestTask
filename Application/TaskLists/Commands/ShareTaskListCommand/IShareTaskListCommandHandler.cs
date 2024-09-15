using Application.Utils; 
using Domain.Interfaces.SQRS.Command;

namespace Application.TaskLists.Commands.ShareTaskListCommand;

public interface IShareTaskListCommandHandler : ICommandHandler<ShareTaskListCommand, Result<bool>>
{
    
}