CREATE PROCEDURE GetFarmDetailsByUserId
(
	@UserId INT
)
AS
BEGIN
	SELECT * FROM Farms WHERE UserId = @UserId
END
GO