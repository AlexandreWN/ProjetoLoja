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
    private Purchase purchase;
    private string name;
    private string CNPJ;

    private List<Purchase> purchases = new List<Purchase>();
    public  List<StoreDTO> storeDTO = new List<StoreDTO>();


    public Store(Owner owner)
    {
        this.owner = owner;
    }

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
        if (this.getOwner() == null) return false;
        if (this.GetPurchases() == null) return false;
        return true;
    }
    public int save(int owner)
    {
        var id = 0;

        using(var context = new DAOContext())
        {
          
            var ownerDAO = context.Owner.Where(c => c.id == owner).Single();

            var store = new DAO.Store{
                name = this.name,
                CNPJ = this.CNPJ,
                owner = ownerDAO
            };

            context.Store.Add(store);
            context.Entry(store.owner).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
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
        storeDTO.Owner = this.owner;
        storeDTO.Purchase = this.purchase;

        return storeDTO;
    }

    public static Store convertDTOToModel(StoreDTO obj){
       var storeDTO = new StoreDTO();
        storeDTO.name = obj.name;
        storeDTO.CNPJ = obj.CNPJ;
        storeDTO.owner = obj.owner.convertDTOToModel();
        return storeDTO;
    }

}