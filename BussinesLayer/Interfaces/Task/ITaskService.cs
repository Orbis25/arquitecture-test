using DataLayer.Dto;
using DataLayer.Models.Works;
using DataLayer.ViewModels.Works;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces.Task
{
    public interface ITaskService
    {
        Task<bool> Create(TaskWorkVM model);
        Task<TaskWorkDto> GetById(Guid id);
        Task<IEnumerable<TaskW>> GetAll();
        Task<bool> Create(Work model);
        Task<IEnumerable<TaskWork>> GetAllByWorkId(Guid id);
    }
}
