CREATE TABLE "categories" (
	"categoryId"	TEXT NOT NULL,
	"name"	TEXT NOT NULL,
	PRIMARY KEY("categoryId")
);

CREATE TABLE "products" (
	"productId"	TEXT NOT NULL,
	"name"	TEXT NOT NULL,
	"categoryId"	TEXT NOT NULL,
	"stock"	INTEGER NOT NULL,
	"unit"	TEXT,
	"price"	INTEGER,
	"submissionDate"	TEXT NOT NULL,
	PRIMARY KEY("productId"),
	FOREIGN KEY("categoryId") REFERENCES "categories"("categoryId")
);

CREATE TABLE "stores" (
	"storeId"	TEXT NOT NULL,
	"address"	TEXT NOT NULL,
	PRIMARY KEY("storeId")
);

CREATE TABLE "orders" (
	"orderId"	TEXT NOT NULL,
	"state"	TEXT NOT NULL CHECK("state" in ("ACCEPTED", "REJECTED", "PENDING")),
	"description"	TEXT,
	"submissionDate"	TEXT NOT NULL,
	PRIMARY KEY("orderId")
);

CREATE TABLE "importOrders" (
	"orderId"	TEXT NOT NULL,
	"sourceId"	TEXT NOT NULL,
	"arrivalDate"	TEXT NOT NULL,
	PRIMARY KEY("orderId"),
	FOREIGN KEY("orderId") REFERENCES "orders"("orderId"),
	FOREIGN KEY("sourceId") REFERENCES "stores"("storeId")
);

CREATE TABLE "exportOrders" (
	"orderId"	TEXT NOT NULL,
	"destinationId"	TEXT NOT NULL,
	"exportDate"	TEXT NOT NULL,
	PRIMARY KEY("orderId"),
    FOREIGN KEY("orderId") REFERENCES "orders"("orderId"),
	FOREIGN KEY("destinationId") REFERENCES "stores"("storeId")
);

CREATE TABLE "orderDetails" (
	"orderId"	TEXT NOT NULL,
	"productId"	TEXT NOT NULL,
	"quantity"	INTEGER NOT NULL,
	FOREIGN KEY("orderId") REFERENCES "orders"("orderId"),
	FOREIGN KEY("productId") REFERENCES "products"("productId"),
	PRIMARY KEY("orderId","productId")
);

CREATE TABLE "inventories" (
	"inventoryId"	TEXT NOT NULL,
	"roomNumber"	TEXT NOT NULL,
	"floorNumber"	TEXT NOT NULL,
	"shelfNumber"	TEXT NOT NULL,
	PRIMARY KEY("inventoryId"),
	UNIQUE("roomNumber","floorNumber","shelfNumber")
);

CREATE TABLE "inventoryProducts" (
	"inventoryId"	TEXT NOT NULL,
	"productId"	TEXT NOT NULL,
	PRIMARY KEY("inventoryId","productId"),
	FOREIGN KEY("inventoryId") REFERENCES "inventories"("inventoryId"),
	FOREIGN KEY("productId") REFERENCES "products"("productId")
);