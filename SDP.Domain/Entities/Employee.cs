using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDP.Domain.Entities
{
    [Table(name: "Employees", Schema ="HR")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string TitleOfCourtesy { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int? MgrId { get; set; }
    }
}
