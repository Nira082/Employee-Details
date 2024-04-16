using EmployeeDetails.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.Models
{
    public class Employees
    {
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string Tole { get; set; }
        [Required]
        public int WardNumber { get; set; }
        [Required]
        public int DistrictId { get; set; }
        [Required]
        public int MunicipalityId { get; set; }
        public string? DistrictName { get; set; }
        public string? MunicipalityName { get; set; }

    }

}

