namespace DGP.DesignPatterns.Facade
{
    class Client
    {
        public void Execute()
        {
            var employeeOnboarder = new EmployeeOnboarder();

            employeeOnboarder.OnboardEmployee("John", "Doe");
        }
    }
}
