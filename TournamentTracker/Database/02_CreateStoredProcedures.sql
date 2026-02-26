USE [TournamentTracker]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- People_GetAll
CREATE OR ALTER PROCEDURE dbo.spPeople_GetAll
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM dbo.People
    ORDER BY FirstName, LastName;
END
GO

-- Tournaments_GetAll
CREATE OR ALTER PROCEDURE dbo.spTournaments_GetAll
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM dbo.Tournaments
    ORDER BY TournamentName;
END
GO

-- TeamMembers_GetByTeam
CREATE OR ALTER PROCEDURE dbo.spTeamMembers_GetByTeam
    @TeamId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT p.*
    FROM dbo.TeamMembers tm
    INNER JOIN dbo.People p ON tm.PersonId = p.PersonId
    WHERE tm.TeamId = @TeamId;
END
GO

-- Team_GetByTournament
CREATE OR ALTER PROCEDURE dbo.spTeam_GetByTournament
    @TournamentId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT t.*
    FROM dbo.TournamentEntries te
    INNER JOIN dbo.Teams t ON te.TeamId = t.TeamId
    WHERE te.TournamentId = @TournamentId;
END
GO

-- Prizes_GetByTournament
CREATE OR ALTER PROCEDURE dbo.spPrizes_GetByTournament
    @TournamentId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT p.*
    FROM dbo.TournamentPrizes tp
    INNER JOIN dbo.Prizes p ON tp.PrizeId = p.PrizeId
    WHERE tp.TournamentId = @TournamentId;
END
GO

-- MatchupEntries_GetByMatchup
CREATE OR ALTER PROCEDURE dbo.spMatchupEntries_GetByMatchup
    @MatchupId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM dbo.MatchupEntries
    WHERE MatchupId = @MatchupId;
END
GO

-- MatchupEntries_GetByTournament
CREATE OR ALTER PROCEDURE dbo.spMatchupEntries_GetByTournament
    @TournamentId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT me.*
    FROM dbo.MatchupEntries me
    INNER JOIN Matchups m ON me.MatchupId = m.MatchupId
    WHERE m.TournamentId = @TournamentId;
END
GO