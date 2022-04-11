using Interfaces;
namespace Model;
public class Client : Person, IValidateDataObject<Client>
{
    private static Client instance;
    private Client(Address address) : base(address) { }
    public static Client getInstance(Address address) {
        if (Client.instance == null)
        {
            Client.instance = new Client(address);
        }
        return instance;
    }

    public bool validateObject(Client obj)
    {
        if (obj.getAddress() == null) return false;
        if (obj.getDateOfBirth() == null) return false;
        if (obj.getDocument() == null) return false;
        if (obj.getEmail() == null) return false;
        if (obj.getLogin() == null) return false;
        if (obj.getName() == null) return false;
        if (obj.getPhone() == null) return false;
        if (obj.getId() == null) return false;
        return true;

    }
}