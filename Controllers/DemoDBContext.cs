using System.Reflection;
using CRUD_MVC;
using Microsoft.EntityFrameworkCore;
namespace Entity
{
    class DemoDbContext : DbContext
    {
        public DbSet<EmployeeModel> EmployeeModel { get; set; }
        public DbSet<DepartmentModel> DepartmentModel { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= DESKTOP-224OMT8 ;Initial catalog=EntityDB;Integrated Security=True;TrustServerCertificate=True;");
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<DepartmentModel>().ToTable("DepartmentModel", "dbo").HasKey(x => x.ID);

            modelBuilder.Entity<EmployeeModel>().ToTable("EmployeeModel", "dbo").HasKey(x => x.ID);

            modelBuilder.Entity<DepartmentModel>().HasMany<EmployeeModel>(x => x.EmployeeModel).WithOne(x => x.DepartmentModel).HasForeignKey(x => x.Dept_ID);

        }
        public void ShowData()
        {
            int showInput = 0;
            System.Console.WriteLine("Press 1 to display from department table");
            System.Console.WriteLine("Press 2 to display from employee table");
            System.Console.WriteLine("Enter your choice:");
            showInput = Convert.ToInt32(Console.ReadLine());

            switch (showInput)
            {
                case 1:
                    foreach (var item in DepartmentModel)
                    {
                        System.Console.WriteLine($"ID : {item.ID}  , Name : {item.Dept_Name} ");
                    }
                    break;
                case 2:
                    foreach (var item in EmployeeModel)
                    {
                        System.Console.WriteLine($"ID : {item.ID} , FirstName : {item.First_Name} , LastName : {item.Last_name} , Department_ID : {item.Dept_ID} , Address : {item.Address} , City : {item.City} , State : {item.State}");
                    }
                    break;
                default:
                    InvalidInputMessage();
                    break;
            }

        }

        public void AddData()
        {
            int addInput = 0;
            System.Console.WriteLine("Press 1 to add from department table");
            System.Console.WriteLine("Press 2 to add from employee table");
            System.Console.WriteLine("Enter your choice:");
            addInput = Convert.ToInt32(Console.ReadLine());

            switch (addInput)
            {
                case 1:
                    var newDepartment = new DepartmentModel();
                    System.Console.WriteLine("Enter Department values:");
                    System.Console.WriteLine("Enter Department Name");
                    newDepartment.Dept_Name = Console.ReadLine();
                    Add(newDepartment);
                    SaveChanges();
                    SuccessMessage();
                    break;
                case 2:
                    var newEmployee = new EmployeeModel();
                    System.Console.WriteLine("Enter Employee values:");
                    System.Console.WriteLine("Enter First Name");
                    newEmployee.First_Name = Console.ReadLine();
                    System.Console.WriteLine("Enter Last Name");
                    newEmployee.Last_name = Console.ReadLine();
                    System.Console.WriteLine("Enter Department Name");
                    string departmentName = Console.ReadLine();
                    var department = DepartmentModel.FirstOrDefault(x => x.Dept_Name == departmentName);
                    if (department == null)
                    {
                        department = new DepartmentModel() { Dept_Name = departmentName };
                        DepartmentModel.Add(department);
                        SaveChanges();
                        newEmployee.Dept_ID = department.ID;
                    }
                    else
                    {
                        newEmployee.Dept_ID = department.ID;
                    }
                    System.Console.WriteLine("Enter Address");
                    newEmployee.Address = Console.ReadLine();
                    System.Console.WriteLine("Enter City");
                    newEmployee.City = Console.ReadLine();
                    System.Console.WriteLine("Enter State");
                    newEmployee.State = Console.ReadLine();

                    Add(newEmployee);
                    SaveChanges();
                    SuccessMessage();
                    break;
                case 3:

                    break;
                default:
                    InvalidInputMessage();
                    break;
            }
        }
        public void UpdateData()
        {
            int updateInput = 0;
            System.Console.WriteLine("Press 1 to update from department table");
            System.Console.WriteLine("Press 2 to update from employee table");
            System.Console.WriteLine("Enter your choice:");
            updateInput = Convert.ToInt32(Console.ReadLine());

            switch (updateInput)
            {
                case 1:
                    var UpdateDepartment = new DepartmentModel();
                    System.Console.WriteLine("Enter ID where you want to update Name");
                    UpdateDepartment.ID = Convert.ToInt32(Console.ReadLine());
                    System.Console.WriteLine("Enter New Department Name to Update");
                    UpdateDepartment.Dept_Name = Console.ReadLine();
                    DepartmentModel.Update(UpdateDepartment);
                    SaveChanges();
                    SuccessMessage();
                    break;
                case 2:
                    var UpdateEmployee = new EmployeeModel();
                    System.Console.WriteLine("Enter ID where you want to update Name");
                    UpdateEmployee.ID = Convert.ToInt32(Console.ReadLine());
                    System.Console.WriteLine("Enter new First Name");
                    UpdateEmployee.First_Name = Console.ReadLine();
                    System.Console.WriteLine("Enter new Last Name");
                    UpdateEmployee.Last_name = Console.ReadLine();
                    System.Console.WriteLine("Enter new Department ID");
                    UpdateEmployee.Dept_ID = Convert.ToInt32(Console.ReadLine());
                    System.Console.WriteLine("Enter new Address");
                    UpdateEmployee.Address = Console.ReadLine();
                    System.Console.WriteLine("Enter new City");
                    UpdateEmployee.City = Console.ReadLine();
                    System.Console.WriteLine("Enter new State");
                    UpdateEmployee.State = Console.ReadLine();
                    EmployeeModel.Update(UpdateEmployee);
                    SaveChanges();
                    SuccessMessage();
                    break;
                default:
                    InvalidInputMessage();
                    break;
            }
        }
        public void SuccessMessage()
        {
            System.Console.WriteLine("Task Performed Successfully");
        }
        public void InvalidInputMessage()
        {
            System.Console.WriteLine("Please Enter A Valid Input!!!!");
        }
    }
}