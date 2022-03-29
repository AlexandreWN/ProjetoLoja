namespace Model;
public class Address
{ 
    private string street;
    private string city;
    private string country;
    private string post_code;

    //GETS
    public string getStreet() {  return street; }
    public string getCity() { return city; }
    public string getCountry() { return country; }
    public string getPostCode() { return post_code; }
    //SETS  
    public void setStreet(string street) { this.street = street; }
    public void setCity(string city) { this.city = city; }
    public void setCountry(string country) { this.country = country; }
    public void setPostCode(string post_code) { this.post_code = post_code; }   
}