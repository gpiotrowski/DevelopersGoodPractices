using System;
using System.Collections.Generic;
using System.Text;
using DGP.DesignPatterns.Facade.Services;

namespace DGP.DesignPatterns.Facade
{
    public class EmployeeOnboarder
    {
        private ILoginGenerator _loginGenerator;
        private IAccountService _accountService;
        private IEmailService _emailService;


        public void OnboardEmployee(string name, string surname)
        {
            var login = _loginGenerator.GenerateLogin(name, surname);
            var account = _accountService.CreateAccount(login);
            _emailService.SendWelcomeEmail(account.Email);

            // Order new hardware
            // [...]

            // Order new software
            // [...]
        }
    }
}
