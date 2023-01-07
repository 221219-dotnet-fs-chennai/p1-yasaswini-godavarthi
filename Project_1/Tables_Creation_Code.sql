CREATE DATABASE Trainer_db;

CREATE TABLE [Trainer_Detailes](
    [user_id] int IDENTITY(1,1),
    [Full_name] VARCHAR(30),
    [Email] VARCHAR(25) UNIQUE,
    [Age] int,
    [Gender] VARCHAR(10),
    [Mobile_number] VARCHAR(10),
    [Website] VARCHAR(30),
    CONSTRAINT [pk_Details] PRIMARY KEY([user_id])

);

CREATE TABLE [Skills](
    [Skill_id] int IDENTITY(1,1),
    [Skill_name] VARCHAR(20),
    [Skill_Type] VARCHAR(20),
    [Skill_Level] VARCHAR(20),
    CONSTRAINT [Fk_skill] FOREIGN KEY(Skill_id) REFERENCES Trainer_Detailes(user_id),
    CONSTRAINT [Pk_skill] PRIMARY KEY([Skill_id]) 
);

CREATE TABLE [Company](
    [Id] int IDENTITY(1,1),
    [Company_name] VARCHAR(30),
    [Company_type] VARCHAR(30),
    [Experience] VARCHAR(20),
    [Company_Description] VARCHAR(50),
    constraint [pk_company] PRIMARY KEY([Id]),
    CONSTRAINT [Fk_company] FOREIGN KEY([Id]) REFERENCES Trainer_Detailes(user_id)
);

CREATE TABLE [Education_Details](
    [Edu_id] int IDENTITY(1,1),
    [Highest_Graduation] VARCHAR(30),
    [Institute] VARCHAR(50),
    [Department] VARCHAR(25),
    [Start_year] VARCHAR(5),
    [End_year] VARCHAR(5),
    CONSTRAINT [pk_education] PRIMARY KEY([Edu_id]),
    CONSTRAINT [Fk_education] FOREIGN KEY([Edu_id]) REFERENCES Trainer_Detailes(user_id)
);