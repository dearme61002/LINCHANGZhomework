using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LINCHANGZHI7324
{
    public partial class ChildFrom : Form
    {
        //為了安全全部都私有化

        private Dictionary<string, int> dataTruck;
        private Dictionary<string, int> datascooter;
        private Dictionary<string, int> databus;
        private Dictionary<string, int> smallbus;
        private Dictionary<string, int> salecar;
        public Dictionary<string, int> DataTruck { get => dataTruck; set => dataTruck = value; }
        public Dictionary<string, int> Datascooter { get => datascooter; set => datascooter = value; }
        public Dictionary<string, int> Databus { get => databus; set => databus = value; }
        public Dictionary<string, int> Smallbus { get => smallbus; set => smallbus = value; }
        public Dictionary<string, int> Salecar { get => salecar; set => salecar = value; }
        private DateTime startTime;
        private DateTime endTime;
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }


        public ChildFrom()
        {
            InitializeComponent();
        }

        private void ChildFrom_Load(object sender, EventArgs e)
        {
            //使用Readxml()方法取得資料
            Datascooter = Readxml("scooter", "cc", "price");
            DataTruck = Readxml("truck", "cc", "price");
            Databus = Readxml("bus", "cc", "price");
            Smallbus = Readxml("smallbus", "cc", "price");
            Salecar = Readxml("salecar", "cc", "price");

            //先給日期們給值
            StartTime = dateTimePickerStart.Value;
            EndTime = MydateTimePickerEnd.Value;


        }
        /// <summary>
        /// 分析XML取得裝有Dictionary<string, string>
        /// </summary>
        /// <param name="toolType"></param>
        /// <param name="cc"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        private Dictionary<string, int> Readxml(String toolType, String cc, String price)
        {
            XmlDocument xmlDocument = new XmlDocument();
            //  string Xmlload= Properties.Resources.importantHowTOCountTax;我可以透過這個選資料卻不知道要如何丟到xmlDocument裡只好用下面的方式處理 PS我把XML刪了等可以實體上課我再問老師您

            xmlDocument.Load(@"./xmldata/importantHowTOCountTax.xml");
            XmlNodeList xl = xmlDocument.SelectNodes(@"/taxs/tax[@id='" + toolType + @"']/" + cc);
            List<string> dataCC = new List<string>();
            List<int> dataPrice = new List<int>();
            Dictionary<string, int> dataResule = new Dictionary<string, int>();
            int icount = 0;

            foreach (XmlNode item in xl)
            {
                dataCC.Add(item.InnerText.ToString());
                icount++;

                //  Console.WriteLine(item.InnerText.ToString());檢查用
            }
            xl = xmlDocument.SelectNodes(@"/taxs/tax[@id='" + toolType + @"']/" + price);
            foreach (XmlNode item in xl)
            {
                dataPrice.Add(Convert.ToInt32((item.InnerText.ToString())));
            }
            for (int i = 0; i < icount; i++)
            {
                dataResule.Add(dataCC[i], dataPrice[i]);
            }
            return dataResule;
        }

        private void MylistBoxCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            MylistBoxCC.Items.Clear();
            ListboxccGatedata();
        }

        public void ListboxccGatedata()
        {
            if (MylistBoxCar.SelectedIndex == 0)
            {
                foreach (var item in Datascooter.Keys)
                {
                    MylistBoxCC.Items.Add(item);
                }

            }
            else if (MylistBoxCar.SelectedIndex == 1)
            {
                foreach (var item in DataTruck.Keys)
                {
                    MylistBoxCC.Items.Add(item);
                }
            }
            else if (MylistBoxCar.SelectedIndex == 2)
            {
                foreach (var item in Databus.Keys)
                {
                    MylistBoxCC.Items.Add(item);
                }
            }
            else if (MylistBoxCar.SelectedIndex == 3)
            {
                foreach (var item in Smallbus.Keys)
                {
                    MylistBoxCC.Items.Add(item);
                }
            }
            else if (MylistBoxCar.SelectedIndex == 4)
            {
                foreach (var item in Salecar.Keys)
                {
                    MylistBoxCC.Items.Add(item);
                }
            }

        }

        private void MytextBoxResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void MybuttonSumit_Click(object sender, EventArgs e)
        {
            CardTaxFather cardTaxFather = new CardTaxFather();
            MytextBoxResult.Text = "";
           if(MyradioButton2.Checked == true)
            {
                dateTimePickerStart.Value = new DateTime(2021, 1, 1);
                MydateTimePickerEnd.Value = new DateTime(2021, 12, 31);
            }
            if (dateTimePickerStart.Value> MydateTimePickerEnd.Value)
            {
                MessageBox.Show("日期出現錯誤");
                dateTimePickerStart.Value = new DateTime(2020, 1, 1);
                MydateTimePickerEnd.Value = new DateTime(2020, 6, 6);
                return;
            }
            if (MylistBoxCar.SelectedIndex==-1|| MylistBoxCC.SelectedIndex==-1)
            {
                MessageBox.Show("還沒有選油箱CC數");
                return;
            }
                if (MylistBoxCar.SelectedIndex == 0)
            {
                List<string> dd = new List<string>();//////////////////////////////////
                dd=  cardTaxFather.countResult(dateTimePickerStart.Value, MydateTimePickerEnd.Value, Datascooter[MylistBoxCC.SelectedItem.ToString()], MylistBoxCC.SelectedItem.ToString(), MylistBoxCar.SelectedItem.ToString());
                MytextBoxResult.Text = "";
                foreach (var item in dd)
                {
                    MytextBoxResult.Text = MytextBoxResult.Text + item;
                }

            }
            else if (MylistBoxCar.SelectedIndex == 1)
            {
                List<string> dd = new List<string>();//////////////////////////////////
                dd = cardTaxFather.countResult(dateTimePickerStart.Value, MydateTimePickerEnd.Value, DataTruck[MylistBoxCC.SelectedItem.ToString()], MylistBoxCC.SelectedItem.ToString(), MylistBoxCar.SelectedItem.ToString());
                MytextBoxResult.Text = "";
                foreach (var item in dd)
                {
                    MytextBoxResult.Text = MytextBoxResult.Text + item;
                }
            }
            else if (MylistBoxCar.SelectedIndex == 2)
            {
                List<string> dd = new List<string>();//////////////////////////////////
                dd = cardTaxFather.countResult(dateTimePickerStart.Value, MydateTimePickerEnd.Value, Databus[MylistBoxCC.SelectedItem.ToString()], MylistBoxCC.SelectedItem.ToString(), MylistBoxCar.SelectedItem.ToString());
                MytextBoxResult.Text = "";
                foreach (var item in dd)
                {
                    MytextBoxResult.Text = MytextBoxResult.Text + item;
                }
            }
            else if (MylistBoxCar.SelectedIndex == 3)
            {
                List<string> dd = new List<string>();//////////////////////////////////
                dd = cardTaxFather.countResult(dateTimePickerStart.Value, MydateTimePickerEnd.Value, Smallbus[MylistBoxCC.SelectedItem.ToString()], MylistBoxCC.SelectedItem.ToString(), MylistBoxCar.SelectedItem.ToString());
                MytextBoxResult.Text = "";
                foreach (var item in dd)
                {
                    MytextBoxResult.Text = MytextBoxResult.Text + item;
                }
            }
            else if (MylistBoxCar.SelectedIndex == 4)
            {
                List<string> dd = new List<string>();//////////////////////////////////
                dd = cardTaxFather.countResult(dateTimePickerStart.Value, MydateTimePickerEnd.Value, Salecar[MylistBoxCC.SelectedItem.ToString()], MylistBoxCC.SelectedItem.ToString(), MylistBoxCar.SelectedItem.ToString());
                MytextBoxResult.Text = "";
                foreach (var item in dd)
                {
                    MytextBoxResult.Text = MytextBoxResult.Text + item;
                }
            }
            
        }

        public void GotoMytextBoxResult()
        {
           
        }

        private void MyradioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
            dateTimePickerStart.Visible = false;
            dateTimePickerStart.Enabled= false;
            MydateTimePickerEnd.Visible = false;
            dateTimePickerStart.Enabled= false;
        }

        private void MyradioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerStart.Visible = true;
            dateTimePickerStart.Enabled = true;
            MydateTimePickerEnd.Visible = true;
            dateTimePickerStart.Enabled = true;
        }

        private void MybuttonRep_Click(object sender, EventArgs e)
        {
            MylistBoxCC.SelectedIndex = -1;
            MyradioButton1.Checked = true;
            dateTimePickerStart.Value = new DateTime(2021, 1, 1);
            MydateTimePickerEnd.Value = new DateTime(2021, 1, 6);

        }
    }
}
