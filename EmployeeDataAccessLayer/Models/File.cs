using System.ComponentModel.DataAnnotations;

namespace EmployeeDataAccessLayer.Models
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
