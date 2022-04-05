using Interfaces;
namespace Model;
public class Stocks: IValidateDataObject<Stocks>
{
    private Store store; // dependencia a Store
    private Product product;// dependencia de Product com Stocks
    private int quantity;


    public int getQuantity() 
    { 
        return quantity; 
    }
    public void setQuantity(int quantity) 
    { 
        this.quantity = quantity; 
    }

    public bool validateObject(Stocks obj)
    {
        if (obj.getQuantity == null) return false;
        return true;    
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
}