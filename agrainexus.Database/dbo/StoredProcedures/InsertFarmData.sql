CREATE PROCEDURE InsertFarmData
(
    @Location VARCHAR(100),
    @Crops NVARCHAR(MAX),
    @Area VARCHAR(100),
    @UserId INT
)
AS
BEGIN
    INSERT INTO Farms (Location, Crops, Area, UserId)
    VALUES (@Location, @Crops, @Area, @UserId)
END