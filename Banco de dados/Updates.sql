/*ATUALIZAR METODO DE PAGAMENTO DE UMA COMPRA*/
UPDATE Purchase SET payment = 'boleto'
WHERE purchase_id = 9

/* Atualizar o método de pagamento de todas compras de determinada loja onde o cliente que realizou a compra tenha idade entre 18 e 25 anos.*/
UPDATE p 
SET p.payment = 'boleto'
FROM Purchase as p
inner join Store as s
ON p.store_id = s.store_id
inner join Client as c
ON p.client_id = c.client_id
inner join Person as pe
ON pe.person_id = c.client_id
WHERE pe.age >= 18 and pe.age <=25

select * from Purchase as p
inner join Client as c
ON p.client_id = c.client_id
inner join Person as pe
ON pe.person_id = c.client_id
where pe.age>= 18 and pe.age <=25