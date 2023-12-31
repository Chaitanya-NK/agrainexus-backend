CREATE PROCEDURE InsertFarmData
(
	@NickName VARCHAR(20),
    @Location VARCHAR(100),
    @Crops NVARCHAR(MAX),
    @Area VARCHAR(100),
	@AreaUnits VARCHAR(25),
    @UserId INT
)
AS
BEGIN
    INSERT INTO Farms (NickName, Location, Crops, Area, AreaUnits, UserId)
    VALUES (@NickName, @Location, @Crops, @Area, @AreaUnits, @UserId)
END