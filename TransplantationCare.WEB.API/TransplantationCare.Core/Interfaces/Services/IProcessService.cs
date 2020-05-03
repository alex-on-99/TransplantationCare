using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransplantationCare.Core.Models.Business;

namespace TransplantationCare.Core.Interfaces.Services
{
    public interface IProcessService
    {
        Task StartProcess(int contractId, int adminId);
        Task<ProcessModel> GetProcessesById(int processId);

        Task<List<ProcessModel>> GetProcessesByUserId(int id);

        Task<List<EventModel>> GetEventsByUserId(int userId);

        Task<List<EventModel>> GetEventsByAdminId(int adminId);

        Task ConfirmEventExecution(int eventId);
    }
}
