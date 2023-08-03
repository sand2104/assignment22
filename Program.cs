using assignment22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace assignment22
{
    public class Program
    {
        public static void MapProperties(Source source, Destination destination)
        {
            Type sourceType = source.GetType();
            Type destinationType = destination.GetType();

            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            PropertyInfo[] destinationProperties = destinationType.GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                foreach (var destinationProperty in destinationProperties)
                {
                    if (sourceProperty.Name == destinationProperty.Name &&
                        sourceProperty.PropertyType == destinationProperty.PropertyType &&
                        destinationProperty.CanWrite) // Ensure the destination property is writable
                    {
                        destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                        break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Source source = new Source
            {
                FirstName = "Trona",
                LastName = "Cha",
                Age = 17,
                Address = "123 Rusell St"
            };

            Destination destination = new Destination
            {
                FirstName = "Sand",
                LastName = "P",
                Age = 23,
                City = "London",
                Email = "psand@example.com"
            };

            MapProperties(source, destination);

            Console.WriteLine("Destination Properties After Mapping:");
            Console.WriteLine($"First Name: {destination.FirstName}");
            Console.WriteLine($"Last Name: {destination.LastName}");
            Console.WriteLine($"Age: {destination.Age}");
            Console.WriteLine($"City: {destination.City}");
            Console.WriteLine($"Email: {destination.Email}");
        }
    }
}
