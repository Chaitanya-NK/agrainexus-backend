CREATE PROCEDURE InsertFarmData
(
	@NickName VARCHAR(20),
    @Location VARCHAR(100),
    @Crops NVARCHAR(MAX),
    @Area VARCHAR(100),
    @UserId INT
)
AS
BEGIN
    INSERT INTO Farms (NickName, Location, Crops, Area, UserId)
    VALUES (@NickName, @Location, @Crops, @Area, @UserId)
END