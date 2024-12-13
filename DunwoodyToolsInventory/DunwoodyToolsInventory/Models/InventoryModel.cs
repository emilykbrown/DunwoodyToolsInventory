using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DunwoodyToolsInventory.Models
{
    public class InventoryModel
    {
        public int InventoryID { get; set; }
        public string InventoryName { get; set; }
        public string CategoryName { get; set; }
        public byte[] InventoryPicture { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }

}