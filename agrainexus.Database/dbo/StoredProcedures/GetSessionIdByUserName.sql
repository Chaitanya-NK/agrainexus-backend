CREATE PROCEDURE GetSessionIdByUserName
	@UserName VARCHAR(20)
AS
BEGIN
	SELECT TOP 1 SessionId
	FROM LoginSessions
	WHERE UserName = @UserName
	ORDER BY LoginTime DESC
END
