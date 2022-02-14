CREATE TABLE [dbo].[Users]
(
	[UserID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [NationalInsuranceNumber] NVARCHAR(50) NOT NULL,
    [Forename] NVARCHAR(50) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL, 
    [DateOfBirth] DATETIME NOT NULL, 
    [Address] NVARCHAR(50) NOT NULL, 
    [PostCode] NVARCHAR(50) NOT NULL, 
    [HomeTel] NVARCHAR(50) NULL, 
    [MobileTel] NVARCHAR(50) NULL, 
    [EmailAddress] NVARCHAR(50) NULL, 
    [AccountType] NVARCHAR(50) NOT NULL, 
    [Authenticated] BIT NOT NULL    
)
