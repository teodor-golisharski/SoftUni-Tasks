using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            Console.WriteLine(RemoveTown(dbContext));
        }

        //Problem 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .ToArray();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} {item.MiddleName}{item.Department} {item.JobTitle} {item.Salary:f2}");
            }

            return sb.ToString().TrimEnd();

        }

        //Problem 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.FirstName)
                .Where(e => e.Salary > 50000)
                .ToArray();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} - {item.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Where(e => e.Department.Name == "Research and Development")
                .ToArray();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} from Research and Development - ${item.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            string text = "Vitoshka 15";

            Address newAddress = new Address()
            {
                AddressText = text,
                TownId = 4
            };

            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");
            employee!.Address = newAddress;

            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address!.AddressText)
                .ToArray();

            return string.Join(Environment.NewLine, employees);
        }

        //Problem 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                //.Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 &&ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager!.FirstName,
                    ManagerLastName = e.Manager!.LastName,
                    Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            EndDate = ep.Project.EndDate.HasValue
                                ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                : "not finished"

                        })
                        .ToArray()

                })
                .ToArray();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - Manager: {item.ManagerFirstName} {item.ManagerLastName}");
                foreach (var p in item.Projects)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        //Problem 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
               .OrderByDescending(a => a.Employees.Count())
               .ThenBy(a => a.Town!.Name)
               .ThenBy(a => a.AddressText)
               .Take(10)
               .Select(a => new
               {
                   Text = a.AddressText,
                   Town = a.Town!.Name,
                   EmployeesCount = a.Employees.Count
               })
               .ToArray();

            foreach (var item in addresses.ToList())
            {
                sb.AppendLine($"{item.Text}, {item.Town} - {item.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 9
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            //var employee = context.Employees.Find(147);

            //sb.AppendLine($"{employee!.FirstName} {employee.LastName} - {employee.JobTitle}");

            //var employeeProjects = employee.EmployeesProjects
            //    .Select(x => x.Project.Name)
            //    .OrderBy(x => x)
            //    .ToArray();

            //sb.Append(string.Join(Environment.NewLine, employeeProjects));

            var employee = context.Employees.Find(147);
            sb.AppendLine($"{employee!.FirstName} {employee.LastName} - {employee.JobTitle}");

            var data = context.EmployeesProjects
                .Where(x => x.Employee == employee)
                .OrderBy(x => x.Project.Name)
                .Select(x => x.Project.Name)
                .ToArray();

            sb.Append(string.Join(Environment.NewLine, data));

            return sb.ToString().Trim();
        }

        //Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => $"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}\n"
                    + string.Join(Environment.NewLine, d.Employees
                            .OrderBy(d => d.FirstName)
                            .ThenBy(d => d.LastName)
                            .Select(d => $"{d.FirstName} {d.LastName} - {d.JobTitle}")));

            return string.Join(Environment.NewLine, departments);
        }

        //Problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .ToArray();

            foreach (var item in projects.OrderBy(x => x.Name))
            {
                sb.AppendLine(item.Name);
                sb.AppendLine(item.Description);
                sb.AppendLine(item.StartDate.ToString());
            }

            return sb.ToString().Trim();
        }

        //Problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            HashSet<string> departments = new HashSet<string>()
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };

            var employees = context.Employees
           .Where(e => departments.Contains(e.Department.Name))
           .OrderBy(e => e.FirstName)
           .ThenBy(e => e.LastName)
           .ToArray();

            employees.ToList().ForEach(e => e.Salary = e.Salary * 1.12M);

            context.SaveChanges();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} (${item.Salary:f2})");
            }

            return sb.ToString().Trim();
        }

        //Problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            
            var employees = context.Employees
                .Where(e => e.FirstName.Substring(0, 2) == "Sa")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - {item.JobTitle} - (${item.Salary:f2})");
            }

            return sb.ToString().Trim();
        }

        //Problem 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            IQueryable<EmployeeProject> employees = context.EmployeesProjects
                .Where(e => e.ProjectId == 2);

            context.EmployeesProjects.RemoveRange(employees);
            
            var project = context.Projects.Find(2);
                
            context.Projects.Remove(project!);

            context.SaveChanges();

            var data = context.Projects
                .Take(10)
                .Select(x => x.Name)
                .ToArray();

            return string.Join(Environment.NewLine, data);
        }

        //Problem 15
        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .FirstOrDefault(x => x.Name == "Seattle");

            int id = town!.TownId;

            foreach (var item in context.Employees
                .Where(e => e.Address!.TownId == id)
                .ToArray())
            {
                item.Address = null;
            }

            var addresses = context.Addresses
                .Where(x => x.TownId == id)
                .ToArray();

            int count = addresses.Count();

            context.Addresses
                .RemoveRange(addresses);

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{count} addresses in Seattle were deleted";
        }
    }
}