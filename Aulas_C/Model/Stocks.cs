using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model;

public class Stocks: IValidateDataObject, IDataController<StocksDTO,Stocks>

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


    public int save(int lojaID, int productID, int quantity, double unit_price)
    {
        var id = 0;
        using (var context = new LibraryContext())
        {
            var store = context.Store.FirstOrDefault(s=>s.id==lojaID);
            var product = context.Product.FirstOrDefault(p=>p.id==productID);
            var stocks = new DAO.Stocks
            {
                quantity = quantity,
                unit_price = unit_price,
                store = store,
                product = product
            };
            context.Stocks.Add(stocks);
            context.Entry(stocks.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.SaveChanges();
            id = stocks.id;
        }
       return id;
    }
    public void delete(StocksDTO obj) { }
    public void update(StocksDTO obj) {
        using (var context = new DAO.LibraryContext())
        {
            var stock = context.Stocks.FirstOrDefault(s=> s.product.bar_code == obj.product.bar_code && s.store.CNPJ == obj.store.CNPJ);   
            if (stock != null)
            {
                stock.unit_price = obj.unit_price;
                stock.quantity = obj.quantity;
                context.SaveChanges();
            }
            
        }
    }
    public StocksDTO findById(int id)
    {
        return new StocksDTO();
    }
    public List<StocksDTO> getAll()
    {
        return this.stocksDTO;
    }


    public StocksDTO convertModelToDTO()
    {
        var stocksDTO = new StocksDTO();
        stocksDTO.quantity = this.quantity;
        stocksDTO.unit_price = this.unit_price;
        stocksDTO.product = this.product.convertModelToDTO();
        stocksDTO.store = this.store.convertModelToDTO();
        return stocksDTO;
    }
    public static Stocks convertDTOToModel(StocksDTO obj)
    {
        Stocks stocks = new Stocks();
        stocks.quantity = obj.quantity;
        stocks.unit_price = obj.unit_price;
        stocks.product = Product.convertDTOToModel(obj.product);
        stocks.store = Store.convertDTOToModel(obj.store);
        return stocks;
    }
}