using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboboxGUI
{
    public partial class Form1 : Form
    {
        List<Food> listItem;
        List<CBClass> ListClass;
        public Form1()
        {
            InitializeComponent();

            listItem = new List<Food>() 
            { 
                new Food(){Name = "Mực một nắng nướng sa tế", Price = 200000}, 
                new Food(){Name = "Dú dê nướng sữa", Price = 75000},
                new Food(){Name = "Ếch núp lùm", Price = 50000}
            };
            comboBox1.DataSource = listItem;
            comboBox1.DisplayMember = "Name";

            AddBinding();


            ListClass = new List<CBClass>();
            ListClass.Add(new CBClass()
            {
                ClassName = "12CK1",
                ListStudent = new List<string>() { "K9", "Kosak"}
            });
            ListClass.Add(new CBClass()
            {
                ClassName = "12CK5",
                ListStudent = new List<string>() { "DG" }
            });

            cbBranch.DataSource = ListClass;
            cbBranch.DisplayMember = "ClassName";

            //AddClassBinding();
        }        
        void AddClassBinding()
        {
            cbClass.DataBindings.Add("DataSource", cbBranch.SelectedItem, "ListStudent", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        void AddBinding()
        {
            textBox1.DataBindings.Add(new Binding("Text", comboBox1.DataSource, "Price"));
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //ComboBox cb = sender as ComboBox;

            //if (cb.SelectedValue != null)
            //{
            //    Food food = cb.SelectedValue as Food;
            //    textBox1.Text = food.Price.ToString();
            //}
        }

        private void cbBranch_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedValue != null)
            {
                CBClass cl = cb.SelectedValue as CBClass;
                cbClass.DataSource = cl.ListStudent;
            }
        }
    }

    public class Food
    {
        public string Name { get; set; }
        public float Price { get; set; }
    }

    public class CBClass
    {
        public string ClassName { get; set; }
        public List<string> ListStudent { get; set; }
    }
}
