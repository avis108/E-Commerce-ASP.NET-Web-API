Use E_Comm

INSERT INTO Customers (EmailAddress,Address,CustomerName)VALUES('Ravi@gamil.com','Old-Road,Mumbai','Ravi') 
INSERT INTO Customers (EmailAddress,Address,CustomerName)VALUES('Sham@yahoo.com','Near Old Statue,Delhi','Sham') 

INSERT INTO Orders (Quantity,CreatedDateTime,TotalPrice,ItemName,CustomerID)
VALUES(2,GETDATE(),2230.00,'Sony HeadSets',1)

INSERT INTO Orders (Quantity,CreatedDateTime,TotalPrice,ItemName,CustomerID)
VALUES(1,GETDATE(),150.00,'Mobile Case',1)

INSERT INTO Orders (Quantity,CreatedDateTime,TotalPrice,ItemName,CustomerID)
VALUES(3,GETDATE(),150.00,'Face Masks',2)

INSERT INTO Orders (Quantity,CreatedDateTime,TotalPrice,ItemName,CustomerID)
VALUES(1,GETDATE(),50.00,'HandWash',2)