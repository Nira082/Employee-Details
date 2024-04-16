using EmployeeDetails.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.Models
{
    public class Municipality
    {
        public int MunicipalityId { get; set; }
        public string MunicipalityName { get; set; }
        public int DistrictId { get; set; }
    }
}


