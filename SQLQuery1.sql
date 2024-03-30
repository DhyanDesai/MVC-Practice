create database EntityDB;

use EntityDB;

create table DepartmentModel(ID int primary Key  identity(1,1),
Dept_Name varchar(20));


Create table EmployeeModel(ID int primary key identity(1,1),
First_Name varchar(20),
Last_name varchar(20),
Dept_ID int references DepartmentModel(ID),
Address varchar(20),
City varchar(20),
State varchar(20)
);

select * from DepartmentModel;
select * from EmployeeModel;