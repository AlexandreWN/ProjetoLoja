namespace Model;
public class Owner : Person
{
    private static Owner instance;
    private Owner(Address address) : base(address)  { }
    public static Owner getInstance(Address address)
    {
        if (Owner.instance == null)
        {
            Owner.instance = new Owner(address);
        }
        return instance;
    }
}