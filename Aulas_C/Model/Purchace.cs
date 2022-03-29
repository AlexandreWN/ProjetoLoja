namespace Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Purchace
{
    private Client client;// dependencia com Client
    private DateTime date_purchace;
    private string payment;
    private int number_confirmation;
    private int number_nf;

    public void getDatePurchase() 
    { 
        return date_purchace; 
    }
    public DateTime setDatePurchase(DateTime date_purchace)
    {
        this.date_purchace = date_purchace;
    }

    public void getPayment() 
    {
        return payment;  
    }
    public string setPayment(string payment)
    {
        this.payment = payment;
    }

    public void getNumberConfirmation() 
    {
        return number_confirmation; 
    }
    public int setNumberConfirmation(int number_confirmation)
    {
        this.number_confirmation = number_confirmation;
    }

    public void getNumberNf() 
    { 
        return number_nf; 
    }
    public int setNummberNf(int number_nf)
    { 
        this.number_nf = number_nf; 
    }
}