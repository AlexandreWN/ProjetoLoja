using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using Interfaces;
namespace Model;
public class Purchase
{
    public int id;
    public DateTime date_purchase;
    public string payment;
    public string number_confirmation;
    public string number_nf;
    public int payment_type;
    public int purchaseStatusEnum;
}