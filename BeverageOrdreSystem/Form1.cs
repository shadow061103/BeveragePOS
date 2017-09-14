using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeverageOrdreSystem
{
    public partial class Form1 : Form
    {

        //this is in develop

        
        //大家好啊
        //this is in develop
        

        public bool focus = true;
       Beveragefactory factory = new Beveragefactory();
      List<OrderDetail> order = new List<OrderDetail>();
    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Beverage> list = factory.list;
           
           

            //動態產生按鈕
            Button[] btn = new Button[list.Count];
            for (int i=0; i < list.Count; i++) {
                btn[i] = new Button();
                btn[i].Name = "btnitem"+i;
                btn[i].Text = list[i].name;
                btn[i].Height = 70;
                btn[i].Width = 80;
                btn[i].Left = i % 3 * btn[i].Width;
                btn[i].Top = i / 3 * btn[i].Height;
                
                btn[i].Click += new EventHandler(itemchoose_Click);
                panel1.Controls.Add(btn[i]);




            }


        }

        private void listBoxSuger_SelectedIndexChanged(object sender, EventArgs e)
        {//選甜度、冰塊、大小
            if (listBoxSuger == (sender as ListBox))
            {
                txtSugar.Text = (sender as ListBox).SelectedItem.ToString();
            }
            else if (listBoxCup == (sender as ListBox))
            {
                txtSize.Text = (sender as ListBox).SelectedItem.ToString();
            }
            else {
                txtIce.Text = (sender as ListBox).SelectedItem.ToString();
            }



            }
        private void itemchoose_Click(object sender, EventArgs e)
        {//選品項
            txtItem.Text = (sender as Button).Text;
}

        private void btnC_Click(object sender, EventArgs e)
        {//計算機C
            if (focus == true)
                txtCup.Text = "0";
            else
                txtincome.Text = "0";
        }
        private void btnCalculator_Click(object sender, EventArgs e)
        {
            //計算機  杯數或實收金額


            if (focus==true)//判斷選到哪個textbox
            {
                if (txtCup.Text.Equals("0"))
                    txtCup.Text = (sender as Button).Text;
                else
                    txtCup.Text += (sender as Button).Text;
            }
            else
            { 
                  if (txtincome.Text.Equals("0"))
                    txtincome.Text = (sender as Button).Text;
                else
                    txtincome.Text += (sender as Button).Text;
            }

          
        
        }

        private void txtCup_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtCup == sender as TextBox)
            focus = true;
            if(txtincome==sender as TextBox)
                focus = false;
        }

        private void btnminus_Click(object sender, EventArgs e)
        {//計算機的消除鍵
            if (focus == true)
            {
                if (txtCup.Text.Length <= 1) {
                    txtCup.Text = "0";
                }
                else
                txtCup.Text = txtCup.Text.Substring(0, txtCup.Text.Length - 1);
            }

            else
            {
                if (txtincome.Text.Length == 0)
                {
                    txtincome.Text = "0";
                }
                else
                    txtincome.Text = txtincome.Text.Substring(0, txtincome.Text.Length - 1);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtItem.Text.Length > 0 &&
                txtIce.Text.Length > 0 &&
                txtSugar.Text.Length > 0 &&
                txtSize.Text.Length > 0 &&
                txtCup.Text.Length > 0 &&
                txtCup.Text != "0")
            {
                OrderDetail item = new OrderDetail();
                item.品名 = txtItem.Text;
                item.大小 = txtSize.Text;
                item.冰塊 = txtIce.Text;
                item.甜度 = txtSugar.Text;
                item.數量 = Convert.ToInt32(txtCup.Text);
                foreach (Beverage b in factory.list)
                {
                    if (b.name.Equals(txtItem.Text))
                    {

                        switch (listBoxCup.SelectedIndex)
                        {
                            case 0:
                                item.價格 = b.pricebig;
                                item.小計 = b.pricebig * Convert.ToInt32(txtCup.Text);
                                break;
                            case 1:
                                item.價格 = b.pricemid;
                                item.小計 = b.pricemid * Convert.ToInt32(txtCup.Text);
                                break;
                            case 2:
                                item.價格 = b.pricesmall;
                                item.小計 = b.pricesmall * Convert.ToInt32(txtCup.Text);
                                break;
                        }
                    }


                }
                order.Add(item);//把訂購品項加進orderdetail陣列

                showGridView();
                int qty = 0, AR = 0;
                foreach (OrderDetail o in order) {
                    qty += o.數量;
                    AR += o.小計;
                 }
                txtAccountReceivable.Text = AR.ToString();
                txtTotalCup.Text = qty.ToString();
  }
            else
                MessageBox.Show("請選擇品項、數量、甜度、冰塊、大小");
        }

        private void showGridView()
        {
            //輸入到dataGridView
            dataGridView1.DataSource = order.ToArray();
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 60;
            dataGridView1.Columns[6].Width = 80;
            bool isColorChanged = true;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                r.DefaultCellStyle.Font = new Font("微軟正黑體", 14);
                isColorChanged = !isColorChanged;
                if (isColorChanged)
                    r.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                else
                    r.DefaultCellStyle.BackColor = Color.LightBlue;


            }
        }

        private void btnBill_Click(object sender, EventArgs e)
        {//計算找零
            int income = Convert.ToInt32(txtincome.Text);
            int AccountReceivable = Convert.ToInt32(txtAccountReceivable.Text);
            if (AccountReceivable > 0 && income > AccountReceivable)
            {
                txtChange.Text = (income - AccountReceivable).ToString();
            }
            else {
                MessageBox.Show("實收金額有誤，請確認");
            }
            focus = true;//焦點回到數量欄位
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
           
            txtTotalCup.Text = "0";
            txtAccountReceivable.Text = "0";
            txtincome.Text="0";
            txtChange.Text="0";
            order.Clear();
            showGridView();
        }

       
    }
    }

