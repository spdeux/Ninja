using System;
using System.Collections.Generic;
using System.Text;

namespace Ninja.Mocking.Business
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _db;
        public EmployeeRepository()
        {
            _db = new EmployeeContext();
        }
        public void Remove(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null) return;
            
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}
