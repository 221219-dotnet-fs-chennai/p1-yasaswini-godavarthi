CREATE DATABASE EmployeeDb;

CREATE TABLE Department(
    Dept_ID int PRIMARY KEY,
    FullName VARCHAR(25),
    Locations VARCHAR(20)
);

CREATE TABLE Employee(
    Id int PRIMARY KEY,
    FirstName VARCHAR(25),
    LastName VARCHAR(25),
    SSN bigint,
    DeptId int FOREIGN KEY REFERENCES Department(Dept_ID)
);

CREATE TABLE Employee_Details(
    Id int PRIMARY KEY,
    Emp_id int FOREIGN KEY REFERENCES Employee(Id),
    Salery int ,
    AddressLine1 varchar(20),
    AddressLine2 varchar(20),
    City VARCHAR(20),
    State VARCHAR(20),
    Country VARCHAR(20)
)

INSERT into Department VALUES(111,'Developer','Chennai'),(112,'Tester','Banglore'),(113,'Marketing','Banglore');

select * from Department;

INSERT into Employee VALUES(1234,'yash','aswini',125478963,112),(2134,'priya','xyz',154236879,113),(2345,'ram','allu',154869237,111);

select * from Employee;

INSERT into Employee_Details VALUES(220,2134,25000,'main line','hightech city','hyd','Telangana','India'),
(215,2345,27000,'it park','ragiv gandhi road','chennai','Tamil nadu','India'),
(219,1234,25000,'cross road','near gardens','Bangalore','Karnataka','India');

select * from Employee_Details;

INSERT into Employee VALUES(1675,'Tina','smith',152486973,113);
INSERT into Employee_Details VALUES(211,1675,27000,'it park','food city','chennai','karanataka','India');
 
---- total salery ------
select sum(Salery) as 'Total salery' from Employee_Details as ed
inner join Employee e  on ed.Emp_id =  e.Id
INNER JOIN Department d on d.Dept_ID = e.DeptId
where d.FullName like 'Marketing';

---- total employees ----

select Count(e.Id) as 'Total_employees',d.FullName as 'Department' from Employee e inner join Department d on d.Dept_ID=e.DeptId GROUP by d.FullName;

-----increasing salery of tine ------

UPDATE Employee_Details set Salery = 90000 from Employee e inner join Employee_Details ed on e.Id = ed.Emp_id where e.FirstName='Tina'; 

SELECT * from Employee_Details;
 
------ Marketing employee names----

select FirstName,LastName from Employee inner join Department on Employee.DeptiD = Department.Dept_Id where Fullname ='Marketing';


