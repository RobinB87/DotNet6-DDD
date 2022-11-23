INSERT INTO SnackMachine (SnackMachineID, OneCentCount, TenCentCount, QuarterCount, OneDollarCount, FiveDollarCount, TwentyDollarCount)
VALUES (1,0,0,0,0,0,0);

# once...
#ALTER TABLE Ids
#ADD EntityName varchar(128);

INSERT INTO Ids (EntityName, NextHigh)
Values ('Slot', 1),
	   ('Snack', 1),
	   ('SnackMachine', 1);

INSERT INTO Snack (SnackID, Name)
Values (1, 'Chocolate'),
	   (2, 'Soda'),
	   (3, 'Gum');

INSERT INTO Slot (SlotID, Position, Quantity, Price, SnackID, SnackMachineID)
VALUES (1, 1, 10, 3.00, 1, 1),
	   (2, 2, 15, 2.00, 2, 1),
	   (3, 3, 20, 1.00, 3, 1);