﻿namespace DTO;
public class StoreDTO
{
    public string name;
    public string CNPJ;
    public OwnerDTO owner;
    
    List<PurchaseDTO> purchase = new List<PurchaseDTO>();
}