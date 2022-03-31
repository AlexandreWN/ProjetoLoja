  
  
  /*DELETE*/
  
/* Apagar um cliente criado*/
/*APAGA PURCHACE DO SHOPPING CARD*/
DELETE  s
FROM ShoppingCart s
INNER JOIN Purchase p ON s.purchase_id = p.purchase_id
WHERE client_id = 6;
/*APAGA PURCHACE*/
DELETE FROM Purchase WHERE client_id = 6
/*APAGAR DA WISHLIST*/
DELETE FROM WishList WHERE client_id = 6
/*APAGA DA TABELA CLIENT*/
DELETE FROM Client WHERE client_id = 6



/*APAGA DONO DE LOJA*/
/*apaga as compras do carrinho vinculadas a loja*/
DELETE s
FROM ShoppingCart s
INNER JOIN Purchase p ON s.purchase_id = p.purchase_id
INNER JOIN Store t ON t.store_id = p.store_id
Where owner_id = 5

/*apaga as compras vinculadas a loja*/
DELETE p
FROM Purchase p
INNER JOIN Store t ON t.store_id = p.store_id
Where owner_id = 5

/*apaga o estoque da loja vinculada ao dono*/
DELETE s 
FROM Stocks s
INNER JOIN Store t ON s.store_id = t.store_id
Where owner_id = 5
/*apaga a store vinculada ao dono*/
DELETE FROM Store WHERE owner_id = 5;
/*apaga da tabela de donos*/
DELETE FROM Owner WHERE owner_id = 5;

