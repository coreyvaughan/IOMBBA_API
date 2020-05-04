CREATE TABLE [dbo].[Shot]
(
	[ShotId]		UNIQUEIDENTIFIER	NOT NULL	DEFAULT newid(),
	[ShotStatId]	UNIQUEIDENTIFIER	NOT NULL,
	[ShotPoints]	INT					NOT NULL,
	[XPosition]		INT					NULL		DEFAULT 0,
	[YPosition]		INT					NULL		DEFAULT 0,
	[ShotType]		VARCHAR(50)			NULL,
	[FreeThrow]		BIT					NOT NULL	DEFAULT 0

	PRIMARY KEY (ShotId),
	CONSTRAINT fk_shot_stat FOREIGN KEY (ShotStatId) REFERENCES GameplayStat(StatId)
)
