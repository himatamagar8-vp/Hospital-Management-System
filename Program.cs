using System;

namespace HospitalManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            PatientManager pm = new PatientManager();
            DoctorManager dm = new DoctorManager();
            AppointmentManager am = new AppointmentManager();

            while (true)
            {
                Console.WriteLine("=== Hospital Management System ===");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Search Patient");
                Console.WriteLine("3. Add Doctor");
                Console.WriteLine("4. Search Doctor");
                Console.WriteLine("5. Book Appointment");
                Console.WriteLine("6. List Appointments");
                Console.WriteLine("7. Cancel Appointment");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine() ! ;

                switch (choice)
                {
                    case "1": pm.AddPatient(); break;
                    case "2": pm.SearchPatient(); break;
                    case "3": dm.AddDoctor(); break;
                    case "4": dm.SearchDoctor(); break;
                    case "5": am.BookAppointment(pm, dm); break;
                    case "6": am.ListAppointments(); break;
                    case "7": am.CancelAppointment(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice.\n"); break;
                }
            }
        }
    }
}

