create table departments (
    department_id int identity(1,1) primary key,
    department_name varchar(100) unique not null
)
create table employees (
    employee_id int identity(1,1) primary key,
    employee_name varchar(100) not null,
    department_id int not null,
    salary decimal not null,
    email varchar(100) not null ,
    mobile_no varchar(20) not null ,
    joining_date date default getdate(),
constraint fk_department foreign key (department_id) references departments(department_id)
)

create procedure DeleteEmployee
    @EmployeeId INT
    AS
    BEGIN
        DELETE from employees
        where employee_id = @EmployeeId
    end

create procedure AddEmployee  
    @Employee_Name VARCHAR(100),  
    @Department int,  
    @Salary DECIMAL,  
    @Email VARCHAR(100),  
    @Mobile_No VARCHAR(20)  
AS  
BEGIN  
    INSERT INTO employees (Employee_Name, department_id, salary, email, mobile_no)  
    VALUES (@Employee_Name, @Department, @Salary, @Email, @Mobile_No); 
END;

create procedure GetEmployees  
as begin   
select * from employees  
end

create procedure EditEmployee  
    @Employee_ID int,  
    @Employee_Name VARCHAR(100),  
    @Department int,  
    @Salary DECIMAL,  
    @Email VARCHAR(100),  
    @Mobile_No VARCHAR(20)  
AS  
BEGIN  
update employees  
    set  
		--here, we use coalesce() function so that the user isnt forced to change all feilds everytime.
        employee_name = coalesce(@Employee_Name, employee_name),  
        department_id = coalesce(@Department, department_id),  
        salary = coalesce(@Salary,salary),  
        email = coalesce(@Email, email),  
        mobile_no = coalesce(@Mobile_No, mobile_no)  
    where employee_id = @Employee_ID;  
END;

