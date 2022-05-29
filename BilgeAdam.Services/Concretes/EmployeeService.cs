using BilgeAdam.Common.Dtos;
using BilgeAdam.Data.Context;
using BilgeAdam.Services.Abstractions;

namespace BilgeAdam.Services.Concretes
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly NorthwindDbContext dbContext;

        public EmployeeService(NorthwindDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public PagedList<List<EmployeeListDto>> GetPagedEmployees(int count, int page)
        {
            var data = dbContext.Employees.Skip((page - 1) * count).Take(count).Select(x => new EmployeeListDto
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Id = x.EmployeeID,
                BirthDate = x.BirthDate,
                Country = x.Country,
                City = x.City,
                HireDate = x.HireDate.Value,
                Title = x.Title
            }).ToList();
            var totalCount = dbContext.Employees.Skip(page * count).Count();
            return new PagedList<List<EmployeeListDto>>() { Data = data, TotalCount = totalCount };
        }
    }
}