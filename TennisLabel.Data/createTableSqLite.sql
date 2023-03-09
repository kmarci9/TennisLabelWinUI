DROP TABLE IF EXISTS OrderDetails;
DROP TABLE IF EXISTS ProductXString;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Strings;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Customers;





CREATE TABLE Customers(
	pk_CustomerID INTEGER PRIMARY KEY AUTOINCREMENT,
	First_name TEXT NOT NULL,
	Last_name TEXT NOT NULL,
	Phone TEXT,
	City TEXT,
	Postal_code INTEGER,
	Country TEXT
);

CREATE TABLE Orders(
	pk_OrderID INTEGER PRIMARY KEY AUTOINCREMENT,
	dt_Order_startdate TEXT,
	dt_Order_enddate TEXT,
	Comments TEXT,
	fk_CustomerID INTEGER,
	CONSTRAINT fk_CustomerID
	FOREIGN KEY (fk_CustomerID)
	REFERENCES Customers(pk_CustomerID)
);

CREATE TABLE Strings(
	pk_StringID INTEGER PRIMARY KEY AUTOINCREMENT,
	StringName TEXT,
	Brand TEXT
);

CREATE TABLE Products(
	pk_ProductID INTEGER PRIMARY KEY AUTOINCREMENT,
	ProductName TEXT,
	Brand TEXT,
	fk_StringID INTEGER,
	CONSTRAINT fk_StringID
	FOREIGN KEY (fk_StringID )
	REFERENCES Strings(pk_StringID)
);

CREATE TABLE OrderDetails (
	fk_OrderID INTEGER,
	fk_ProductID INTEGER, 
	UnitPrice INTEGER,
	Quantity INTEGER,
	foreign key (fk_OrderID) REFERENCES Orders(pk_OrderID),
	foreign key (fk_ProductID) REFERENCES Products(pk_ProductID)
);

CREATE TABLE ProductXString (
	fk_ProductID INTEGER,
	fk_StringID INTEGER, 
	foreign key (fk_ProductID)  REFERENCES Products(pk_ProductID),
	foreign key (fk_StringID)  REFERENCES Strings(pk_StringID)
);