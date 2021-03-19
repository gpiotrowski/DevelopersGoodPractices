using System;
using System.Collections.Generic;
using System.Linq;

namespace DGP.CleanCode
{
    public class Methods
    {
        // Input parameters
        private void CalculateEmployeeSalary(Employee employee, List<Timesheet> employeeTimesheets, List<Shift> employeePlannedShifts)
        {

        }
        // Create new class
        private void CalculateEmployeeSalary(EmployeeSalaryData employeeSalaryData)
        {

        }
        // Or create separate class for that
        private class SalaryCalculator
        {
            public SalaryCalculator(Employee employee, List<Shift> plannedShifts)
            {
                
            }

            public decimal CalculateSalary(List<Timesheet> timesheets)
            {
                return 0;
            }
        }

        // Output parameters
        private class SalaryCalculatorWithSalaryProperty
        {
            public decimal Salary { get; set; }

            public void CalculateSalary(List<Timesheet> timesheets)
            {
                Salary = 0;
            }
        }
        // Instead do
        private class SalaryCalculatorWithReturnValue
        {
            public decimal CalculateSalary(List<Timesheet> timesheets)
            {
                return 0;
            }
        }


        // Separate code blocks
        private void AddShiftToEmployeeBad(Guid employeeId, Shift newShift)
        {
            ValidateShift(newShift);
            var employee = GetEmployee(employeeId);
            if (employee == null) throw new EmployeeNotFoundException();
            if (!employee.IsActive)
            {
                throw new AddingShiftToInactiveEmployeeException();
            }
            var employeeShifts = GetEmployeeShifts(employeeId);
            if (employeeShifts == null) throw new EmployeeShiftNotFoundException();
            employeeShifts.AddShift(newShift);
            Save(employeeShifts);
        }
        // Its more readable this way
        private void AddShiftToEmployee(Guid employeeId, Shift newShift)
        {
            ValidateShift(newShift);

            var employee = GetEmployee(employeeId);
            if (employee == null) throw new EmployeeNotFoundException();

            if (!employee.IsActive)
            {
                throw new AddingShiftToInactiveEmployeeException();
            }

            var employeeShifts = GetEmployeeShifts(employeeId);
            if (employeeShifts == null) throw new EmployeeShiftNotFoundException();

            employeeShifts.AddShift(newShift);

            Save(employeeShifts);
        }


        // Method size
        private decimal GetBillableHoursWithBonusesBad(List<Timesheet> userTimesheets)
        {
            var standardShiftInHours = 8;

            var overtimesMultiplier = 1.5M;
            var sundayOvertimesMultiplier = 2M;

            var shiftDays = new List<DayOfWeek>() {DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Wednesday, DayOfWeek.Saturday};

            var standardShiftDayTimesheets = userTimesheets.Where(x => shiftDays.Contains(x.Date.DayOfWeek)).ToList();
            var saturdayTimesheets = userTimesheets.Where(x => x.Date.DayOfWeek == DayOfWeek.Saturday);
            var sundayTimesheets = userTimesheets.Where(x => x.Date.DayOfWeek == DayOfWeek.Sunday);

            var standardWorkHours = standardShiftDayTimesheets.Sum(x => x.WorkHours > standardShiftInHours ? standardShiftInHours : x.WorkHours );
            var missingStandardWorkHours = standardShiftDayTimesheets.Sum(x => x.WorkHours < standardShiftInHours ? standardShiftInHours - x.WorkHours : 0);

            var standardOvertimes = standardShiftDayTimesheets.Sum(x => x.WorkHours > standardShiftInHours ? x.WorkHours - standardShiftInHours : 0);

            var saturdayOvertimes = saturdayTimesheets.Sum(x => x.WorkHours);
            var sundayOvertimes = sundayTimesheets.Sum(x => x.WorkHours);

            if (missingStandardWorkHours > 0)
            {
                if (standardOvertimes >= missingStandardWorkHours)
                {
                    standardWorkHours += missingStandardWorkHours;
                    standardOvertimes -= missingStandardWorkHours;
                }
                else
                {
                    standardWorkHours += standardOvertimes;
                    standardOvertimes = 0;
                    missingStandardWorkHours -= standardOvertimes;
                }

                if (missingStandardWorkHours > 0)
                {
                    if (saturdayOvertimes >= missingStandardWorkHours)
                    {
                        standardWorkHours += missingStandardWorkHours;
                        sundayOvertimes -= missingStandardWorkHours;
                    }
                    else
                    {
                        standardWorkHours += saturdayOvertimes;
                        saturdayOvertimes = 0;
                        missingStandardWorkHours -= saturdayOvertimes;
                    }

                    if (missingStandardWorkHours > 0)
                    {
                        if (sundayOvertimes >= missingStandardWorkHours)
                        {
                            standardWorkHours += missingStandardWorkHours;
                            sundayOvertimes -= missingStandardWorkHours;
                        }
                        else
                        {
                            standardWorkHours += sundayOvertimes;
                            sundayOvertimes = 0;
                            missingStandardWorkHours -= sundayOvertimes;
                        }

                        if (missingStandardWorkHours > 0)
                        {
                            throw new InsufficientTimesheetWorkHoursException();
                        }
                    }
                }
            }

            return standardWorkHours + standardOvertimes * overtimesMultiplier +
                   saturdayOvertimes * overtimesMultiplier + sundayOvertimes * sundayOvertimesMultiplier;
        }
        // Refactor to smaller methods (or even better - to separate class)
        private decimal GetBillableHoursWithBonuses(List<Timesheet> employeeTimesheets)
        {
            var standardShiftInHours = 8;

            var overtimesMultiplier = 1.5M;
            var sundayOvertimesMultiplier = 2M;

            var standardShiftDayTimesheets = GetStandardShiftTimesheets(employeeTimesheets);
            
            var standardWorkHours = standardShiftDayTimesheets.Sum(x => x.WorkHours > standardShiftInHours ? standardShiftInHours : x.WorkHours);
            var missingStandardWorkHours = standardShiftDayTimesheets.Sum(x => x.WorkHours < standardShiftInHours ? standardShiftInHours - x.WorkHours : 0);
            
            var overtimes = GetOvertimes(employeeTimesheets);

            var missingHoursCompensation = new MissingHoursCompensation();
            var compensatedHours = missingHoursCompensation.CompensateMissingHours(overtimes, missingStandardWorkHours);

            if (compensatedHours.MissingHours > 0) throw new InsufficientTimesheetWorkHoursException();

            return standardWorkHours + compensatedHours.LeftOvertimes.StandardOvertimes * overtimesMultiplier +
                   compensatedHours.LeftOvertimes.SaturdayOvertimes * overtimesMultiplier + compensatedHours.LeftOvertimes.SundayOvertimes * sundayOvertimesMultiplier;
        }

        private Overtimes GetOvertimes(List<Timesheet> employeeTimesheets)
        {
            var standardShiftInHours = 8;

            var standardShiftDayTimesheets = GetStandardShiftTimesheets(employeeTimesheets);

            var standardOvertimes = standardShiftDayTimesheets.Sum(x => x.WorkHours > standardShiftInHours ? x.WorkHours - standardShiftInHours : 0);
            var saturdayOvertimes = GetSaturdayOvertimes(employeeTimesheets);
            var sundayOvertimes = GetSundayOvertimes(employeeTimesheets);

            return new Overtimes(standardOvertimes, saturdayOvertimes, sundayOvertimes);
        }

        private List<Timesheet> GetStandardShiftTimesheets(List<Timesheet> employeeTimesheets)
        {
            var shiftDays = new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Wednesday, DayOfWeek.Saturday };

            return employeeTimesheets.Where(x => shiftDays.Contains(x.Date.DayOfWeek)).ToList();
        }

        private decimal GetSaturdayOvertimes(List<Timesheet> employeeTimesheets)
        {
            var saturdayTimesheets = employeeTimesheets.Where(x => x.Date.DayOfWeek == DayOfWeek.Saturday);
            var saturdayOvertimes = saturdayTimesheets.Sum(x => x.WorkHours);

            return saturdayOvertimes;
        }

        private decimal GetSundayOvertimes(List<Timesheet> employeeTimesheets)
        {
            var sundayTimesheets = employeeTimesheets.Where(x => x.Date.DayOfWeek == DayOfWeek.Sunday);
            var sundayOvertimes = sundayTimesheets.Sum(x => x.WorkHours);

            return sundayOvertimes;
        }

        private class MissingHoursCompensation
        {
            public CompensatedMissingHours CompensateMissingHours(Overtimes employeeOvertimes, decimal missingHours)
            {
                var compensatedMissingHours = new CompensatedMissingHours(missingHours);

                compensatedMissingHours =
                    CompensateHoursFromStandardOvertimes(compensatedMissingHours, employeeOvertimes);
                compensatedMissingHours =
                    CompensateHoursFromSaturdayOvertimes(compensatedMissingHours, employeeOvertimes);
                compensatedMissingHours =
                    CompensateHoursFromSundayOvertimes(compensatedMissingHours, employeeOvertimes);

                // DRY
                compensatedMissingHours = CompensateHoursFromSelectedOvertimesType(compensatedMissingHours,
                    employeeOvertimes,
                    (overtime) => overtime.StandardOvertimes,
                    (overtime, newValue) => overtime.StandardOvertimes = newValue);

                compensatedMissingHours = CompensateHoursFromSelectedOvertimesType(compensatedMissingHours,
                    employeeOvertimes,
                    (overtime) => overtime.SaturdayOvertimes,
                    (overtime, newValue) => overtime.SaturdayOvertimes = newValue);

                compensatedMissingHours = CompensateHoursFromSelectedOvertimesType(compensatedMissingHours,
                    employeeOvertimes,
                    (overtime) => overtime.SundayOvertimes,
                    (overtime, newValue) => overtime.SundayOvertimes = newValue);


                return compensatedMissingHours;
            }

            private CompensatedMissingHours CompensateHoursFromStandardOvertimes(
                CompensatedMissingHours compensatedMissingHours, Overtimes employeeOvertimes)
            {
                if (compensatedMissingHours.HasHoursToCompensate())
                {
                    if (employeeOvertimes.StandardOvertimes >= compensatedMissingHours.MissingHours)
                    {
                        compensatedMissingHours.CompensatedHours += compensatedMissingHours.MissingHours;
                        compensatedMissingHours.LeftOvertimes.StandardOvertimes = employeeOvertimes.StandardOvertimes -
                            compensatedMissingHours.MissingHours;
                        compensatedMissingHours.MissingHours = 0;
                    }
                    else
                    {
                        compensatedMissingHours.CompensatedHours += employeeOvertimes.StandardOvertimes;
                        compensatedMissingHours.LeftOvertimes.StandardOvertimes = 0;
                        compensatedMissingHours.MissingHours -= employeeOvertimes.StandardOvertimes;
                    }
                }

                return compensatedMissingHours;
            }

            private CompensatedMissingHours CompensateHoursFromSaturdayOvertimes(
                CompensatedMissingHours compensatedMissingHours, Overtimes employeeOvertimes)
            {
                if (compensatedMissingHours.HasHoursToCompensate())
                {
                    if (employeeOvertimes.SaturdayOvertimes >= compensatedMissingHours.MissingHours)
                    {
                        compensatedMissingHours.CompensatedHours += compensatedMissingHours.MissingHours;
                        compensatedMissingHours.LeftOvertimes.SaturdayOvertimes = employeeOvertimes.SaturdayOvertimes -
                            compensatedMissingHours.MissingHours;
                        compensatedMissingHours.MissingHours = 0;
                    }
                    else
                    {
                        compensatedMissingHours.CompensatedHours += employeeOvertimes.SaturdayOvertimes;
                        compensatedMissingHours.LeftOvertimes.SaturdayOvertimes = 0;
                        compensatedMissingHours.MissingHours -= employeeOvertimes.SaturdayOvertimes;
                    }
                }

                return compensatedMissingHours;
            }

            private CompensatedMissingHours CompensateHoursFromSundayOvertimes(
                CompensatedMissingHours compensatedMissingHours, Overtimes employeeOvertimes)
            {
                if (compensatedMissingHours.HasHoursToCompensate())
                {
                    if (employeeOvertimes.SundayOvertimes >= compensatedMissingHours.MissingHours)
                    {
                        compensatedMissingHours.CompensatedHours += compensatedMissingHours.MissingHours;
                        compensatedMissingHours.LeftOvertimes.SundayOvertimes = employeeOvertimes.SundayOvertimes -
                            compensatedMissingHours.MissingHours;
                        compensatedMissingHours.MissingHours = 0;
                    }
                    else
                    {
                        compensatedMissingHours.CompensatedHours += employeeOvertimes.SundayOvertimes;
                        compensatedMissingHours.LeftOvertimes.SundayOvertimes = 0;
                        compensatedMissingHours.MissingHours -= employeeOvertimes.SundayOvertimes;
                    }
                }

                return compensatedMissingHours;
            }

            // DRY
            private CompensatedMissingHours CompensateHoursFromSelectedOvertimesType(
                CompensatedMissingHours compensatedMissingHours, Overtimes employeeOvertimes,
                Func<Overtimes, decimal> getOvertimesType, Action<Overtimes, decimal> setOvertimesType)
            {
                if (compensatedMissingHours.HasHoursToCompensate())
                {
                    if (getOvertimesType(employeeOvertimes) >= compensatedMissingHours.MissingHours)
                    {
                        compensatedMissingHours.CompensatedHours += compensatedMissingHours.MissingHours;

                        var leftOvertimes = getOvertimesType(employeeOvertimes) - compensatedMissingHours.MissingHours;
                        setOvertimesType(compensatedMissingHours.LeftOvertimes, leftOvertimes);

                        compensatedMissingHours.MissingHours = 0;
                    }
                    else
                    {
                        compensatedMissingHours.CompensatedHours += getOvertimesType(employeeOvertimes);
                        setOvertimesType(compensatedMissingHours.LeftOvertimes, 0);
                        compensatedMissingHours.MissingHours -= getOvertimesType(employeeOvertimes);
                    }
                }

                return compensatedMissingHours;
            }
        }

        private class Overtimes
        {
            public decimal StandardOvertimes { get; set; }
            public decimal SaturdayOvertimes { get; set; }
            public decimal SundayOvertimes { get; set; }

            public Overtimes(decimal standardOvertimes, decimal saturdayOvertimes, decimal sundayOvertimes)
            {
                StandardOvertimes = standardOvertimes;
                SaturdayOvertimes = saturdayOvertimes;
                SundayOvertimes = sundayOvertimes;
            }
        }

        private class CompensatedMissingHours
        {
            public decimal MissingHours { get; set; }
            public decimal CompensatedHours { get; set; }
            public Overtimes LeftOvertimes { get; set; }

            public CompensatedMissingHours(decimal missingHours)
            {
                MissingHours = missingHours;
                CompensatedHours = 0;
                LeftOvertimes = new Overtimes(0, 0, 0);
            }

            public bool HasHoursToCompensate()
            {
                return MissingHours > 0;
            }
        }

        #region Not relevant - tech stuff
        private class Timesheet
        {
            public DateTime Date { get; set; }
            public decimal WorkHours { get; set; }
        }

        private class InsufficientTimesheetWorkHoursException : Exception { }

        private class Employee
        {
            public bool IsActive { get; set; }
        }

        private class Shift { }

        private class EmployeeShift
        {
            public void AddShift(Shift newShift) { }
        }

        private class EmployeeSalaryData { }

        private class AddingShiftToInactiveEmployeeException : Exception { }

        private class EmployeeShiftNotFoundException : Exception { }

        private class EmployeeNotFoundException : Exception { }

        private EmployeeShift GetEmployeeShifts(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        private Employee GetEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        private void ValidateShift(Shift newShift)
        {
            throw new NotImplementedException();
        }

        private void Save(EmployeeShift employeeShifts)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
