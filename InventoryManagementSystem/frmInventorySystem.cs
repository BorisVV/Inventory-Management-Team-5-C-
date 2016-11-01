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
        InventoryItems inventories = new InventoryItems("The Little Angel", "Frank Gray", "Oxford University");


        public frmInventorySystem()
        {
            InitializeComponent();
        }

        //An action handler that add inventories to that inventories
        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            inventories.AddInventories(txtBookTitle.Text, txtAuthor.Text, txtPublisher.Text);

            List<InventoryItems> items = inventories.getListsItems();
            if (lstSummary.Items.Count > 0)
            {
                lstSummary.Items.Clear();
            }
            foreach (InventoryItems item in items)
            {

                lstSummary.Items.Add("Item successfully Added to Inventory");
                lstSummary.Items.Add("");
                lstSummary.Items.Add(label2.Text + " " + item.getbookTitle());
                lstSummary.Items.Add(label3.Text + " " + item.GetAuthorName());
                lstSummary.Items.Add(label4.Text + " " + item.getPubisher());
                lstSummary.Items.Add("");
                lstSummary.Items.Add("*****************************");


            }
            clearControls();
        }
        public void clearControls()
        {
            txtAuthor.Text = "";
            txtBookTitle.Text = "";
            txtPublisher.Text = "";
            txtBookTitle.Focus();
            

        }




        //An action handler that search and retrieves the author name along with the book from the inventories

        private void btnSearchAuthor_Click(object sender, EventArgs e)
        {
            InventoryItems itemFound = inventories.searchAuthor(txtAuthorSearch.Text);
            if (txtAuthorSearch.Text == "")
            {
                MessageBox.Show("You haven't added any inventories, os you can't search anything", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (itemFound == null && txtAuthorSearch.Text != null)
            {
                MessageBox.Show(txtAuthorSearch.Text + " is not in inventory", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                lstSearchItems.Items.Add(label2.Text + itemFound.getbookTitle());
                lstSearchItems.Items.Add(label3.Text + itemFound.GetAuthorName());
                lstSearchItems.Items.Add(label4.Text + itemFound.getPubisher());
                lstSearchItems.Items.Add("");
                lstSearchItems.Items.Add("************************************");
               
            }
            txtAuthorSearch.Clear();
            txtAuthorSearch.Focus();
        }

        //An action handler that search the book title added by the user to  the inventoris        
        private void btnBookTitleSearch_Click(object sender, EventArgs e)
        {
            InventoryItems itemFound = inventories.searchBookTitel(txtBookSearch.Text);
            if(txtBookSearch.Text == "")
            {
                MessageBox.Show("You haven't added anything, so you can't search anything", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          else if(itemFound == null && txtBookSearch != null)
            {
                MessageBox.Show(txtBookSearch.Text + " is not in inventories", "Information", MessageBoxButtons.OK);
            }
            else
            {
                lstSearchItems.Items.Add(label2.Text + itemFound.getbookTitle());
                lstSearchItems.Items.Add(label3.Text + itemFound.GetAuthorName());
                lstSearchItems.Items.Add(label4.Text + itemFound.getPubisher());
                lstSearchItems.Items.Add("");
                lstSearchItems.Items.Add("**********************************");
            }
            txtBookSearch.Clear();
            txtBookSearch.Focus();
                     
        }
    }
   }
//Inventories Class that holds the book name, author name and publisher name of the inventories
    class InventoryItems
    {
        private string bookTitle;
        private string authorName;
        private string publisher;
        private List<InventoryItems> inventories = new List<InventoryItems>();

    //The constructor of the inventories
        public InventoryItems(string bookTitle, string authorname, string publisher)
        {
            this.bookTitle = bookTitle;
            this.authorName = authorname;
            this.publisher = publisher;
        }

    //A method that adds inventory to the inventries
        public void AddInventories(string bookTitle, string authorname, string publisher)
        {
            this.inventories.Add(new InventoryItems( bookTitle, authorname, publisher));
            
        }
        public List<InventoryItems> getListsItems()
        {
            return this.inventories; 
        }
    
        // A method that search and return book in the inventory
        public InventoryItems searchBookTitel(String name)
        {
            for(int i=0; i<this.inventories.Count; i++)
            {
                InventoryItems itemFound = this.inventories[i];
                if (itemFound.getbookTitle().Equals(name))
                {
                    return this.inventories[i];
                }
              
            }
            return null;
        }

    public InventoryItems searchAuthor(String name)
    {
        for (int i = 0; i < this.inventories.Count; i++)
        {
            InventoryItems itemFound = this.inventories[i];
            if (itemFound.GetAuthorName().Equals(name))
            {
                return this.inventories[i];
            }

        }
        return null;
    }
    //A method that gets the name  of the book enter by the user
    public String getbookTitle()
        {
            return this.bookTitle;
        }
    //A method that get the author name  of the book
        public String GetAuthorName()
        {
            return this.authorName;
        }
    //A method that gets the publisher name of the book
        public String getPubisher()
        {
            return this.publisher;
        }
    
    }

