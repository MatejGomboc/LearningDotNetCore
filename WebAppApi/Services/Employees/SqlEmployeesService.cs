using WebAppApi.DbContexts;
using WebAppApi.Models;

namespace WebAppApi.Services.Employees
{
    public class SqlEmployeesService : IEmployeesService
    {
        private readonly WebAppDbContext _webAppDbContext;

        public SqlEmployeesService(WebAppDbContext webAppDbContext)
        {
            if (webAppDbContext.Employees == null)
            {
                throw new ArgumentNullException(nameof(WebAppDbContext.Employees));
            }

            _webAppDbContext = webAppDbContext;
        }

        public void AddEmployee(Employee newEmployee)
        {
            newEmployee.Id = Guid.NewGuid();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _webAppDbContext.Employees.Add(newEmployee);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _webAppDbContext.SaveChanges();
        }

        public bool DeleteEmployee(Guid id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Employee? existingEmployee = _webAppDbContext.Employees.Find(id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (existingEmployee == null)
            {
                return false;
            }

            _webAppDbContext.Employees.Remove(existingEmployee);
            _webAppDbContext.SaveChanges();
            return true;
        }

        public Employee? EditEmployee(Employee newEmployee)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Employee? existingEmployee = _webAppDbContext.Employees.Find(newEmployee.Id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.Name = newEmployee.Name;
            _webAppDbContext.Employees.Update(existingEmployee);
            _webAppDbContext.SaveChanges();
            return existingEmployee;
        }

        public Employee? GetEmployee(Guid id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return _webAppDbContext.Employees.Find(id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public List<Employee> GetEmployees()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return _webAppDbContext.Employees.ToList();
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}