CREATE TABLE [dbo].[GameplayStat]
(
	[StatId]			UNIQUEIDENTIFIER	NOT NULL	DEFAULT newid(),
	[StatMemberId]		INT					NOT NULL,
	[StatCategory]		VARCHAR(20)			NOT NULL,
	[PeriodId]			UNIQUEIDENTIFIER	NOT NULL,
	[TimeOfStat]		INT					NOT NULL,
	[IsPlaying]			BIT					NOT NULL,
	[Order]				INT				    NOT NULL	IDENTITY(1,1),

	PRIMARY KEY (StatId),
	CONSTRAINT fk_player_of_stat FOREIGN KEY (StatMemberId) REFERENCES Member(MemberId),
	CONSTRAINT fk_gameplay_stat_period_number FOREIGN KEY (PeriodId) REFERENCES Period(PeriodId)
)
