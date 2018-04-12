USE GuildCars
GO

DROP PROCEDURE IF EXISTS dbo.GetAllVehicles
DROP PROCEDURE IF EXISTS dbo.GetAllNew
DROP PROCEDURE IF EXISTS dbo.GetAllUsed
DROP PROCEDURE IF EXISTS dbo.GetAllFeatured
DROP PROCEDURE IF EXISTS dbo.GetVehicle
DROP PROCEDURE IF EXISTS dbo.AddVehicle
DROP PROCEDURE IF EXISTS dbo.EditVehicle
DROP PROCEDURE IF EXISTS dbo.DeleteVehicle
DROP PROCEDURE IF EXISTS dbo.GetStates
DROP PROCEDURE IF EXISTS dbo.GetState
DROP PROCEDURE IF EXISTS dbo.GetModels
DROP PROCEDURE IF EXISTS dbo.GetModel
DROP PROCEDURE IF EXISTS dbo.AddModel
DROP PROCEDURE IF EXISTS dbo.GetModelsByMakeId
DROP PROCEDURE IF EXISTS dbo.GetMakes
DROP PROCEDURE IF EXISTS dbo.GetMake
DROP PROCEDURE IF EXISTS dbo.AddMake
DROP PROCEDURE IF EXISTS dbo.GetMakeByModelId
DROP PROCEDURE IF EXISTS dbo.GetSpecials
DROP PROCEDURE IF EXISTS dbo.GetSpecial
DROP PROCEDURE IF EXISTS dbo.AddSpecial
DROP PROCEDURE IF EXISTS dbo.DeleteSpecial
DROP PROCEDURE IF EXISTS dbo.GetSales
DROP PROCEDURE IF EXISTS dbo.GetColors
DROP PROCEDURE IF EXISTS dbo.GetColor
DROP PROCEDURE IF EXISTS dbo.GetInteriors
DROP PROCEDURE IF EXISTS dbo.GetInterior
DROP PROCEDURE IF EXISTS dbo.AddContact
DROP PROCEDURE IF EXISTS dbo.AddSaleItem
DROP PROCEDURE IF EXISTS dbo.InventoryReportNew
DROP PROCEDURE IF EXISTS dbo.InventoryReportUsed
GO

--Get All Vehicles--
CREATE PROCEDURE GetAllVehicles
AS
BEGIN
SELECT v.VIN, v.New, v.[Year],ma.MakeId, ma.MakeName, mo.ModelId, mo.ModelName, v.BodyStyle, c.ColorId, c.ColorName, i.InteriorId, i.InteriorName, v.Transmission, v.Mileage, v.SalePrice, v.MSRP, v.[Description], v.Featured, v.Sold, v.ImageFileName
FROM Vehicles v
	INNER JOIN Models mo ON mo.ModelId = v.ModelId
	INNER JOIN Makes ma ON ma.MakeId = mo.MakeId
	INNER JOIN Colors c ON c.ColorId = v.ColorId
	INNER JOIN Interiors i ON i.InteriorId = v.InteriorId
ORDER BY v.[Year] DESC, ma.MakeName, mo.ModelName
END
GO



--Get All New--
CREATE PROCEDURE GetAllNew
AS
BEGIN
SELECT v.VIN, v.New, v.[Year],ma.MakeId, ma.MakeName, mo.ModelId, mo.ModelName, v.BodyStyle, c.ColorId, c.ColorName, i.InteriorId, i.InteriorName, v.Transmission, v.Mileage, v.SalePrice, v.MSRP, v.[Description], v.Featured, v.Sold, v.ImageFileName
FROM Vehicles v
	INNER JOIN Models mo ON mo.ModelId = v.ModelId
	INNER JOIN Makes ma ON ma.MakeId = mo.MakeId
	INNER JOIN Colors c ON c.ColorId = v.ColorId
	INNER JOIN Interiors i ON i.InteriorId = v.InteriorId
WHERE v.New = 1
END
GO


--Get All Used--
CREATE PROCEDURE GetAllUsed
AS
BEGIN
SELECT v.VIN, v.New, v.[Year],ma.MakeId, ma.MakeName, mo.ModelId, mo.ModelName, v.BodyStyle, c.ColorId, c.ColorName, i.InteriorId, i.InteriorName, v.Transmission, v.Mileage, v.SalePrice, v.MSRP, v.[Description], v.Featured, v.Sold, v.ImageFileName
FROM Vehicles v
	INNER JOIN Models mo ON mo.ModelId = v.ModelId
	INNER JOIN Makes ma ON ma.MakeId = mo.MakeId
	INNER JOIN Colors c ON c.ColorId = v.ColorId
	INNER JOIN Interiors i ON i.InteriorId = v.InteriorId
WHERE v.New = 0
END
GO


--Get All Featured--
CREATE PROCEDURE GetAllFeatured
AS
BEGIN
SELECT v.VIN, v.New, v.[Year],ma.MakeId, ma.MakeName, mo.ModelId, mo.ModelName, v.BodyStyle, c.ColorId, c.ColorName, i.InteriorId, i.InteriorName, v.Transmission, v.Mileage, v.SalePrice, v.MSRP, v.[Description], v.Featured, v.Sold, v.ImageFileName
FROM Vehicles v
	INNER JOIN Models mo ON mo.ModelId = v.ModelId
	INNER JOIN Makes ma ON ma.MakeId = mo.MakeId
	INNER JOIN Colors c ON c.ColorId = v.ColorId
	INNER JOIN Interiors i ON i.InteriorId = v.InteriorId
WHERE v.Featured = 1
END
GO


--Get Vehicle--
CREATE PROCEDURE GetVehicle(
	@VIN CHAR(17)
)
AS
BEGIN
SELECT v.VIN, v.New, v.[Year],ma.MakeId, ma.MakeName, mo.ModelId, mo.ModelName, v.BodyStyle, c.ColorId, c.ColorName, i.InteriorId, i.InteriorName, v.Transmission, v.Mileage, v.SalePrice, v.MSRP, v.[Description], v.Featured, v.Sold, v.ImageFileName
FROM Vehicles v
	INNER JOIN Models mo ON mo.ModelId = v.ModelId
	INNER JOIN Makes ma ON ma.MakeId = mo.MakeId
	INNER JOIN Colors c ON c.ColorId = v.ColorId
	INNER JOIN Interiors i ON i.InteriorId = v.InteriorId
WHERE v.VIN = @VIN
END
GO



--Add Vehicle--
CREATE PROCEDURE AddVehicle(
	@VIN CHAR(17),
	@NEW BIT,
	@Year INT,
	@ModelId INT,
	@BodyStyle INT,
	@ColorId INT,
	@InteriorId INT,
	@Transmission INT,
	@Mileage INT,
	@SalePrice DECIMAL(9,2),
	@MSRP DECIMAL(9,2),
	@Description NVARCHAR(180),
	@Featured BIT,
	@Sold BIT, 
	@ImageFileName NVARCHAR(200)
)
AS
BEGIN

INSERT INTO Vehicles (VIN,New,[Year],ModelId,BodyStyle,ColorId,InteriorId,Transmission,Mileage,SalePrice,MSRP,[Description],Featured,Sold,ImageFileName)
	VALUES(@VIN,@NEW,@Year,@ModelId,@BodyStyle,@ColorId,@InteriorId,@Transmission,@Mileage,@SalePrice,@MSRP,@Description,@Featured,@Sold,@ImageFileName)
END
GO



--Edit Vehicle--
CREATE PROCEDURE EditVehicle(
	@VIN CHAR(17),
	@NEW BIT,
	@Year INT,
	@ModelId INT,
	@BodyStyle INT,
	@ColorId INT,
	@InteriorId INT,
	@Transmission INT,
	@Mileage INT,
	@SalePrice DECIMAL(9,2),
	@MSRP DECIMAL(9,2),
	@Description NVARCHAR(180),
	@Featured BIT,
	@Sold BIT, 
	@ImageFileName NVARCHAR(200)
)
AS
BEGIN
	BEGIN TRANSACTION
UPDATE Vehicles 
	SET New = @NEW,
		[Year] = @Year,
		ModelId = @ModelId,
		BodyStyle = @BodyStyle,
		ColorId = @ColorId,
		InteriorId = @InteriorId,
		Transmission = @Transmission,
		Mileage = @Mileage,
		SalePrice = @SalePrice,
		MSRP = @MSRP,
		[Description] = @Description,
		Featured = @Featured,
		Sold = @Sold,
		ImageFileName = @ImageFileName
	WHERE VIN = @VIN
	COMMIT TRANSACTION
END
GO



--Delete Vehicle--
CREATE PROCEDURE DeleteVehicle(
	@VIN CHAR(17)
)
AS
BEGIN
BEGIN TRANSACTION
DELETE FROM Contacts
WHERE VIN = @VIN
DELETE FROM SaleItems
WHERE VIN = @VIN
DELETE FROM Vehicles
WHERE VIN = @VIN
COMMIT TRANSACTION
END
GO


--Get All States--
CREATE PROCEDURE GetStates
AS 
BEGIN
SELECT * FROM States
END
GO



--Get State By ID--
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
CREATE PROCEDURE GetModels
AS 
BEGIN
SELECT m.ModelId, m.ModelName, ma.MakeId, ma.MakeName, m.DateAdded, u.UserName, u.Id AS UserId
FROM Models m
	INNER JOIN AspNetUsers u ON u.Id = m.UserId
	INNER JOIN Makes ma ON ma.MakeId = m.MakeId
END
GO


--Get Models by Make Id--
CREATE PROCEDURE GetModelsByMakeId(
	@MakeId INT
)
AS
BEGIN
SELECT m.ModelId, m.ModelName, ma.MakeId, ma.MakeName, m.DateAdded, u.UserName, u.Id AS UserId
FROM Models m
	INNER JOIN AspNetUsers u ON u.Id = m.UserId
	INNER JOIN Makes ma ON ma.MakeId = m.MakeId
WHERE m.MakeId = @MakeId
	
END
GO


--Get Model By Name--
CREATE PROCEDURE GetModel(
	@ModelId INT
)
AS 
BEGIN
SELECT m.ModelId, m.ModelName, ma.MakeId, ma.MakeName, m.DateAdded, u.UserName, u.Id AS UserId
FROM Models m
	INNER JOIN AspNetUsers u ON u.Id = m.UserId
	INNER JOIN Makes ma ON ma.MakeId = m.MakeId

WHERE ModelId = @ModelId
END
GO


-- Add Model -- 
CREATE PROCEDURE AddModel(
	@ModelId INT OUTPUT,
	@MakeId NVARCHAR(30),
	@ModelName NVARCHAR(30),
	@UserId NVARCHAR(128)
)
AS
BEGIN
INSERT INTO Models(ModelName, MakeId, UserId)
	VALUES(@ModelName, @MakeId, @UserId)
	SET @ModelId = SCOPE_IDENTITY()
END
GO



--Get Makes--
CREATE PROCEDURE GetMakes
AS 
BEGIN
SELECT m.MakeId, m.MakeName, m.DateAdded, u.UserName, u.Id AS UserId
FROM Makes m
	INNER JOIN AspNetUsers u ON u.Id = m.UserId
END
GO


--Add Make--
CREATE PROCEDURE AddMake(
	@MakeId INT OUTPUT,
	@MakeName NVARCHAR(30),
	@UserId NVARCHAR(128)
)
AS
BEGIN
INSERT INTO Makes(MakeName, UserId)
	VALUES(@MakeName, @UserId)
	SET @MakeId = SCOPE_IDENTITY()
END
GO


--Get Model By Name--
CREATE PROCEDURE GetMake(
	@MakeId INT
)
AS 
BEGIN
SELECT m.MakeId, m.MakeName, m.DateAdded, u.UserName, u.Id AS UserId
FROM Makes m
	INNER JOIN AspNetUsers u ON u.Id = m.UserId
WHERE MakeId = @MakeId
END
GO



--Get Make by Model Id--
CREATE PROCEDURE GetMakeByModelId(
	@ModelId INT
)
AS
BEGIN
SELECT m.MakeId, m.MakeName, m.DateAdded, u.UserName, u.Id AS UserId
FROM Makes m
	INNER JOIN AspNetUsers u ON u.Id = m.UserId
	INNER JOIN Models mo ON mo.MakeId = m.MakeId
WHERE mo.ModelId = @ModelId
END
GO


-- Get Specials --
CREATE PROCEDURE GetSpecials
AS
BEGIN
SELECT * FROM Specials
END
GO


-- Get Special --
CREATE PROCEDURE GetSpecial(
	@SpecialId INT 
)
AS
BEGIN
SELECT * FROM Specials
WHERE SpecialId = @SpecialId
END
GO


-- Add Special --
CREATE PROCEDURE AddSpecial(
	@SpecialId INT OUTPUT,
	@SpecialName NVARCHAR(30),
	@Description NVARCHAR(250),
	@ImageFileName NVARCHAR(200)
)	
AS
BEGIN
BEGIN TRANSACTION
INSERT Specials (SpecialName, [Description], ImageFileName)
	VALUES(@SpecialName, @Description, @ImageFileName)
	SET @SpecialId = SCOPE_IDENTITY()
COMMIT TRANSACTION
END
GO


-- Delete Special --
CREATE PROCEDURE DeleteSpecial(
	@SpecialId INT
)
AS
BEGIN
DELETE FROM Specials
WHERE SpecialId = @SpecialID
END
GO



--Sale Item --
CREATE PROCEDURE GetSales
AS
BEGIN
SELECT * FROM SaleItems
END
GO



--Get Colors--
CREATE PROCEDURE GetColors
AS
BEGIN
SELECT * FROM Colors
END
GO

--Get Color--
CREATE PROCEDURE GetColor(
	@ColorId INT
)
AS
BEGIN
SELECT * FROM Colors
WHERE ColorId = @ColorId
END
GO



--Get Interiors--
CREATE PROCEDURE GetInteriors
AS
BEGIN
SELECT * FROM Interiors
END
GO

--Get Interior--
CREATE PROCEDURE GetInterior(
	@InteriorId INT
)
AS
BEGIN
SELECT * FROM Interiors
WHERE InteriorId = @InteriorId
END
GO



--Add Contact--
CREATE PROCEDURE AddContact(
	@ContactId INT OUTPUT,
	@VIN CHAR(17),
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Email NVARCHAR(100) = NUll,
	@Phone NVARCHAR(30) = NULL,
	@Message NVARCHAR(250)
)
AS
BEGIN
BEGIN TRANSACTION
INSERT INTO Contacts (VIN, FirstName, LastName, [Message])
	VALUES(@VIN, @FirstName, @LastName, @Message)
	SET @ContactId = SCOPE_IDENTITY()
	
	IF @Email IS NOT NULL
	UPDATE Contacts
	SET Email = @Email
	WHERE ContactId = @ContactId

	IF @Phone IS NOT NULL
	UPDATE Contacts
	SET Phone = @Phone
	WHERE ContactId = @ContactId
COMMIT TRANSACTION
END
GO


--Add Sale Item--
CREATE PROCEDURE AddSaleItem(
	@SaleId INT OUTPUT,
	@VIN CHAR(17),
	@UserId NVARCHAR(128),
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR (100),
	@Email NVARCHAR(100) = NULL,
	@Phone NVARCHAR(30) = NULL,
	@Street1 NVARCHAR(100),
	@Street2 NVARCHAR(100),
	@StateId CHAR(2),
	@City NVARCHAR(50),
	@Zipcode INT,
	@PurchasePrice DECIMAL(9,2),
	@PurchaseType INT
)
AS
BEGIN
BEGIN TRANSACTION
INSERT INTO SaleItems(VIN, UserId,FirstName,LastName,Street1,Street2,StateId,City,Zipcode,PurchasePrice,PurchaseType)
	VALUES(@VIN,@UserId,@FirstName,@LastName,@Street1,@Street2,@StateId, @City,@Zipcode,@PurchasePrice,@PurchaseType)
	SET @SaleId = SCOPE_IDENTITY()
	
UPDATE Vehicles
	SET Sold = 1
	WHERE VIN = @VIN

	IF @Email IS NOT NULL
	UPDATE SaleItems
	SET Email = @Email
	WHERE SaleId = @SaleId

	IF @Phone IS NOT NULL
	UPDATE SaleItems
	SET Phone = @Phone
	WHERE SaleId = @SaleId
COMMIT TRANSACTION
END
GO



CREATE PROCEDURE InventoryReportNew
AS
BEGIN
SELECT  v.[Year], ma.MakeName, mo.ModelName,COUNT(*) as [Count], SUM(SalePrice)as StockValue
FROM Vehicles v
	INNER JOIN Models mo ON mo.ModelId = v.ModelId
	INNER JOIN Makes ma ON ma.MakeId = mo.MakeId
	WHERE New = 1 AND Sold = 0
GROUP BY [Year], ma.MakeName, mo.ModelName, SalePrice
END
GO

CREATE PROCEDURE InventoryReportUsed
AS
BEGIN
SELECT  v.[Year], ma.MakeName, mo.ModelName,COUNT(*) as [Count], SUM(SalePrice) as StockValue
FROM Vehicles v
	INNER JOIN Models mo ON mo.ModelId = v.ModelId
	INNER JOIN Makes ma ON ma.MakeId = mo.MakeId
	WHERE New = 0 AND Sold = 0
GROUP BY [Year], ma.MakeName, mo.ModelName, SalePrice
END
GO