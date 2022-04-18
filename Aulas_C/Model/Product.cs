using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
namespace Model;
public class Product: IValidateDataObject<Product>
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

    public bool validateObject(Product obj)
    {
        if (obj.getBarCode() == null) return false;
        if (obj.getName() == null) return false;
        if (obj.getUnitprice() == 0.0) return false;
        return true;
    }


    public void seve()
    {
        var id = 0;
        using (var context = new ProductDTO)
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
    }
    public void delete(ProductDTO obj) { }
    public void update(ProductDTO obj) { }
    public ProductDTO findByID()
    {
        return new productDTO;
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
        return new Product(obj.name,obj.bar_code);
    }
}