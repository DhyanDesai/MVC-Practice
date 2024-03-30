namespace CRUD_MVC
{
    class DepartmentModel
    {
        public int ID { get; set; }
        public string? Dept_Name { get; set; }

        public List<EmployeeModel>? EmployeeModel{get;set;}
    }
}