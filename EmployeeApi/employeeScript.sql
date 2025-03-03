--cmd sqllocaldb info

CREATE TABLE Employees (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    PhoneNumber NVARCHAR(20) NULL,
    Position NVARCHAR(100) NOT NULL,
    Salary DECIMAL(18,2) NOT NULL CHECK (Salary >= 0),
    IsActive BIT NOT NULL DEFAULT 1,  -- Soft delete (1 = Active, 0 = Deleted)
    CreatedAt DATETIME2 DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2 DEFAULT GETUTCDATE()
);
GO

-- Create Index for Soft Delete Query Optimization
CREATE INDEX IX_Employees_IsActive ON Employees(IsActive);
GO

-- Trigger to Update 'UpdatedAt' Column on Modifications
CREATE TRIGGER trg_UpdateEmployeeTimestamp
ON Employees
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Employees
    SET UpdatedAt = GETUTCDATE()
    WHERE Id IN (SELECT DISTINCT Id FROM inserted);
END;
GO

INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber, Position, Salary)
VALUES 
('John', 'Doe', 'john.doe@email.com', '1234567890', 'Software Engineer', 75000.00),
('Jane', 'Smith', 'jane.smith@email.com', '0987654321', 'Project Manager', 90000.00);

SELECT * FROM Employees WHERE IsActive = 1;
