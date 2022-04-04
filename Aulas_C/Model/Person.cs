namespace Model;
public class Person
{
    protected Address address; //dependencia

    protected string name;
    protected int    age;
    protected string document;
    protected string email;
    protected string phone;
    protected string login;

    protected Person(Address addres)
    {
        this.address = addres;
    }

    public Address getAddress()
    {
        return address;
    }
    public void setAddress(Address address)
    {
        this.address = address;
    }

    public string getName()
    {
        return name;
    }
    public void setName(string name)
    {
        this.name = name;
    }

    public int getAge()
    {
        return age;
    }
    public void setAge(int age)
    {
        this.age = age;
    }

    public string getDocument()
    {
        return document;
    }
    public void setDocument(string document)
    {
        this.document = document;
    }

    public string getEmail()
    {
        return email;
    }
    public void setEmail(string email)
    {
        this.email = email;
    }

    public string getPhone()
    {
        return phone;
    }
    public void setPhone(string phone)
    {
        this.phone = phone;
    }

    public string getLogin()
    {
        return login;
    }
    public void setLogin(string login)
    {
        this.login = login;
    }
}
