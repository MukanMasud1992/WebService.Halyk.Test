using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Halyk.Test.Model
{
    [Table("R_CURRENCY")]
    public class Currency
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public decimal Value { get; set; }
        public DateTime A_Date { get; set; }
    }
}
