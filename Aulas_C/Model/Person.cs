namespace Model;
public class Person
{
    private Address address; //dependencia

    protected string name;
    protected int    age;
    protected string document;
    protected string email;
    protected string phone;
    protected string login;

    protected Person()
    {

    }
    protected Person(Addres addres)
    {
        this.address = addres.address;
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
    public void setEmail()
    {
        this.email = email;
    }

    public string getPhone()
    {
        return phone;
    }
    public void setPhone()
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
