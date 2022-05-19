using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
namespace Model;
using Microsoft.EntityFrameworkCore;
public class Address : IValidateDataObject, IDataController<AddressDTO,Address>
{ 
    private string street;
    private string city;
    private string state;
    private string country;
    private string postal_code;
    public List<AddressDTO> addressDTO = new List<AddressDTO>();

    public Address(string street, string city, string state, string country, string postal_code)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
        this.postal_code = postal_code;
    }

    public AddressDTO find(int id){
        using(var context = new DAO.LibraryContext())
        {
            var address = convertDAOToDTO(context.Address.Where(a => a.id == id).Single());
              return address;
        }
      
    }

    
    public string getStreet() 
    {  
        return street; 
    }
    public void setStreet(string street) {
        this.street = street; 
    }

    public string getCity()
    { 
        return city; 
    }
    public void setCity(string city) 
    { 
        this.city = city; 
    }

    public string getState()
    {
        return state;
    }
    public void setState()
    {
        this.state = state;
    }

    public string getCountry() 
    { 
        return country; 
    }
    public void setCountry(string country) 
    { 
        this.country = country; 
    }

    public string getPostalCode() 
    {
        return postal_code; 
    }
    public void setPostalCode(string postal_code) 
    { 
        this.postal_code = postal_code; 
    }

    public bool validateObject()
    {
        if(this.getCity() == null)return false;
        if(this.getCountry() == null)return false;
        if(this.getPostalCode() == null)return false;
        if(this.getState() == null)return false;
        if(this.getStreet() == null)return false;
        return true;
    }

    public void delete(AddressDTO obj){

    }

    public int save(){
        var id = 0;

        using(var context = new LibraryContext())
        {
            var address = new DAO.Address
            {
                street = this.street,
                city = this.city,
                state = this.state,
                country = this.country,
                postal_code = this.postal_code
            };

            context.Address.Add(address);
            context.SaveChanges();
            id = address.id;

        }
         return id;
    }
    public static string removeAdress(int id){
        using(var context = new LibraryContext())
        {
     
            var address = context.Address.FirstOrDefault(e=>e.id == id);
            var clientsAddress = context.Client.Include(c=>c.address).Where(c=>c.address.id == id);
            foreach(var clientAdd in clientsAddress){
                if(clientAdd == null){
                    context.Remove(clientAdd.address);
                }
            }

            var ownersAddress = context.Owner.Include(c=>c.address).Where(c=>c.address.id == id);
            foreach(var ownerAdd in ownersAddress){
                if(ownerAdd == null){
                    context.Remove(ownerAdd.address);
                }
            }
         
            context.Remove(address);
            context.SaveChanges();
            return "removido!";
        }
        
        
    }

public static List<object>  getAllAddress(){
    using(var context = new DAO.LibraryContext())
    {
        var allAddress = context.Address;
        List<object> address = new List<object>();
        foreach(var add in allAddress){
            address.Add(new{
                city = add.city,
                country = add.country,
                state = add.state
            });
        }
        return address;
    }
}
    public void update(AddressDTO obj){
        /*
        using (var context = new DAO.LibraryContext())
        {
            var Person = context.Owner.FirstOrDefault(c => c.document == obj.);
            var address = context.Address.FirstOrDefault(s=> s.postal_code == obj.postal_code);   
            if (address != null)
            {
                address.city = obj.city;
                address.country = obj.country;
                address.state = obj.state;
                address.street = obj.state;
                address.postal_code = obj.state;
            }
            context.SaveChanges();
        }*/
    }

    public AddressDTO findById(int id)
    {

        return new AddressDTO();
    }

    public List<AddressDTO> getAll()
    {        
        return this.addressDTO;      
    }

   
    public AddressDTO convertModelToDTO()
    {
        var addressDTO = new AddressDTO();

        addressDTO.street = this.street;

        addressDTO.state = this.state;

        addressDTO.city = this.city;

        addressDTO.country = this.country;

        addressDTO.postal_code = this.postal_code;

        return addressDTO;
    }

   
    public static Address convertDTOToModel(AddressDTO obj)
    {
        return new Address(obj.street, obj.city, obj.state, obj.country, obj.postal_code);
    }
    public static AddressDTO convertDAOToDTO(DAO.Address obj){
        var addressDTO = new AddressDTO();

        addressDTO.street = obj.street;

        addressDTO.state = obj.state;

        addressDTO.city = obj.city;

        addressDTO.country = obj.country;

        addressDTO.postal_code = obj.postal_code;

        return addressDTO;
    }

}   