USE [master];

DECLARE @kill varchar(8000) = '';  
SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'  
FROM sys.dm_exec_sessions
WHERE database_id  = db_id('GuildCars')

EXEC(@kill);

if exists (select * from sysdatabases where name='GuildCars')
		drop database GuildCars
GO

CREATE DATABASE GuildCars
GO

