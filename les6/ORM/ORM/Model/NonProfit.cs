using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Model
{
    [Table("NonProfit")]
    public class NonProfit : Organisation
    {
        public NonProfit() : base()
        {
        }

        public string Goal { get; set; }

        public string Category { get; set; }
    }
}
