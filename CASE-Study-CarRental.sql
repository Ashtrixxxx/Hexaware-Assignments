
create Database CASESTUDY

use CASESTUDY

CREATE TABLE Customer(
CustomerID int primary key not null,
FirstName varchar(10),
LastName varchar(10),
Email varchar(30),
PhoneNumber varchar(12),
[Address] varchar(255),
Username varchar(15) UNIQUE,
[Password] varchar(20),
RegistrationDate date

)

CREATE TABLE VEHICLE(
VehicleID INT PRIMARY KEY NOT NULL,
Model VARCHAR(8) ,
Make VARCHAR(25),
[Year]  INT,
Color varchar(10),
RegistrationNumber INT UNIQUE,
[Availability] BIT,
DailyRate decimal
)


CREATE TABLE ReservationTable(
ReservationID INT PRIMARY KEY NOT NULL,
CustomerID INT,
VehicleID INT,
StartDate DATE,
EndDate DATE,
TotalCost DECIMAL,
[Status] varchar(12),
foreign key (CustomerID) references Customer(CustomerID),
foreign key (VehicleID) references VEHICLE (VehicleID)
)

CREATE TABLE AdminTable(
AdminID INT PRIMARY KEY NOT NULL,
FirstName varchar(10),
LastName varchar(10),
Email varchar(30),
PhoneNumber varchar(12),
Username varchar(15) UNIQUE,
[Password] varchar(20),
[Role] varchar(17),--super admin,fleet manager 
JoinDate date
)



-- Inserting sample data into the Customer table
INSERT INTO Customer (CustomerID, FirstName, LastName, Email, PhoneNumber, [Address], Username, [Password], RegistrationDate)
VALUES (1, 'John', 'Doe', 'john.doe@example.com', '1234567890', '123 Main St', 'johndoe123', 'password123', '2023-01-01'),
       (2, 'Jane', 'Smith', 'jane.smith@example.com', '9876543210', '456 Elm St', 'janesmith456', 'password456', '2023-02-01'),
       (3, 'Michael', 'Johnson', 'michael.johnson@example.com', '4567890123', '789 Oak St', 'michael', 'password789', '2023-03-01'),
       (4, 'Emily', 'Brown', 'emily.brown@example.com', '3216549870', '101 Pine St', 'emilybrown101', 'password101', '2023-04-01'),
       (5, 'David', 'Wilson', 'david.wilson@example.com', '7890123456', '222 Maple St', 'davidwilson222', 'password222', '2023-05-01'),
       (6, 'Emma', 'Martinez', 'emma.martinez@example.com', '6543210987', '333 Cedar St', 'emmartinez333', 'password333', '2023-06-01'),
       (7, 'Daniel', 'Taylor', 'daniel.taylor@example.com', '2109876543', '444 Birch St', 'danieltaylor444', 'password444', '2023-07-01'),
       (8, 'Olivia', 'Anderson', 'olivia.anderson@example.com', '7890123456', '555 Oak St', 'olivia555', 'password555', '2023-08-01'),
       (9, 'James', 'Thomas', 'james.thomas@example.com', '1234567890', '666 Pine St', 'jamesthomas666', 'password666', '2023-09-01'),
       (10, 'Sophia', 'Hernandez', 'sophia.hernandez@example.com', '9876543210', '777 Maple St', 'sophiaher777', 'password777', '2023-10-01');

-- Inserting sample data into the VEHICLE table
INSERT INTO VEHICLE (VehicleID, Model, Make, [Year], Color, RegistrationNumber, [Availability], DailyRate)
VALUES (1, 'SUV', 'Toyota', 2020, 'Red', 123456, 1, 50.00),
       (2, 'Sedan', 'Honda', 2021, 'Blue', 654321, 1, 40.00),
       (3, 'Truck', 'Ford', 2019, 'Black', 789012, 1, 60.00),
       (4, 'Van', 'Chevrolet', 2018, 'White', 987654, 1, 55.00),
       (5, 'Coupe', 'Nissan', 2022, 'Silver', 135792, 1, 45.00),
       (6, 'Hatch', 'Volkswagen', 2017, 'Green', 246813, 1, 35.00),
       (7, 'GT', 'BMW', 2023, 'Yellow', 369258, 1, 65.00),
       (8, 'Pickup', 'GMC', 2020, 'Gray', 147258, 1, 70.00),
       (9, 'CROSS', 'Kia', 2021, 'Brown', 258369, 1, 48.00),
       (10, 'Minivan', 'Chrysler', 2019, 'Orange', 159753, 1, 52.00);

-- Inserting sample data into the ReservationTable table
INSERT INTO ReservationTable (ReservationID, CustomerID, VehicleID, StartDate, EndDate, TotalCost, [Status])
VALUES (1, 1, 1, '2023-02-01', '2023-02-05', 200.00, 'Active'),
       (2, 2, 2, '2023-03-10', '2023-03-15', 240.00, 'Active'),
       (3, 3, 3, '2023-04-05', '2023-04-10', 300.00, 'Active'),
       (4, 4, 4, '2023-05-15', '2023-05-20', 260.00, 'Active'),
       (5, 5, 5, '2023-06-20', '2023-06-25', 225.00, 'Active'),
       (6, 6, 6, '2023-07-25', '2023-07-30', 210.00, 'Active'),
       (7, 7, 7, '2023-08-05', '2023-08-10', 280.00, 'Active'),
       (8, 8, 8, '2023-09-10', '2023-09-15', 350.00, 'Active'),
       (9, 9, 9, '2023-10-15', '2023-10-20', 320.00, 'Active'),
       (10, 10, 10, '2023-11-20', '2023-11-25', 300.00, 'Active');

-- Inserting sample data into the AdminTable table
INSERT INTO AdminTable (AdminID, FirstName, LastName, Email, PhoneNumber, Username, [Password], [Role], JoinDate)
VALUES (1, 'Admin', 'Smith', 'admin@example.com', '5551234567', 'admin1', 'adminpassword', 'super admin', '2023-01-01'),
       (2, 'Manager', 'Doe', 'manager@example.com', '5559876543', 'manager1', 'managerpassword', 'fleet manager', '2023-02-01');


select * from Customer
select * from VEHICLE
select * from ReservationTable
select * from AdminTable

/*
Interfaces:
	CustomerService:
• GetCustomerById(customerId)
• GetCustomerByUsername(username)
• RegisterCustomer(customerData)
• UpdateCustomer(customerData)
• DeleteCustomer(customerId)
*/

Declare @id int;

set @id=11;

select * from Customer where CustomerID= @id;

Declare @name varchar(10);
set @name= 'John'
select * from Customer where FirstName=@name

--Register customer

insert into Customer values(11,'Ashwin','S','ashwin94429@gmail.com','7708564861','Coimbatore','Ashtrixx','pass123',getDate());

update Customer set PhoneNumber='7708564866' where CustomerID=11;

Delete from Customer where CustomerID=11;


/*• IVehicleService:
• GetVehicleById(vehicleId)
• GetAvailableVehicles()
• AddVehicle(vehicleData)
• UpdateVehicle(vehicleData)
• RemoveVehicle(vehicleId)
*/
select * from VEHICLE

select * from VEHICLE where VehicleID=1;

select * from VEHICLE where Availability=1;

Insert INTO VEHICLE values(11,'GT350','FORD SHELBY',2022,'BLACK',333423,0,150)

update VEHICLE set Availability = 1 where VehicleID=11;

delete from VEHICLE where VehicleID=11

/*
• IReservationService:
• GetReservationById(reservationId)
• GetReservationsByCustomerId(customerId)
• CreateReservation(reservationData)
• UpdateReservation(reservationData)
• CancelReservation(reservationId)
*/


Select * from ReservationTable
where ReservationID=6;


Select * from ReservationTable
where CustomerID=6;

--create reservation

INSERT INTO ReservationTable VALUES(11,10,3,getDate(),'2025-10-02',900,'Active')

UPDATE ReservationTable set Status='Inactive' where ReservationID=11

delete from ReservationTable where ReservationID=11;

/*
• IAdminService:
• GetAdminById(adminId)
• GetAdminByUsername(username)
• RegisterAdmin(adminData)
• UpdateAdmin(adminData)
• DeleteAdmin(adminId)
*/

select * from AdminTable where AdminID=1;

select * from AdminTable where Username='admin1';

INSERT INTO AdminTable values(3,'Ajith','Kumar','ajith@gmail.com',3928309123,'admin3','adminpass3','super admin',getDate());

update AdminTable set Password='adminpass10' where AdminID=3

delete from AdminTable where AdminID=3







