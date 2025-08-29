namespace SDP.Domain.Dtos
{
    public class EmployeeDto
    {
        public int Empid { get; set; }
        public string Lastname { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Titleofcourtesy { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public DateTime Hiredate { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Postalcode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int Mgrid { get; set; }
    }
}
