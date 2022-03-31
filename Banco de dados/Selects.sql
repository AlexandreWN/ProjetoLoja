SELECT p.number_confirmation, p.number_nf, d.store_name 
FROM Purchase AS p 
inner join ShoppingCart AS s 
ON p.purchase_id = s.purchase_id
inner join Store As d
ON d.store_id = s.store_id
WHERE d.store_name = 'Egestas LLC';


SELECT amount, product_id, purchase_id
FROM ShoppingCart;


SELECT * FROM Purchase
WHERE client_id = 6;


SELECT Purchase.purchase_id, Purchase.date_purchase, Person.person_name FROM Purchase
inner join Client
ON Purchase.client_id = Client.client_id
inner join Person
ON Person.person_id = Client.client_id
WHERE Person.document = '837.218.465-78';


SELECT ShoppingCart.purchase_id FROM ShoppingCart
inner join Purchase 
ON ShoppingCart.purchase_id = Purchase.purchase_id
inner join Store
ON Store.store_id = ShoppingCart.store_id
inner join Owner
ON Owner.owner_id = Store.owner_id
inner join Person
ON Person.person_id = Owner.owner_id
WHERE Person.person_name = 'Austin Livingston'


SELECT quantity from Stocks
inner join Product
ON Stocks.product_id = Product.product_id
WHERE Product.product_name = 'Samsung Galaxy S4'


SELECT Person.person_name FROM Person
inner join Client
ON Person.person_id = Client.client_id
inner join WishList
ON Client.client_id = WishList.client_id
inner join Product
ON WishList.product_id = Product.Product_id
WHERE Product.product_name = 'Samsung Galaxy S4'


SELECT Person.person_name FROM Person
inner join Client
ON Person.person_id = Client.client_id
inner join Purchase
ON Purchase.client_id = Client.client_id
inner join ShoppingCart
ON Purchase.purchase_id = ShoppingCart.purchase_id
inner join Product
ON ShoppingCart.product_id = Product.product_id
WHERE Product.product_name = 'Samsung Galaxy S4'


SELECT Purchase.purchase_id FROM Purchase
inner join Client
ON Purchase.client_id = Client.client_id
inner join Person
ON Person.person_id = Client.client_id
inner join Address
ON Person.person_id = Address.person_id
WHERE country = 'Colombia'


SELECT Purchase.purchase_id FROM Purchase
inner join Client
ON Purchase.client_id = Client.client_id
inner join Person
ON Person.person_id = Client.client_id
inner join Address
ON Person.person_id = Address.person_id
WHERE city = 'Częstochowa'


SELECT Product.product_name,Stocks.quantity, Address.country from Stocks
inner join Product
ON Stocks.product_id = Product.product_id
inner join Store
ON Stocks.store_id = Store.store_id
inner join Owner
ON Store.owner_id = Owner.owner_id
inner join Person
ON Person.person_id = Owner.owner_id
inner join Address
ON Person.person_id = Address.person_id
WHERE Product.product_name = 'Samsung Galaxy S4' order by Address.Country


SELECT COUNT(client_id) as 'clientes' , Address.country FROM Client
inner join Person
ON Person.person_id = Client.client_id
inner join Address
ON Person.person_id = Address.person_id
GROUP BY Address.country


SELECT COUNT(store_id) as 'lojas' , Address.country FROM Store
inner join Owner
ON Store.owner_id = Owner.owner_id
inner join Person
ON Person.person_id = Owner.owner_id
inner join Address
ON Person.person_id = Address.person_id
GROUP BY Address.country

/*ATUALIZAR METODO DE PAGAMENTO DE UMA CONTA*/
UPDATE Purchase SET payment = 'boleto'
WHERE purchase_id = 9



