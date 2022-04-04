using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;
public class Purchase
{
    private List<Product> products = new List<Product>();
    private Client client;// dependencia com Client
    private DateTime date_purchase;
    private string payment;
    private string number_confirmation;
    private string number_nf;
    
    public Purchase(Client client)
    {
        this.client = client;
    }

    public List<Product> getProducts()
    {
        return products;
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

    public string getPaymentType() 
    {
        return payment;  
    }
    public void setPaymentType(string payment)
    {
        this.payment = payment;
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
}