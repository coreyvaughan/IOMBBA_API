CREATE TABLE [dbo].[Member]
(
	[MemberId]				INT				 IDENTITY(1,1)	NOT NULL,
	[FirstName]				VARCHAR(100)	 NOT NULL,
	[Surname]				VARCHAR(100)	 NOT NULL,
	[ShirtNumber]			VARCHAR(2)		 NULL,
	[Position]				VARCHAR(50)		 NULL,
	[IsPlayer]				BIT				 NOT NULL,	
	[IsCoach]				BIT				 NOT NULL,
	[IsOfficial]			BIT				 NOT NULL,
	[IsTableOfficial]		BIT				 NOT NULL,
	[RefQualifications]		VARCHAR(MAX)	 NULL,
	[TableQualifications]	VARCHAR(MAX)	 NULL,
	[IsDeleted]				BIT				 NOT NULL	DEFAULT 0

	PRIMARY KEY(MemberId)
)
	
