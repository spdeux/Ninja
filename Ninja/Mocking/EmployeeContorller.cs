
using Ninja.Mocking.Business;

namespace Ninja.Mocking
{
    public class EmployeeContorller 
    {
        private readonly IEmployeeRepository _employeeService;

        public EmployeeContorller(IEmployeeRepository employeeService)
        {
            _employeeService = employeeService;
        }

        public ActionResult DeleteEmployee(int id)
        {
            _employeeService.Remove(id);
            return RedirectedToAction("Employees");
        }

        private ActionResult RedirectedToAction(string employees)
        {
            return null;
        }
    }

    public class ActionResult
    {
    }
}
