IF EXISTS (SELECT name FROM sys.databases WHERE name = 'EmployeeManagement')
BEGIN
    ALTER DATABASE EmployeeManagement SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    use master;
	DROP DATABASE EmployeeManagement;
END
GO

CREATE DATABASE EmployeeManagement;
GO

use EmployeeManagement;
GO

create table Position(
	Id int constraint PK_Position_Id primary key not null,
	Title varchar(255) not null
)

create table Employee(
	Id int constraint PK_Employee_Id primary key,
	FirstName varchar(255) not null,
	LastName varchar(255) not null,
	Position int not null constraint FK_Employee_To_Position foreign key references Position(Id)
)

INSERT INTO Position (Id, Title)
VALUES
(1, '��������'),
(2, '����������'),
(3, '���������');

INSERT INTO Employee (Id, FirstName, LastName, Position)
VALUES
(1, '����', '������', 1),
(2, '����', '������', 2),
(3, '��������', '��������', 3),
(4, '���������', '�������', 1),
(5, '�����', '���������', 2),
(6, '�������', '�������', 3);