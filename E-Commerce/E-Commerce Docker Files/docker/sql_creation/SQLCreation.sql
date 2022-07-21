
Create Database e_commerce
GO

use e_commerce
CREATE TABLE Accounts (
	AccountId int NOT NULL,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50),
	Email varchar(50) NOT NULL,
	Password varchar(50) NOT NULL,
	CardNum BIGINT NOT NULL,
	ExpDate varchar(5) NOT NULL,
	SecurityNum int NOT NULL,
	NameOnCard varchar(50),
	Street varchar(100) NOT NULL,
	Apartment varchar(100),
	City varchar(50) NOT NULL,
	State varchar(2) NOT NULL,
	Zipcode int NOT NULL,
	Primary Key(AccountId)
);
GO
