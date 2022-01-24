using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPlayGround.Patterns
{
    public static class FluentInterfacePattern
    {
        public static void Run()
        {
            Console.WriteLine("Fluent Interface Pattern\n--------------------------\n");

            Customer customer = new Customer();
            customer.AddName("Hakan").AddSurname("Eren").AddEmail("xxx@gmail.com").AddAge(30);

            Console.WriteLine(customer);
        }
    }

    public class Customer 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public Customer AddName(string name) 
        {
            Name = name;
            return this;
        }


        public Customer AddSurname(string surname)
        {
            Surname = surname;
            return this;
        }

        public Customer AddEmail(string email)
        {
            Email = email;
            return this;
        }

        public Customer AddAge(int age)
        {
            Age = age;
            return this;
        }

        public override string ToString()
        {
            return $"Name = {Name} - Surname = {Surname} - Email = {Email} - Age = {Age}";
        }
    }
}
