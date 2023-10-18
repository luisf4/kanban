CREATE DATABASE Kanban
GO

USE Kanban
GO

CREATE TABLE Status
(
	StatusId  int           primary key  identity,
	Name      varchar(60)   not null
)

INSERT INTO Status VALUES ('To Do')
INSERT INTO Status VALUES ('Doing')
INSERT INTO Status VALUES ('Done')

SELECT * FROM Status