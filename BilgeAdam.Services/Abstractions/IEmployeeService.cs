using BilgeAdam.Common.Dtos;

namespace BilgeAdam.Services.Abstractions
{
    public interface IEmployeeService
    {
        PagedList<List<EmployeeListDto>> GetPagedEmployees(int count, int page);
    }
}
