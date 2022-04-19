using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using DAO;
using DTO;

using Interfaces;
namespace Model;
public class Purchase : IValidateDataObject, IDataController<PurchaseDTO,Purchase>
{
    private List<Product> products = new List<Product>();
    private Client client;
    private DateTime date_purchase;
    private string number_confirmation;
    private string number_nf;
    private PaymentEnum payment_type;
    private PurchaseStatusEnum purchase_status;
    private double purchase_value;

    public List<Product> getProducts()
    {
        return products;
    }

    public Client getClient()
    {
        return client;
    }
    public void setClient(Client client)
    {
        this.client = client;
    }

    public void setProducts(List<Product> products)
    {
        this.products = products;
    }

    public DateTime getDatePurchase() 
    { 
        return this.date_purchase; 
    }
    public void setDataPurchase(DateTime date_purchase)
    {
        this.date_purchase = date_purchase;
    }

    public string getNumberConfirmation() 
    {
        return number_confirmation; 
    }
    public void setNumberConfirmation(string number_confirmation)
    {
        this.number_confirmation = number_confirmation;
    }

    public string getNumberNf() 
    { 
        return number_nf; 
    }
    public void setNumberNf(string number_nf)
    { 
        this.number_nf = number_nf; 
    }

    public PaymentEnum getPaymentType()
    {
        return payment_type;
    }
    public void setPaymentType(PaymentEnum payment_type)
    {
        this.payment_type = (int)payment_type;
    } 

    public PurchaseStatusEnum getPurchaseStatus()
    {
        return purchase_status;
    }
    public void setPurchaseStatus(PurchaseStatusEnum purchase_status)
    {
        this.purchase_status =(int)purchase_status;
    }

    public double getValue(){
        return value;
    }
    public void setValue(){
        this.value = value;
    }

    public bool validateObject()
    {
        if (this.getClient() == null) return false;
        if (this.getDatePurchase() == null) return false;
        if (this.getNumberConfirmation() == null) return false;
        if (this.getNumberNf() == null) return false;
        if (this.getPaymentType() == null) return false;
        if (this.getProducts() == null) return false;
        if (this.getPurchaseStatus() == null) return false;
        if (this.getValue() == null) return false;
        return true;
    }

    public void updateStatus(){

    }
    public void delete(PurchaseDTO obj){

    }

    public int save(){
        var id = 0;

        using(var context = new LibraryContext())
        {
            var purchase = new DAO.Purchase{
                purchase.date_purchase = this.date_purchase,
                purchase.number_confirmation = this.number_confirmation,
                purchase.number_nf = this.number_nf,
                purchase.payment_type = this.payment_type,
                purchase.purchase_status = this.purchase_status,
                purchase.purchase_value = this.purchase_value
            };

            context.Purchase.Add(purchase);

            context.SaveChanges();

            id = purchase.id;

        }
         return id;
    }

    public void update(PurchaseDTO obj){

    }

    public PurchaseDTO findById(int id)
    {

        return new PurchaseDTO();
    }

    public List<PurchaseDTO> getAll()
    {        
        return this.PurchaseDTO;      
    }

   
    public PurchaseDTO convertModelToDTO()
    {
        var PurchaseDTO = new PurchaseDTO();

        PurchaseDTO.street = this.street;

        PurchaseDTO.state = this.state;

        PurchaseDTO.city = this.city;

        PurchaseDTO.country = this.country;

        PurchaseDTO.postal_code = this.postal_code;

        return PurchaseDTO;
    }

    public static Purchase convertDTOToModel(PurchaseDTO obj){
        return new Purchase(obj.date_purchase, obj.number_confirmation, obj.number_nf, obj.payment_type, obj.purchase_status, obj.purchase_value);
    }
}
