using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConektaClientDummyDemo.Models
{
    public class ChargeDemo
    {
        [Required]
        public string card_token { get; set; }

        [DisplayName("Card number")]
        public string card_number { get; set; }

        public ChargeDemo()
        {
            card_number = "4242424242424242"; // demo card number, see reference: https://www.conekta.io/en/docs/references/tests
        }
    }
}