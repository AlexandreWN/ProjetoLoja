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
owner_id int  PRIMARY KEY NOT NULL,
FOREIGN KEY (owner_id) REFERENCES Person (person_id)
);
CREATE TABLE Client(
client_id int  PRIMARY KEY NOT NULL,
FOREIGN KEY (client_id) REFERENCES Person (person_id)
);

CREATE TABLE Store(
store_id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
store_name varchar(50),
cnpj varchar(18),
owner_id int not null,
FOREIGN KEY (owner_id) REFERENCES Owner (owner_id)
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
client_id int not null,
FOREIGN KEY (product_id) REFERENCES Product (product_id),
FOREIGN KEY (client_id) REFERENCES Client (client_id)
);

CREATE TABLE Purchase(
purchase_id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
date_purchase date,
payment varchar(30),
number_confirmation int,
number_nf int,
client_id int not null,
FOREIGN KEY (client_id) REFERENCES Client (client_id)
);

CREATE TABLE ShoppingCart(
cart_id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
amount int,
total decimal(8,2),
product_id int,
purchase_id int,
store_id int,
FOREIGN KEY (product_id) REFERENCES Product (product_id),
FOREIGN KEY (purchase_id) REFERENCES Purchase (purchase_id),
FOREIGN KEY (store_id) REFERENCES Store (store_id)
);

INSERT INTO Person (person_name,age,document,email,phone,person_login)
VALUES
  ('Austin Livingston',24,'535.585.680-76','nec.luctus.felis@protonmail.net','(37)31752-9335','non,'),
  ('Gretchen Castillo',39,'443.842.235-58','tempor@icloud.edu','(25)39783-2116','lorem'),
  ('Ferris Hammond',49,'260.513.225-51','sapien@google.ca','(31)25364-4646','mauris'),
  ('Joseph Torres',46,'127.458.203-49','tellus@aol.edu','(87)22984-4222','lectus.'),
  ('Alana Stein',50,'868.647.186-35','congue.in@yahoo.couk','(84)35174-2551','Cras'),
  ('Cherokee Rutledge',57,'724.876.474-73','sed.dictum@hotmail.net','(88)76298-8843','Cras'),
  ('Cassady Hahn',37,'081.164.344-22','lectus.pede@outlook.com','(36)74661-7768','rutrum,'),
  ('Seth Brewer',24,'245.888.447-55','phasellus.libero.mauris@icloud.com','(66)79386-4425','posuere,'),
  ('Kibo Kerr',34,'837.218.465-78','eros.non.enim@aol.edu','(78)64659-7839','Maecenas'),
  ('Linus Kaufman',47,'524.184.046-38','nec@aol.net','(84)43536-3347','vel,'),
  ('Maggie Stafford',25,'018.317.144-22','nullam.scelerisque@google.ca','(87)69538-1673','aliquam'),
  ('Clementine Warner',58,'112.234.928-48','nonummy@google.ca','(67)22493-8472','egestas'),
  ('Rhoda Combs',63,'235.497.433-50','velit.quisque@google.org','(34)67263-4765','vel,'),
  ('Regan Odom',35,'613.134.577-72','risus.donec@outlook.couk','(57)83737-8593','eu'),
  ('Martena Houston',63,'858.553.081-19','ante.nunc.mauris@icloud.couk','(97)53234-8192','nec'),
  ('Myra Dodson',24,'831.830.779-78','tristique.aliquet.phasellus@aol.couk','(26)35828-7272','arcu'),
  ('Jameson Medina',51,'637.121.514-47','curae.phasellus@protonmail.net','(83)58566-7418','dictum'),
  ('Mara Trujillo',45,'356.184.456-48','orci.ut.sagittis@protonmail.net','(65)84337-5377','arcu.'),
  ('Martena Galloway',23,'876.563.345-73','dictum.augue@icloud.com','(86)44972-9722','Mauris'),
  ('Donna Avila',58,'209.575.394-72','risus.nunc@yahoo.net','(33)82679-2957','tellus');


  INSERT INTO Address (street,city,state,country,poste_code,person_id)
VALUES
  ('P.O. Box 310, 5505 Inceptos Rd.','Kamianske','Zeeland','Peru','51679-877',1),
  ('P.O. Box 520, 5066 Suspendisse Street','Thames','Catalunya','Poland','25459-672',2),
  ('P.O. Box 180, 9077 Turpis Rd.','Beijing','Los Lagos','Colombia','65625-876',3),
  ('Ap #461-543 Dolor. Rd.','Hà Nội','North Region','Peru','96545-877',4),
  ('Ap #921-5096 Ac Av.','Nelson','Durham','Austria','60133-167',5),
  ('5246 Elit. Av.','Sakhalin','Connacht','Costa Rica','93983-746',6),
  ('Ap #910-6701 Mi Street','Cork','Kogi','Indonesia','68774-832',7),
  ('1231 Cursus Rd.','Bremen','Luhansk oblast','Pakistan','65592-512',8),
  ('Ap #517-7667 Duis Rd.','Poznań','Caldas','Spain','67282-808',9),
  ('848-2752 Orci Rd.','Guápiles','Kocaeli','South Korea','74743-503',10),
  ('181-8502 Volutpat Street','Saint-Malo','Sachsen-Anhalt','Australia','34683256',11),
  ('566-4252 Aliquet. St.','Emalahleni','Zhytomyr oblast','Turkey','23552-353',12),
  ('2393 Fringilla. Avenue','Starachowice','Northern Cape','France','89294-727',13),
  ('9952 Interdum. Road','Cromer','Brandenburg','Austria','93669-433',14),
  ('Ap #378-9686 Eu St.','Chiavari','Nord-Pas-de-Calais','South Korea','36546567',15),
  ('4490 Velit. St.','Hamburg','Carinthia','Indonesia','58817-758',16),
  ('Ap #918-5254 Molestie Ave','San Pablo','Aisén','Singapore','67781-549',17),
  ('Ap #583-6081 Tellus Rd.','San Lorenzo','South Australia','Colombia','85744-908',18),
  ('Ap #493-2309 Nulla. Rd.','Zhytomyr','West Region','France','58835-880',19),
  ('328 Ultrices. St.','Częstochowa','Newfoundland and Labrador','Colombia','94567-860',20);

  INSERT INTO Owner (owner_id)
VALUES
  (1),
  (2),
  (3),
  (4),
  (5);

INSERT INTO Client(client_id)
VALUES
  (6),
  (7),
  (8),
  (9),
  (10),
  (11),
  (12),
  (13),
  (14),
  (15),
  (16),
  (17),
  (18),
  (19),
  (20);


  INSERT INTO Store (store_name,cnpj,owner_id)
VALUES
  ('Cum Sociis LLC','48.453.428/0001-82',1),
  ('Egestas Hendrerit LLC','42.697.646/0001-76',2),
  ('Ultrices Industries','43.324.229/0001-72',3),
  ('Aliquam LLC','94.172.285/0001-21',4),
  ('Egestas LLC','54.375.493/0001-66',5);


INSERT INTO Product (product_name,unit_price,bar_code)
VALUES
  ('Kit câmera de segurança','62.47','XUQ26QIR8GX'),
  ('Saquinho para maternidade','11.66','ZMU11UPC1CO'),
  ('Máscara esportiva','42.23','HTT15CBF6ZL'),
  ('Tênis branco feminino','37.63','MPF24RXG1VH'),
  ('Samsung A01','37.48','ELR16ZKN6VT'),
  ('Samsung Galaxy S4','83.47','QAI04IRZ6BQ'),
  ('Dodge Ram','48.26','MIE30TQL4HA'),
  ('Lembrancinha batizado','85.29','PTU82ARA8GA'),
  ('GoPro','84.75','WWL82YYR6JL'),
  ('Quadros para sala','13.41','FET64TNZ4LU'),
  ('Fogão industrial','62.93','YNP21QSE7RH'),
  ('Lembrancinha batizado','36.11','DXK81LHY5CX'),
  ('Pulverizador manual','64.82','KIW59ZVD3LA'),
  ('Máquina de solda inversora','49.84','EOC14GNM2AF'),
  ('Samsung A31','82.86','WHL08YHX3VM'),
  ('Poltrona para amamentacão','73.13','WRN45CRT9AI'),
  ('Patrulha Canina','63.98','EKV55ZPB8KP'),
  ('Quadros para sala','44.51','HVD66EPL3XT'),
  ('Ipad','66.66','XVL45MRI4HV'),
  ('Manta','27.69','RSN76VXW1DO'),
  ('Bermuda feminina','65.82','RMR93UJV6LC'),
  ('Panela pipoqueira','53.36','PEN12MRS5LI'),
  ('Mousepad gamer','81.65','PWE19UCN4PI'),
  ('Jogo de jantar completo','35.93','SXT31AEH0VB'),
  ('Tênis Olympikus feminino','13.82','DIS55OFV8VQ');

INSERT INTO Stocks(quantity,store_id,product_id)
VALUES
  (22,4,1),
  (15,1,2),
  (11,3,3),
  (10,2,4),
  (13,3,5),
  (12,3,6),
  (23,4,7),
  (24,3,8),
  (22,2,9),
  (20,1,10),
  (2,5,11),
  (25,2,12),
  (20,2,13),
  (19,4,14),
  (12,2,15),
  (24,4,16),
  (20,2,17),
  (16,5,18),
  (5,3,19),
  (5,4,20),
   (4,2,21),
  (24,4,22),
  (4,1,23),
  (21,3,24),
  (8,4,25);



INSERT INTO WishList (product_id,client_id)
VALUES
  (23,9),
  (22,12),
  (11,19),
  (3,11),
  (9,14),
  (2,8),
  (17,14),
  (23,13),
  (20,13),
  (7,14),
  (16,16),
  (2,10),
  (10,10),
  (11,6),
  (5,15),
  (7,16),
  (14,11),
  (24,7),
  (18,19),
  (24,16),
  (10,18),
  (18,6),
  (14,8),
  (11,15),
  (7,13),
  (23,14),
  (24,9),
  (20,18),
  (13,7),
  (17,11),
  (12,14),
  (8,16),
  (5,10),
  (14,20),
  (3,8),
  (8,20),
  (24,16),
  (13,16),
  (17,17),
  (18,12),
  (24,11),
  (6,15),
  (4,20),
  (8,16),
  (7,17),
  (3,6),
  (18,13),
  (23,11),
  (8,12),
  (10,10);


INSERT INTO Purchase (date_purchase,payment,number_confirmation,number_nf,client_id)
VALUES
  ('Mar 24, 2021','Débito',5651,'597416780',6),
  ('Mar 21, 2021','Débito',8897,'785782442',7),
  ('Mar 26, 2021','PayPal',5695,'385307901',8),
  ('Mar 15, 2021','Crédito',8344,'249252214',9),
  ('Mar 19, 2021','Débito',8385,'508917624',10),
  ('Mar 6, 2021','Débito',9890,'498689423',11),
  ('Mar 12, 2021','PayPal',3533,'589115432',12),
  ('Mar 16, 2021','PayPal',4058,'782034609',13),
  ('Mar 12, 2021','PIX',9830,'172688625',14),
  ('Mar 6, 2021','Crédito',1631,'758628808',15),
  ('Mar 2, 2021','PayPal',9688,'848605467',16),
  ('Mar 11, 2021','PayPal',4689,'782818850',17),
  ('Mar 11, 2021','Boleto',6307,'945075667',18),
  ('Mar 5, 2021','Boleto',3996,'402187668',19),
  ('Mar 19, 2021','Crédito',1592,'917023786',20);

 INSERT INTO ShoppingCart (amount,total,product_id,purchase_id,store_id)
VALUES
  (2,'88.51',13,10,1),
  (5,'36.80',20,13,4),
  (5,'12.17',24,5,3),
  (3,'17.14',3,3,2),
  (5,'63.35',16,7,3),
  (2,'55.59',15,13,5),
  (3,'24.14',3,10,4),
  (1,'63.78',7,10,1),
  (4,'83.66',2,6,4),
  (4,'21.55',9,2,2),
  (2,'43.87',8,3,1),
  (2,'33.37',9,9,4),
  (1,'43.41',20,8,3),
  (3,'47.83',22,8,3),
  (2,'46.66',23,10,3),
  (2,'37.89',6,6,3),
  (5,'72.65',9,2,3),
  (2,'62.11',18,10,1),
  (4,'07.03',19,5,4),
  (2,'97.22',5,3,3),
  (4,'96.25',9,12,3),
  (2,'52.62',10,14,2),
  (2,'23.52',14,6,3),
  (3,'95.60',19,12,2),
  (4,'42.86',8,3,2),
  (3,'15.83',5,12,3),
  (3,'66.89',23,4,4),
  (4,'04.40',13,5,2),
  (3,'42.50',21,12,4),
  (4,'19.07',21,1,2);


  
