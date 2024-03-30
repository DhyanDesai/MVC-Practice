namespace CRUD_MVC
{
    class EmployeeModel
    {
        public int ID { get; set; }
        public string? First_Name { get; set; }
        public string? Last_name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public DepartmentModel DepartmentModel{get;set;}
        public int Dept_ID { get; set; }
    }
}