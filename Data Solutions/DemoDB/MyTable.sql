﻿CREATE TABLE [dbo].[MyTable]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY 
	,guid UNIQUEIDENTIFIER DEFAULT NEW_ID() NOT NULL 
	,Naam	CHAR(10)  NOT NULL 
)
