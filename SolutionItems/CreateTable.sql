-- This file should contain code that could be executed within a
-- database transaction (guaranteeing data and schema consistency), 
-- for example create and maintain tables, table relations, CRUD 
-- of data

USE [LvivPolytechlic];

DECLARE @errMessage varchar(max)
DECLARE @sql varchar(max)
DECLARE @schemaVersion int, @newSchemaVersion int

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = N'dbo' AND TABLE_NAME = N'DatabaseSettings' AND TABLE_TYPE = 'BASE TABLE')
BEGIN 
	CREATE TABLE [dbo].[DatabaseSettings] (
		[ID] [int] NOT NULL,
		[SchemaVersion] [int] NOT NULL,
		CONSTRAINT [PK_DatabaseSettings] PRIMARY KEY CLUSTERED([ID])
	)
	INSERT INTO [dbo].[DatabaseSettings]([Id], [SchemaVersion]) VALUES(1, 0)
END

SELECT @schemaVersion = MAX(SchemaVersion) FROM [dbo].[DatabaseSettings]
BEGIN TRY

-- =============================================================
-- Author:		Mariya Bilyk
-- Update date:	2017-05-01
-- Description:	Add initial tables.
-- =============================================================
SET @newSchemaVersion = 1
IF @schemaVersion < @newSchemaVersion
BEGIN
	BEGIN TRANSACTION
		CREATE TABLE [Institute]
		(	
			[id] INT IDENTITY,
			[name] NVARCHAR(MAX),
			[shortName] NVARCHAR(MAX),
			CONSTRAINT [PK_Institute] PRIMARY KEY (id)
		)

		CREATE TABLE [Department]
		(
			[id] INT IDENTITY,
			[name] NVARCHAR(MAX),
			[instituteId] INT,
			CONSTRAINT [PK_Department] PRIMARY KEY (id),
			CONSTRAINT [FK_Department_Institute] FOREIGN KEY ([instituteId]) REFERENCES [Institute](Id)
		)

		CREATE TABLE [Teacher]
		(
			[id] INT IDENTITY,
			[fullName] NVARCHAR(MAX),
			[departmentId] INT,
			CONSTRAINT [PK_Teacher] PRIMARY KEY (id),
			CONSTRAINT [FK_Teacher_Department] FOREIGN KEY (departmentId) REFERENCES [Department](id)
		)

		CREATE TABLE [Specialization]
		(
			[id] [int] IDENTITY,
			[code] [nvarchar](10),
			[name] [nvarchar](MAX),
			[instituteId] INT,
			CONSTRAINT [PK_Specialization] PRIMARY KEY (id),
			CONSTRAINT [FK_Specialization_Institute] FOREIGN KEY ([instituteId]) REFERENCES [Institute](id)
		)

		CREATE TABLE [Subject]
		(
			[id] [int] IDENTITY,
			[name] [nvarchar](MAX),
			[teacherId] [int],
			[typeControl] [varchar](10) NOT NULL,
			[ectsCredits] [decimal](15, 2) NULL,
			CONSTRAINT [PK_Subject] PRIMARY KEY (id),
			CONSTRAINT [FK_Subject_Teacher] FOREIGN KEY ([teacherId]) REFERENCES [Teacher](id)
		)

		CREATE TABLE [StudyForm]
		(
			[id] [int] NOT NULL,
			[name] [nvarchar](MAX),
			CONSTRAINT [PK_StudyForm] PRIMARY KEY (id),
		)

		CREATE TABLE [StudyQualification]
		(
			[id] [int] NOT NULL,
			[name] [nvarchar](MAX),
			CONSTRAINT [PK_StudyQualification] PRIMARY KEY (id),
		)

		CREATE TABLE [Student]
		(
			 [id] [int] identity,
			 [lastName] [nvarchar](50) NULL,
			 [firstName] [nvarchar](50) NULL,
			 [fatherName] [nvarchar](50) NULL,
			 [birthDate] [nvarchar](20) NULL,
			 [oblast] [nvarchar](50) NULL,
			 [region] [nvarchar](50) NULL,
			 [city] [nvarchar](50) NULL,
			 [instituteId] [int] NULL,
			 [studyFormId] [int] NULL,
			 [studyQualificationId] [int] NULL,
			 [studySpetsId] [int] NULL,
			 [studyYear] [int] NULL,
			 [commerc] [int] NULL,
			 [foreigner] [int] NULL DEFAULT 0,
			 [gender] [int] NULL,
			 CONSTRAINT [PK_Student] PRIMARY KEY (id),
			 CONSTRAINT [FK_Student_Institute] FOREIGN KEY ([instituteId]) REFERENCES [Institute](id),
			 CONSTRAINT [FK_Student_StudyForm] FOREIGN KEY ([studyFormId]) REFERENCES [StudyForm](id),
			 CONSTRAINT [FK_Student_StudyQualification] FOREIGN KEY ([studyQualificationId]) REFERENCES [StudyQualification](id)	
		)

		CREATE TABLE [Success]
		(
			 [id] [int] identity,
			 [subjectId] [int] NULL,
			 [semester] [smallint] NOT NULL,
			 [totalMark] [int] NULL,
			 [K] [int] NOT NULL,
			 [repeatStuding] [int] NOT NULL DEFAULT 0,
			 [departmentId] [int] NULL,
			 [studentId] [int]
			 CONSTRAINT [PK_Success] PRIMARY KEY (id),
			 CONSTRAINT [FK_Success_Subject] FOREIGN KEY ([subjectId]) REFERENCES [Subject](id),
			 CONSTRAINT [FK_Success_Department] FOREIGN KEY ([departmentId]) REFERENCES [Department](id),
			 CONSTRAINT [FK_Success_Student] FOREIGN KEY ([studentId]) REFERENCES [Student](id),

		)

		UPDATE [dbo].[DatabaseSettings] SET SchemaVersion = @newSchemaVersion
	
		COMMIT
	END 


 --=============================================================
 --Author:		Mariia Bilyk
 --Update date:	2017-05-01
 --Description:	Add initial data
 --=============================================================
SET @newSchemaVersion = 2
IF @schemaVersion < @newSchemaVersion
BEGIN
	BEGIN TRANSACTION
	
	ALTER TABLE [dbo].[Success]
	ADD [assesmentDate] [date] NOT NULL;
		
	UPDATE [dbo].[DatabaseSettings] SET SchemaVersion = @newSchemaVersion
	COMMIT
END 

 --=============================================================
 --Author:		Mariia Bilyk
 --Update date:	2017-05-01
 --Description:	Add initial data
 --=============================================================
SET @newSchemaVersion = 3
IF @schemaVersion < @newSchemaVersion
BEGIN
	BEGIN TRANSACTION
	
	ALTER TABLE [dbo].[Success]
	DROP COLUMN [assesmentDate];

	ALTER TABLE [dbo].[Success]
	ADD [assessmentDate] [date] NOT NULL;
		
	UPDATE [dbo].[DatabaseSettings] SET SchemaVersion = @newSchemaVersion
	COMMIT
END 


/*
-- =============================================================
-- Author:		<full name>
-- Update date:	<yyyy-mm-dd>
-- Description:	<desc>
-- =============================================================
SET @newSchemaVersion = 4
IF @schemaVersion < @newSchemaVersion
BEGIN
	BEGIN TRANSACTION
	
		
	UPDATE [dbo].[DatabaseSettings] SET SchemaVersion = @newSchemaVersion
	COMMIT
END */

END TRY
BEGIN CATCH
	SELECT @errMessage = CAST(ERROR_LINE() AS VARCHAR(10)) + ' - ' + ERROR_MESSAGE()
	ROLLBACK
	RAISERROR (@errMessage, 17, 1)
END CATCH
