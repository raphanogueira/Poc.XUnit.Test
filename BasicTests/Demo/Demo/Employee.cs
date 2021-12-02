using System;
using System.Collections.Generic;

namespace Demo
{
    public abstract class Person
    {
        public string Name { get; protected set; }
        public string LastName { get; set; }
    }

    public sealed class Employee : Person
    {
        public double Salary { get; private set; }
        public ProfessionalTierType ProfessionalTierType { get; private set; }
        public ICollection<string> Habilities { get; private set; }

        public Employee(string name, double salary)
        {
            Name = string.IsNullOrEmpty(name) ? "Fulano" : name;
            SetSalary(salary);
            SetHabilities();
        }

        public void SetSalary(double salary)
        {
            if (salary < 500) throw new Exception("Salario inferior ao permitido");

            Salary = salary;
            if (Salary < 2000) ProfessionalTierType = ProfessionalTierType.Junior;
            else if (Salary >= 2000 && Salary < 8000) ProfessionalTierType = ProfessionalTierType.Pleno;
            else if (Salary >= 8000) ProfessionalTierType = ProfessionalTierType.Senior;
        }

        public void SetHabilities()
        {
            var basicHabilities = new List<string>()
            {
                "Lógica de Programação",
                "OOP"
            };

            Habilities = basicHabilities;

            switch (ProfessionalTierType)
            {
                case ProfessionalTierType.Pleno:
                    Habilities.Add("Testes");
                    break;

                case ProfessionalTierType.Senior:
                    Habilities.Add("Testes");
                    Habilities.Add("Microservices");
                    break;

                default:
                    break;
            }
        }
    }

    public enum ProfessionalTierType
    {
        Junior,
        Pleno,
        Senior
    }

    public sealed class EmployeeFactory
    {
        public static Employee Create(string name, double salary) => new Employee(name, salary);
    }
}