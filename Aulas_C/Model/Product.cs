using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
namespace Model;
public class Product: IValidateDataObject, IDataController<ProductDTO, Product>
{ 
    private string name;
    private string bar_code;
    public List<ProductDTO> productDTO = new List<ProductDTO>();


    public string getName() 
    { 
        return name; 
    }
    public void setName(string name)
    {
        this.name = name;
    }
    public string getBarCode() 
    { 
        return bar_code; 
    }
    public void setBarCode(string bar_code)
    { 
        this.bar_code = bar_code; 
    }

    public bool validateObject()
    {
        if (this.getBarCode() == null) return false;
        if (this.getName() == null) return false;
        return true;
    }


    public static object find(int id){
        using(var context = new DAO.LibraryContext())
        {
            var productDTO = context.Product.FirstOrDefault(a => a.id == id);
              return product;
        }
      
    }
    public static object find(string document){
        using(var context = new DAO.LibraryContext())
        {
            var clientDTO = context.Client.Include(e=> e.address).FirstOrDefault(a => a.document == document);
                return new{
                nome = clientDTO.name,
                date_of_birth = clientDTO.date_of_birth,
                document = clientDTO.document,
                email  = clientDTO.email,
                phone = clientDTO.phone,
                login = clientDTO.login,
                passwd = clientDTO.passwd,
                address = clientDTO.address
            };
        }
      
    }

    public int save()
    {
        var id = 0;
        using (var context = new LibraryContext())
        {
            var product = new DAO.Product
            {
                name = this.name,
                bar_code = this.bar_code
            };
            context.Product.Add(product);
            context.SaveChanges();
            id = product.id;
        }
        return id;
    }
    public void delete(ProductDTO obj) { }
    public void update(ProductDTO obj) { }
    public ProductDTO findById(int id)
    {
        return new ProductDTO();
    }

    public List<ProductDTO> getAll()
    {
        return this.productDTO;
    }


    public ProductDTO convertModelToDTO()
    {
        var productDTO = new ProductDTO();
        productDTO.name = this.name;
        productDTO.bar_code = this.bar_code;
        return productDTO;
    }
    public static Product convertDTOToModel(ProductDTO obj)
    {
       Product product = new Product(); 
        product.name = obj.name;
        product.bar_code = obj.bar_code;
        return product;
    }
}
