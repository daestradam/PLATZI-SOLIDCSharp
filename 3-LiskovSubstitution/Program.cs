using Liskov;

CalculateSalaryMonthly(new List<Employee>() {
    new EmployeeFullTime("Pepito Pérez", 160, 10),
    new EmployeeContractor("Manuel Lopera", 180)
});

void CalculateSalaryMonthly(List<Employee> employees) 
{
    foreach (var employee in employees)
    {
        decimal salary = employee.CalculateSalary();
        Console.WriteLine($"The {employee.Fullname}'s salary is {salary}");
        
    }
}