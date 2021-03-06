/*How to INSERT INTO the Database.
*Remember, cannot use the ID if it is SEEDED
*INSERT INTO Payment (Pay_Type, Pay_CardNum, Pay_ExpDate) VALUES ('VISA', 1234567812345678, '10/01/2015');
*/

/*HOW TO DELETE ALL ROWS
*DELETE FROM Payment WHERE PaymentID > 1;
*/

/*How to RESET the IDENTITY SEED
*ALTER TABLE Payment ALTER COLUMN PaymentID IDENTITY (1,1);
*/

/*
*Changing Data Types
*ALTER TABLE Customer ALTER COLUMN Cust_ZipCode VARCHAR(5);
*/

//Payment Table Inserts, Create Before Customer
INSERT INTO Payment (Pay_Type, Pay_CardNum, Pay_ExpDate) VALUES ('VISA', 1234567812345678, '10/01/2015');
INSERT INTO Payment (Pay_Type, Pay_CardNum, Pay_ExpDate) VALUES ('MASTERCARD', 8765432187654321, '01/01/2016');
INSERT INTO Payment (Pay_Type, Pay_CardNum, Pay_ExpDate) VALUES ('DISCOVER', 1111222233334444, '07/01/2018');
INSERT INTO Payment (Pay_Type, Pay_CardNum, Pay_ExpDate) VALUES ('CHASE', 5555666677778888, '12/01/2014');
 
//AccessCode Table Inserts, Create Before Employee
INSERT INTO AccessCode VALUES ('a', 'Administrator');
INSERT INTO AccessCode VALUES ('m', 'Manager');
INSERT INTO AccessCode VALUES ('s', 'Specialist');
INSERT INTO AccessCode VALUES ('w', 'Worker');
INSERT INTO AccessCode VALUES ('c', 'Clerk');

//Employee Table Inserts
INSERT INTO Employee (AccessCodeID, Emp_FirstName, Emp_LastName, Emp_Email, Emp_UserID, Emp_Password) VALUES ('a', 'Ryan', 'Oftedahl', 'wscadm60683@gmail.com', 'ryan', 'admin');
INSERT INTO Employee (AccessCodeID, Emp_FirstName, Emp_LastName, Emp_Email, Emp_UserID, Emp_Password) VALUES ('a', 'Thomas', 'Ford', 'wscadm60683@gmail.com', 'thomas', 'admin');
INSERT INTO Employee (AccessCodeID, Emp_FirstName, Emp_LastName, Emp_Email, Emp_UserID, Emp_Password) VALUES ('m', 'Jon', 'Hartis', 'wscman60683@gmail.com', 'jon', 'manager');
INSERT INTO Employee (AccessCodeID, Emp_FirstName, Emp_LastName, Emp_Email, Emp_UserID, Emp_Password) VALUES ('m', 'Colby', 'Gauff', 'wscman60683@gmail.com', 'colby', 'manager');
INSERT INTO Employee (AccessCodeID, Emp_FirstName, Emp_LastName, Emp_Email, Emp_UserID, Emp_Password) VALUES ('c', 'Jason', 'Grey', 'wscclerk60683@gmail.com', 'jason', 'clerk');
INSERT INTO Employee (AccessCodeID, Emp_FirstName, Emp_LastName, Emp_Email, Emp_UserID, Emp_Password) VALUES ('w', 'Sean', 'Cooper', 'wscspec60683@gmail.com', 'sean', 'specialist');
INSERT INTO Employee (AccessCodeID, Emp_FirstName, Emp_LastName, Emp_Email, Emp_UserID, Emp_Password) VALUES ('s', 'Chris', 'Newby', 'wscsales60683@gmail.com', 'chris', 'sales');
INSERT INTO Employee (AccessCodeID, Emp_FirstName, Emp_LastName, Emp_Email, Emp_UserID, Emp_Password) VALUES ('s', 'Andy', 'Show', 'wscsales60683@gmail.com', 'andy', 'sales');

//Customer Table Inserts
INSERT INTO Customer (PaymentID, Cust_FirstName, Cust_LastName, Cust_Address, Cust_City, Cust_State, Cust_ZipCode, Cust_Email, Cust_Phone) VALUES (51, 'John', 'Doe', '123 Anywhere St', 'Anytown', 'IA', 12345, 'johndoe@nowhere.com', '1112223333');
INSERT INTO Customer (PaymentID, Cust_FirstName, Cust_LastName, Cust_Address, Cust_City, Cust_State, Cust_ZipCode, Cust_Email, Cust_Phone) VALUES (52, 'Jane', 'Doe', '321 Anywhere St', 'Hometown', 'DC', 54321, 'janedoe@nowhere.com', '4445556666');
INSERT INTO Customer (PaymentID, Cust_FirstName, Cust_LastName, Cust_Address, Cust_City, Cust_State, Cust_ZipCode, Cust_Email, Cust_Phone) VALUES (53, 'Dale', 'Smith', '100 Main St', 'Gametown', 'IL', 22222, 'dalesmith@nowhere.com', '2223334444');
INSERT INTO Customer (PaymentID, Cust_FirstName, Cust_LastName, Cust_Address, Cust_City, Cust_State, Cust_ZipCode, Cust_Email, Cust_Phone) VALUES (54, 'Jane', 'Fonda', '1 Big Time St', 'Hollywood', 'CA', 90210, 'janefonda@bestemail.com', '1234567890');

//Inventory Table Inserts
INSERT INTO Inventory (Inv_Name, Inv_Manufacturer, Inv_Quantity, Inv_QtySold) VALUES ('Gold Watch', 'Mattel', 5, 0);
INSERT INTO Inventory (Inv_Name, Inv_Manufacturer, Inv_Quantity, Inv_QtySold) VALUES ('Silver Watch', 'Mattel', 10, 0);
INSERT INTO Inventory (Inv_Name, Inv_Manufacturer, Inv_Quantity, Inv_QtySold) VALUES ('Bronze Watch', 'Mattel', 15, 0);
INSERT INTO Inventory (Inv_Name, Inv_Manufacturer, Inv_Quantity, Inv_QtySold) VALUES ('Plastic Watch', 'Mattel', 20, 0);
INSERT INTO Inventory (Inv_Name, Inv_Manufacturer, Inv_Quantity, Inv_QtySold) VALUES ('Small Wood Plaque', 'Paul Bunyan Workshop', 10, 0);
INSERT INTO Inventory (Inv_Name, Inv_Manufacturer, Inv_Quantity, Inv_QtySold) VALUES ('Medium Wood Plaque', 'Paul Bunyan Workshop', 5, 0);
INSERT INTO Inventory (Inv_Name, Inv_Manufacturer, Inv_Quantity, Inv_QtySold) VALUES ('Large Wood Plaque', 'Paul Bunyan Workshop', 1, 0);
INSERT INTO Inventory (Inv_Name, Inv_Manufacturer, Inv_Quantity, Inv_QtySold) VALUES ('Small Gold Trophy', 'Circle of Winners', 10, 0);
INSERT INTO Inventory (Inv_Name, Inv_Manufacturer, Inv_Quantity, Inv_QtySold) VALUES ('Medium Gold Trophy', 'Circle of Winners', 5, 0);
INSERT INTO Inventory (Inv_Name, Inv_Manufacturer, Inv_Quantity, Inv_QtySold) VALUES ('Large Gold Trophy', 'Circle of Winners', 1, 0);
INSERT INTO Inventory (Inv_Name, Inv_Manufacturer, Inv_Quantity, Inv_QtySold) VALUES ('Large Shirt', 'Top Line', 5, 0);
INSERT INTO Inventory (Inv_Name, Inv_Manufacturer, Inv_Quantity, Inv_QtySold) VALUES ('Medium Shirt', 'Top Line', 10, 0);
INSERT INTO Inventory (Inv_Name, Inv_Manufacturer, Inv_Quantity, Inv_QtySold) VALUES ('Small Shirt', 'Top Line', 15, 0);
INSERT INTO Inventory (Inv_Name, Inv_Manufacturer, Inv_Quantity, Inv_QtySold) VALUES ('Child Shirt', 'Top Line', 20, 0);