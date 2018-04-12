USE GuildCars
GO

DROP PROCEDURE IF EXISTS DBReset
GO

CREATE PROCEDURE DBReset
AS
BEGIN


DELETE FROM SaleItems
DELETE FROM Contacts
DELETE FROM Vehicles
DELETE FROM Colors
DELETE FROM Models
DELETE FROM Makes
DELETE FROM Interiors
DELETE FROM Specials
DELETE FROM States


SET IDENTITY_INSERT Colors ON 
INSERT INTO Colors (ColorId,ColorName)
	VALUES(1,'White'),
		(2,'Black'),
		(3,'Red'),
		(4,'Tan'),
		(5,'Grey'),
		(6,'Blue'),
		(7,'Yellow'),
		(8,'Lime Green'),
		(9,'Burnt Orange'),
		(10,'Purple')
SET IDENTITY_INSERT Colors OFF 


SET IDENTITY_INSERT Interiors ON 
INSERT INTO Interiors(InteriorId,InteriorName)
	VALUES(1,'Cloth'),
		(2,'Leather'),
		(3,'Valour'),
		(4,'Suede'),
		(5,'Creme'),
		(6,'Black n'' Tan'),
		(7,'Black'),
		(8,'Walnut'),
		(9,'Alligator'),
		(10,'Jersey')
SET IDENTITY_INSERT Interiors OFF


SET IDENTITY_INSERT Makes ON 
INSERT INTO Makes(MakeId,MakeName)
	VALUES(1, 'Ford'),
		(2, 'Chevrolet'),
		(3, 'Dodge'),
		(4, 'Jeep'),
		(5, 'Nissan'),
		(6, 'GMC'),
		(7, 'BMW'),
		(8, 'Kia'),
		(9, 'Toyota'),
		(10, 'Saturn')
SET IDENTITY_INSERT Makes OFF
UPDATE Makes 
	SET UserId = '57383afa-9157-4d24-86cf-2e1a097b29f4'


SET IDENTITY_INSERT Models ON
INSERT INTO Models (MakeId,ModelId, ModelName)
	VALUES(1,1,'Focus'),(1,2,'F150'),(1,3,'Tarus'),
		(2,4,'Cruze'),(2,5,'Malibu'),(2,6,'Impala'),
		(3,7,'Challenger'),(3,8,'Ram'),(3,9,'Charger'),
		(4,10,'Wrangler'),(4,11,'Grand Cherokee'),(4,12,'Compass'),
		(5,13,'Rogue'),(5,14,'Sentra'),(5,15,'Juke'),
		(6,16,'Yukon'),(6,17,'Canyon'),(6,18,'Sierra 1500'),
		(7,19,'X5'),(7,20,'M5'),(7,21,'M4'),
		(8,22,'Sonata'),(8,23,'Rio'),(8,24,'Soul'),
		(9,25,'Tacoma'),(9,26,'Prius'),(9,27,'Highlander'),
		(10,28,'VUE'),(10,29,'ION'),(10,30,'Relay')
SET IDENTITY_INSERT Models OFF
UPDATE Models
	SET UserId = '57383afa-9157-4d24-86cf-2e1a097b29f4'



SET IDENTITY_INSERT Specials ON
INSERT INTO Specials (SpecialId, SpecialName, [Description], ImageFileName)
	VALUES(1,'Summer Sale','No money down, no payments until next summer! SAY WHAT?! Yeah, you heard us. When you can''t beat the heat, you can''t beat these prices!', 'summersale.jpg'),
		(2, 'BOGO', 'Buy one car, truck or SUV and get a FREE used van!!!','bogo.jpg'),
		(3, 'Car-o-ween', '$3000 off any new or used car! The deals are just down right spooky this time of year. BOOOOOOOOOO!','caroween.jpg'),
		(4, 'Back 2 School', 'Get everything you need for the semester and then get $2000 off any new vehicle on the lot', 'back2school.jpg'),
		(5, 'Winter Sales Event', 'No money down and no payments for 6 months when you finance a new van with us! Take the fam to someplace warm and pay us when you get back.', 'wintersalesevent.jpg'),
		(6, '#truckme', 'WIN A FREE TRUCK!! Follow our instagram, tag us in a picture of your sad excuse of a vehicle, with #truckme in the caption to be entered to win a FREE TRUCK! FREE TRUCK DUDE! IT DOESN''T COST MONEY!', 'truckme.jpg'),
		(7, 'Health Plan', 'Get free oil changes, washer fluid, and car washes with purchase of any new or used vehicle', 'healthplan.jpg'),
		(8, 'Soccer Season', 'All new and used vans at least %15 off', 'soccerseason.jpg'),
		(9, 'Speed Racer', 'Free helmet with purchase of any coupe', 'speedracer.jpg'),
		(10, 'Drive Theater', 'Upgrade to a full media package for FREE when purchasing a new SUV', 'drivetheater.jpg')
SET IDENTITY_INSERT Specials OFF



INSERT INTO States (StateId,StateName)
	VALUES('AL','Alabama'),('AK','Alaska'),('AZ','Arizona'),('AR','Arkanasas'),
		('CA','California'),('CO','Colorado'),('CT','Connecticut'),('DE','Delaware'),
		('DC','District of Columbia'),('FL','Florida'),('GA','Georgia'),('HI','Hawaii'),
		('ID','Idaho'),('IL','Illinois'),('IN','Indiana'),('IA','Iowa'),('KS','Kansas'),
		('KY','Kentucky'),('LA','Louisiana'),('ME','Maine'),('MD','Maryland'),('MA','Massachusetts'),
		('MI','Michigan'),('MN','Minnesota'),('MS','Mississippi'),('MO','Missouri'),('MT','Montana'),
		('NE','Nebraska'),('NV','Nevada'),('NH','New Hampshire'),('NJ','New Jersey'),('NM','New Mexico'),
		('NY','New York'),('NC','North Carolina'),('ND','North Dakota'),('OK','Oklahoma'),('OH','Ohio'),
		('OR','Oregon'),('PA','Pennsylvania'),('RI','Rhode Island'),('SC','South Carolina'),('SD','South Dakota'),
		('TN','Tennessee'),('TX','Texas'),('UT','Utah'),('VT','Vermont'),('VA','Virginia'),('WA','Washington'),
		('WV','West Virgina'),('WI','Wisconsin'),('WY','Wyoming')


INSERT INTO Vehicles (VIN, New, [Year], ModelId, BodyStyle, ColorId, InteriorId, Transmission, Mileage, SalePrice, MSRP, [Description], Featured, Sold, ImageFileName)
	VALUES('00000000000000000', 1, 2018, 7, 1, 1, 2, 2, 34, 26500.99, 29999.99, 'New 2018 Dodge Challenger, Automatic Transmission, White with Leather Interior. Only white one in the tri-state area! Act fast before this beauty is gone', 1, 0, '2018challengerwhite.jpg'),
		('00000000000000001', 1, 2017, 2, 2, 7, 1, 1, 136, 21999.99, 27999.99, 'New 2018 Ford F150, Manual Transmission, Yellow with Cloth Interior', 1, 0, '2018fordf150.jpg'),
		('00000000000000002', 0, 2014, 16, 3, 2, 5, 2, 126792, 19499.99, 24000, 'Used 2014 GMC Yukon, Automatic Transmission, Black with Creme Interior', 0, 0, '2014gmcyukon.jpg'),
		('00000000000000003', 0, 2011, 13, 4, 10, 1, 2, 140576, 7999.99, 12000, 'Used 2011 Nissan Rogue, Automatic Transmission, Purple with Cloth Interior', 0, 0, '2011nissanrogue.jpg'),
		('00000000000000004', 1, 2017, 9, 1, 9, 7, 1, 44, 29999.99, 38000.00, 'New 2017 Dodge Charger, Manual Transmission, Lime Green with Black Interior', 0, 1, '2017dodgecharger.jpg')





SET IDENTITY_INSERT SaleItems ON
INSERT INTO SaleItems(SaleId, VIN, UserId, FirstName, LastName, Email, Phone, Street1, Street2, City, StateId, Zipcode, PurchasePrice, PurchaseType)
	VALUES(1,'00000000000000004', '57383afa-9157-4d24-86cf-2e1a097b29f4', 'Cody', 'Larson', 'clarson@cody.com', '6127993875', '17000 Yttrium St. NW', '#3', 'Ramsey', 'MN', 55303, 26500, 2)
SET IDENTITY_INSERT SaleItems OFF

END
GO