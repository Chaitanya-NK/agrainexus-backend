CREATE PROCEDURE TokenDetails
(
	@UserName varchar(100)
)
AS
BEGIN
	SELECT Id, UserName, Email 
	FROM Users
	WHERE UserName = @UserName
END
GO