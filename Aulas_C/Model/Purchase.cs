using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using DAO;
using DTO;
using Interfaces;
namespace Model;
using Microsoft.EntityFrameworkCore;
public class Purchase : IValidateDataObject, IDataController<PurchaseDTO, Purchase>
{
    private List<Product> products = new List<Product>();
    public List<PurchaseDTO> purchaseDTO = new List<PurchaseDTO>();
    private Client client;
    private DateTime date_purchase;
    private string number_confirmation;
    private string number_nf;
    private int payment_type;
    private int purchase_status;
    private double purchase_value;
    private Store store;
    public List<Product> getProducts()
    {
        return products;
    }

    public Client getClient()
    {
        return client;
    }
    public void setClient(Client client)
    {
        this.client = client;
    }

    public void setProducts(List<Product> products)
    {
        this.products = products;
    }

    public DateTime getDatePurchase()
    {
        return this.date_purchase;
    }
    public void setDataPurchase(DateTime date_purchase)
    {
        this.date_purchase = date_purchase;
    }

    public string getNumberConfirmation()
    {
        return number_confirmation;
    }
    public void setNumberConfirmation(string number_confirmation)
    {
        this.number_confirmation = number_confirmation;
    }

    public string getNumberNf()
    {
        return number_nf;
    }
    public void setNumberNf(string number_nf)
    {
        this.number_nf = number_nf;
    }

    public int getPaymentType()
    {
        return payment_type;
    }
    public void setPaymentType(int payment_type)
    {
        this.payment_type = payment_type;
    }

    public int getPurchaseStatus()
    {
        return purchase_status;
    }
    public void setPurchaseStatus(int purchase_status)
    {
        this.purchase_status = purchase_status;
    }

    public double getValue()
    {
        return purchase_value;
    }
    public void setValue(double purchase_value)
    {
        this.purchase_value = purchase_value;
    }
    public Store getStore()
    {
        return store;
    }
    public void setStore(Store store)
    {
        this.store = store;
    }

    public bool validateObject()
    {
        if (this.getDatePurchase() == null) return false;
        if (this.getValue() == 0.0) return false;
        if (this.getNumberNf() == null) return false;
        if (this.getNumberConfirmation() == null) return false;
        return true;
    }

    public void updateStatus(int purchaseStatusEnum)
    {
        this.purchase_status = purchaseStatusEnum;
    }
    public void delete(PurchaseDTO obj)
    {

    }
<<<<<<< HEAD



    public int save()
    {
=======
    public int save(string document, string cnpj, string bar_code, int payment_type){
>>>>>>> 4ea9eb7855688bb85b53429d0e313986ea33da10
        var id = 0;

        using (var context = new LibraryContext())
        {
<<<<<<< HEAD
            if (this.products.Count() <= 0) { return -1; }

            var purchase = new DAO.Purchase
            {
                date_purchase = this.date_purchase,
                number_confirmation = this.number_confirmation,
                number_nf = this.number_nf,
                payment_type = this.payment_type,
                purchase_status = this.purchase_status,
                client = context.Client.FirstOrDefault(c => c.document == this.client.getDocument()),
                store = context.Store.FirstOrDefault(s => s.CNPJ == this.store.getCNPJ()),
                product = context.Product.FirstOrDefault(p => p.bar_code == this.products.First().getBarCode())
            };

            context.Purchase.Add(purchase);
            context.Entry(purchase.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Entry(purchase.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Entry(purchase.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.SaveChanges();
            this.products.Remove(products.First());
            this.save();
            id = purchase.id;
=======
            try{
                var client = context.Client.FirstOrDefault(c => c.document == document);
                var store = context.Store.FirstOrDefault(s => s.CNPJ == cnpj);
                var product = context.Product.FirstOrDefault(p => p.bar_code == bar_code);

                var purchase = new DAO.Purchase{
                    date_purchase = this.date_purchase,
                    number_confirmation = this.number_confirmation,
                    number_nf = this.number_nf,
                    payment_type = payment_type,
                    purchase_status = this.purchase_status,
                    purchase_value = this.purchase_value,
                    client = client,
                    store = store,
                    product = product
                };
                
                context.Entry(purchase.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(purchase.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(purchase.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                
                context.Purchase.Add(purchase);
                
                context.SaveChanges();
                id = purchase.id;
            }catch(Exception e){
                Console.WriteLine(e);
            }
            
>>>>>>> 4ea9eb7855688bb85b53429d0e313986ea33da10
        }
        return id;
    }

    public static string removePurchase(int id)
    {
        using (var context = new LibraryContext())
        {
            var purchase = context.Purchase.FirstOrDefault(e => e.id == id);
            context.Remove(purchase);
            context.SaveChanges();
            return purchase.id + " foi removido!";
        }
    }
    public void update(PurchaseDTO obj)
    {

    }

    public PurchaseDTO findById(int id)
    {

        return new PurchaseDTO();
    }

    public List<PurchaseDTO> getAll()
    {
        return this.purchaseDTO;
    }

    public static List<object> getStorePurchases(int storeID)
    {
        using (var context = new DAO.LibraryContext())
        {
            var storePurchase = context.Purchase.Include(p => p.client).Include(p => p.client.address).Include(p => p.store).Include(p => p.product).Include(p => p.store.owner).Include(p => p.store.owner.address).Where(p => p.store.id == storeID);

            List<object> compras = new List<object>();
            foreach (var comp in storePurchase)
            {
                compras.Add(comp);
            }
            return compras;
        }

    }

    public static List<object> getOwnerPurchases(string document)
    {
        List<int> storeId = new List<int>();
        List<object> compras = new List<object>();
        using (var context = new DAO.LibraryContext())
        {
            var store = context.Store.Where(s => s.owner.document == document);
            foreach (var item in store)
            {
                storeId.Add(item.id);
            }
        }




        using (var context = new DAO.LibraryContext())
        {
            foreach (var s in storeId)
            {
                var storePurchase = context.Purchase.Include(p => p.store).Include(p => p.product).Include(p => p.store.owner).Include(p => p.store.owner.address).Where(p => p.store.id == s);

                foreach (var comp in storePurchase)
                {
                    compras.Add(comp);
                }
            }
            return compras;
        }

    }
    public static List<object> getClientPurchases(string document)
    {
        using (var context = new DAO.LibraryContext())
        {
            var clientPurchase = context.Purchase.Include(p => p.client).Include(p => p.client.address).Include(p => p.store).Include(p => p.product).Include(p => p.store.owner).Include(p => p.store.owner.address).Where(p => p.client.document == document);

            List<object> compras = new List<object>();
            foreach (var comp in clientPurchase)
            {
                compras.Add(comp);
            }
            return compras;
        }

    }
    public static object getPurchase(int id)
    {
        using (var context = new DAO.LibraryContext())
        {
            var purchase = context.Purchase.Include(p => p.client).Include(p => p.client.address).Include(p => p.store).Include(p => p.product).Include(p => p.store.owner).Include(p => p.store.owner.address).Where(p => p.id == id).Single();
            return purchase;
        }
    }


    public PurchaseDTO convertModelToDTO()
    {
        var PurchaseDTO = new PurchaseDTO();
        PurchaseDTO.date_purchase = this.date_purchase;
        PurchaseDTO.purchase_status = this.purchase_status;
        PurchaseDTO.number_nf = this.number_nf;
        PurchaseDTO.purchase_value = this.purchase_value;
        PurchaseDTO.number_confirmation = this.number_confirmation;


        return PurchaseDTO;
    }


    public static Purchase convertDTOToModel(PurchaseDTO obj)
    {
        Purchase purchase = new Purchase();
        purchase.date_purchase = obj.date_purchase;
        purchase.purchase_status = obj.purchase_status;
        purchase.number_nf = obj.number_nf;
        purchase.purchase_value = obj.purchase_value;
        purchase.number_confirmation = obj.number_confirmation;
        return purchase;
    }

    public static Purchase convertDAOToModel(DAO.Purchase obj)
    {
        var purchase = new Purchase();
        purchase.date_purchase = obj.date_purchase;
        purchase.purchase_status = obj.purchase_status;
        purchase.number_nf = obj.number_nf;
        purchase.purchase_value = obj.purchase_value;
        purchase.number_confirmation = obj.number_confirmation;

        return purchase;
    }
}
