using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATM_WEB.Models
{
    public class ATMWEB
    {
        [Required(ErrorMessage = "Please Enter Amount")]
        [Display(Name = "Enter Value :")]
        public string UserATM { get; set; }

        [Required(ErrorMessage = "Please Enter Amount")]
        [Display(Name = "Bankbankbalance : ")]
        public int Bankbankbalance { get; set; }

        [Required(ErrorMessage = "Please Enter Amount")]
        [Display(Name = "WidrowAmount : ")]
        public int WidrowAmount { get; set; }


        public int IN { get; set; }
        public List<INS> YUIOP { get; set; }
    }
    public class INS
    {

        public int ID { get; set; }
        public int IV { get; set; }

        public int IR { get; set; }

        public int IY { get; set; }

        public int IRN { get; set; }

        public int IS { get; set; }

    }
}