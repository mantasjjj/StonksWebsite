CREATE TABLE [dbo].[DBFinancialPlan] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [UserId]        INT            NOT NULL,
    [DateCreated]   DATETIME2 (7)  NOT NULL,
    [FinancialPlan] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[DBUser] ([Id])
);