using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAO;
using DTO;
namespace Model;
public class Store:IValidateDataObject,IDataController<StoreDTO, Store>
{
    private Owner owner;
    private string name;
    private string CNPJ;

    private List<Purchase> purchases = new List<Purchase>();
    public  List<StoreDTO> storeDTO = new List<StoreDTO>();

    /* não sei se fica
    public Store(Owner owner)
    {
        this.owner = owner;
    }*/

    public void addNewPurchase(Purchase purchase)
    {
        purchases.Add(purchase);
    }

    public string getName() 
    { 
        return name; 
    }
    public void setName(string name) 
    {
        this.name = name;
    }
    public string getCNPJ() 
    { 
        return CNPJ; 
    }
    public void setCNPJ(string CNPJ) 
    { 
        this.CNPJ = CNPJ; 
    }

    public List<Purchase> GetPurchases() { 
        return purchases; 
    }

    public Owner getOwner()
    {
        return owner;
    }

    public bool validateObject()
    {
        if (this.getCNPJ() == null) return false;
        if (this.getName() == null) return false;
        return true;
    }
    public int save(int owner)
    {
        var id = 0;

        using(var context = new LibraryContext())
        {
          
            var ownerDAO = context.Owner.FirstOrDefault(c => c.id == owner);

            var store = new DAO.Store{
                name = this.name,
                CNPJ = this.CNPJ,
                owner = ownerDAO
            };
            context.Entry(store.owner).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Store.Add(store);
            context.SaveChanges();

            id = store.id;

        }
         return id;
    }

    public void update(StoreDTO obj){

    }
    public void delete(StoreDTO obj) { }
    public StoreDTO findById(int id)
    {

        return new StoreDTO();
    }

    public List<StoreDTO> getAll()
    {        
        return this.storeDTO;      
    }

   
    public StoreDTO convertModelToDTO()
    {
        var storeDTO = new StoreDTO();
        storeDTO.name = this.name;
        storeDTO.CNPJ = this.CNPJ;    
        storeDTO.owner = this.owner.convertModelToDTO();
        return storeDTO;
    }

    public static Store convertDTOToModel(StoreDTO obj){
        var store = new Store();
        store.setName(obj.name);
        store.setCNPJ(obj.CNPJ);
        foreach(var p in obj.purchase)
        {
            store.addNewPurchase(Purchase.convertDTOToModel(p));
        }
        return store;
    }

}