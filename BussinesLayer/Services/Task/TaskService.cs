using AutoMapper;
using AutoMapper.QueryableExtensions;
using BussinesLayer.Interfaces.Task;
using DataLayer.Dto;
using DataLayer.Models.Works;
using DataLayer.Persistence;
using DataLayer.ViewModels.Works;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Task
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public TaskService(ApplicationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> Create(TaskWorkVM model)
        {

            var task = new TaskW { Title = model.Title };
            _dbContext.TaskWs.Add(task);
            var result = await _dbContext.SaveChangesAsync() > 0;
            if (!result) return result;
            _dbContext.TaskWork.Add(new TaskWork { TaskId = task.Id, WorkId = model.WorkId });
            result = await _dbContext.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> Create(Work model)
        {
            _dbContext.Works.Add(model);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<TaskWorkDto> GetById(Guid id)
            => await _dbContext.TaskWork.Include(x => x.Task).Include(x => x.Work).ProjectTo<TaskWorkDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.TaskId == id);

        public async Task<IEnumerable<TaskWork>> GetAllByWorkId(Guid id)
           => await _dbContext.TaskWork.Include(x => x.Task).Include(x => x.Work)
           .Where(x => x.WorkId == id).ToListAsync();

        //e3d78864-da23-44c8-5d1e-08d86a4a5e9b

        public async Task<IEnumerable<TaskW>> GetAll()
         => await _dbContext.TaskWs.ToListAsync();
    }
}
