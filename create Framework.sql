CREATE DATABASE IF NOT EXISTS SuppliersFramework;
USE SuppliersFramework;

CREATE TABLE IF NOT EXISTS Suppliers (
	SupplierID int AUTO_INCREMENT Primary Key NOT NULL,
	Name varchar(100) NOT NULL,
	Address varchar(50) NOT NULL,
	email varchar(50) NOT NULL,
	PhoneNumber char(15) NOT NULL,
    ConcurrencyID int NOT NULL DEFAULT 1);
    
CREATE TABLE IF NOT EXISTS Orders(
	OrderID varchar(50),
	SupplierID int NOT NULL,
	Quantity int NOT NULL,
	OrderTotal decimal(10,4) NOT NULL,
    ConcurrencyID int NOT NULL DEFAULT 1, 
	PRIMARY KEY (SupplierID));  
    
    
    INSERT Suppliers (SupplierID, Name, Address, email, PhoneNumber) VALUES (1, 'Willemtte hops co', '1108 Johanna Bay Drive', 'willemtteHopCO@gmail.com', '158648626');
    INSERT Suppliers (SupplierID, Name, Address, email, PhoneNumber) VALUES (2, 'Life harvest', '1001 main', 'LifeHarvest@gmail.com', '158648626');
    
    
    INSERT Orders (OrderId,SupplierID, Quantity, OrderTotal) VALUES (53256-48626,1 , 15, 150.00);
    INSERT Orders (OrderId,SupplierID, Quantity, OrderTotal) VALUES (54832-48632,2 , 5, 25.00);