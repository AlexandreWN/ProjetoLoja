namespace Model;
public class Client : Person
{
    private static Client instance;
    private Client(Address address) { 
        this.address = address; 
    }
    public static Client getInstance(Address address) {
        if (instance == null)
        {
            instance = new Client(address);
        }
        return instance;
    }
}