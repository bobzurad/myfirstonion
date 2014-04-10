--Azure SQL Server: g5l0rxiy9x.database.windows.net
--Database: cwcreations

CREATE TABLE [dbo].[Jewelry]
(
	[Id] INT IDENTITY (1,1) PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [ImageFileName] NVARCHAR(100) NULL, 
    [Quantity] INT NOT NULL DEFAULT 0
)

