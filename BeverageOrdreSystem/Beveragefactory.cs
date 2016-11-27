using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeverageOrdreSystem
{
    class Beveragefactory
    {
        public List<Beverage> list = new List<Beverage>();
        

        public Beveragefactory(){
            loadData();
        }
        public void loadData() {
            list.Add(new Beverage() { name = "綠茶", pricebig = 20, pricemid = 15, pricesmall = 10 });
            list.Add(new Beverage() { name = "紅茶", pricebig = 20, pricemid = 15, pricesmall = 10 });
            list.Add(new Beverage() { name = "珍珠奶茶", pricebig = 45, pricemid = 35, pricesmall = 25 });
            list.Add(new Beverage() { name = "布丁奶茶", pricebig = 45, pricemid = 40, pricesmall = 20 });
            list.Add(new Beverage() { name = "咖啡凍奶茶", pricebig = 50, pricemid = 40, pricesmall = 30 });
            list.Add(new Beverage() { name = "烏龍綠茶", pricebig = 30, pricemid = 20, pricesmall = 10 });
            list.Add(new Beverage() { name = "冬瓜茶", pricebig = 20, pricemid = 15, pricesmall = 10 });
            list.Add(new Beverage() { name = "檸檬紅茶", pricebig = 35, pricemid = 25, pricesmall = 15 });
            list.Add(new Beverage() { name = "啤酒", pricebig = 80, pricemid = 65, pricesmall = 40 });
            list.Add(new Beverage() { name = "紅酒", pricebig = 120, pricemid = 85, pricesmall = 70 });
            list.Add(new Beverage() { name = "阿華田", pricebig = 30, pricemid = 25, pricesmall = 20 });
            list.Add(new Beverage() { name = "高粱", pricebig = 150, pricemid = 125, pricesmall = 100 });
            list.Add(new Beverage() { name = "御香青茶", pricebig = 20, pricemid = 15, pricesmall = 10 });
            list.Add(new Beverage() { name = "桂圓紅棗茶", pricebig = 30, pricemid = 25, pricesmall = 20 });
            list.Add(new Beverage() { name = "多多綠", pricebig = 20, pricemid = 15, pricesmall = 10 });
            //原則上按鈕15個  也可以新增更多  會出現卷軸
            /*
            list.Add(new Beverage() { name = "綠茶", pricebig = 20, pricemid = 15, pricesmall = 10 });
            list.Add(new Beverage() { name = "紅茶", pricebig = 20, pricemid = 15, pricesmall = 10 });
            list.Add(new Beverage() { name = "珍珠奶茶", pricebig = 45, pricemid = 35, pricesmall = 25 });
            list.Add(new Beverage() { name = "布丁奶茶", pricebig = 45, pricemid = 40, pricesmall = 20 });
            list.Add(new Beverage() { name = "咖啡凍奶茶", pricebig = 50, pricemid = 40, pricesmall = 30 });
            list.Add(new Beverage() { name = "烏龍綠茶", pricebig = 30, pricemid = 20, pricesmall = 10 });
            list.Add(new Beverage() { name = "冬瓜茶", pricebig = 20, pricemid = 15, pricesmall = 10 });
            list.Add(new Beverage() { name = "檸檬紅茶", pricebig = 35, pricemid = 25, pricesmall = 15 });
            */
        }
      



        
        








    }
}
