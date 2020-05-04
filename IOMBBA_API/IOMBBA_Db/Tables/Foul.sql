CREATE TABLE [dbo].[Foul]
(
	[FoulId]				UNIQUEIDENTIFIER	NOT NULL	DEFAULT	newid(),
	[FoulStatId]			UNIQUEIDENTIFIER	NOT NULL,
	[FoulType]				VARCHAR(15)			NOT NULL,
	[FoulMinute]			INT					NOT NULL,
	[FreeThrowsAwarded]		INT					NOT NULL,
	
	PRIMARY KEY (FoulId),
	CONSTRAINT fk_foul_stat_id FOREIGN KEY (FoulStatId) REFERENCES GameplayStat(StatId)
)
