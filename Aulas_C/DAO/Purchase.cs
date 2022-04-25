namespace DAO;
public class Purchase
{
    public Store store;
    public Product product;
    public Client client;

    public int id;
    public string number_confirmation;
    public string number_nf;
    public int payment_type;
    public DateTime date_purchase;
    public int purchase_status;
    public double purchase_value;
}