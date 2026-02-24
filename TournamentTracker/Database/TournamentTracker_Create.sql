-- =============================================
-- Tournament Tracker Database - Setup
-- =============================================

CREATE DATABASE TournamentTracker;
GO

USE TournamentTracker;
GO

-- =======================
-- Teams
-- =======================
CREATE TABLE Teams (
    TeamId INT IDENTITY(1,1) PRIMARY KEY,
    TeamName NVARCHAR(100) NOT NULL
);

-- =======================
-- People
-- =======================
CREATE TABLE People (
    PersonId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    EmailAddress NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(20) NULL
);

-- =======================
-- TeamMembers (junction table)
-- =======================
CREATE TABLE TeamMembers (
    TeamMemberId INT IDENTITY(1,1) PRIMARY KEY,
    TeamId INT NOT NULL,
    PersonId INT NOT NULL,
    CONSTRAINT FK_TeamMembers_Teams FOREIGN KEY (TeamId) REFERENCES Teams(TeamId),
    CONSTRAINT FK_TeamMembers_People FOREIGN KEY (PersonId) REFERENCES People(PersonId)
);

-- =======================
-- Tournaments
-- =======================
CREATE TABLE Tournaments (
    TournamentId INT IDENTITY(1,1) PRIMARY KEY,
    TournamentName NVARCHAR(200) NOT NULL,
    EntryFee DECIMAL(10,2) NOT NULL
);

-- =======================
-- TournamentEntries (junction table)
-- =======================
CREATE TABLE TournamentEntries (
    TournamentEntryId INT IDENTITY(1,1) PRIMARY KEY,
    TournamentId INT NOT NULL,
    TeamId INT NOT NULL,
    CONSTRAINT FK_TournamentEntries_Tournaments FOREIGN KEY (TournamentId) REFERENCES Tournaments(TournamentId),
    CONSTRAINT FK_TournamentEntries_Teams FOREIGN KEY (TeamId) REFERENCES Teams(TeamId)
);

-- =======================
-- Prizes
-- =======================
CREATE TABLE Prizes (
    PrizeId INT IDENTITY(1,1) PRIMARY KEY,
    PlaceNumber INT NOT NULL,
    PlaceName NVARCHAR(100) NOT NULL,
    PrizeAmount MONEY NOT NULL DEFAULT 0,
    PrizePercentage FLOAT NULL
);

-- =======================
-- TournamentPrizes (junction table)
-- =======================
CREATE TABLE TournamentPrizes (
    TournamentPrizeId INT IDENTITY(1,1) PRIMARY KEY,
    TournamentId INT NOT NULL,
    PrizeId INT NOT NULL,
    CONSTRAINT FK_TournamentPrizes_Tournaments FOREIGN KEY (TournamentId) REFERENCES Tournaments(TournamentId),
    CONSTRAINT FK_TournamentPrizes_Prizes FOREIGN KEY (PrizeId) REFERENCES Prizes(PrizeId)
);

-- =======================
-- Matchups
-- =======================
CREATE TABLE Matchups (
    MatchupId INT IDENTITY(1,1) PRIMARY KEY,
    TournamentId INT NOT NULL,
    MatchupRound INT NOT NULL,
    WinnerId INT NULL,
    CONSTRAINT FK_Matchups_Tournaments FOREIGN KEY (TournamentId) REFERENCES Tournaments(TournamentId),
    CONSTRAINT FK_Matchups_Teams_WinnerId FOREIGN KEY (WinnerId) REFERENCES Teams(TeamId)
);

-- =======================
-- MatchupEntries
-- =======================
CREATE TABLE MatchupEntries (
    MatchupEntryId INT IDENTITY(1,1) PRIMARY KEY,
    MatchupId INT NOT NULL,
    TeamCompetingId INT NULL,
    Score FLOAT NULL,
    ParentMatchupId INT NULL,
    CONSTRAINT FK_MatchupEntries_Matchups FOREIGN KEY (MatchupId) REFERENCES Matchups(MatchupId),
    CONSTRAINT FK_MatchupEntries_Teams_TeamCompetingId FOREIGN KEY (TeamCompetingId) REFERENCES Teams(TeamId),
    CONSTRAINT FK_MatchupEntries_Matchups_ParentMatchupId FOREIGN KEY (ParentMatchupId) REFERENCES Matchups(MatchupId)
);