//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CashBillDetail
    {
        public int ID { get; set; }
        public int BillID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int SalePrice { get; set; }
    
        public virtual CashBill CashBill { get; set; }
        public virtual Product Product { get; set; }
    }
}
