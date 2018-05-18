Use [Online Railway Reservation System]
GO

CREATE TABLE AdminUser (
	UserID int NOT NULL PRIMARY KEY IDENTITY(1, 1), 						
	UserCNIC varchar(15) NOT NULL,
	FullName varchar(30) NOT NULL,
	Email varchar(20) NOT NULL,
	PWD varchar(25) NOT NULL,
	PhoneNumber varchar(15) NOT NULL,
	Role char(1) NOT NULL,
);

CREATE TABLE Passenger (
	PassengerID int NOT NULL PRIMARY KEY IDENTITY(1, 1), 						
	PassengerCNIC varchar(15) NOT NULL,
	FullName varchar(30) NOT NULL,
	UserID int NOT NULL,
	FOREIGN KEY (UserID) REFERENCES AdminUser(UserID)
);

CREATE TABLE Ticket (
	TicketID int NOT NULL PRIMARY KEY IDENTITY(1, 1), 						
	CustomerID int NOT NULL,
	SrcStation varchar(30) NOT NULL,
	DstStation varchar(30) NOT NULL,
	Fare int NOT NULL,
	AllocatedSeat int DEFAULT 0,
	AllocatedBirth int DEFAULT 0,
	TrainID int NOT NULL,
	FOREIGN KEY (CustomerID) REFERENCES AdminUser(UserID),							
	FOREIGN KEY (CustomerID) REFERENCES Passenger(PassengerID),
	FOREIGN KEY (TrainID) REFERENCES Train(TrainID),
);

CREATE TABLE Train (
	TrainID int NOT NULL PRIMARY KEY IDENTITY(1, 1), 						
	TrainName varchar(30) NOT NULL,
	AvailableDay varchar(60), 														
	TotalNumberOfCoach int NOT NULL
);

CREATE TABLE Station (
	StationID int NOT NULL PRIMARY KEY IDENTITY(1, 1), 						
	TrainID int NOT NULL,
	StationName varchar(30) NOT NULL,
	TrainArrivalTime Time,
	TrainDepartureTime Time,
	FOREIGN KEY (TrainID) REFERENCES Train(TrainID)
);

CREATE TABLE TrainStation (
	ID int NOT NULL PRIMARY KEY IDENTITY(1, 1),
	TrainID int NOT NULL,
	StationID int NOT NULL,
	FOREIGN KEY (TrainID) REFERENCES Train(TrainID),
	FOREIGN KEY (StationID) REFERENCES Station(StationID),
);

CREATE TABLE Coach (
	CoachID int NOT NULL IDENTITY(1, 1) PRIMARY KEY,												
	TrainID int NOT NULL,
	Class varchar(20) NOT NULL,
	TotalNumberOfSeat int NOT NULL,
	TotalNumberOfBirth int NOT NULL,
	FOREIGN KEY (TrainID) REFERENCES Train(TrainID) 
);

CREATE TABLE Seat (
	CoachID int NOT NULL,
	ID int NOT NULL IDENTITY(1, 1),
	PRIMARY KEY (CoachID, ID),
	TrainID int NOT NULL,
	SeatNumber int NOT NULL,
	BirthNumber int NOT NULL,
	FOREIGN KEY (CoachID) REFERENCES Coach(coachID),
	FOREIGN KEY (TrainID) REFERENCES Train(TrainID),
);

CREATE TABLE Route (
	TrainID int NOT NULL,
	RouteID int NOT NULL,
	PRIMARY KEY(TrainID, RouteID),
	RouteSource varchar(30) NOT NULL,
	RouteDestination varchar(30) NOT NULL,
	TotalDistance float NOT NULL,
	NumberOfStations int NOT NULL,
	FOREIGN KEY (TrainID) REFERENCES Train(TrainID),
);

CREATE TABLE Complain (
	ComplainID int NOT NULL PRIMARY KEY IDENTITY(1, 1),
	UserID int NOT NULL,
	ComplainType text,
	ComplainDescription text,
	FOREIGN KEY (UserID) REFERENCES AdminUser(UserID),
);

CREATE TABLE Account (
	AccountID int NOT NULL PRIMARY KEY IDENTITY(1, 1),
	AccountTitle varchar(30) NOT NULL,
	AccountType varchar(20) NOT NULL,
	Status char(1),
	UserID int NOT NULL,
	FOREIGN KEY (UserID) REFERENCES AdminUser(UserID),
);