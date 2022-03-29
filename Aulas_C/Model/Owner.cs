namespace Model;
public class Owner : Person
{
    private static Owner instance;
    private Owner(Address address) : base(address)  {
        this.address = address;
    }
    public static Owner getInstance()
    {
        if (instance == null)
        {
            instance = new Owner(address);
        }
        return instance;
    }
}