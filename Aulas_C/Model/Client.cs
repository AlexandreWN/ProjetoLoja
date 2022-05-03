using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
namespace Model;
using Microsoft.EntityFrameworkCore;
public class Client : Person, IValidateDataObject, IDataController<ClientDTO,Client>
{
    private Guid uuid;
    public List<ClientDTO> clientDTO = new List<ClientDTO>();
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

        public static object findClient(int id){
        using(var context = new DAO.LibraryContext())
        {
            var clientDTO = context.Client.Include(e=> e.address).FirstOrDefault(a => a.id == id);
              return new{
                nome = clientDTO.name,
                date_of_birth = clientDTO.date_of_birth,
                document = clientDTO.document,
                email  = clientDTO.email,
                phone = clientDTO.phone,
                login = clientDTO.login,
                passwd = clientDTO.passwd,
                address = clientDTO.address
              };
        }
      
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
            var addressDAO = new DAO.Address();
            addressDAO.street = this.address.getStreet();
            addressDAO.city = this.address.getCity();
            addressDAO.state = this.address.getState();
            addressDAO.postal_code = this.address.getPostalCode();
            addressDAO.country = this.address.getCountry();

            var client = new DAO.Client{
                address = addressDAO,
                date_of_birth = this.date_of_birth,
                document = this.document,
                email = this.email,
                login = this.login,
                name = this.name,
                passwd = this.passwd,
                phone = this.phone,
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
        clientDTO.name = this.name;
        clientDTO.date_of_birth = this.date_of_birth;
        clientDTO.document = this.document;
        clientDTO.email = this.email;
        clientDTO.phone = this.phone;
        clientDTO.login = this.login;
        clientDTO.passwd = this.passwd;
        return clientDTO;
    }

    public static Client convertDTOToModel(ClientDTO obj){
        Client client = new Client(Address.convertDTOToModel(obj.address));
        client.name = obj.name;
        client.date_of_birth = obj.date_of_birth;
        client.document = obj.document;
        client.email = obj.email;
        client.phone = obj.phone;
        client.login = obj.login;
        client.passwd = obj.passwd;
        return client;
    }
}