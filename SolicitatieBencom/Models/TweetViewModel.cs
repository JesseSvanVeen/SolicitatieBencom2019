using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SolicitatieBencom.Models
{
    public class TweetViewModel
    {

        [DisplayName("User")]
        public string User { get; set; }

        [DisplayName("Tweet")]
        public string Tweet { get; set; }
    }
}
