BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Items" (
	"Id"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL,
	"Brand"	TEXT NOT NULL,
	"Condition"	INTEGER NOT NULL,
	"BasePrice"	REAL NOT NULL,
	"AuctionId"	INTEGER NOT NULL,
	FOREIGN KEY("AuctionId") REFERENCES "Auctions"("Id"),
	PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Users" (
	"Id"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL,
	"Email"	TEXT NOT NULL,
	PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Offers" (
	"Id"	INTEGER NOT NULL UNIQUE,
	"CreatedOn"	TEXT NOT NULL,
	"Price"	REAL NOT NULL,
	"ItemId"	INTEGER NOT NULL,
	"UserId"	INTEGER NOT NULL,
	FOREIGN KEY("UserId") REFERENCES "Users"("Id"),
	FOREIGN KEY("ItemId") REFERENCES "Items"("Id"),
	PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Auctions" (
	"Id"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL,
	"Starts"	TEXT NOT NULL,
	"Ends"	TEXT NOT NULL,
	PRIMARY KEY("Id" AUTOINCREMENT)
);
INSERT INTO "Items" ("Id","Name","Brand","Condition","BasePrice","AuctionId") VALUES (1,'Galaxy S21','Samsung',0,800.0,1),
 (2,'Macbook Pro','Apple',1,1000.0,1),
 (3,'Camera Canon EOS','Canon',2,1200.0,1),
 (4,'Headphone WH-1000XM5','Sony',1,200.0,1),
 (5,'Nintendo Switch OLED','Nintendo',0,80.0,1),
 (6,'Drone com Camera Mavic Air 2','DJI',2,700.0,1),
 (7,'Kindle Paperwhite 2022','Amazon',0,50.0,1);
INSERT INTO "Users" ("Id","Name","Email") VALUES (1,'Cristiano','cristiano@cristiano.com'),
 (2,'Tatiana','tatiana@tatiana.com'),
 (3,'Lucimar','lucimar@lucimar.com');
INSERT INTO "Auctions" ("Id","Name","Starts","Ends") VALUES (1,'Leilao da Rocketseat','2024-01-20 00:00:00.000','2024-01-29 23:59:59.000');
COMMIT;
