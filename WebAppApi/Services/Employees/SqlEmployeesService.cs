using WebAppApi.Models;
using WebAppApi.DbContexts;

namespace WebAppApi.Services.Employees
{
    public class SqlEmployeesService : IEmployeesService
    {
        private EmployeesDbContext _employeesDbContext;

        public SqlEmployeesService(EmployeesDbContext employeesDbContext)
        {
            if (employeesDbContext.Employees == null)
            {
                throw new ArgumentNullException(nameof(EmployeesDbContext.Employees));
            }

            _employeesDbContext = employeesDbContext;
        }

        public void AddEmployee(Employee newEmployee)
        {
            newEmployee.Id = Guid.NewGuid();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _employeesDbContext.Employees.Add(newEmployee);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _employeesDbContext.SaveChanges();
        }

        public bool DeleteEmployee(Guid id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Employee? existingEmployee = _employeesDbContext.Employees.Find(id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (existingEmployee == null)
            {
                return false;
            }

            _employeesDbContext.Employees.Remove(existingEmployee);
            _employeesDbContext.SaveChanges();
            return true;
        }

        public Employee? EditEmployee(Employee newEmployee)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Employee? existingEmployee = _employeesDbContext.Employees.Find(newEmployee.Id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.Name = newEmployee.Name;
            _employeesDbContext.Employees.Update(existingEmployee);
            _employeesDbContext.SaveChanges();
            return existingEmployee;
        }

        public Employee? GetEmployee(Guid id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return _employeesDbContext.Employees.Find(id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public List<Employee> GetEmployees()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return _employeesDbContext.Employees.ToList();
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}