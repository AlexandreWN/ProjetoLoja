using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model;
public class WishList : IValidateDataObject<WishList>
{
    private Client client;
    private List<Product> products = new List<Product>();

    public WishList(Client client)
    {
        this.client = client;
    }

    public void addProductToWishList(Product product) {
        products.Add(product);
    }

    public List<Product> getProducts() { 
        return products; 
    }

    public Client getClient() {
        return client;
    }

    public bool validateObject(WishList obj)
    {
        if(obj.getProducts == null) return false;
        if(obj.getClient == null) return false;
        return true;
    }
}