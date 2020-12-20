﻿CREATE TABLE [dbo].[DBFinancialPlan]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [UserId] INT NOT NULL,
    [DateCreated] DATETIME2 NOT NULL,
    [FinancialPlan] NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (UserId) REFERENCES DBUser(Id)
)
