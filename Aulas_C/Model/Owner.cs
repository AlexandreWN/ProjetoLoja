using Interfaces;
namespace Model;
public class Owner : Person, IValidateDataObject<Owner> 
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

    public bool validateObject(Owner obj)
    {
        if(obj.getAddress == null) return false;
        if(obj.getAge == null) return false;
        if(obj.getDocument == null) return false;
        if(obj.getEmail == null) return false;
        if(obj.getLogin == null) return false;
        if(obj.getName == null) return false;
        if(obj.getPhone == null) return false;
        return true;
  
    }
}