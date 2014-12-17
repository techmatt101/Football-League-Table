--DECLARE @Place int;
--SET @Place = 1;

--DECLARE @Played int;
--SET @Played = 1;

--DECLARE @Won int;
--SET @Won = 2;

--DECLARE @Drawn int;
--SET @Drawn = 3;

--DECLARE @Lost int;
--SET @Lost = 4;

--DECLARE @For int;
--SET @For = 5;

--DECLARE @Against int;
--SET @Against = 6;

--DECLARE @GoalDifference int;
--SET @GoalDifference = 7;

--DECLARE @Points int;
--SET @Points = 99;

--DECLARE @Team nvarchar(MAX);
--SET @Team = 'TestTeam';


DECLARE @TeamId int;
SET @TeamId = (SELECT MatchHistoryId FROM Teams WHERE Name = @Team);

IF @TeamId IS NOT NULL
	BEGIN
		UPDATE MatchHistories SET "Played" = @Played, "Won" = @Won, "Drawn" = @Drawn, "Lost" = @Lost, "For" = @For, "Against" = @Against, "GoalDifference" = @GoalDifference, "Points" = @Points
		WHERE MatchHistoryId = @TeamId
	END
ELSE
	BEGIN
		INSERT INTO MatchHistories ("Position", "Played", "Won", "Drawn", "Lost", "For", "Against", "GoalDifference", "Points")
		VALUES (@Place, @Played, @Won, @Drawn, @Lost, @For, @Against, @GoalDifference, @Points)

		INSERT INTO Teams ("Name", "LeagueId", "MatchHistoryId")
		VALUES (@Team, 1, @@IDENTITY)
	END
