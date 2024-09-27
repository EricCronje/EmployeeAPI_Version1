using EmployeeAPI_Version1.Models;

namespace EmployeeAPI_Version1.Repositories
{
 /// <summary>
 /// Repository - abstraction layer between the applications and data access layer which is in this case the EmployeeContext
 /// </summary>
    public interface IEmployeeRepository
    {
        //Return all employees
        Task<IEnumerable<Employee>> Get();
        Task<Employee> Get(int EmployeeId);
        Task<Employee> Create(Employee employee);
        Task Update(Employee employee);
        Task Delete(int EmpId);

    }
}
