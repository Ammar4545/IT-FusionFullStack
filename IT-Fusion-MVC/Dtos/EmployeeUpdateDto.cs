using IT_Fusion_MVC.Models;

namespace IT_Fusion_MVC.Dtos
{
    public class EmployeeUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
    }
}
