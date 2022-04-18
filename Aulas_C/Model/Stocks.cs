using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
namespace Model;

public class Stocks: IValidateDataObject<Stocks>,IDataController<StocksDTO, Stocks>

{
    private Store store;
    private Product product;

    private int quantity;
    private double unit_price;
    public List<StocksDTO> stocksDTO = new List<StocksDTO>();


    public int getQuantity() 
    { 
        return quantity; 
    }
    public void setQuantity(int quantity) 
    { 
        this.quantity = quantity; 
    }
    public double getUnitPrice()
    {
        return unit_price;
    }
    public void setUnitPrice(double unit_price)
    {
        this.unit_price = unit_price;
    }
    public Store getStore()
    {
        return store;
    }
    public void setStore(Store store)
    {
        this.store = store;
    }
    public Product getProduct()
    {
        return product;
    }
    public void setProduct(Product product)
    {
        this.product = product;
    }

     public bool validateObject(Stocks obj)
    {
        if (obj.getProduct() == null) return false;
        if (obj.getQuantity() == 0) return false;
        if (obj.getStore() == null) return false;
        if (obj.getUnitPrice() == null) return false;
        return true;
    }

    

    public void save()
    {
        var id = 0;
        using (var context = new DAOContext())
        {
            var stoks = new DAO.Stoks
            {
                quantity = this.quantity,
                unit_price = this.unit_price,
                store = this.store,
                product = this.product
            };
            context.Product.Add(stoks);
            context.SaveChanges();
            id = stoks.id;
        }
       return id;
    }
    public void delete(StoksDTO obj) { }
    public void update(StoksDTO obj) { }
    public StoksDTO findByID()
    {
        return new StoksDTO;
    }
    public List<StoksDTO> getAll()
    {
        return this.StoksDTO;
    }


    public StoksDTO convertModelToDTO()
    {
        var stoksDTO = new StoksDTO();
        stocksDTO.quantity = this.quantity;
        stocksDTO.unit_price = this.unit_price;
        stocksDTO.product = this.product;
        stocksDTO.store = this.store;
        return stoksDTO;
    }
    public static Stocks convertDTOToModel(StoksDTO obj)
    {
        return new Stocks(obj.quantity,obj.unit_price,obj.product,obj.store);
    }
}