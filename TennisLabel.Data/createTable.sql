DROP TABLE IF EXISTS OrderDetails;
DROP TABLE IF EXISTS ProductXString;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Strings;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Customers;





CREATE TABLE Customers(
	pk_CustomerID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	First_name NVARCHAR(300),
	Last_name NVARCHAR(300),
	Phone NVARCHAR(15),
	City NVARCHAR(100),
	Postal_code INT,
	Country NVARCHAR(100)
);

CREATE TABLE Orders (
	pk_OrderID INT PRIMARY KEY,
	Order_startdate DATE,
	Order_enddate DATE,
	Comments NVARCHAR(3000),
	fk_CustomerID INT REFERENCES Customers(pk_CustomerID),
);

CREATE TABLE Strings(
	pk_StringID INT PRIMARY KEY,
	StringName NVARCHAR(500),
	Brand NVARCHAR(500),
	
);

CREATE TABLE Products(
	pk_ProductID INT PRIMARY KEY,
	ProductName NVARCHAR(500),
	Brand NVARCHAR(500),
	fk_StringID INT REFERENCES Strings(pk_StringID)
	
);

CREATE TABLE OrderDetails (
	fk_OrderID INT REFERENCES Orders(pk_OrderID),
	fk_ProductID INT REFERENCES Products(pk_ProductID),
	UnitPrice INT,
	Quantity INT,
);

CREATE TABLE ProductXString (
	fk_ProductID INT REFERENCES Products(pk_ProductID),
	fk_StringID INT REFERENCES Strings(pk_StringID),
)





