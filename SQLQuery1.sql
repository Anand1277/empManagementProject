create database EmployeeManagment;
use EmployeeManagment;

CREATE TABLE Employees (
    employee_id INT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    phone_number VARCHAR(15),
    hire_date DATE NOT NULL,
    job_title VARCHAR(50),
    department_id INT,
    FOREIGN KEY (department_id) REFERENCES Departments(department_id)
);

CREATE TABLE Departments (
    department_id INT PRIMARY KEY ,
    department_name VARCHAR(20) NOT NULL,
    manager_id INT  
);


CREATE TABLE Salaries (
    salary_id INT PRIMARY KEY ,
    employee_id INT NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    effective_date DATE NOT NULL,
   
);



CREATE TABLE UserAccounts (
    user_id INT PRIMARY KEY,
    password_hash VARCHAR(255) NOT NULL,

);
use EmployeeManagment;
select * from Employees;





INSERT INTO Departments (department_id, department_name, manager_id) VALUES
(1, 'Engineering', 1),
(2, 'Product', 2),
(3, 'Human Resources', 4),
(4, 'Marketing', 6),
(5, 'Sales', 7);


INSERT INTO Employees (employee_id, first_name, last_name, email, phone_number, hire_date, job_title, department_id) VALUES
(1, 'Alice', 'Smith', 'alice.smith@example.com', '555-0101', '2023-01-15', 'Software Engineer', 1),
(2, 'Bob', 'Johnson', 'bob.johnson@example.com', '555-0102', '2023-02-20', 'Product Manager', 2),
(3, 'Charlie', 'Brown', 'charlie.brown@example.com', '555-0103', '2023-03-25', 'UX Designer', 1),
(4, 'Diana', 'Prince', 'diana.prince@example.com', '555-0104', '2023-04-30', 'HR Specialist', 3),
(5, 'Edward', 'Norton', 'edward.norton@example.com', '555-0105', '2023-05-05', 'Data Analyst', 2),
(6, 'Fiona', 'Green', 'fiona.green@example.com', '555-0106', '2023-06-15', 'Marketing Coordinator', 4),
(7, 'George', 'Miller', 'george.miller@example.com', '555-0107', '2023-07-20', 'Sales Associate', 5),
(8, 'Hannah', 'Moore', 'hannah.moore@example.com', '555-0108', '2023-08-10', 'Project Coordinator', 3),
(9, 'Isaac', 'Taylor', 'isaac.taylor@example.com', '555-0109', '2023-09-01', 'Systems Administrator', 2),
(10, 'Jack', 'Wilson', 'jack.wilson@example.com', '555-0110', '2023-10-01', 'Finance Officer', 4);


INSERT INTO Salaries (salary_id, employee_id, amount, effective_date) VALUES
(1, 1, 80000.00, '2023-01-15'),
(2, 2, 95000.00, '2023-02-20'),
(3, 3, 75000.00, '2023-03-25'),
(4, 4, 60000.00, '2023-04-30'),
(5, 5, 70000.00, '2023-05-05'),
(6, 6, 55000.00, '2023-06-15'),
(7, 7, 48000.00, '2023-07-20'),
(8, 8, 50000.00, '2023-08-10'),
(9, 9, 90000.00, '2023-09-01'),
(10, 10, 65000.00, '2023-10-01');



INSERT INTO UserAccounts (user_id, password_hash) VALUES
(1, 'hashed_password_1'),
(2, 'hashed_password_2'),
(3, 'hashed_password_3'),
(4, 'hashed_password_4'),
(5, 'hashed_password_5'),
(6, 'hashed_password_6'),
(7, 'hashed_password_7'),
(8, 'hashed_password_8'),
(9, 'hashed_password_9'),
(10, 'hashed_password_10');





select * from Employees;

select * from Departments;


select * from Salaries;

select * from UserAccounts;
