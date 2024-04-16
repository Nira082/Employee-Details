using System.Data.SqlClient;
using System.IO.Pipelines;

namespace EmployeeDetails.Models
{
    public class  EmployeeDataContext
    {
        ///(List part for Employees)
        public List<Employees> GetEmployees()
        {
            SqlConnection conn = new SqlConnection("Data Source=NIRA; User Id=sa; Password=Khanalnira; Initial Catalog= EmployeeDetails");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select e.EmployeeId,e.EmployeeName,e.MobileNumber,e.Tole,e.WardNumber,d.DistrictName,m.MunicipalityName from dbo.Employees e\r\nINNER JOIN Districts d  ON e.DistrictId = d.DistrictId\r\nINNER JOIN Municipalities m  ON e.MunicipalityId = m.MunicipalityId";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employees> result = new List<Employees>();
            while (reader.Read())
            {
                var employees = new Employees();
                employees.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                if (reader["EmployeeName"] != null && reader["EmployeeName"] != DBNull.Value)
                    employees.EmployeeName = reader["EmployeeName"].ToString();
                employees.WardNumber = Convert.ToInt32(reader["WardNumber"]);
                employees.MobileNumber = reader["MobileNumber"].ToString();
                if (reader["Tole"] != null && reader["Tole"] != DBNull.Value)
                    employees.Tole  =reader["Tole"].ToString();
                employees.WardNumber = Convert.ToInt32(reader["WardNumber"]);
                employees.DistrictName = reader["DistrictName"].ToString();
                employees.MunicipalityName = reader["MunicipalityName"].ToString();
                result.Add(employees);
            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return result;
        }
        ///(Read part for Employees)
        public Employees GetEmployee(int MunicipalityId)
        {
            SqlConnection conn = new SqlConnection("Data Source=NIRA; User Id=sa; Password=Khanalnira; Initial Catalog=EmployeeDetails");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from dbo.Employees Where MunicipalityId = @MunicipalityId";
            cmd.Parameters.Add(new SqlParameter("@MunicipalityId", MunicipalityId));
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Employees emp = new Employees();
            while (reader.Read())
            {
                if (reader["EmployeeName"] != null && reader["EmployeeName"] != DBNull.Value)
                    emp.EmployeeName = reader["EmployeeName"].ToString();
                if (reader["MobileNumber"] != null && reader["MobileNumber"] != DBNull.Value)
                    emp.MobileNumber = reader["MobileNumber"].ToString();              
                if (reader["Tole"] != null && reader["Tole"] != DBNull.Value)
                    emp.Tole =  reader["Tole"].ToString();
                emp.WardNumber = Convert.ToInt32(reader["WardNumber"]);
                emp.MunicipalityId = Convert.ToInt32(reader["MunicipalityId"]);

            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return emp;
        }
        ///(Create part for Employees)
        public void CreateEmployees(Employees model)
        {
            SqlConnection conn = new SqlConnection("Data Source=NIRA; User ID=sa; Password=Khanalnira; Initial Catalog=EmployeeDetails");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"Insert into dbo.Employees(EmployeeName,MobileNumber,DistrictId,MunicipalityId,Tole,WardNumber)
                                                                values(@EmployeeName,@MobileNumber,@DistrictId,@MunicipalityId,@Tole,@WardNumber)";
            cmd.Parameters.Add(new SqlParameter("@EmployeeName", model.EmployeeName));
            cmd.Parameters.Add(new SqlParameter("@MobileNumber", model.MobileNumber));
            cmd.Parameters.Add(new SqlParameter("@DistrictId", model.DistrictId));
            cmd.Parameters.Add(new SqlParameter("@MunicipalityId", model.MunicipalityId));
            cmd.Parameters.Add(new SqlParameter("@Tole", model.Tole));
            cmd.Parameters.Add(new SqlParameter("@WardNumber", model.WardNumber));
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }
        ///(Update part for Employees)
        public void updateEmployees(Employees model)
        {
            SqlConnection conn = new SqlConnection("Data Source=NIRA; User Id=sa; Password=Khanalnira; Initial Catalog=EmployeeDetails");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"Updata dbo.EmployeeDetails Set
                                            EmployeeName=@EmployeeName,
                                            MobileNumber=@MobileNumber,
                                            MunicipalityId=@MunicipalityId,
                                            Tole=@Tole,
                                            WardNumber=@WardNumber
                                            Where EmployeeId = @EmployeeId";
            cmd.Parameters.Add(new SqlParameter("@EmployeeId", model.EmployeeId));
            cmd.Parameters.Add(new SqlParameter("@EmployeeName", model.EmployeeName));
            cmd.Parameters.Add(new SqlParameter("@MobileNumber", model.MobileNumber));
            cmd.Parameters.Add(new SqlParameter("@MunicipalityId", model.MunicipalityId));
            cmd.Parameters.Add(new SqlParameter("@Tole", model.Tole));
            cmd.Parameters.Add(new SqlParameter("@WardNumber", model.WardNumber));
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }
        ///(delete part for Employees)
        public void DeleteEmployees(int EmployeeId)
        {
            SqlConnection conn = new SqlConnection("Data Source=NIRA; User Id=sa; Password=Khanalnira; Initial Catalog=EmployeeDetails");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"Delete from dbo.Employees where EmployeeId = @EmployeeId";
            cmd.Parameters.Add(new SqlParameter("@EmployeeId", EmployeeId));
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }

        public List<District> GetDistrict()
        {
            SqlConnection conn = new SqlConnection("Data Source=NIRA; User Id=sa; Password=Khanalnira; Initial Catalog= EmployeeDetails");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from [dbo].[Districts]";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<District> result = new List<District>();
            while (reader.Read())
            {
                var districts = new District();
                districts.DistrictId = Convert.ToInt32(reader["DistrictId"]);
                districts.DistrictName =reader["DistrictName"].ToString();
                result.Add(districts);
            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return result;
        }

        public List<Municipality> GetMunicipalitiesByDistrictId(int DistrictId)
        {
            SqlConnection conn = new SqlConnection("Data Source=NIRA; User Id=sa; Password=Khanalnira; Initial Catalog= EmployeeDetails");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from dbo.Municipalities where DistrictId = "+ DistrictId;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Municipality> result = new List<Municipality>();
            while (reader.Read())
            {
                var municipality = new Municipality();
                municipality.MunicipalityId = Convert.ToInt32(reader["MunicipalityId"]);
                municipality.MunicipalityName = reader["MunicipalityName"].ToString();
                municipality.DistrictId = Convert.ToInt32(reader["DistrictId"]);
                result.Add(municipality);
            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return result;
        }
    }
}






