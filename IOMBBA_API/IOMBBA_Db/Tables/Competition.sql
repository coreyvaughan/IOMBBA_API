CREATE TABLE [dbo].[Competition]
(
	[CompetitionId]		UNIQUEIDENTIFIER	NOT NULL	DEFAULT newid(),
	[CompetitionName]	VARCHAR(100)		NOT NULL

	PRIMARY KEY (CompetitionId)
)