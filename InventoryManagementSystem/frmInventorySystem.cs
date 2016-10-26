using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class frmInventorySystem : Form

    {
      


        public frmInventorySystem()
        {
            InitializeComponent();
        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            List<InventoryItems> items = new List<InventoryItems>();
            items.Add(new InventoryItems(txtBookTitle.Text, txtAuthor.Text, txtPublisher.Text));
            foreach (InventoryItems item in items)
            {
                lstSummary.Items.Add("Item successfully Added to Inventory");
                lstSummary.Items.Add("");
                lstSummary.Items.Add(label2.Text +" "+item.getbookTitle());
                lstSummary.Items.Add(label3.Text +" "+item.GetAuthorName());
                lstSummary.Items.Add(label4.Text +" "+item.getPubisher());
                lstSummary.Items.Add("");
                lstSummary.Items.Add("*****************************");
               
               
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
           
        }
    }
    class InventoryItems
    {
        private string bookTitle;
        private string authorName;
        private string publisher;
        private List<InventoryItems> inventories = new List<InventoryItems>();

        public InventoryItems(string bookTitle, string authorname, string publisher)
        {
            this.bookTitle = bookTitle;
            this.authorName = authorname;
            this.publisher = publisher;
        }

        public bool AddInventories(string bookTitle, string authorname, string publisher)
        {
            return false;
            
        }
        public InventoryItems findCustomer(String name)
        {
            for (int i = 0; i < this.inventories.Count; i++)
            {
                InventoryItems customer = this.inventories[i];
                if (customer.getbookTitle().Equals(name));
                {
                    return customer;
                }
            }
            return null;
        }

        public String getbookTitle()
        {
            return this.bookTitle;
        }
        public String GetAuthorName()
        {
            return this.authorName;
        }
        public String getPubisher()
        {
            return this.publisher;
        }

        public override string ToString()
        {
            return bookTitle + " "  + authorName + " " + publisher;
        }
    }
}
