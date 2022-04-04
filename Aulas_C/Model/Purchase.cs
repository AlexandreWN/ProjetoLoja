using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using Interfaces;
namespace Model;
public class Purchase : IValidateDataObject<Purchase>
{
    private List<Product> products = new List<Product>();
    private Client client;// dependencia com Client
    private DateTime date_purchase;
    private string payment;
    private string number_confirmation;
    private string number_nf;
    private int payment_type;
    private int purchaseStatusEnum;



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

    public int getPaymentType()
    {
        return payment_type;
    }
    public void setPaymentType(PaymentEnum payment_type)
    {
        this.payment_type = (int)payment_type;
    } 
    public int getPurchaseStatus()
    {
        return purchaseStatusEnum;
    }
    public void setPurchaseStatus(PurchaseStatusEnum purchaseStatusEnum)
    {
        this.purchaseStatusEnum =(int)purchaseStatusEnum;
    }

    public bool validateObject(Purchase obj)
    {
        if (obj.getClient == null) return false;
        if (obj.getDatePurchase == null) return false;
        if (obj.getNumberConfirmation == null) return false;
        if (obj.getNumberNf == null) return false;
        if (obj.getPaymentType == null) return false;
        if (obj.getProducts == null) return false;
        if (obj.getPurchaseStatus == null) return false;
        return true;
    }
}