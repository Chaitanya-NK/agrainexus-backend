-- Generate Random String for Session Id & Create Login Session Stored Procedure
CREATE PROCEDURE CreateLoginSession
    @UserName VARCHAR(50),
    @LoginTime DATETIME
AS
BEGIN
    DECLARE @SessionId NVARCHAR(50)
    DECLARE @chars NVARCHAR(62)
    DECLARE @randomString NVARCHAR(MAX) = ''
    DECLARE @i INT = 0
    DECLARE @charIndex INT

    -- Characters to be used in the random string (a-z, A-Z, 0-9)
    SET @chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789'

    -- Generate random string of 30 characters
    WHILE @i < 30
    BEGIN
        SET @charIndex = CAST((RAND() * 62) AS INT) + 1
        SET @randomString = @randomString + SUBSTRING(@chars, @charIndex, 1)
        SET @i = @i + 1
    END

    SET @SessionId = @randomString

    -- Insert into the LoginSessions table
    INSERT INTO LoginSessions (UserName, SessionId, LoginTime)
    VALUES (@UserName, @SessionId, @LoginTime)
END
GO