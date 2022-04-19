using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
namespace Model;

public class Stocks: IValidateDataObject,IDataController<StocksDTO, Stocks>

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

    public bool validateObject()
    {
        if (this.getProduct() == null) return false;
        if (this.getQuantity() == 0) return false;
        if (this.getStore() == null) return false;
        if (this.getUnitPrice() == null) return false;
        return true;
    }

    

    public int save()
    {
        var id = 0;
        using (var context = new LibraryContext())
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
    public void delete(StocksDTO obj) { }
    public void update(StocksDTO obj) { }
    public StocksDTO findById(int id)
    {
        return new StocksDTO();
    }
    public List<StocksDTO> getAll()
    {
        return this.StocksDTO;
    }


    public StocksDTO convertModelToDTO()
    {
        var StocksDTO = new StocksDTO();
        stocksDTO.quantity = this.quantity;
        stocksDTO.unit_price = this.unit_price;
        stocksDTO.product = this.product;
        stocksDTO.store = this.store;
        return StocksDTO;
    }
    public static Stocks convertDTOToModel(StocksDTO obj)
    {
        return new Stocks(obj.quantity,obj.unit_price,obj.product,obj.store);
    }
}