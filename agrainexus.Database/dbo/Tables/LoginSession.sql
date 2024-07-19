-- Login Sessions Table
CREATE TABLE LoginSessions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserName VARCHAR(50),
    SessionId NVARCHAR(50),
    LoginTime DATETIME,
    LogoutTime DATETIME
);