using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ConsultoriaLaSante.Entities
{
    [Table("Invoices")]
    public class Invoice
    {
        public enum State
        {
            delete = 0,
            open = 1,
            close = 2
        }
        internal Invoice()   {}

        public Invoice(string orderNumber, string billNumber, string nit, string nameSupplier)
        {
            FormNumber = Guid.NewGuid();
            PurchaseNumber = orderNumber;
            BillNumber = billNumber;
            OrderState = State.open;
            Supplier = new Supplier()
            {
                 Nit = nit,
                 Name = nameSupplier
            };
        }

        [Key]
        public Guid FormNumber { get; private set; }

        public string PurchaseNumber { get; private set; }

        public string BillNumber { get; private set; }

        public int Supplier_id { get; private set; }

        public State OrderState { get; private set; }

        [ForeignKey("Supplier_id")]
        public virtual Supplier Supplier { get; private set; }

        public void changeStatus(State status)
        {
            OrderState = status;
        }

        public void UpdateInvoice(string orderNumber, string billNumber, string nit, string name, string formNumber)
        {
            FormNumber = new Guid(formNumber);
            PurchaseNumber = orderNumber;
            BillNumber = billNumber;
            Supplier.Nit = nit;
            Supplier.Name = name;
        }
    }

}