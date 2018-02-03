using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Approval.Models
{
    public class ApprovalModel
    {
        [Key]
        [Display(Name = "Quote ID")]
        public string quote_id { get; set; }
        [Display(Name = "Order ID")]
        public string order_id { get; set; }
        [Display(Name = "Date")]
        public string date_trans { get; set; }
        [Display(Name = "Amount")]
        public decimal quote_value { get; set; }
        [Display(Name = "Ship From")]
        public string ship_from_city { get; set; }
        [Display(Name = "Ship To")]
        public string ship_to_city { get; set; }
        [Display(Name = "Ship Type")]
        public string ship_type { get; set; }
        //[Display(Name = "Lead Time")]
        [Display(Name ="Lead Time")]
        public int lead_time { get; set; }
        [Display(Name = "Lead Days")]
        public string lead_time_days { get; set; }
        [Display(Name = "TOP Code")]
        public string term_pay_code { get; set; }
        [Display(Name = "Status")]
        public int status { get; set; }
        [Display(Name = "Ship Description 1")]
        public string ship_desc_1 { get; set; }
        [Display(Name = "Ship Description 2")]
        public string ship_desc_2 { get; set; }
        [Display(Name = "Ship Description 3")]
        public string ship_desc_3 { get; set; }
        [Display(Name = "Customer")]
        public string customer { get; set; }
        [Display(Name = "Goods")]
        public string goods { get; set; }
        [Display(Name = "Action Type")]
        public string action_type_name { get; set; }
        [Display(Name = "TOP Days")]
        public string top_days { get; set; }
        [Display(Name = "TOP Description")]
        public string top_desc { get; set; }
    }
}