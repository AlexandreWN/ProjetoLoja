namespace Model;
public class Product
{ 
    private string name;
    private decimal unit_price;
    private string bar_code;

    //GETS
    public string getName() { return name; }
    public decimal getUnitePrice() { return unit_price; }
    public string getBarCode() { return bar_code; }

    //SETS

    public void setName(string name) { this.name = name; }
    public void setUnitPrice(decimal unit_price) { this.unit_price = unit_price; }
    public void setBarCode(string bar_code) { this.bar_code = bar_code; }
}