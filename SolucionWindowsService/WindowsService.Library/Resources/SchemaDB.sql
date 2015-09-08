IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name=N'DbService')
	CREATE DATABASE [DbService]
GO

USE [DbService]
GO

IF NOT EXISTS (SELECT name FROM DbService.dbo.sysobjects WHERE name=N'TB_Messages')
	CREATE TABLE [dbo].[TB_Messages]
	(
		[Id]			int identity(1,1) PRIMARY KEY,
		[FileMessage]	varchar(max) NOT NULL
	)
GO

IF NOT EXISTS (SELECT name FROM DbService.dbo.sysobjects WHERE name=N'TB_Logs')
	CREATE TABLE [dbo].[TB_Logs]
	(
		[Id]			int identity(1,1) PRIMARY KEY,
		[LogMessage]	varchar(max) NOT NULL
	)
GO

IF NOT EXISTS (SELECT Id FROM TB_Messages)
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