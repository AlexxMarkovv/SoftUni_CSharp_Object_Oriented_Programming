﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
    }

    public string FirstName
    {
        get => firstName; 
        set
        {
            if (value != null && value.Length < 3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }

            firstName = value;
        }
    }

    public string LastName
    {
        get => lastName;
        set
        {
            if (value != null && value.Length < 3)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }

            lastName = value;
        }
    }

    public int Age
    {
        get => age;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }

            age = value;
        }
    }

    public decimal Salary
    {
        get => salary;
        set
        {
            if (value < 650)
            {
                throw new ArgumentException("Salary cannot be less than 650 leva!");
            }

            salary = value;
        }
    }

    //Andrew Williams receives 2640.00 leva.
    public override string ToString()
    {
        return $"{FirstName} {LastName} receives {Salary:F2} leva.";
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (Age < 30)
        {
            percentage /= 2;
            Salary += Salary * percentage / 100;
        }
        else
        {
            Salary += Salary * percentage / 100;
        }
    }
}

