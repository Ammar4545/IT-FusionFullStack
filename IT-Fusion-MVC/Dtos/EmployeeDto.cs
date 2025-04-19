namespace IT_Fusion_MVC.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
    }
}
