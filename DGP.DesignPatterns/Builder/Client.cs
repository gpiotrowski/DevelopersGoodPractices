namespace DGP.DesignPatterns.Builder
{
    class Client
    {
        public void Execute()
        {
            var manager = new Employee();

            var employee = new EmployeeBuilder()
                .SetLogin("employee01")
                .SetManager(manager)
                .SetLocation(WorkLocations.Remote)
                .Build();
        }
    }
}
