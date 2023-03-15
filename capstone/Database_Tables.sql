CREATE TABLE [PatientBasicRecord](
    [Id] UNIQUEIDENTIFIER ,
    [DateTime] smalldatetime,
    [Patient_Id] NVARCHAR(100) PRIMARY KEY,
    [Nurse_Id] NVARCHAR(max),
    [Bp] NVARCHAR(max),
    [Heart_Rate] int,
    [SpO2] NVARCHAR(max) 
);


CREATE table [PatientAllergy](
    [Id] UNIQUEIDENTIFIER PRIMARY KEY,
    [Health_Id] NVARCHAR(100),
    [Allergy] NVARCHAR(max),
    CONSTRAINT [Fk_PatientAllergy]  FOREIGN Key(Health_Id) REFERENCES [PatientBasicRecord](Patient_Id) ON DELETE CASCADE ON UPDATE CASCADE
)


CREATE TABLE [PatientHealthRecord](
    [Id] UNIQUEIDENTIFIER PRIMARY KEY,
    [DateTime] smalldatetime,
    [Patient_Id] NVARCHAR(max),
    [Doctor_Id] NVARCHAR(max),
    [Conclusion] NVARCHAR(max) 
);

Create TABLE [PatientMedication](
    [Id] UNIQUEIDENTIFIER PRIMARY Key,
    [Health_Id] UNIQUEIDENTIFIER,
    [Drug] NVARCHAR(max),
    CONSTRAINT [Fk_patientmedication] FOREIGN KEY(Health_Id) REFERENCES [PatientHealthRecord](Id) ON DELETE CASCADE ON UPDATE CASCADE
);

Create TABLE [PatientTest](
    [Id] UNIQUEIDENTIFIER PRIMARY Key,
    [Health_Id] UNIQUEIDENTIFIER,
    [Test] NVARCHAR(max),
    [Result] NVARCHAR(max),
    CONSTRAINT [Fk_patientTest] FOREIGN KEY(Health_Id) REFERENCES [PatientHealthRecord](Id) ON DELETE CASCADE ON UPDATE CASCADE
);

SELECT * FROM PatientBasicRecord
SELECT * FROM PatientAllergy
SELECT * FROM PatientHealthRecord
SELECT * FROM PatientMedication
SELECT * FROM PatientTest
