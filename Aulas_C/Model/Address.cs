namespace Model;
public class Address
{ 
    private string street;
    private string city;
    private string country;
    private string post_code;

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

    public string getCountry() 
    { 
        return country; 
    }
    public void setCountry(string country) 
    { 
        this.country = country; 
    }

    public string getPostCode() 
    {
        return post_code; 
    }
    public void setPostCode(string post_code) 
    { 
        this.post_code = post_code; 
    }   
}