namespace Model;
public class Stocks
{
    private Store store; // dependencia a Store
    private Product product;// dependencia de Product com Stocks
    private int quantity;

    //GETS
    public int getQuantity() { return quantity; }

    //SETS
    public void setQuantity(int quantity) { this.quantity = quantity; }
}