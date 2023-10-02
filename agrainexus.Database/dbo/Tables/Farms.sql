﻿CREATE TABLE Farms (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Location VARCHAR(100) NOT NULL,
    Crops NVARCHAR(MAX) NOT NULL,
    Area VARCHAR(100) NOT NULL,
    UserId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);