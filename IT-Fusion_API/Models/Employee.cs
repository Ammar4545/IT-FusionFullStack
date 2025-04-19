using System.Reflection;

namespace IT_Fusion_API.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public Gender Gender { get; set; }  
        public string Phone { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
