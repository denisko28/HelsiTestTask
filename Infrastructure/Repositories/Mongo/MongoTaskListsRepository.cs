using Application.Interfaces.Repositories;
using Application.TaskLists.Queries.GetTaskListsByUser;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Configuration.Models;
using Infrastructure.Entities.Mongo;
using Infrastructure.Extensions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Infrastructure.Repositories.Mongo;

public class MongoTaskListsRepository : ITaskListsRepository
{
    private readonly IMongoCollection<MongoTaskList> _taskLists;
    private readonly IMapper _mapper;

    public MongoTaskListsRepository(IMongoDatabase database, IOptions<MongoDbSettings> mongoDbSettings, IMapper mapper)
    {
        _taskLists = database.GetCollection<MongoTaskList>(mongoDbSettings.Value.TaskListsCollection);
        _mapper = mapper;
    }

    public async Task<IEnumerable<TaskListShortInfo>> GetByUserAsync(GetTaskListsByUserQuery query)
    {
        var taskLists = await _taskLists
            .AsQueryable()
            .Where(x => x.CreatedByUserId == query.CurrentUserId || 
                        x.SharedWithUsers.Contains(query.CurrentUserId))
            .Sort(query)
            .Paginate(query)
            .ToListAsync();

        return taskLists.Select(_mapper.Map<TaskListShortInfo>);
    }

    public async Task<TaskList?> GetByIdAsync(string id)
    {
        var taskList = await _taskLists
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync();
        return taskList == null ? null : _mapper.Map<TaskList>(taskList);
    }

    public async Task AddAsync(TaskList taskList)
    {
        var mongoEntity = _mapper.Map<MongoTaskList>(taskList);
        await _taskLists.InsertOneAsync(mongoEntity);
        taskList.Id = mongoEntity.Id;
    }

    public async Task UpdateAsync(TaskList taskList)
    {
        var mongoEntity = _mapper.Map<MongoTaskList>(taskList);
        await _taskLists.ReplaceOneAsync(x => x.Id == taskList.Id, mongoEntity);
    }

    public async Task DeleteAsync(string id)
    {
        await _taskLists.DeleteOneAsync(x => x.Id == id);
    }
}