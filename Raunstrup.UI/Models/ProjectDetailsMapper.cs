using Raunstrup.Contract;
using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Raunstrup.UI.Models
{
    public static class ProjectDetailsMapper
    {

        public static ProjectDetailsViewModel Map(ProjectDto dto)
        {

            return new ProjectDetailsViewModel
            {
                Id = dto.Id,
                Active = dto.Active,
                Description = dto.Description,
                EndDate = dto.EndDate,
                IsAccepted = dto.IsAccepted,
                IsDone = dto.IsDone,
                IsFixedPrice = dto.IsFixedPrice,
                Price = dto.Price,
                ESTdriving = dto.ESTdriving,
                StartDate = dto.StartDate,
                Rowversion = dto.Rowversion,
                CustomerId = dto.CustomerId,
                Customer = CustomerMapper.Map(dto.CustomerDto),

                //ProjectDrivings = ProjectDrivingMapper.Map(dto.ProjectDrivingDtos).ToList(),

                ProjectDrivings = ProjectDrivingMapper.Map(dto.ProjectDrivingDtos).GroupBy(PD => PD.UnitPrice)
                    .Select(PD => new ProjectDrivingViewModel
                    {
                        Amount = PD.Sum(a => a.Amount),
                        EmployeeId = PD.First().EmployeeId,
                        Employee = PD.First().Employee,
                        ProjectId = PD.First().ProjectId,
                        UnitPrice = PD.First().UnitPrice
                    }).ToList(),

                ProjectEmployees = ProjectEmployeeMapper.Map(dto.ProjectEmployeeDtos).ToList(),

                //working hours summed up by employee 
                WorkingHours = WorkingHoursMapper.Map(dto.WorkingHoursDtos)
                .GroupBy(WH => WH.EmployeeId)
                    .Select(WH => new WorkingHoursViewModel
                    {
                        Amount = WH.Sum(a => a.Amount),
                        EmployeeId = WH.First().EmployeeId,
                        Employee = WH.First().Employee,
                        ProjectId = WH.First().ProjectId,
                        HourlyPrice = WH.First().Employee.Type.HourlyPrice + WH.First().Employee.Specialties.Sum(b => b.Bonus),
                        WorkingHoursId = WH.First().WorkingHoursId
                    }).ToList(),

                //assigned items summed up
                AssignedItems = ProjectAssignedItemMapper.Map(dto.AssignedItemDtos).GroupBy(PAI => PAI.ItemId)
                    .Select(PAI => new ProjectAssignedItemViewModel
                    {
                        Amount = PAI.Sum(c => c.Amount),
                        Item = PAI.First().Item,
                        Price = PAI.First().Price,
                        ProjectId = PAI.First().ProjectId
                    }).ToList(),

                //used items summed up
                UsedItems = ProjectUsedItemMapper.Map(dto.UsedItemsDtos).GroupBy(PUI => PUI.ItemId)
                    .Select(PUI => new ProjectUsedItemViewModel
                    {
                        Amount = PUI.Sum(c => c.Amount),
                        Item = PUI.First().Item,
                        Price = PUI.First().Price,
                        ProjectId = PUI.First().ProjectId
                    }).ToList()

            };
        }

        public static IEnumerable<ProjectDetailsViewModel> Map(IEnumerable<ProjectDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ProjectDto Map(ProjectDetailsViewModel project)
        {
            return new ProjectDto
            {
                Id = project.Id,
                Active = project.Active,
                Description = project.Description,
                EndDate = project.EndDate,
                IsAccepted = project.IsAccepted,
                IsDone = project.IsDone,
                IsFixedPrice = project.IsFixedPrice,
                Price = project.Price,
                ESTdriving = project.ESTdriving,
                StartDate = project.StartDate,
                Rowversion = project.Rowversion,
                CustomerId = project.CustomerId,
                //UsedItemsDtos = ProjectMapper.Map(project.UsedItems).ToList()
                ProjectEmployeeDtos = ProjectEmployeeMapper.Map(project.ProjectEmployees).ToList(),
                CustomerDto = CustomerMapper.Map(project.Customer)
            };
        }
    }
}
