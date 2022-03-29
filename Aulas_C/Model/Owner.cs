namespace Model;
public class Owner : Person
{
    public static Owner getInstance()
    {
        return new Owner();
    }
}