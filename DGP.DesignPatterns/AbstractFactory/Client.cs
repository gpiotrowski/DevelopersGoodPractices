namespace DGP.DesignPatterns.AbstractFactory
{
    class Client
    {
        public void Execute()
        {
            var deskDeviceFactory = new DeveloperDeskDevicesFactory();

            var monitorToOrder = deskDeviceFactory.CreateMonitor();
            var computerToOrder = deskDeviceFactory.CreateComputer();
        }
    }
}
