USE GuildCars
GO


--Get All Vehicles--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllVehicles'
)
BEGIN 
	DROP PROCEDURE GetAllVehicles
END 
GO

CREATE PROCEDURE GetAllVehicles
AS
BEGIN
SELECT v.VIN, v.New, v.[Year], ma.MakeName, mo.ModelName, v.BodyStyle, c.ColorName, i.InteriorName, v.Transmission, v.Mileage, v.SalePrice, v.MSRP, v.[Description], v.Featured, v.Sold, v.ImageFileName
FROM Vehicles v
	INNER JOIN Models mo ON mo.ModelId = v.ModelId
	INNER JOIN Makes ma ON ma.MakeId = mo.MakeId
	INNER JOIN Colors c ON c.ColorId = v.ColorId
	INNER JOIN Interiors i ON i.InteriorId = v.InteriorId
END
GO



--Get All New--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllNew'
)
BEGIN 
	DROP PROCEDURE GetAllNew
END 
GO

CREATE PROCEDURE GetAllNew
AS
BEGIN
SELECT v.VIN, v.New, v.[Year], ma.MakeName, mo.ModelName, v.BodyStyle, c.ColorName, i.InteriorName, v.Transmission, v.Mileage, v.SalePrice, v.MSRP, v.[Description], v.Featured, v.Sold, v.ImageFileName
FROM Vehicles v
	INNER JOIN Models mo ON mo.ModelId = v.ModelId
	INNER JOIN Makes ma ON ma.MakeId = mo.MakeId
	INNER JOIN Colors c ON c.ColorId = v.ColorId
	INNER JOIN Interiors i ON i.InteriorId = v.InteriorId
WHERE v.New = 1
END
GO


--Get All Used--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllUsed'
)
BEGIN 
	DROP PROCEDURE GetAllUsed
END 
GO

CREATE PROCEDURE GetAllUsed
AS
BEGIN
SELECT v.VIN, v.New, v.[Year], ma.MakeName, mo.ModelName, v.BodyStyle, c.ColorName, i.InteriorName, v.Transmission, v.Mileage, v.SalePrice, v.MSRP, v.[Description], v.Featured, v.Sold, v.ImageFileName
FROM Vehicles v
	INNER JOIN Models mo ON mo.ModelId = v.ModelId
	INNER JOIN Makes ma ON ma.MakeId = mo.MakeId
	INNER JOIN Colors c ON c.ColorId = v.ColorId
	INNER JOIN Interiors i ON i.InteriorId = v.InteriorId
WHERE v.New = 0
END
GO


--Get All Featured--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllFeatured'
)
BEGIN 
	DROP PROCEDURE GetAllFeatured
END 
GO

CREATE PROCEDURE GetAllFeatured
AS
BEGIN
SELECT v.VIN, v.New, v.[Year], ma.MakeName, mo.ModelName, v.BodyStyle, c.ColorName, i.InteriorName, v.Transmission, v.Mileage, v.SalePrice, v.MSRP, v.[Description], v.Featured, v.Sold, v.ImageFileName
FROM Vehicles v
	INNER JOIN Models mo ON mo.ModelId = v.ModelId
	INNER JOIN Makes ma ON ma.MakeId = mo.MakeId
	INNER JOIN Colors c ON c.ColorId = v.ColorId
	INNER JOIN Interiors i ON i.InteriorId = v.InteriorId
WHERE v.Featured = 1
END
GO


--Get Vehicle--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetVehicle'
)
BEGIN 
	DROP PROCEDURE GetVehicle
END 
GO

CREATE PROCEDURE GetVehicle(
	@VIN CHAR(17)
)
AS
BEGIN
SELECT v.VIN, v.New, v.[Year], ma.MakeName, mo.ModelName, v.BodyStyle, c.ColorName, i.InteriorName, v.Transmission, v.Mileage, v.SalePrice, v.MSRP, v.[Description], v.Featured, v.Sold, v.ImageFileName
FROM Vehicles v
	INNER JOIN Models mo ON mo.ModelId = v.ModelId
	INNER JOIN Makes ma ON ma.MakeId = mo.MakeId
	INNER JOIN Colors c ON c.ColorId = v.ColorId
	INNER JOIN Interiors i ON i.InteriorId = v.InteriorId
WHERE v.VIN = @VIN
END
GO



--Get All States--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetStates'
)
BEGIN 
	DROP PROCEDURE GetStates
END 
GO

CREATE PROCEDURE GetStates
AS 
BEGIN
SELECT * FROM States
END
GO



--Get State By ID--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetState'
)
BEGIN 
	DROP PROCEDURE GetState
END 
GO

CREATE PROCEDURE GetState(
	@StateId CHAR(2)
)
AS 
BEGIN
SELECT * FROM States
WHERE StateId = @StateId
END
GO




--Get Models--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetModels'
)
BEGIN 
	DROP PROCEDURE GetModels
END 
GO

CREATE PROCEDURE GetModels
AS 
BEGIN
SELECT m.ModelId, m.ModelName, ma.MakeName, m.DateAdded, u.UserName
FROM Models m
	INNER JOIN AspNetUsers u ON u.Id = m.UserId
	INNER JOIN Makes ma ON ma.MakeId = m.ModelId
END
GO


--Get Model By Name--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetModel'
)
BEGIN 
	DROP PROCEDURE GetModel
END 
GO

CREATE PROCEDURE GetModel(
	@ModelName NVARCHAR(30)
)
AS 
BEGIN
SELECT m.ModelId, m.ModelName, ma.MakeName, m.DateAdded, u.UserName
FROM Models m
	INNER JOIN AspNetUsers u ON u.Id = m.UserId
	INNER JOIN Makes ma ON ma.MakeId = m.ModelId

WHERE ModelName = @ModelName
END
GO



--Get Makes--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetMakes'
)
BEGIN 
	DROP PROCEDURE GetMakes
END 
GO

CREATE PROCEDURE GetMakes
AS 
BEGIN
SELECT m.MakeId, m.MakeName, m.DateAdded, u.UserName
FROM Makes m
	INNER JOIN AspNetUsers u ON u.Id = m.UserId
END
GO



--Get Model By Name--
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetMake'
)
BEGIN 
	DROP PROCEDURE GetMake
END 
GO

CREATE PROCEDURE GetMake(
	@MakeName NVARCHAR(30)
)
AS 
BEGIN
SELECT m.MakeId, m.MakeName, m.DateAdded, u.UserName
FROM Makes m
	INNER JOIN AspNetUsers u ON u.Id = m.UserId
WHERE MakeName = @MakeName
END
GO



-- Get Specials --
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetSpecials'
)
BEGIN 
	DROP PROCEDURE GetSpecials
END 
GO

CREATE PROCEDURE GetSpecials
AS
BEGIN
SELECT * FROM Specials
END




--Sale Item --
If EXISTS (
	SELECT * 
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetSales'
)
BEGIN 
	DROP PROCEDURE GetSales
END 
GO

CREATE PROCEDURE GetSales
AS
BEGIN
SELECT * FROM SaleItems
END


