using Interfaces;
namespace Model;
public class Stocks: IValidateDataObject<Stocks>
{
    private Store store;
    private Product product;

    private int quantity;
    private double unit_price;

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
    }
    public static Product convertDTOToModel(ProductDTO obj)
    {
        return new Product(obj.name,obj.bar_code);
    }
}