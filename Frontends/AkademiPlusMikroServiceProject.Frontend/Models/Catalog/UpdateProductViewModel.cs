﻿namespace AkademiPlusMikroServiceProject.Frontend.Models.Catalog
{
    public class UpdateProductViewModel
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; }
        public string CategoryID { get; set; }
      
    }
}
