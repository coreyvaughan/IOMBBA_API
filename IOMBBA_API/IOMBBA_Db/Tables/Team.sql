CREATE TABLE [dbo].[Team]
(
	[TeamId]			UNIQUEIDENTIFIER    NOT NULL	DEFAULT	newid(),
	[TeamName]			VARCHAR(100)		NOT NULL,
    [ShortTeamCode]		VARCHAR(3)			NOT NULL,
	[DominantKitColour]	VARCHAR(6)			NOT NULL,
	[IsDeleted]			BIT					NULL		DEFAULT 0

    PRIMARY KEY (TeamId), 

)
