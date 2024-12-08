using System;
using System.Collections.Generic;
using System.Text;

namespace zd7_romanov
{
    class Data
    {
        public string adress;
        public string tel;
        public string oklad;
        public string markAvto;
        public string fio;
        public string win;
        public string probeg;
        public string dateStart;
        public string dateEnd;
        public string godvip;
        public string srokIspoln;
        public string price;

        public Data(string godvip,string adress, string tel, string oklad, string markAvto, string fio, string win, string probeg, string dateStart, string dateEnd, string srokIspoln, string price)
        {
            this.adress = adress;
            this.tel = tel;
            this.oklad = oklad;
            this.markAvto = markAvto;
            this.fio = fio;
            this.win = win;
            this.probeg = probeg;
            this.dateStart = dateStart;
            this.dateEnd = dateEnd;
            this.srokIspoln = srokIspoln;
            this.price = price;
            this.godvip = godvip;
        }
    }
}
