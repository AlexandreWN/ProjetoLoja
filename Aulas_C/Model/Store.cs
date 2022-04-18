using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAO;
using DTO;
namespace Model;
public class Store:IValidateDataObject<Store>,IDataController<StoreDTO, Store>
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

    public bool validateObject(Store obj)
    {
        if (obj.getCNPJ() == null) return false;
        if (obj.getName() == null) return false;
        if (obj.getOwner() == null) return false;
        if (obj.GetPurchases() == null) return false;
        return true;
    }


    public int save(){
        var id = 0;

        using(var context = new DAOContext())
        {
            var store = new DAO.Store
            {
                name = this.name,
                CNPJ = this.CNPJ,
                owner = this.owner,
                purchase = this.purchase

            };

            context.Store.Add(store);
            context.SaveChanges();
            id = store.id;

        }
         return id;
    }

    public void update(StoreDTO obj){

    }

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
        var StoreDTO = new StoreDTO();

        StoreDTO.name = this.name;
        StoreDTO.CNPJ = this.CNPJ;    
        StoreDTO.Owner = this.owner;
        StoreDTO.Purchase = this.purchase;

        return StoreDTO;
    }

    public static Store convertDTOToModel(StoreDTO obj){
        return new Store(obj.name,obj.CNPJ.obj.Owner,obj.Purchase);
    }

}