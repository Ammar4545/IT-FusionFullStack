﻿using IT_Fusion_API.Models;
using IT_Fusion_API.Service.IService;
using System.Text.Json;

namespace IT_Fusion_API.Service
{
    public class EmployeeFileService : IEmployeeFileService
    {
        private static readonly string _jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "DataStorage\\Employee.json");
        
        private List<Employee> ReadFromFile()
        {
            if (!File.Exists(_jsonFilePath))
                return new List<Employee>();

            var json = File.ReadAllText(_jsonFilePath);
            return JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();
        }

        private void WriteToFile(List<Employee> employees)
        {
            var json = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonFilePath, json);
        }
        public List<Employee> GetAll() => ReadFromFile();

        public Employee GetById(int id) => ReadFromFile().FirstOrDefault(e => e.Id == id);

        public void Add(Employee employee)
        {
            var employees = ReadFromFile();

            // Ensure the provided Id is not already used
            if (employees.Any(e => e.Id == employee.Id))
                throw new Exception($"Employee with Id {employee.Id} already exists.");

            employees.Add(employee);
            WriteToFile(employees);
        }
        public void Update(int id, Employee updatedEmployee)
        {
            var employees = ReadFromFile();

            var index = employees.FindIndex(e => e.Id == id);
            if (index == -1)
                throw new Exception($"Employee with Id {id} not found.");

            updatedEmployee.Id = id;
            employees[index] = updatedEmployee;

            WriteToFile(employees);
        }

        public void Delete(int id)
        {
            var employees = ReadFromFile();
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
                WriteToFile(employees);
            }
        }

    }
}
