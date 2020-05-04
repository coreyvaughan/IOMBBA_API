CREATE TABLE [dbo].[Period]
(
	[PeriodId]				UNIQUEIDENTIFIER	NOT NULL	DEFAULT newid(),
	[GameNumberOfPeriod]	UNIQUEIDENTIFIER	NOT NULL,
	[PeriodNumber]			INT					NOT NULL,
	[PeriodDuration]		INT					NOT NULL,
	[TimeRemaining]			INT					NOT NULL

	PRIMARY KEY (PeriodId),
	CONSTRAINT fk_game_number_of_period FOREIGN KEY (GameNumberOfPeriod) REFERENCES Fixture(MatchNumber)
)
