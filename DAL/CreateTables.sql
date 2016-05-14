--DROP TABLE [dbo].[Question];
--DROP TABLE [dbo].[Game];
--DROP TABLE [dbo].[ArtWork];
--DROP TABLE [dbo].[User];
--DROP TABLE [dbo].[QuestionSet];
--DROP TABLE [dbo].[Artist];
--DROP TABLE [dbo].[Log];

CREATE TABLE [dbo].[GameQuestions]
(
	[GameQuestionsId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NULL,
	[IsGameMode] BIT NOT NULL DEFAULT 'FALSE'
);

create table [dbo].[Artist]
(
	[ArtistId] int not null primary key identity, 
    [Name] nvarchar(50) not null
)

create table [dbo].[Artwork]
(
	[ArtworkId] int not null primary key identity, 
    [ArtistId] int not null, 
	[ArtWorkType] int not null, 
    [Name] nvarchar(100) not null, 
    [Year] int null, 
	[FileLocation] nvarchar (255) not null,
	constraint [Fk_Artwork_ToArtist] foreign key ([ArtistId]) references [Artist]([ArtistId])
)


create table [dbo].[Game] (
    [GameId]        int      not null primary key identity,
    [UserId]        nvarchar(128)      not null,
    [GameQuestionsId] int      not null,
    [Maxpoints]      int      not null,
    [Points]         int      not null,
    [Duration]       INT	  NULL,
	[Type]			 int	  not null,
    constraint [Fk_Game_GameQuestions] foreign key ([GameQuestionsId]) references [dbo].[GameQuestions] ([GameQuestionsId]),
    constraint [Fk_Game_User] foreign key ([UserId]) references [dbo].[User] ([UserId])
);

create table [dbo].[Question] (
    [QuestionId]    int identity (1, 1) not null,
    [GameQuestionsId] int not null,
    [ArtWorkId]     int not null,
    [Points]  INT NULL,
	[IsAuthorCorrect] BIT NOT NULL DEFAULT 'FALSE',
	[IsArtWorkCorrect] BIT NOT NULL DEFAULT 'FALSE',
    primary key clustered ([QuestionId] asc),
    constraint [Fk_Question_ToGameQuestions] foreign key ([GameQuestionsId]) references [dbo].[GameQuestions] ([GameQuestionsId]),
	constraint [Fk_Question_ToArtWork] foreign key ([ArtWorkId]) references [dbo].[Artwork] ([ArtWorkId])
);

CREATE TABLE [dbo].[Log] (
    [LogsId]     INT           NOT NULL PRIMARY KEY IDENTITY,
    [Type]        SMALLINT 		NOT NULL,
    [CreatedTime] DATETIME2 (3) NOT NULL,
    [Message]     TEXT          NOT NULL
);