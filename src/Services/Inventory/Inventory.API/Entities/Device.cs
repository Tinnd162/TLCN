using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.API.Entities
{
    [Table("Device")]
    public class Device
    {
        public string Id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? ImportDate { get; set; }
        public DateTime? ActivateDate { get; set; }
        public bool IsActivate { get; set; }
        public string ImportUser { get; set; }
        public string ExportUser { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}