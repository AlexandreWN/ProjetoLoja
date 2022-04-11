using Interfaces;
namespace Model;
public class Address : IValidateDataObject<Address>
{ 
    private string street;
    private string city;
    private string state;
    private string country;
    private string post_code;
    private int id;

    public Address(int id, string street, string city, string state, string country, string post_code)
    {
        this.id = id;
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
        this.post_code = post_code;
    }

    public int getId()
    {
        return id;
    }
    public void setId(int id)
    {
        this.id = id;
    }

    public string getStreet() 
    {  
        return street; 
    }
    public void setStreet(string street) {
        this.street = street; 
    }

    public string getCity()
    { 
        return city; 
    }
    public void setCity(string city) 
    { 
        this.city = city; 
    }

    public string getState()
    {
        return state;
    }
    public void setState()
    {
        this.state = state;
    }

    public string getCountry() 
    { 
        return country; 
    }
    public void setCountry(string country) 
    { 
        this.country = country; 
    }

    public string getPostalCode() 
    {
        return post_code; 
    }
    public void setPostalCode(string post_code) 
    { 
        this.post_code = post_code; 
    }

    public bool validateObject(Address obj)
    {
        if(obj.getId() == null) return false;
        if(obj.getCity() == null)return false;
        if(obj.getCountry() == null)return false;
        if(obj.getPostalCode() == null)return false;
        if(obj.getState() == null)return false;
        if(obj.getStreet() == null)return false;
        return true;
    }
}