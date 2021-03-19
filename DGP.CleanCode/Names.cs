using System;
using System.Collections.Generic;
using System.Linq;

namespace DGP.CleanCode
{
    public class Names
    {
        // You don't know what is it
        public string A { get; set; }
        public string B { get; set; }
        public int C { get; set; }


        // Shorthand - you will forget what it mean later
        public int NumberOfP { get; set; } // Number of People
        public int AvailableCC { get; set; } // Available Coffees Cup


        // Sounds good - but what is it?
        public int GlobalValue { get; set; }


        // Too long is not too good
        public int ValueWhichTellsUsHowManyCoffeeCupsAreLeftInVendingMachineBasedOnInitialCupsQuantity { get; set; }
        // But don't be afraid of a little bit longer variable names. IDE will help us
        public int RemainingCoffeeCups { get; set; } // RCC


        // Be precise
        public int ElapsedTime { get; set; } // What it mean?
        // Should be:
        public int ElapsedTimeInDays { get; set; }
        public int ElapsedTimeInDaysSinceLastRestart { get; set; }
        // Better:
        public int DaysSinceLastRestart { get; set; }


        // Names should be easy to read and tell:
        public Guid CstRcrdId { get; set; } // CustomerRecordId
        public decimal TtlVlOfCstOrdr { get; set; } // TotalValueOfCustomerOrder


        // Typo should be fixed when spotted
        public int Lenght { get; set; } // => Length
        public Guid CustomreId { get; set; } // => CustomerId


        // Hungarian notation
        public string szWarningMassage { get; set; }
        public bool bIsEligibleForDiscount { get; set; }


        // Methods

        // Looks good... But imagine what will happen when we have lots of "Get(Guid id)" methods. We shouldn't make using IDE harder
        private List<Account> Get()
        {
            // [...]
            return new List<Account>();
        }

        // Method name should describe intent
        private List<Account> GetActiveAccounts()
        {
            // [...]
            return new List<Account>();
        }

        public int GetNumberOfActiveAccounts()
        {
            return 5;
        }

        // Previous rules still applies - both for methods and classes
        private List<Account> GetAAs()
        {
            return new List<Account>();
        }

        // Method also should indicate intent
        private List<Timesheet> GetMissing(List<Timesheet> input)
        {
            var filtered = input.Where(x => !x.WorkingDay);
            filtered = filtered.Where(x => x.WorkHours < 7);

            return filtered.ToList();
        }
        // Refactor to
        private List<Timesheet> GetTimesheetsWithMissingHours(List<Timesheet> userTimesheet)
        {
            var standardShiftInHours = 7;

            var workingDayTimesheets = userTimesheet.Where(x => !x.WorkingDay);
            var timesheetWithMissingHours = workingDayTimesheets.Where(x => x.WorkHours < standardShiftInHours);

            return timesheetWithMissingHours.ToList();
        }


        // Do you see the differences?
        private decimal GetMulti(int d, bool ps)
        {

            if (ps) return 1M;

            if (d < 5) return 1M;

            if (d == 5) return 1.5M;

            if (d == 6) return 2M;

            throw new GetMultiError();
        }
        // Transform to
        private decimal GetPaymentMultiplier(int dayIndex, bool plannedShift)
        {
            if (plannedShift) return 1M;

            if (dayIndex < 5) return 1M;

            if (dayIndex == 5) return 1.5M;

            if (dayIndex == 6) return 2M;

            throw new InvalidDayIndexException();
        }

        // We should use names related to our domain (Ubiquitous Language - DDD)

        #region Not relevant - tech stuff
        private class Account { }

        private class Timesheet
        {
            public DateTime Date { get; set; }
            public decimal WorkHours { get; set; }
            public bool WorkingDay { get; set; }
        }
        private class GetMultiError : Exception { }
        private class InvalidDayIndexException : Exception { }
        #endregion
    }
}
