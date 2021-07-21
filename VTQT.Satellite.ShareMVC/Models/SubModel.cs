using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VTQT.Satellite.ShareMVC.Models
{
    public class SubModel : BaseEntityModel
    {

        public string ReferenceId { get; set; }


        public string SubscriberCode { get; set; }


        [EnumDataType(typeof(Status))]

        public string Status { get; set; }

        public string ContractNo { get; set; }

        public string CustomerName { get; set; }


        public string ShipPlateNo { get; set; }


        public string CustomerMobile { get; set; }


        public string CustomerAddress { get; set; }


        public string Province { get; set; }


        public string District { get; set; }



        public string PaymentCycleRegisted { get; set; }


        public int? DataCapacity { get; set; }

        public decimal? MonthlyBillingAmount { get; set; }


        public decimal? SuspendFee { get; set; }


        public decimal? ActiveFee { get; set; }


        public decimal? ReActiveFee { get; set; }


        public DateTime? ContractDate { get; set; }


        public DateTime? ContractDueDate { get; set; }


        public DateTime? BillingStartDate { get; set; }


        public DateTime? BillingDueDate { get; set; }


        public DateTime? LastSync { get; set; }

        public string Provider { get; set; }


    }




    public enum Status
    {
        ACTIVED, SUSPEND, DEACTIVE
    }

    public partial class SubValidator : AbstractValidator<SubModel>
    {
        public SubValidator()
        {
            RuleFor(x => x.CustomerName).NotNull().Length(0, 20).WithMessage("Tên là bắt buộc !");
        }
    }
}
