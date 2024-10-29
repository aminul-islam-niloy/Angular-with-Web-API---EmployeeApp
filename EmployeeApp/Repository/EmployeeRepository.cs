using EmployeeApp.Data;
using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task SaveEmployee (Employee employee)
        {
            await _context.Employees.AddAsync(employee);  
            await _context.SaveChangesAsync();
        }


        // Update an existing employee
        public async Task<bool> updateEmployee(Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employee.Id);
            if (existingEmployee == null)
            {
                return false; // Employee not found
            }

            // Update properties
            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.Mobile = employee.Mobile;
            existingEmployee.Age = employee.Age;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Status = employee.Status;

            _context.Employees.Update(existingEmployee);
            await _context.SaveChangesAsync();
            return true; // Update successful
        }

        // Delete an employee by ID
        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false; // Employee not found
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true; // Delete successful
        }
    }
}
