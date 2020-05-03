using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Interfaces.Services;
using TransplantationCare.Core.Models.Business;
using TransplantationCare.Core.Models.DataBase;
using TransplantationCare.Core.Constants;

namespace TransplantationCare.BusinessLogic.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessRepository processRepository;
        private readonly IEventRepository eventRepository;
        private readonly IUserRepository userRepository;
        private readonly IUserContractRepository userContractRepository;
        private readonly IContractService contractService;

        public ProcessService(
            IProcessRepository processRepository,
            IEventRepository eventRepository,
            IUserRepository userRepository,
            IContractService contractService,
            IUserContractRepository userContractRepository)
        {
            this.processRepository = processRepository;
            this.eventRepository = eventRepository;
            this.userRepository = userRepository;
            this.userContractRepository = userContractRepository;
            this.contractService = contractService;

        }

        public async Task StartProcess(int contractId, int adminId)
        {
            var contract = await contractService.GetContract(contractId);
            var client = (await userContractRepository.GetAllWithIncludesByContractIdAsync(contractId))
                .FirstOrDefault(us => us.User.Role.Name.Equals("Client")).User;
            var employee = (await userContractRepository.GetAllWithIncludesByContractIdAsync(contractId))
                .FirstOrDefault(us => us.User.Role.Name.Equals("Employee")).User;

            await contractService.ConfirmContract(contractId);

            var process = new Process
            {
                ContractId = contractId,
                ProcessStatusId = 2,
                AdminId = adminId
            };

            await processRepository.AddAsync(process);

            var baseEvents = CreateBaseEvents(
                process.Id,
                client.Id,
                employee.Id,
                Convert.ToDateTime(contract.OrganReceivingDate),
                Convert.ToDateTime(contract.OrganTransferringDate),
                Convert.ToDateTime(contract.BiomaterialsReceivingDate),
                Convert.ToDateTime(contract.BiomaterialsTransferringDate)
                );

            foreach (var e in baseEvents)
            {
                await eventRepository.AddAsync(e);
            }
        }

        public async Task<ProcessModel> GetProcessesById(int processId)
        {
            var process = await processRepository.GetWithIncludesByIdAsync(processId);
            var processModels = new ProcessModel
            {
                Id = process.Id,
                ProcessStatusId = process.ProcessStatusId,
                ContractId = process.Id,
                Description = process.Contract.Description,
                Organ = process.Contract.Organ,
                StatusName = process.ProcessStatus.Name
            };

            return processModels;
        }

        public async Task<List<ProcessModel>> GetProcessesByUserId(int id)
        {
            var userContracts = await userContractRepository.GetAllWithIncludesByUserIdAsync(id);
            var processModels = new List<ProcessModel>();

            foreach (var item in userContracts)
            {
                processModels.Add(
                    new ProcessModel
                    {
                        Id = item.Contract.Process.Id,
                        ProcessStatusId = item.Contract.Process.ProcessStatusId,
                        ContractId = item.Contract.Id,
                        Description = item.Contract.Description,
                        Organ = item.Contract.Organ,
                        StatusName = item.Contract.Process.ProcessStatus.Name
                    });
            }

            return processModels;
        }

        public async Task<List<EventModel>> GetEventsByUserId(int userId)
        {
            var events = await eventRepository.GetAllWithIncludesByUserIdAsync(userId);
            var eventModels = new List<EventModel>();

            foreach (var item in events)
            {
                eventModels.Add(
                    new EventModel
                    {
                        Id = item.Id,
                        Text = item.Text,
                        ExecutionTime = item.ExecutionTime,
                        IsCompleted = item.IsCompleted,
                        ProcessId = item.ProcessId,
                        UserId = item.UserId,
                    });
            }

            return eventModels;
        }

        public async Task<List<EventModel>> GetEventsByAdminId(int adminId)
        {
            var events = await eventRepository.GetAllWithIncludesByAdminIdAsync(adminId);
            var eventModels = new List<EventModel>();

            foreach (var item in events)
            {
                eventModels.Add(
                    new EventModel
                    {
                        Id = item.Id,
                        Text = item.Text,
                        ExecutionTime = item.ExecutionTime,
                        IsCompleted = item.IsCompleted,
                        ProcessId = item.ProcessId,
                        UserId = item.UserId,
                    });
            }

            return eventModels;
        }

        public async Task ConfirmEventExecution(int eventId)
        {
            var _event = await eventRepository.GetWithIncludesByIdAsync(eventId);
            var process = await processRepository.GetByIdAsync(_event.ProcessId);

            _event.IsCompleted = true;
            await eventRepository.UpdateAsync(_event);

            if (_event.Text == EventTextConstants.BiomaterialsReceivingEventText)
            {
                process.ProcessStatusId = 3;
            }
            else if (_event.Text == EventTextConstants.BiomaterialsTransferringEventText)
            {
                process.ProcessStatusId = 4;
            }
            else if (_event.Text == EventTextConstants.OrganReceivingEventText)
            {
                process.ProcessStatusId = 5;
            }
            else if(_event.Text == EventTextConstants.OrganTransferringEventText)
            {
                process.ProcessStatusId = 6;
                await contractService.EndContract(process.ContractId);
            }

            await processRepository.UpdateAsync(process);
        }

        private List<Event> CreateBaseEvents(
            int processId,
            int clientId,
            int employeeId,
            DateTime OrganReceivingDate,
            DateTime OrganTransferringDate,
            DateTime BiomaterialsReceivingDate,
            DateTime BiomaterialsTransferringDate)
        {
            return new List<Event> 
            {
                new Event
                {
                    ProcessId = processId,
                    Text = EventTextConstants.BiomaterialsReceivingEventText,
                    ExecutionTime = BiomaterialsReceivingDate,
                    IsCompleted = false,
                    UserId = clientId
                },
                new Event
                {
                    ProcessId = processId,
                    Text = EventTextConstants.BiomaterialsTransferringEventText,
                    ExecutionTime = BiomaterialsTransferringDate,
                    IsCompleted = false,
                    UserId = employeeId
                },
                new Event
                {
                    ProcessId = processId,
                    Text = EventTextConstants.OrganReceivingEventText,
                    ExecutionTime = OrganReceivingDate,
                    IsCompleted = false,
                    UserId = employeeId
                },
                new Event
                {
                    ProcessId = processId,
                    Text = EventTextConstants.OrganTransferringEventText,
                    ExecutionTime = OrganTransferringDate,
                    IsCompleted = false,
                    UserId = clientId
                }
            };
        }

        private async Task ChangeProcessStatus(int processid, int statusId)
        {
            var process = await processRepository.GetByIdAsync(processid);
            process.ProcessStatusId = statusId;

            await processRepository.UpdateAsync(process);
        }
    }
}
