using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
namespace Model;
using Microsoft.EntityFrameworkCore;
public class Owner : Person, IValidateDataObject,IDataController<OwnerDTO,Owner> 
{
    private Guid uuid;
    private static Owner instance;
    private List<OwnerDTO> ownerDTO = new List<OwnerDTO>();
    private Owner(Address address) : base(address)  { }

    public static Owner getInstance(Address address)
    {
        if (Owner.instance == null)
        {
            Owner.instance = new Owner(address);
        }
        return instance;
    }

    public Guid getUuid(){
        return uuid;
    }
    public void setUuid(Guid uuid){
        this.uuid = uuid;
    }


 public static object find(string document){

        using(var context = new DAO.LibraryContext())
        {
            var ownerDAO = context.Owner.Include(e=> e.address).FirstOrDefault(a => a.document == document);
                return new{
                id = ownerDAO.id,
                nome = ownerDAO.name,
                date_of_birth = ownerDAO.date_of_birth,
                document = ownerDAO.document,
                email  = ownerDAO.email,
                phone = ownerDAO.phone,
                login = ownerDAO.login,
                passwd = ownerDAO.passwd,
                address = ownerDAO.address
            };
        }
      
    }
public static int findId(string document){
    using(var context = new DAO.LibraryContext()){
        var ownerDAO = context.Owner.Include(e=> e.address).FirstOrDefault(a => a.document == document);
        int id = ownerDAO.id;
        return id;
    }
}
    public bool validateObject()
    {
        if(this.getId() == null) return false;
        if(this.getAddress() == null) return false;
        if(this.getDateOfBirth() == null) return false;
        if(this.getDocument() == null) return false;
        if(this.getEmail() == null) return false;
        if(this.getLogin() == null) return false;
        if(this.getName() == null) return false;
        if(this.getPhone() == null) return false;
        if(this.getUuid() == null) return false;
        return true;
  
    }
        public void delete(OwnerDTO obj){

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
            

            var owner = new DAO.Owner{ 
                address = addressDAO,
                date_of_birth = this.date_of_birth,
                document = this.document,
                email = this.email,
                login = this.login,
                name = this.name,
                passwd = this.passwd,
                phone = this.phone,
            };

            context.Owner.Add(owner);
            context.SaveChanges();

            id = owner.id;
        }
         return id;
    }






    public void update(OwnerDTO obj){

    }

    public OwnerDTO findById(int id)
    {

        return new OwnerDTO();
    }

    public List<OwnerDTO> getAll()
    {        
        return this.ownerDTO;      
    }

   
    public OwnerDTO convertModelToDTO()
    {
        var ownerDTO = new OwnerDTO();
        ownerDTO.name = this.name;
        ownerDTO.date_of_birth = this.date_of_birth;
        ownerDTO.document = this.document;
        ownerDTO.email = this.email;
        ownerDTO.phone = this.phone;
        ownerDTO.login = this.login;
        ownerDTO.passwd = this.passwd;

        return ownerDTO;
    }

    public static Owner convertDTOToModel(OwnerDTO obj){
        Owner owner = new Owner(Address.convertDTOToModel(obj.address));
        owner.name = obj.name;
        owner.date_of_birth = obj.date_of_birth;
        owner.document = obj.document;
        owner.email = obj.email;
        owner.phone = obj.phone;
        owner.login = obj.login;
        owner.passwd = obj.passwd;
        return owner;
    }
}