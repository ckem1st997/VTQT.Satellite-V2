using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VTQT.Satellite.Entity.Entity
{

    public partial class Subscriber: BaseEntity
    {
        [Column(Name = "ReferenceId")]
        public string ReferenceId { get; set; }

        [Column(Name = "SubscriberCode")]
        public string SubscriberCode { get; set; }

        [Column(Name = "Status")]
        [EnumDataType(typeof(Status))]

        public string Status { get; set; }

        [Column(Name = "ContractNo")]
        public string ContractNo { get; set; }

        [Column(Name = "CustomerName")]
        public string CustomerName { get; set; }


        [Column(Name = "ShipPlateNo")]
        public string ShipPlateNo { get; set; }


        [Column(Name = "CustomerMobile")]
        public string CustomerMobile { get; set; }


        [Column(Name = "CustomerAddress")]
        public string CustomerAddress { get; set; }

        [Column(Name = "Province")]
        public string Province { get; set; }

        [Column(Name = "District")]
        public string District { get; set; }

        [Column(Name = "PaymentCycleRegisted")]
        public string PaymentCycleRegisted { get; set; }

        [Column(Name = "DataCapacity")]
        public int? DataCapacity { get; set; }

        [Column(Name = "MonthlyBillingAmount")]
        public decimal? MonthlyBillingAmount { get; set; }


        [Column(Name = "SuspendFee")]
        public decimal? SuspendFee { get; set; }


        [Column(Name = "ActiveFee")]
        public decimal? ActiveFee { get; set; }


        [Column(Name = "ReActiveFee")]
        public decimal? ReActiveFee { get; set; }

        [Column(Name = "ContractDate")]
        public DateTime? ContractDate { get; set; }

        [Column(Name = "ContractDueDate")]
        public DateTime? ContractDueDate { get; set; }

        [Column(Name = "BillingStartDate")]
        public DateTime? BillingStartDate { get; set; }

        [Column(Name = "BillingDueDate")]
        public DateTime? BillingDueDate { get; set; }

        [Column(Name = "LastSync")]
        public DateTime? LastSync { get; set; }

        [Column(Name = "Provider")]
        public string Provider { get; set; }

    }
    
    
    
    
    public enum Status
    {
        ACTIVED, SUSPEND,DEACTIVE
    }
}

