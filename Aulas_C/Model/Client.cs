using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
namespace Model;
public class Client : Person, IValidateDataObject, IDataController<ClientDTO,Client>
{
    private Guid uuid;
    public List<Client> client = new List<Client>();
    private static Client instance;
    private Client(Address address) : base(address) { }
    public static Client getInstance(Address address) {
        if (Client.instance == null)
        {
            Client.instance = new Client(address);
        }
        return instance;
    }

    public Guid getUuid(){
        return uuid;
    }
    public void setUuid(Guid uuid){
        this.uuid = uuid;
    }

    public bool validateObject()
    {
        if (this.getAddress() == null) return false;
        if (this.getDateOfBirth() == null) return false;
        if (this.getDocument() == null) return false;
        if (this.getEmail() == null) return false;
        if (this.getLogin() == null) return false;
        if (this.getName() == null) return false;
        if (this.getPhone() == null) return false;
        if (this.getUuid() == null) return false;
        return true;

    }

    public void delete(ClientDTO obj){

    }

    public int save(){
        var id = 0;

        using(var context = new LibraryContext())
        {
            var client = new DAO.Client{
                id = this.id
            };

            context.Client.Add(client);

            context.SaveChanges();

            id = client.id;
        }
         return id;
    }
    public void update(ClientDTO obj){

    }

    public ClientDTO findById(int id)
    {

        return new ClientDTO();
    }

    public List<ClientDTO> getAll()
    {        
        return this.clientDTO;      
    }

   
    public ClientDTO convertModelToDTO()
    {
        var clientDTO = new ClientDTO();
        clientDTO.id = this.id;
        clientDTO.name = this.name;
        clientDTO.date_of_birth = this.date_of_birth;
        clientDTO.document = this.document;
        clientDTO.email = this.email;
        clientDTO.phone = this.phone;
        clientDTO.login = this.login;
        clientDTO.id = this.id;
        clientDTO.passwd = this.passwd;
        return clientDTO;
    }

    public static Client convertDTOToModel(ClientDTO obj){
        Client client = new Client(Address.convertDTOToModel(obj.Address));
        client.name = obj.name;
        client.date_of_birth = obj.date_of_birth;
        client.document = obj.document;
        client.email = obj.email;
        client.phone = obj.phone;
        client.login = obj.login;
        client.id = obj.id;
        client.passwd = obj.passwd;
        return client;
    }
}