IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name=N'DbService')
	DROP DATABASE [DbService]


CREATE DATABASE [DbService]
GO

USE [DbService]
GO

CREATE TABLE [dbo].[TB_Messages]
(
	[Id]			int identity(1,1) PRIMARY KEY,
	[FileMessage]	varchar(max) NOT NULL
)
GO

CREATE TABLE [dbo].[TB_Logs]
(
	[Id]			int identity(1,1) PRIMARY KEY,
	[LogMessage]	varchar(max) NOT NULL
)
GO

INSERT INTO [TB_Messages] (FileMessage)
VALUES
('Random Message 1'),
('Random Message 2'),
('Random Message 3'),
('Random Message 4'),
('Random Message 5'),
('Random Message 6'),
('Random Message 7'),
('Random Message 8'),
('Random Message 9')