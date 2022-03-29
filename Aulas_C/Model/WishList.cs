using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model;
class WishList
{
    private Client client;
    private List<Product> products = new List<Product>();

    public void addProductToWishList(Product product) {
        products.Add(product);
    }

    public List<Product> getProduct() { return products; }
}