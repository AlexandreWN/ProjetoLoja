using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;
public class Store
{
    private Owner owner; // dependencia a Owner
    private string name;
    private string cnpj;

    private List<Purchase> purchases = new List<Purchase>();

    public void addNewPurchase(Purchase purchase)
    {
        purchases.Add(purchase);
    }

    public string getName() 
    { 
        return name; 
    }
    public void setName(string name) 
    {
        this.name = name;
    }
    public string getCnpj() 
    { 
        return cnpj; 
    }
    public void setCnpj(string cnpj) 
    { 
        this.cnpj = cnpj; 
    }

}