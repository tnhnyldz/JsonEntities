using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace JsonEntities.EntityLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public decimal Price { get; set; }


        [NotMapped]
        public ProductDetail Detail { get; set; } = new ProductDetail();

        [JsonIgnore]
        [Column("Detail")]
        [MaxLength(int.MaxValue)]
        public string RequestString
        {
            get { return JsonConvert.SerializeObject(Detail); }
            set { Detail = JsonConvert.DeserializeObject<ProductDetail>(value); }
        }

        public DateTime Created { get; set; } = DateTime.Now;
    }
    public partial class ProductDetail
    {
        public List<ProductRequest> ProductRequests { get; set; }
        public List<ProductQuote> ProductQuotes { get; set; }

    }
    public class ProductRequest
    {
        public string Currency { get; set; } = "USD";
        public int CountryId { get; set; } = 0;
        public List<string> CouponCode { get; set; } = new List<string>();
        public bool CancelOrderIfCouponFails { get; set; } = false;
        public string Instructions { get; set; }
        public List<ProductFiles> Files { get; set; } = new List<ProductFiles>();
        public decimal? MaxPrice { get; set; } //Don't buy if greater than this

    }
    public class ProductQuote
    {
        public Guid RequestId { get; set; }
        public List<string> CouponCode { get; set; } = new List<string>();
        public string Notes { get; set; } //Internal
        public decimal SubTotal { get; set; } //Sum Of (Qty * Product Price)
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal Shipping { get; set; }
        public decimal OrderTotal
        {
            get { return SubTotal - Discount + Tax + Shipping; }
        }
        public decimal Commission
        {
            get
            {
                return OrderTotal > 70 ? OrderTotal * 0.1m : 7;
            }
        }
        public decimal Total
        {
            get { return OrderTotal + Commission; }
        }
        public DateTime Date { get; set; }
    }
    public class ProductFiles
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
