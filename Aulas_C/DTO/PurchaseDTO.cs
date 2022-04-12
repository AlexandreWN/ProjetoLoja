namespace DTO;
public class PurchaseDTO
{
    public DateTime date_purchase;
    public double purchase_value;
    public int payment_type;
    public int purchase_status;
    public string number_confirmation;
    public string number_nf;
    public ProductDTO product;
    public StoreDTO store;
}