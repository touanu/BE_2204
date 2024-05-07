CREATE TABLE Employees
(
	EmployeeID INT PRIMARY KEY,
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	Position INT,
	DepartmentID INT,
	Salary INT
)

INSERT INTO Employees
VALUES
	(0, 'A', N'Nguyễn Văn', 10, 0, 10000000),
	(1, 'B', N'Nguyễn Thị', 23, 3, 8000000),
	(2, 'C', N'Trần Văn', 29, 3, 20000000),
	(3, 'D', N'Đặng Bá', 17, 2, 9000000),
	(5, 'E', N'Nguyễn Ngọc ', 19, 2, 10000000)

SELECT * FROM Employees
GO

CREATE TABLE Departments
(
	DepartmentID INT PRIMARY KEY,
	DepartmentName NVARCHAR(50)
)

INSERT INTO Departments
VALUES
	(0, N'Hành chính'),
	(1, N'Quản lý nhân sự'),
	(2, N'Vận hành'),
	(3, N'Marketing')

SELECT Employees.LastName + ' ' + Employees.FirstName as N'Họ tên',
	   Departments.DepartmentName as N'Tên phòng ban'
FROM Employees INNER JOIN Departments
ON Employees.DepartmentID = Departments.DepartmentID

SELECT DepartmentID as N'Mã phòng ban', SUM(Salary) as N'Tổng lương'
FROM Employees 
GROUP BY DepartmentID
ORDER BY SUM(Salary) DESC