CREATE DATABASE Trainer_db;
-------------------Database-----------------------
------------------Trainer details table ---------------
CREATE TABLE [Trainer_Detailes](
    [user_id] int IDENTITY(1,1),
    [Full_name] VARCHAR(30),
    [Email] VARCHAR(25) UNIQUE,
    [Age] int,
    [Gender] VARCHAR(10),
    [Mobile_number] VARCHAR(10),
    [Website] VARCHAR(30),
    PASSWORD VARCHAR(10)
    CONSTRAINT [pk_Details] PRIMARY KEY([user_id]) 

);

--------------------Skills table ---------------------

CREATE TABLE [Skills](
    [user_id] int IDENTITY(1,1),
    [Skill_name] VARCHAR(20),
    [Skill_Type] VARCHAR(20),
    [Skill_Level] VARCHAR(20),
    CONSTRAINT [Fk_skill] FOREIGN KEY(user_id) REFERENCES Trainer_Detailes(user_id),
    CONSTRAINT [Pk_skill] PRIMARY KEY([user_id])
);

---------------------Company -----------------------------------

CREATE TABLE [Company](
    [user_id] int IDENTITY(1,1),
    [Company_name] VARCHAR(30),
    [Company_type] VARCHAR(30),
    [Experience] VARCHAR(20),
    [Company_Description] VARCHAR(50),
    constraint [pk_company] PRIMARY KEY([user_id]),
    CONSTRAINT [Fk_company] FOREIGN KEY([user_id]) REFERENCES Trainer_Detailes(user_id)
);

-----------------------Education details ----------------------------------

CREATE TABLE [Education_Details](
    [user_id] int IDENTITY(1,1),
    [Highest_Graduation] VARCHAR(30),
    [Institute] VARCHAR(50),
    [Department] VARCHAR(25),
    [Start_year] VARCHAR(5),
    [End_year] VARCHAR(5),
    CONSTRAINT [pk_education] PRIMARY KEY([user_id]),
    CONSTRAINT [Fk_education] FOREIGN KEY([user_id]) REFERENCES Trainer_Detailes(user_id)
);

------------------------Inserting rows into table -------------------------

INSERT into [Trainer_Detailes] VALUES ('Yasaswini','yasaswini@gmail.com',21,'Female','8765490321','www.yasaswini.com','Yas1')
INSERT into [Trainer_Detailes] VALUES ('mike','mike@gmail.com',22,'male','8769054321','www.mikeswebsite.com','Mike1'),('Bhagya','Bhagya@gmail.com',21,'Female','9879678534','www.bhagyaswebsite.com','Bhag4')
UPDATE [Trainer_Detailes] SET Password = 'mike@'  WHERE Email = 'mike@gmail.com';

INSERT INTO [Skills] VALUES('Programming','Technical','profisional'),('Coding','Technical','Experienced'),('code','Tech','Interme');

INSERT INTO [Company] VALUES('Revature','Talent development','Fresher','Technology talent development')
INSERT INTO [Company] VALUES('Infosys','Service type','2 years','Consulting'),('ibm','service','1','tech company')

INSERT INTO [Education_Details] VALUES('Mtech','jntu','mech','19','23'),('Btech','university','Cs','16','20'),('ms','anna','cse','18','22');

----------------------------Displaying details ------------------------

select * from Trainer_Detailes;
select * from Company;
select * from Skills;
SELECT * FROM Education_Details;