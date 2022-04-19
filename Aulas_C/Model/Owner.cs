using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
namespace Model;
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
            var owner = new DAO.Owner{
                id = this.id
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
        Owner owner = new Owner(Address.convertDTOToModel(obj.Address));
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