CREATE TABLE Person(
person_id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
person_name varchar(50),
age int,
document varchar(14),
email varchar(50),
phone varchar(14),
person_login varchar(50)
);

CREATE TABLE "Address"(
addres_id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
street varchar(50),
city varchar(50),
"state" varchar(50),
country varchar(50),
poste_code varchar(50),
person_id int not null,
FOREIGN KEY (person_id) REFERENCES Person (person_id)
);

CREATE TABLE Owner(
owner_id int not null,
FOREIGN KEY (owner_id) REFERENCES Person (person_id)
);
CREATE TABLE Client(
client_id int not null,
FOREIGN KEY (client_id) REFERENCES Person (person_id)
);

CREATE TABLE Store(
store_id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
store_name varchar(50),
cnpj varchar(18),
person_id int not null,
FOREIGN KEY (person_id) REFERENCES Person (person_id)
);

CREATE TABLE Product(
product_id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
product_name varchar(50),
unit_price decimal(8,2),
bar_code varchar(100)
);

CREATE TABLE Stocks(
stock_id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
quantity int,
store_id int not null,
product_id int not null,
FOREIGN KEY (store_id) REFERENCES Store (store_id),
FOREIGN KEY (product_id) REFERENCES Product (product_id)
);

CREATE TABLE WishList(
wishlist_id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
product_id int not null,
person_id int not null,
FOREIGN KEY (product_id) REFERENCES Product (product_id),
FOREIGN KEY (person_id) REFERENCES Person (person_id)
);

CREATE TABLE Purchase(
purchase_id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
date_purchase date,
payment varchar(30),
number_confirmation int,
number_nf int,
person_id int not null,
FOREIGN KEY (person_id) REFERENCES Person (person_id)
);

CREATE TABLE Shopping_cart(
cart_id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
amount int,
total decimal(8,2),
product_id int,
purchase_id int,
FOREIGN KEY (product_id) REFERENCES Product (product_id),
FOREIGN KEY (purchase_id) REFERENCES Purchase (purchase_id)
);