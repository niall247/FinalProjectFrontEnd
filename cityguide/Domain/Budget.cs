using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace cityguide.Domain
{
    [Table("Budget")]
    public class Budget
    {

        public int BudgetID {get;set;}
        public string BudgetName {get;set;}

    }
}
