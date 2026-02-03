using System;
using System.Collections.Generic;

namespace HospitalManagementSystem
{
    public class Appointment
    {
        public int Id { get; set; }
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            string patientName = Patient?.Name ?? "Unknown";
            string doctorName = Doctor?.Name ?? "Unknown";
            return $"Appointment ID: {Id}, Patient: {patientName}, Doctor: {doctorName}, Date: {Date}";
        }
    }

    public class AppointmentManager
    {
        private List<Appointment> appointments = new List<Appointment>();
        private int appointmentIdCounter = 1;

        public void BookAppointment(PatientManager pm, DoctorManager dm)
        {
            Console.Write("Enter Patient ID: ");
            if (!int.TryParse(Console.ReadLine(), out int pid))
            {
                Console.WriteLine("Invalid Patient ID.\n");
                return;
            }

            Patient patient = pm.GetPatients().Find(p => p.Id == pid)!;
            if (patient == null)
            {
                Console.WriteLine("Patient not found.\n");
                return;
            }

            Console.Write("Enter Doctor ID: ");
            if (!int.TryParse(Console.ReadLine(), out int did))
            {
                Console.WriteLine("Invalid Doctor ID.\n");
                return;
            }

            Doctor doctor = dm.GetDoctors().Find(d => d.Id == did) !;
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.\n");
                return;
            }

            Console.Write("Enter Appointment Date (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("Invalid date format.\n");
                return;
            }

            Appointment ap = new Appointment
            {
                Id = appointmentIdCounter++,
                Patient = patient,
                Doctor = doctor,
                Date = date
            };

            appointments.Add(ap);
            Console.WriteLine("Appointment booked successfully!\n");
        }

        public void ListAppointments()
        {
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments scheduled.\n");
                return;
            }

            foreach (var a in appointments)
                Console.WriteLine(a);
        }

        public void CancelAppointment()
        {
            Console.Write("Enter Appointment ID to cancel: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Appointment ID.\n");
                return;
            }

            var ap = appointments.Find(a => a.Id == id);

            if (ap != null)
            {
                appointments.Remove(ap);
                Console.WriteLine("Appointment canceled.\n");
            }
            else
                Console.WriteLine("Appointment not found.\n");
        }
    }
}
