using Application.DTOs.TaskLists;
using Application.TaskLists.Commands.CreateTaskList;
using Application.TaskLists.Commands.DeleteTaskList;
using Application.TaskLists.Commands.EditTaskList;
using Application.TaskLists.Commands.ShareTaskListCommand;
using Application.TaskLists.Commands.UnshareTaskListCommand;
using Application.TaskLists.Queries.GetTaskListById;
using Application.TaskLists.Queries.GetTaskListsByUser;
using Application.TaskLists.Queries.GetTaskListSharedWith;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TaskListsController(IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromServices] IGetTaskListsByUserQueryHandler handler,
        [FromQuery] GetTaskListDTO model,
        [FromHeader] string userId
    )
    {
        var query = mapper.Map<GetTaskListsByUserQuery>(model);
        query.CurrentUserId = userId;
        
        var result = await handler.HandleAsync(query);
        if(!result.IsSuccess)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
    
    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> GetById(
        [FromServices] IGetTaskListByIdQueryHandler handler,
        string id,
        [FromHeader] string userId
    )
    {
        var query = new GetTaskListByIdQuery
        {
            Id = id,
            CurrentUserId = userId
        };
        
        var result = await handler.HandleAsync(query);
        if(!result.IsSuccess)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
    
    [HttpGet("{id:length(24)}/shared")]
    public async Task<IActionResult> GetShared(
        [FromServices] IGetTaskListSharedWithQueryHandler handler,
        string id,
        [FromHeader] string userId
    )
    {
        var query = new GetTaskListSharedWithQuery
        {
            Id = id,
            CurrentUserId = userId
        };
        
        var result = await handler.HandleAsync(query);
        if(!result.IsSuccess)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] ICreateTaskListCommandHandler handler,
        [FromBody] CreateTaskListDTO model,
        [FromHeader] string userId
    )
    {
        var command = mapper.Map<CreateTaskListCommand>(model);
        command.CurrentUserId = userId;
        
        var result = await handler.HandleAsync(command);
        if(!result.IsSuccess)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
    
    [HttpPost("share")]
    public async Task<IActionResult> ShareWithUser(
        [FromServices] IShareTaskListCommandHandler handler,
        [FromBody] ShareUnshareTaskListDTO model,
        [FromHeader] string userId
    )
    {
        var command = mapper.Map<ShareTaskListCommand>(model);
        command.CurrentUserId = userId;
        
        var result = await handler.HandleAsync(command);
        if(!result.IsSuccess)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
    
    [HttpPost("unshare")]
    public async Task<IActionResult> UnshareWithUser(
        [FromServices] IUnshareTaskListCommandHandler handler,
        [FromBody] ShareUnshareTaskListDTO model,
        [FromHeader] string userId
    )
    {
        var command = mapper.Map<UnshareTaskListCommand>(model);
        command.CurrentUserId = userId;
        
        var result = await handler.HandleAsync(command);
        if(!result.IsSuccess)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
    
    [HttpPut]
    public async Task<IActionResult> Edit(
        [FromServices] IEditTaskListCommandHandler handler,
        [FromBody] EditTaskListDTO model,
        [FromHeader] string userId
    )
    {
        var command = mapper.Map<EditTaskListCommand>(model);
        command.CurrentUserId = userId;
        
        var result = await handler.HandleAsync(command);
        if(!result.IsSuccess)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
    
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteTaskListCommandHandler handler,
        string id,
        [FromHeader] string userId
    )
    {
        var command = new DeleteTaskListCommand
        {
            Id = id,
            CurrentUserId = userId
        };
        
        var result = await handler.HandleAsync(command);
        if(!result.IsSuccess)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}