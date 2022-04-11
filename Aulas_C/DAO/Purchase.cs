namespace DAO;
public class Purchase
{
    public Store store; // dependencia a Store
    public Product product;// dependencia de Product com Stocks
    public int id;
    public DateTime date_purchase;
    public string payment;
    public string number_confirmation;
    public string number_nf;
    public int payment_type;
    public int purchaseStatusEnum;
}