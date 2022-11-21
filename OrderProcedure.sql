DELIMITER // 
CREATE PROCEDURE usp_SupplierCreate (out SupplierID int, in Name varchar(100), in Address varchar(50), in email varchar(50), in PhoneNumber char(15))
BEGIN
	Insert into suppliers (SupplierID, Name, Address, email,PhoneNumber, concurrencyid)
    Values (SupplierID, Name, Address, email, PhoneNumber, 1);
    Select LAST_INSERT_ID() into SupplierID;
    
END //
DELIMITER ; 
DELIMITER // 
CREATE PROCEDURE usp_OrderSelect (in uspSupplierID int)
BEGIN
	Select * from Orders where OrderID = uspSupplierID;
END //
DELIMITER;


DELIMITER // 
CREATE PROCEDURE usp_supplierDelete (in uspSupplierID int, in conCurrId int)
BEGIN
	Delete from suppliers where SupplierID = uspSupplierID and ConcurrencyID = conCurrId;
END //
DELIMITER ; 

DELIMITER // 
CREATE PROCEDURE usp_SupplierSelectAll ()
BEGIN
	Select * from suppliers order by SupplierID;
END //
DELIMITER ;

DELIMITER // 
CREATE PROCEDURE usp_SupplierUpdate (in uspsupplierID int, in uspName char(100),in uspAddress Varchar(50),in uspemail varchar(50),in uspPhoneNumber char(15), in conCurrId int)
BEGIN
	Update suppliers
    Set SupplierID = uspsupplierID, Name = uspName, Address = uspAddress, email = uspemail, Phonenumber = uspPhoneNumber , concurrencyid = (concurrencyid + 1)
    Where SupplierID = uspsupplierID and concurrencyid = conCurrId;
END //
DELIMITER ;
