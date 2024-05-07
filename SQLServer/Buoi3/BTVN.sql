CREATE DATABASE LibraryDB
GO
USE LibraryDB

CREATE TABLE Authors
(
	AuthorID INT PRIMARY KEY,
	AuthorName NVARCHAR(100),
	Country NVARCHAR(50),
)

CREATE TABLE Books
(
	BookID INT PRIMARY KEY,
	BookName NVARCHAR(100),
	AuthorID INT,
	Tag NVARCHAR(50),
	Price INT,
	Stock INT,
	FOREIGN KEY(AuthorID) REFERENCES Authors(AuthorID)
)

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY,
	OrderDate DateTime,
	CustomerName NVARCHAR(50),
	AddressStreet NVARCHAR(30),
	AddressVillage NVARCHAR(30),
	AddressDistrict NVARCHAR(30),
	AddressCity NVARCHAR(30),
	AddressCountry NVARCHAR(50),
	TotalPrice INT
)

CREATE TABLE OrderDetails
(
	ODID INT PRIMARY KEY,
	OrderID INT,
	BookID INT,
	Quantity INT,
	Price INT
	FOREIGN KEY(OrderID) REFERENCES Orders(OrderID),
	FOREIGN KEY(BookID) REFERENCES Books(BookID)
)
