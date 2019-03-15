-- DELETE All data
DELETE FROM survey_result;
DELETE FROM weather;
DELETE FROM users;
DELETE FROM park;

-- Insert a fake park
INSERT INTO park VALUES('ABC', 'Kings Dominion', 'VA', 12000, 1, 2, 0, 'Rainy', 1982, 12, 'Of all the things I have lost, I miss my mind the most.', 'Ozzy Osbourne', 'The best park in the world', 0, 10);

-- Insert fake forecast
INSERT INTO weather VALUES('ABC', 1, 14, 22, 'cloudy');
INSERT INTO weather VALUES('ABC', 2, 23, 32, 'sunny');
INSERT INTO weather VALUES('ABC', 3, 20, 25, 'partly cloudy');
INSERT INTO weather VALUES('ABC', 4, 30, 42, 'thunderstorms');
INSERT INTO weather VALUES('ABC', 5, 37, 45, 'rain');

-- Insert a fake survey result
INSERT INTO survey_result VALUES('ABC', 'd@yo.org', 'VA', 'active');
DECLARE @newSurveyId int = (SELECT @@IDENTITY);

-- Send new surveyId value back
SELECT @newSurveyId as newSurveyId;
