IF OBJECT_ID('tblPatient', 'U') IS NOT NULL DROP TABLE tblPatient;
IF OBJECT_ID('tblDoctor', 'U') IS NOT NULL DROP TABLE tblDoctor;

-- Checks if the database already exists.
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'MedicalDB')
CREATE DATABASE MedicalDB;
GO

USE MedicalDB
CREATE TABLE tblDoctor(
	DoctorID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	FirstName nvarchar(30) NOT NULL,
	LastName nvarchar(30) NOT NULL,
	JMBG nvarchar(13) NOT NULL,
	BankAccount nvarchar(20) NOT NULL,
	Username nvarchar(30) UNIQUE NOT NULL,
	UserPassword nvarchar(200) NOT NULL
);

USE MedicalDB
CREATE TABLE tblPatient(
	PatientID INT IDENTITY(1,1) PRIMARY KEY,
	FirstName nvarchar(30) NOT NULL,
	LastName nvarchar(30) NOT NULL,
	JMBG nvarchar(13) NOT NULL,
	HealthIsuranceNumber nvarchar(40) NOT NULL,
	Username nvarchar(30) UNIQUE NOT NULL,
	UserPassword nvarchar(200) NOT NULL,
	DoctorID INT FOREIGN KEY REFERENCES tblDoctor(DoctorID) 
);