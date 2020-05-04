CREATE TABLE [dbo].[Fixture]
(
	[MatchNumber]		UNIQUEIDENTIFIER    NOT NULL	DEFAULT		newid(),
	[CompetitionId]		UNIQUEIDENTIFIER	NOT NULL,
	[FixtureStartTime]  DATETIME            NOT NULL,
	[CourtVenue]        VARCHAR(100)        NOT NULL,
    [HomeTeamId]		UNIQUEIDENTIFIER	NOT NULL, 
    [AwayTeamId]		UNIQUEIDENTIFIER	NOT NULL, 
	[NumberOfPeriods]	INT					NOT NULL

    PRIMARY KEY(MatchNumber),
	CONSTRAINT fk_competition_of_fixture FOREIGN KEY (CompetitionId) REFERENCES Competition(CompetitionId),
    CONSTRAINT fk_fixture_home_team FOREIGN KEY (HomeTeamId) REFERENCES Team(TeamId),
	CONSTRAINT fk_fixture_away_team FOREIGN KEY (AwayTeamId) REFERENCES Team(TeamId)
)
