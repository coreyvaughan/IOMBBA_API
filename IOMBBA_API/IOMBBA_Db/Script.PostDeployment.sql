﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
------------------------------------------------------------
--MEMBERS TABLE
------------------------------------------------------------

SELECT TOP 0 * INTO #Member FROM [dbo].[Member];

--SET IDENTITY_INSERT #Member ON;

INSERT INTO #Member ([Firstname], [Surname], [ShirtNumber], [Position], [IsPlayer], [IsCoach], [IsOfficial], [IsTableOfficial], [RefQualifications], [TableQualifications], [IsDeleted]) 
VALUES 
--players
( 'Corey', 'Vaughan', 69, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 1
( 'Nathan', 'Vaughan', 23, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 2
( 'Josh', 'Looker', 22, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 3
( 'Eliot', 'Stutt', 21, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 4
( 'Owen', 'Baggaley', 10, 'Centre', 1, 0, 0, 0, '', '', 0),--MemberId = 5
( 'Luke', 'Connor', 11, 'Centre', 1, 0, 0, 0, '', '', 0),--MemberId = 6
( 'Louis', 'Huntley', 19, 'Centre', 1, 0, 0, 0, '', '', 0),--MemberId = 7
( 'Zac', 'Hart', 34, 'Centre', 1, 0, 0, 0, '', '', 0),--MemberId = 8
( 'Jack', 'Gallagher', 30, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 9
( 'Adam', 'Clark', 45, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 10
( 'Ewan', 'Cannon', 66, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 11
( 'Becca', 'Kelly', 73, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 12
( 'Adrian', 'Clear', 28, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 13
('Ben', 'Donaldson', 78, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 14
( 'Ben', 'Yeardsley', 23, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 15
( 'Tom', 'White', 21, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 16
( 'Jack', 'McDaid', 10, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 17
( 'Ollie', 'Morris', 9, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 18
( 'Ollie', 'Mitchell', 4, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 19
( 'Max', 'Turner', 4, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 20

( 'LeBron', 'James', 4, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 21
( 'Michael', 'Jordan', 3, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 22
( 'Kobe', 'Bryant', 47, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 23
( 'Kevin', 'Durant', 54, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 24
( 'Shaquille', 'O''Neal', 23, 'Centre', 1, 0, 0, 0, '', '', 0),--MemberId = 25
( 'Antony', 'Davis', 89, 'Centre', 1, 0, 0, 0, '', '', 0),--MemberId = 26
( 'James', 'Harden', 14, 'Centre', 1, 0, 0, 0, '', '', 0),--MemberId = 27
( 'Chris', 'Paul', 36, 'Centre', 1, 0, 0, 0, '', '', 0),--MemberId = 28
( 'Russel', 'Westbrook', 30, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 29
( 'Larry', 'Bird', 25, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 30
( 'Stephen', 'Curry', 25, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 31
( 'Vince', 'Carter', 74, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 32
( 'Wilt', 'Chamberlain', 34, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 33
('Magic', 'Johnson', 55, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 34
( 'Kyrie', 'Irving', 44, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 35
( 'Dwayne', 'Wade', 22, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 36
( 'Derrick', 'Rose', 29, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 37
( 'Dennis', 'Rodman', 64, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 38
( 'Carmelo', 'Antony', 12, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 39
( 'Allen', 'Iverson', 18, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 40

( 'Julius', 'Irving', 19, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 41
( 'Becca', 'Kelly', 43, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 42
( 'Josh', 'Looker', 82, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 43
( 'Eliot', 'Stutt', 53, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 44
( 'Owen', 'Baggaley', 15, 'Centre', 1, 0, 0, 0, '', '', 0),--MemberId = 45
( 'Luke', 'Connor', 11, 'Centre', 1, 0, 0, 0, '', '', 0),--MemberId = 46
( 'Louis', 'Huntley', 16, 'Centre', 1, 0, 0, 0, '', '', 0),--MemberId = 47
( 'Zac', 'Hart', 23, 'Centre', 1, 0, 0, 0, '', '', 0),--MemberId = 48
( 'Jack', 'Gallagher', 76, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 49
( 'Adam', 'Clark', 99, 'Guard', 1, 0, 0, 0, '', '', 0),--MemberId = 50
( 'Ewan', 'Cannon', 98, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 51
( 'Becca', 'Kelly', 67, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 52
( 'Adrian', 'Clear', 54, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 53
('Ben', 'Donaldson', 69, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 54
( 'Ben', 'Yeardsley', 26, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 55
( 'Tom', 'White', 22, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 56
( 'Jack', 'McDaid', 46, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 57
( 'Ollie', 'Morris', 9, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 58
( 'Ollie', 'Mitchell', 4, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 59

( 'Rajon', 'Rondo', 6, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 60
( 'Dwight', 'Howard', 76, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 61
( 'Zion', 'Wiliamson', 34, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 62
( 'Lonzo', 'Ball', 28, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 63
('Jayson', 'Tatum', 81, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 64
( 'Klay', 'Thompson', 57, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 65
( 'Draymond', 'Green', 89, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 66
( 'Kawhi', 'Leonard', 5, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 67
( 'Joel', 'Embid', 68, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 68
( 'Carmelo', 'Antony', 81, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 69
( 'Allen', 'Iverson', 35, 'Forward', 1, 0, 0, 0, '', '', 0),--MemberId = 70

--coaches
( 'Martin', 'Dunne', null, '', 0, 1, 0, 0, '', '', 0),--MemberId = 61
( 'Peter', 'Dunne', null, '', 0, 1, 0, 0, '', '', 0),--MemberId = 62
( 'Becky', 'Dunne', null, '', 0, 1, 0, 0, '', '', 0),--MemberId = 63
--official
( 'Official', 'Officialson', null, '', 0, 0, 1, 0, '', '', 0),--MemberId = 64

--table official
( 'Table', 'Officialson', null, '', 0, 0, 0, 1, '', '', 0);--MemberId = 65


MERGE [dbo].[Member] AS TARGET
USING #Member AS SOURCE ON (TARGET.MemberId = SOURCE.MemberId)
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Firstname], [Surname], [ShirtNumber], [Position], [IsPlayer], [IsCoach], [IsOfficial], [IsTableOfficial], [RefQualifications], [TableQualifications], [IsDeleted])
VALUES (SOURCE.[Firstname], SOURCE.[Surname], SOURCE.[ShirtNumber], SOURCE.[Position], SOURCE.[IsPlayer], SOURCE.[IsCoach], SOURCE.[IsOfficial], SOURCE.[IsTableOfficial], SOURCE.[RefQualifications], SOURCE.[TableQualifications], SOURCE.[IsDeleted]);

IF(OBJECT_ID('tempdb..#Member') IS NOT NULL)
BEGIN
	DROP TABLE #Member
END

------------------------------------------------------------
--TEAMS TABLE
------------------------------------------------------------
SELECT TOP 0 * INTO #Team FROM [dbo].[Team];

INSERT INTO #Team ([TeamId], [TeamName], [ShortTeamCode], [DominantKitColour], [IsDeleted]) VALUES 
--players


--colours fe6847 eb7532 fbb13c 37d63e 49da9a 57b8ff 2176ae


('a69bb43d-c8ea-44b4-b546-44e63147be40', 'Wolves', 'WOL', 'fe6847', 0),
('3e7173fc-c12c-4d04-b24d-b3edeadd727f', 'Eagles', 'EAG', 'eb7532', 0),
('44746c76-7411-4968-9cef-aeb96bfcd463', 'Jets', 'JET', 'fbb13c', 0),
('d34a7d5b-27b6-4ca0-9289-3a10b6b48f26', 'Cavaliers', 'CAV', '37d63e', 0),
('3d4a1a5e-517f-42a3-8e89-70663d354eb4', 'Turkeys', 'TUR', '49da9a', 0),
('d037583f-7098-4917-af04-7aeceef32d6d', 'PokerStars', 'POK', '57b8ff', 0),
('40b00666-e477-4756-adaf-ae078bf80ba7', 'The Giants', 'GIA', '2176ae', 0);



MERGE [dbo].[Team] AS TARGET
USING #Team AS SOURCE ON (TARGET.TeamId = SOURCE.TeamId)
WHEN NOT MATCHED BY TARGET THEN
INSERT ([TeamId], [TeamName], [ShortTeamCode], [DominantKitColour], [IsDeleted])
VALUES (SOURCE.[TeamId], SOURCE.[TeamName], SOURCE.[ShortTeamCode], SOURCE.[DominantKitColour], SOURCE.[IsDeleted]);

IF(OBJECT_ID('tempdb..#Team') IS NOT NULL)
BEGIN
	DROP TABLE #Team
END
------------------------------------------------------------
--MEMBERTEAM TABLE
------------------------------------------------------------
SELECT TOP 0 * INTO #MemberTeam FROM [dbo].[MemberTeam];

INSERT INTO #MemberTeam ([MemberTeamId], [TeamOfMember], [MemberOfTeam], [DateJoinedTeam], [DateLeftTeam], [IsDeleted]) VALUES 


--wolves memberteam records
('6705db25-1341-4301-b604-a3ff8a010960', 'a69bb43d-c8ea-44b4-b546-44e63147be40', 1, GETDATE(), '1753-01-01 00:00:00.000', 0),
('9bbc4883-7629-435a-b3ab-88c8fee976c3', 'a69bb43d-c8ea-44b4-b546-44e63147be40', 2, GETDATE(), '1753-01-01 00:00:00.000', 0),
('8d060056-5b55-4cfc-a532-a7237245a32b', 'a69bb43d-c8ea-44b4-b546-44e63147be40', 3, GETDATE(), '1753-01-01 00:00:00.000', 0),
('dbebf5a3-e7d6-400d-af1b-09aad82f4f2c', 'a69bb43d-c8ea-44b4-b546-44e63147be40', 4, GETDATE(), '1753-01-01 00:00:00.000', 0),
('1076638c-a197-42cc-983b-fa77b982f538', 'a69bb43d-c8ea-44b4-b546-44e63147be40', 5, GETDATE(), '1753-01-01 00:00:00.000', 0),
('9fa4d54c-4bce-452a-a7db-31ce9bdfc60a', 'a69bb43d-c8ea-44b4-b546-44e63147be40', 6, GETDATE(), '1753-01-01 00:00:00.000', 0),
('45749d25-4692-4cf3-a6c0-c98f311899af', 'a69bb43d-c8ea-44b4-b546-44e63147be40', 7, GETDATE(), '1753-01-01 00:00:00.000', 0),
('80f5946b-8adf-4ab8-8ea8-bdeb00f7a26c', 'a69bb43d-c8ea-44b4-b546-44e63147be40', 8, GETDATE(), '1753-01-01 00:00:00.000', 0),
('3dccdec2-4352-4ab3-b919-7533ee4d2d75', 'a69bb43d-c8ea-44b4-b546-44e63147be40', 9, GETDATE(), '1753-01-01 00:00:00.000', 0),
('113e888a-c706-4354-a41a-afdf714debe0', 'a69bb43d-c8ea-44b4-b546-44e63147be40', 10, GETDATE(), '1753-01-01 00:00:00.000', 0),

--eagles memberteam records
('202da60a-6d4a-4a0e-b689-4d4b885382c2', '3e7173fc-c12c-4d04-b24d-b3edeadd727f', 11, GETDATE(), '1753-01-01 00:00:00.000', 0),
('2fae2f7a-d4f9-46ad-8e39-6c23bf9b7696', '3e7173fc-c12c-4d04-b24d-b3edeadd727f', 12, GETDATE(), '1753-01-01 00:00:00.000', 0),
('a529af85-9508-4589-86ff-2de64f7a5926', '3e7173fc-c12c-4d04-b24d-b3edeadd727f', 13, GETDATE(), '1753-01-01 00:00:00.000', 0),
('1db0a00a-9e89-4e2c-8eac-d936b1b38e22', '3e7173fc-c12c-4d04-b24d-b3edeadd727f', 14, GETDATE(), '1753-01-01 00:00:00.000', 0),
('07d65298-7f46-40bb-b711-342c6fa70e8e', '3e7173fc-c12c-4d04-b24d-b3edeadd727f', 15, GETDATE(), '1753-01-01 00:00:00.000', 0),
('dfc6b22e-d724-4190-b61b-49d7dc099deb', '3e7173fc-c12c-4d04-b24d-b3edeadd727f', 16, GETDATE(), '1753-01-01 00:00:00.000', 0),
('de2cfbce-de1a-4b8e-b5bd-7b4a28350f4b', '3e7173fc-c12c-4d04-b24d-b3edeadd727f', 17, GETDATE(), '1753-01-01 00:00:00.000', 0),
('7aec7fad-06a6-4cdf-b3c4-0ab9b5281341', '3e7173fc-c12c-4d04-b24d-b3edeadd727f', 18, GETDATE(), '1753-01-01 00:00:00.000', 0),
('0c791ee5-caa7-4273-94db-7d5428acf9b4', '3e7173fc-c12c-4d04-b24d-b3edeadd727f', 19, GETDATE(), '1753-01-01 00:00:00.000', 0),
('86427da0-ca69-4986-95f9-197515731a4d', '3e7173fc-c12c-4d04-b24d-b3edeadd727f', 20, GETDATE(), '1753-01-01 00:00:00.000', 0),

--jets memberteam records
('9afcfb5a-eba1-46b1-b1f6-e3acf08dd4b4', '44746c76-7411-4968-9cef-aeb96bfcd463', 21, GETDATE(), '1753-01-01 00:00:00.000', 0),
('f27e55b1-d8dc-453c-841b-a5613846d63e', '44746c76-7411-4968-9cef-aeb96bfcd463', 22, GETDATE(), '1753-01-01 00:00:00.000', 0),
('8c8d746a-fae6-411c-ac7a-6a86c1d1f8d7', '44746c76-7411-4968-9cef-aeb96bfcd463', 23, GETDATE(), '1753-01-01 00:00:00.000', 0),
('07ae1fb1-2821-4ee7-8df2-7e47f90f2f00', '44746c76-7411-4968-9cef-aeb96bfcd463', 24, GETDATE(), '1753-01-01 00:00:00.000', 0),
('7c02155f-02d2-4fa1-ab40-f08a6f1e167f', '44746c76-7411-4968-9cef-aeb96bfcd463', 25, GETDATE(), '1753-01-01 00:00:00.000', 0),
('13c5694c-7715-40bb-9ee9-68ab5f9f28d2', '44746c76-7411-4968-9cef-aeb96bfcd463', 26, GETDATE(), '1753-01-01 00:00:00.000', 0),
('c805d1d4-ba2b-4700-af07-df3c6b4bcac4', '44746c76-7411-4968-9cef-aeb96bfcd463', 27, GETDATE(), '1753-01-01 00:00:00.000', 0),
('0efd87eb-67d2-426d-b265-85a2066d688f', '44746c76-7411-4968-9cef-aeb96bfcd463', 28, GETDATE(), '1753-01-01 00:00:00.000', 0),
('d3c758cd-1e7a-4a01-9d3c-1a2d233b17d3', '44746c76-7411-4968-9cef-aeb96bfcd463', 29, GETDATE(), '1753-01-01 00:00:00.000', 0),
('6559e5a5-62e1-4e5f-8106-8097717ac606', '44746c76-7411-4968-9cef-aeb96bfcd463', 30, GETDATE(), '1753-01-01 00:00:00.000', 0),

--cavaliers memberteam records
('3ae52cb9-ae8f-4f6b-965d-f89baeab3d81', 'd34a7d5b-27b6-4ca0-9289-3a10b6b48f26', 31, GETDATE(), '1753-01-01 00:00:00.000', 0),
('d8f1f19a-3431-4857-a417-d80f1e88a348', 'd34a7d5b-27b6-4ca0-9289-3a10b6b48f26', 32, GETDATE(), '1753-01-01 00:00:00.000', 0),
('cfcb0d03-404b-44be-b7bc-344db7817a1e', 'd34a7d5b-27b6-4ca0-9289-3a10b6b48f26', 33, GETDATE(), '1753-01-01 00:00:00.000', 0),
('a946aea6-467d-4ed3-b8bf-24ded1c774d5', 'd34a7d5b-27b6-4ca0-9289-3a10b6b48f26', 34, GETDATE(), '1753-01-01 00:00:00.000', 0),
('ee14fefe-c28c-4cba-ba5e-4f3fddf280b1', 'd34a7d5b-27b6-4ca0-9289-3a10b6b48f26', 35, GETDATE(), '1753-01-01 00:00:00.000', 0),
('9f77b7ab-6da6-4d62-8a72-16632e22ee6f', 'd34a7d5b-27b6-4ca0-9289-3a10b6b48f26', 36, GETDATE(), '1753-01-01 00:00:00.000', 0),
('e3be9020-9266-403f-8687-b17a4e596f99', 'd34a7d5b-27b6-4ca0-9289-3a10b6b48f26', 37, GETDATE(), '1753-01-01 00:00:00.000', 0),
('0b1d737a-8844-4ae2-9f5b-a4eebc3b51ad', 'd34a7d5b-27b6-4ca0-9289-3a10b6b48f26', 38, GETDATE(), '1753-01-01 00:00:00.000', 0),
('8c6aedb7-5e21-4ae7-90a9-a8b0dd0591a8', 'd34a7d5b-27b6-4ca0-9289-3a10b6b48f26', 39, GETDATE(), '1753-01-01 00:00:00.000', 0),
('c9dddd9d-2e7d-44ad-be1e-46f7c92f7603', 'd34a7d5b-27b6-4ca0-9289-3a10b6b48f26', 40, GETDATE(), '1753-01-01 00:00:00.000', 0),
--turkeys memberteam records
('962b69b7-20a8-47e9-af6f-f6381c6c0470', '3d4a1a5e-517f-42a3-8e89-70663d354eb4', 41, GETDATE(), '1753-01-01 00:00:00.000', 0),
('d021972a-d396-441a-845d-716c5e1d1a64', '3d4a1a5e-517f-42a3-8e89-70663d354eb4', 42, GETDATE(), '1753-01-01 00:00:00.000', 0),
('4b27c882-6a06-4b5d-9713-13ea0d6aa52f', '3d4a1a5e-517f-42a3-8e89-70663d354eb4', 43, GETDATE(), '1753-01-01 00:00:00.000', 0),
('137cc81d-7dfc-468b-9068-e3910c12e093', '3d4a1a5e-517f-42a3-8e89-70663d354eb4', 44, GETDATE(), '1753-01-01 00:00:00.000', 0),
('a9a81701-8621-4e77-9b71-6f69740b85e7', '3d4a1a5e-517f-42a3-8e89-70663d354eb4', 45, GETDATE(), '1753-01-01 00:00:00.000', 0),
('9bc83128-efb8-483b-a584-816c78a44d5f', '3d4a1a5e-517f-42a3-8e89-70663d354eb4', 46, GETDATE(), '1753-01-01 00:00:00.000', 0),
('1d7cfc8d-0284-4801-ac74-0f81ffdf8b2c', '3d4a1a5e-517f-42a3-8e89-70663d354eb4', 47, GETDATE(), '1753-01-01 00:00:00.000', 0),
('5b7598ae-dc95-47f9-9a42-e1d83d840ab3', '3d4a1a5e-517f-42a3-8e89-70663d354eb4', 48, GETDATE(), '1753-01-01 00:00:00.000', 0),
('f60dc32c-d1eb-4bcf-ac13-6a0466780031', '3d4a1a5e-517f-42a3-8e89-70663d354eb4', 49, GETDATE(), '1753-01-01 00:00:00.000', 0),
('06f5f6cb-11b4-483a-9252-fec6fb80e83f', '3d4a1a5e-517f-42a3-8e89-70663d354eb4', 50, GETDATE(), '1753-01-01 00:00:00.000', 0),
--pokerstars memberteam records
('db756069-bc77-404e-9b2f-ce79d2ec185a', 'd037583f-7098-4917-af04-7aeceef32d6d', 51, GETDATE(), '1753-01-01 00:00:00.000', 0),
('080ee73b-28e4-45af-9562-607dc43e229e', 'd037583f-7098-4917-af04-7aeceef32d6d', 52, GETDATE(), '1753-01-01 00:00:00.000', 0),
('f9d6a93c-2636-40ff-b74d-28413ae8555d', 'd037583f-7098-4917-af04-7aeceef32d6d', 53, GETDATE(), '1753-01-01 00:00:00.000', 0),
('4c14375f-6a08-4936-8f0f-ba311624fb32', 'd037583f-7098-4917-af04-7aeceef32d6d', 54, GETDATE(), '1753-01-01 00:00:00.000', 0),
('9721ff66-e735-48c1-9962-8ceb54b8b3aa', 'd037583f-7098-4917-af04-7aeceef32d6d', 55, GETDATE(), '1753-01-01 00:00:00.000', 0),
('1e1cdb7e-564a-4baa-b810-fa45b2f0890b', 'd037583f-7098-4917-af04-7aeceef32d6d', 56, GETDATE(), '1753-01-01 00:00:00.000', 0),
('f0df5b76-b2f1-41fe-ac45-8ff0eedd7485', 'd037583f-7098-4917-af04-7aeceef32d6d', 57, GETDATE(), '1753-01-01 00:00:00.000', 0),
('7a23876a-64ad-4907-8778-842fe2337049', 'd037583f-7098-4917-af04-7aeceef32d6d', 58, GETDATE(), '1753-01-01 00:00:00.000', 0),
('5c863974-c0da-4e0e-96ee-3c082dc0f8d2', 'd037583f-7098-4917-af04-7aeceef32d6d', 59, GETDATE(), '1753-01-01 00:00:00.000', 0),
('3c98a32f-76c3-4603-80d6-a7cccbd56092', 'd037583f-7098-4917-af04-7aeceef32d6d', 60, GETDATE(), '1753-01-01 00:00:00.000', 0),
--giants memberteam records
('487b1fc8-56bc-4909-b6b2-3a7334120f2f', '40b00666-e477-4756-adaf-ae078bf80ba7', 61, GETDATE(), '1753-01-01 00:00:00.000', 0),
('157a6875-35a6-48ad-8faf-1db1e055e3bb', '40b00666-e477-4756-adaf-ae078bf80ba7', 62, GETDATE(), '1753-01-01 00:00:00.000', 0),
('c8cc0919-ef7d-4c7b-8cdf-0fcce40e964a', '40b00666-e477-4756-adaf-ae078bf80ba7', 63, GETDATE(), '1753-01-01 00:00:00.000', 0),
('4ebf9dad-e1bf-4df9-8936-d400fd97df72', '40b00666-e477-4756-adaf-ae078bf80ba7', 64, GETDATE(), '1753-01-01 00:00:00.000', 0),
('cb965481-1bb0-4e13-a7e3-f15844cd8be0', '40b00666-e477-4756-adaf-ae078bf80ba7', 65, GETDATE(), '1753-01-01 00:00:00.000', 0),
('b3309342-31da-4857-9a19-cd22b055ee6e', '40b00666-e477-4756-adaf-ae078bf80ba7', 66, GETDATE(), '1753-01-01 00:00:00.000', 0),
('25b77709-de65-4c26-a456-b3b8cd83e39b', '40b00666-e477-4756-adaf-ae078bf80ba7', 67, GETDATE(), '1753-01-01 00:00:00.000', 0),
('e5db334c-dba6-4a30-9ef8-610d7e1ea3af', '40b00666-e477-4756-adaf-ae078bf80ba7', 68, GETDATE(), '1753-01-01 00:00:00.000', 0),
('ef603c0f-dbd0-4b0b-bfe8-8c7eb6b2c6a6', '40b00666-e477-4756-adaf-ae078bf80ba7', 69, GETDATE(), '1753-01-01 00:00:00.000', 0),
('44c198b8-a006-4c07-8af8-472421f6559e', '40b00666-e477-4756-adaf-ae078bf80ba7', 70, GETDATE(), '1753-01-01 00:00:00.000', 0);



MERGE [dbo].[MemberTeam] AS TARGET
USING #MemberTeam AS SOURCE ON (TARGET.MemberTeamId = SOURCE.MemberTeamId)
WHEN NOT MATCHED BY TARGET THEN
INSERT ([MemberTeamId], [TeamOfMember], [MemberOfTeam], [DateJoinedTeam], [DateLeftTeam], [IsDeleted])
VALUES (SOURCE.[MemberTeamId], SOURCE.[TeamOfMember], SOURCE.[MemberOfTeam], SOURCE.[DateJoinedTeam], SOURCE.[DateLeftTeam], SOURCE.[IsDeleted]);

IF(OBJECT_ID('tempdb..#MemberTeam') IS NOT NULL)
BEGIN
	DROP TABLE #MemberTeam
END

------------------------------------------------------------
--COMPETITION TABLE
------------------------------------------------------------
SELECT TOP 0 * INTO #Competition FROM [dbo].[Competition];

INSERT INTO #Competition ([CompetitionId], [CompetitionName]) VALUES 

('45677a49-e49f-4401-b957-ce6c4323929e', 'IOM Men''s league'),
('f4e1ea48-0ccc-4334-8dc7-69871f0ec526', 'IOM Women''s league');

MERGE [dbo].[Competition] AS TARGET
USING #Competition AS SOURCE ON (TARGET.CompetitionId = SOURCE.CompetitionId)
WHEN NOT MATCHED BY TARGET THEN
INSERT ([CompetitionId], [CompetitionName])
VALUES (SOURCE.[CompetitionId], SOURCE.[CompetitionName]);

IF(OBJECT_ID('tempdb..#Competition') IS NOT NULL)
BEGIN
	DROP TABLE #Competition
END


------------------------------------------------------------
--FIXTURE TABLE
------------------------------------------------------------
SELECT TOP 0 * INTO #Fixture FROM [dbo].[Fixture];

INSERT INTO #Fixture ([MatchNumber], [NumberOfPeriods], [CourtVenue], [FixtureStartTime], [HomeTeamId], [AwayTeamId], [CompetitionId]) VALUES 

('5771DF03-9EC5-4BA9-B04E-E23C32D2BBF0', 4, 'NSC', '2020-04-30 19:00:00.000', 'A69BB43D-C8EA-44B4-B546-44E63147BE40', '44746C76-7411-4968-9CEF-AEB96BFCD463', '45677A49-E49F-4401-B957-CE6C4323929E'),
('725da0e1-6dec-499a-9ff1-4f03a659cd0e', 4, 'NSC', '2020-04-30 19:00:00.000', '3e7173fc-c12c-4d04-b24d-b3edeadd727f', '40b00666-e477-4756-adaf-ae078bf80ba7', '45677A49-E49F-4401-B957-CE6C4323929E'),
('1ecb7b77-0eed-4d16-ba0b-ab08f6be37c5', 4, 'NSC', '2020-05-01 20:30:00.000', '3d4a1a5e-517f-42a3-8e89-70663d354eb4', 'd34a7d5b-27b6-4ca0-9289-3a10b6b48f26', '45677A49-E49F-4401-B957-CE6C4323929E');


MERGE [dbo].[Fixture] AS TARGET
USING #Fixture AS SOURCE ON (TARGET.MatchNumber = SOURCE.MatchNumber )
WHEN NOT MATCHED BY TARGET THEN
INSERT ([MatchNumber], [NumberOfPeriods], [CourtVenue], [FixtureStartTime], [HomeTeamId], [AwayTeamId], [CompetitionId])
VALUES (SOURCE.[MatchNumber], SOURCE.[NumberOfPeriods], SOURCE.[CourtVenue], SOURCE.[FixtureStartTime], SOURCE.[HomeTeamId], SOURCE.[AwayTeamId], SOURCE.[CompetitionId]);

IF(OBJECT_ID('tempdb..#Fixture') IS NOT NULL)
BEGIN
	DROP TABLE #Fixture
END



------------------------------------------------------------
--PERIOD TABLE
------------------------------------------------------------
SELECT TOP 0 * INTO #Period FROM [dbo].[Period];

INSERT INTO #Period ([PeriodId], [GameNumberOfPeriod], [PeriodDuration], [PeriodNumber], [TimeRemaining]) VALUES 

--1st period for fixture 1
('4f8922e8-e5d0-4cfc-b539-24c87c02596b', '5771DF03-9EC5-4BA9-B04E-E23C32D2BBF0',10, 1, 600),

--1st period for fixture 2
('96f7a509-16c8-47ec-bcbb-058e07561f71', '725da0e1-6dec-499a-9ff1-4f03a659cd0e',10, 1, 600),

--1st period for fixture 3
('a0a69bb5-94df-455f-90c0-7b723c999054', '1ecb7b77-0eed-4d16-ba0b-ab08f6be37c5',10, 1, 600);

MERGE [dbo].[Period] AS TARGET
USING #Period AS SOURCE ON (TARGET.PeriodId = SOURCE.PeriodId)
WHEN NOT MATCHED BY TARGET THEN
INSERT ([PeriodId], [GameNumberOfPeriod], [PeriodDuration], [PeriodNumber], [TimeRemaining])
VALUES (SOURCE.[PeriodId], SOURCE.[GameNumberOfPeriod], SOURCE.[PeriodDuration], SOURCE.[PeriodNumber], SOURCE.[TimeRemaining]);
IF(OBJECT_ID('tempdb..#Period') IS NOT NULL)
BEGIN
	DROP TABLE #Period
END


------------------------------------------------------------
--GAMEPLAYSTAT TABLE
------------------------------------------------------------
SELECT TOP 0 * INTO #GameplayStat FROM [dbo].[GameplayStat];

INSERT INTO #GameplayStat ([StatId], [StatMemberId], [StatCategory], [TimeOfStat], [PeriodId], [IsPlaying])  VALUES 

--fixture 1 stats:
--starting 5 substitutions
('9875389A-87E7-4738-9262-AF54B96AA04A', 1, 'substitution', 600000, '4f8922e8-e5d0-4cfc-b539-24c87c02596b', 1),
('D161A017-D0A5-4C1A-9224-9EE1A3EB1CC3', 2, 'substitution', 600000, '4f8922e8-e5d0-4cfc-b539-24c87c02596b', 1),
('643ECB64-2549-40E1-90A9-ECF73574881A', 3, 'substitution', 600000, '4f8922e8-e5d0-4cfc-b539-24c87c02596b', 1),
('019B8F40-6DFC-44EC-87EC-AE2B12F8BD05', 4, 'substitution', 600000, '4f8922e8-e5d0-4cfc-b539-24c87c02596b', 1),
('D533AD25-95FA-4C90-B381-64A569929F45', 5, 'substitution', 600000, '4f8922e8-e5d0-4cfc-b539-24c87c02596b', 1),
('2627DB75-9EB8-487E-8FF3-C32834F6DC59', 21, 'substitution', 600000, '4f8922e8-e5d0-4cfc-b539-24c87c02596b', 1),
('856092D6-1370-4371-83A1-9002779EFA06', 22, 'substitution', 600000, '4f8922e8-e5d0-4cfc-b539-24c87c02596b', 1),
('EA71E883-0F07-4379-945F-369CA08F1695', 23, 'substitution', 600000, '4f8922e8-e5d0-4cfc-b539-24c87c02596b', 1),
('65B77A1C-F6EE-4416-982D-BE7959484CBB', 24, 'substitution', 600000, '4f8922e8-e5d0-4cfc-b539-24c87c02596b', 1),
('191AD267-BC80-4F72-9483-C4F39B931CDD', 25, 'substitution', 600000, '4f8922e8-e5d0-4cfc-b539-24c87c02596b', 1),

--first period shots
('2409C2D1-6583-46E2-8D25-58D3BA7838C8', 24, 'shot', 586000, '4f8922e8-e5d0-4cfc-b539-24c87c02596b', 1),
('446DB3AB-C1CA-49EE-035A-08D7ED3BBBCA', 24, 'shot', 564000, '4f8922e8-e5d0-4cfc-b539-24c87c02596b', 1),
('56248EA4-AFA8-47BE-87F3-A236F1579E4E', 23, 'shot', 586000, '4f8922e8-e5d0-4cfc-b539-24c87c02596b', 1),

--fixture 3 stats:
--starting 5 substitutions
('6a5d5280-531f-4ff6-b42f-7a368f9a60e2', 31, 'substitution', 600000, 'a0a69bb5-94df-455f-90c0-7b723c999054', 1),
('fe541e04-531e-4aee-b5c4-b415798b4b42', 32, 'substitution', 600000, 'a0a69bb5-94df-455f-90c0-7b723c999054', 1),
('9b534bf9-09d6-4384-ba06-cbd8f9e54bd9', 33, 'substitution', 600000, 'a0a69bb5-94df-455f-90c0-7b723c999054', 1),
('202a6fb1-57e2-4de5-a813-096ec60a36af', 34, 'substitution', 600000, 'a0a69bb5-94df-455f-90c0-7b723c999054', 1),
('0bdd4b77-ddcb-4322-86d3-89bc3a7d2e5d', 35, 'substitution', 600000, 'a0a69bb5-94df-455f-90c0-7b723c999054', 1),
('addda34d-c131-4bb5-afd1-9a26ca67469f', 41, 'substitution', 600000, 'a0a69bb5-94df-455f-90c0-7b723c999054', 1),
('7dee8f30-06bf-4c99-b9c5-1e097e8dfd5f', 42, 'substitution', 600000, 'a0a69bb5-94df-455f-90c0-7b723c999054', 1),
('fd09d0a6-c2a7-4bf5-aa32-771a3f19bef3', 43, 'substitution', 600000, 'a0a69bb5-94df-455f-90c0-7b723c999054', 1),
('deaaa762-903c-48a4-ba11-834da9190e24', 44, 'substitution', 600000, 'a0a69bb5-94df-455f-90c0-7b723c999054', 1),
('14df33f1-c2e6-4344-826a-d45fcf5ac0b1', 45, 'substitution', 600000, 'a0a69bb5-94df-455f-90c0-7b723c999054', 1);



MERGE [dbo].[GameplayStat] AS TARGET
USING #GameplayStat AS SOURCE ON (TARGET.StatId = SOURCE.StatId)
WHEN NOT MATCHED BY TARGET THEN
INSERT ([StatId], [StatMemberId], [StatCategory], [TimeOfStat], [PeriodId], [IsPlaying]) 
VALUES (SOURCE.[StatId], SOURCE.[StatMemberId], SOURCE.[StatCategory], SOURCE.[TimeOfStat], SOURCE.[PeriodId], SOURCE.[IsPlaying]);
IF(OBJECT_ID('tempdb..#GameplayStat') IS NOT NULL)
BEGIN
	DROP TABLE #GameplayStat
END

------------------------------------------------------------
--SHOT TABLE
------------------------------------------------------------
SELECT TOP 0 * INTO #Shot FROM [dbo].[Shot];

INSERT INTO #Shot ([ShotId], [ShotStatId], [ShotPoints], [FreeThrow])  VALUES 

--first period shot stats
('abefb21c-5f9f-4b24-a7cc-c33399cd7934', '2409C2D1-6583-46E2-8D25-58D3BA7838C8', 2, 0),
('8785dec5-5c26-4b1b-bd06-d478d5dbb29f', '446DB3AB-C1CA-49EE-035A-08D7ED3BBBCA', 2, 0),
('61f67bc1-1ad9-4abf-ab2c-00052df5ced2', '56248EA4-AFA8-47BE-87F3-A236F1579E4E', 3, 0);


MERGE [dbo].[Shot] AS TARGET
USING #Shot AS SOURCE ON (TARGET.ShotId = SOURCE.ShotId)
WHEN NOT MATCHED BY TARGET THEN
INSERT ([ShotId], [ShotStatId], [ShotPoints], [FreeThrow])
VALUES (SOURCE.[ShotId], SOURCE.[ShotStatId], SOURCE.[ShotPoints], SOURCE.[FreeThrow]);
IF(OBJECT_ID('tempdb..#Shot') IS NOT NULL)
BEGIN
	DROP TABLE #Shot
END
