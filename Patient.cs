using System;
using System.Collections.Generic;

namespace HospitalManagementSystem
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Contact { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Age: {Age}, Gender: {Gender}, Contact: {Contact}";
        }
    }

    public class PatientManager
    {
        private List<Patient> patients = new List<Patient>();
        private int patientIdCounter = 1;

        public void AddPatient()
        {
            Patient p = new Patient();
            p.Id = patientIdCounter++;

            Console.Write("Enter Name: ");
            p.Name = Console.ReadLine() ! ;

            Console.Write("Enter Age: ");
            p.Age = int.Parse(Console.ReadLine() ! ) ;

            Console.Write("Enter Gender: ");
            p.Gender = Console.ReadLine() ! ;

            Console.Write("Enter Contact: ");
            p.Contact = Console.ReadLine() ! ;

            patients.Add(p);
            Console.WriteLine("Patient added successfully!\n");
        }

        public void SearchPatient()
        {
            Console.Write("Enter Patient Name or ID: ");
            string input = Console.ReadLine() ! ;
            bool found = false;

            foreach (var p in patients)
            {
                if (!string.IsNullOrEmpty(p.Name) &&
    (p.Name.Equals(input, StringComparison.OrdinalIgnoreCase)
     || p.Id.ToString() == input))

                {
                    Console.WriteLine(p);
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("Patient not found.\n");
        }

        public List<Patient> GetPatients()
        {
            return patients;
        }
    }
}
