using System;
using System.Collections.Generic;
using System.Text;

namespace DGP.DesignPatterns.Builder
{
    public class EmployeeBuilder
    {
        private string _login;
        private Employee _manager;
        private WorkLocations _location;

        public EmployeeBuilder SetLogin(string login)
        {
            _login = login;
            
            return this;
        }

        public EmployeeBuilder SetManager(Employee manager)
        {
            _manager = manager;

            return this;
        }

        public EmployeeBuilder SetLocation(WorkLocations location)
        {
            _location = location;

            return this;
        }

        public Employee Build()
        {
            return new Employee()
            {
                Login = _login,
                Manager = _manager,
                Location = _location
            };
        }
    }

    public class Employee
    {
        public string Login { get; set; }
        public Employee Manager { get; set; }
        public WorkLocations Location { get; set; }
    }

    public enum WorkLocations
    {
        Remote,
        MainOffice
    }
}
