CREATE TABLE [dbo].[User]
(
	[Username]			VARCHAR(100)		 NOT NULL,
	[PasswordHash]		VARCHAR(100)		 NOT NULL,
	[UserMemberId]		INT					 NOT NULL

	PRIMARY KEY (Username),
	CONSTRAINT fk_user_account_member_id FOREIGN KEY (UserMemberId) REFERENCES Member(MemberId)
)
