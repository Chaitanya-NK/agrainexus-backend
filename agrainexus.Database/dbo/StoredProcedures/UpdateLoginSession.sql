CREATE PROCEDURE UpdateLoginSession
    @SessionId NVARCHAR(50),
    @LogoutTime DATETIME
AS
BEGIN
    UPDATE LoginSessions 
	SET LogoutTime = @LogoutTime 
	WHERE SessionId = @SessionId AND LogoutTime IS NULL
END