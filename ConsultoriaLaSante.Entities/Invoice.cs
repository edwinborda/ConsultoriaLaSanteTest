using System;
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

        public Invoice(string orderNumber, string billNumber, int nit, string nameSupplier)
        {
            this.FormNumber = Guid.NewGuid();
            this.OrderNumber = orderNumber;
            this.BillNumber = billNumber;
            this.OrderState = State.open;
            this.Supplier = new Supplier()
            {
                 Nit = nit,
                 Name = nameSupplier
            };
        }

        public Guid FormNumber { get; private set; }

        public string OrderNumber { get; private set; }

        public string BillNumber { get; private set; }

        public int Supplier_id { get; private set; }

        [ForeignKey("Supplier_id")]
        public virtual Supplier Supplier { get; private set; }

        public State OrderState { get; private set; }

    }

}