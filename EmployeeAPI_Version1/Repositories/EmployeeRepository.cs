using EmployeeAPI_Version1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeAPI_Version1.Repositories
{
    /// <summary>
    /// Need to implement the interface.
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;
        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<Employee> Create(Employee employee)
        {
            _context.employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task Delete(int EmployeeId)
        {
            var employeeToDelete = await _context.employees.FindAsync(EmployeeId);
            if (employeeToDelete != null)
            {
                _context.employees.Remove(employeeToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _context.employees.ToListAsync();
        }

        public async Task<Employee> Get(int EmployeeId)
        {
            ValueTask<Employee?>? employee = _context.employees.FindAsync(EmployeeId);
            return await _context.employees.FindAsync(EmployeeId);
        }

        public async Task Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
