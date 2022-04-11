using Interfaces;
namespace Model;
public class Stocks
{
    public int id;
    public Product product;// dependencia de Product com Stocks
    public int quantity;
}