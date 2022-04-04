using Interfaces;
namespace Model;
public class Product: IValidateDataObject<Product>
{ 
    private string name;
    private double unit_price;
    private string bar_code;

    public string getName() 
    { 
        return name; 
    }
    public void setName(string name)
    {
        this.name = name;
    }

    public double getUnitprice() 
    { 
        return unit_price; 
    }
    public void setUnitPrice(double unit_price)
    {
        this.unit_price = unit_price;
    }

    public string getBarCode() 
    { 
        return bar_code; 
    }
    public void setBarCode(string bar_code)
    { 
        this.bar_code = bar_code; 
    }

    public bool validateObject(Product obj)
    {
        if (obj.getBarCode == null) return false;
        if (obj.getName == null) return false;
        if (obj.getUnitprice == null) return false;
        return true;
    }
}