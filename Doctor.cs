using System;
using System.Collections.Generic;

namespace HospitalManagementSystem
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = "" ;
        public string Department { get; set; } = "" ;

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Department: {Department}";
        }
    }

    public class DoctorManager
    {
        private List<Doctor> doctors = new List<Doctor>();
        private int doctorIdCounter = 1;

        public void AddDoctor()
        {
            Doctor d = new Doctor();
            d.Id = doctorIdCounter++;

            Console.Write("Enter Name: ");
            d.Name = Console.ReadLine() ! ;

            Console.Write("Enter Department: ");
            d.Department = Console.ReadLine () ! ;

            doctors.Add(d);
            Console.WriteLine("Doctor added successfully!\n");
        }

        public void SearchDoctor()
        {
            Console.Write("Enter Doctor Name or Department: ");
            string input = Console.ReadLine() ! ;
            bool found = false;

            foreach (var d in doctors)
            {
                if (d.Name.Equals(input, StringComparison.OrdinalIgnoreCase) ||
                    d.Department.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(d);
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("Doctor not found.\n");
        }

        public List<Doctor> GetDoctors()
        {
            return doctors;
        }
    }
}
