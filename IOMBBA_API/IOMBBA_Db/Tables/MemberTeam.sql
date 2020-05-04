CREATE TABLE [dbo].[MemberTeam]
(
	[MemberTeamId]      UNIQUEIDENTIFIER    NOT NULL    DEFAULT newid(),
    [TeamOfMember]      UNIQUEIDENTIFIER    NOT NULL, 
    [MemberOfTeam]      INT                 NOT NULL, 
    [DateJoinedTeam]    DATETIME            NOT NULL, 
    [DateLeftTeam]      DATETIME            NULL,
    [IsDeleted]         BIT                 NOT NULL    DEFAULT 0,

    PRIMARY KEY(MemberTeamId),
    CONSTRAINT fk_team_of_member FOREIGN KEY (TeamOfMember) REFERENCES Team(TeamId),
    CONSTRAINT fk_member_of_team FOREIGN KEY (MemberOfTeam) REFERENCES Member(MemberId),

)
