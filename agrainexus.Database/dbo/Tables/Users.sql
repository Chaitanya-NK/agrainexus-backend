﻿CREATE TABLE Users (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  UserName VARCHAR(255) NOT NULL,
  Email VARCHAR(255) NOT NULL,
  Password VARCHAR(255) NOT NULL
);