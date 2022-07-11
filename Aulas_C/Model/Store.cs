using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DAO;
using DTO;
namespace Model;
using Microsoft.EntityFrameworkCore;
public class Store : IValidateDataObject, IDataController<StoreDTO, Store>
{
    private Owner owner;
    private string name;
    private string CNPJ;

    private List<Purchase> purchases = new List<Purchase>();
    public List<StoreDTO> storeDTO = new List<StoreDTO>();
    /*
        public Store(Owner owner)
        {
            this.owner = owner;
        }
    */
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

    public List<Purchase> GetPurchases()
    {
        return purchases;
    }

    public static object find(int id)
    {
        using (var context = new DAO.LibraryContext())
        {
            var storeDTO = context.Store.Include(p => p.owner).FirstOrDefault(a => a.id == id);
            return new
            {
                name = storeDTO.name,
                CNPJ = storeDTO.CNPJ,
                owner = storeDTO.owner
            };
        }

    }

    public static int findID(string CNPJ)
    {
        using (var context = new DAO.LibraryContext())
        {
            var storeDTO = context.Store.Include(p => p.owner).FirstOrDefault(a => a.CNPJ == CNPJ);
            return storeDTO.id;
        }

    }
    public static string removeStore(int id)
    {
        using (var context = new LibraryContext())
        {

            var stocks = context.Stocks.Where(s => s.store.id == id);
            foreach (var stock in stocks)
            {
                Stocks.removeStocks(stock.id);
            }
            context.SaveChanges();
            var purchases = context.Purchase.Where(s => s.store.id == id);
            foreach (var purchase in purchases)
            {
                Purchase.removePurchase(purchase.id);
            }
            context.SaveChanges();

            var store = context.Store.FirstOrDefault(e => e.id == id);
            context.Remove(store);
            context.SaveChanges();
            return store.id + " foi removido!";
        }
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

        using (var context = new LibraryContext())
        {

            var ownerDAO = context.Owner.FirstOrDefault(c => c.id == owner);

            var store = new DAO.Store
            {
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

    public void update(StoreDTO obj)
    {

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

    public static List<Object> getAllStore()
    {
        using (var context = new DAO.LibraryContext())
        {
            var allStores = context.Store;

            List<object> stores = new List<object>();
            foreach (var prod in allStores)
            {
                stores.Add(prod);
            }
            return stores;
        }
    }
    public static List<Object> getOwnerStore(string document)
    {
        using (var context = new DAO.LibraryContext())
        {
            var allStores = context.Store.Include(o => o.owner).Where(s => s.owner.document == document);

            List<object> stores = new List<object>();
            foreach (var prod in allStores)
            {
                stores.Add(prod);
            }
            return stores;
        }
    }


    public StoreDTO convertModelToDTO()
    {
        var storeDTO = new StoreDTO();
        storeDTO.name = this.name;
        storeDTO.CNPJ = this.CNPJ;
        storeDTO.owner = this.owner.convertModelToDTO();
        return storeDTO;
    }

    public static Store convertDTOToModel(StoreDTO obj)
    {
        var store = new Store();
        store.setName(obj.name);
        store.setCNPJ(obj.CNPJ);
        foreach (var p in obj.purchase)
        {
            store.addNewPurchase(Purchase.convertDTOToModel(p));
        }
        return store;
    }
}