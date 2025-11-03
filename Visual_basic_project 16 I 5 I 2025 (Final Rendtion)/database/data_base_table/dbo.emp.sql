CREATE TABLE [dbo].[employee_records]
([Id] INT NOT NULL PRIMARY KEY, 
    [name] NCHAR(20) NOT NULL, 
    [role] NCHAR(20) NOT NULL, 
    [shift_hours ] NCHAR(20) NOT NULL, 
    [monthly_salary] INT NOT NULL, 
    [account_name] NCHAR(20) NOT NULL, 
    [account_password] NCHAR(20) NOT NULL, 
    [account_level] INT NOT NULL
)
