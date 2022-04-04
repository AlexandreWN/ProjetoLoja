using Interfaces;
namespace Model;
public class Stocks: IValidateDataObject<Stocks>
{
    private Store store; // dependencia a Store
    private Product product;// dependencia de Product com Stocks
    private int quantity;

    public  Stocks(Store store, Product product)
    {
        this.store = store;
        this.product = product;
    }


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
}