using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        double total = 0; // 總值
        string operation = ""; // 運算符號
        bool operationBtn_pressed = false; 
        bool multiOperation = false; //按運算時，算出前面算式的值
        bool enterBtn_pressed = false;
        bool removeBtn_pressed = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)　// 數值鈕方法
        {
            if (result.Text == "0" || operationBtn_pressed == true) //去除一開始的0或刪除前次數值
            {
                result.Clear();
            }
            Button btn = (Button)sender;  // 轉型並讀取參數
            result.Text +=  btn.Text; // 改變提示框的字
            operationBtn_pressed = false;
        }

        private void floatBtn_Click(object sender, EventArgs e)　// 小數點鈕方法
        {
            Button btn = (Button)sender;  // 轉型並讀取參數
            if (operationBtn_pressed == false) // 前次輸入為數值鈕
            {
                result.Text += btn.Text; 
            }
            if (enterBtn_pressed == true ) // 前次輸入為enter，總值為字框裡的值
            {
                total = Double.Parse(result.Text);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            total = 0;
            result.Text = "0";
            equation.Text = "";
        }

        private void operationBtn_click(object sender, EventArgs e) //按運算鈕時，計算前次的值
        {
           
            if (multiOperation == false || enterBtn_pressed == true) // 未按過運算鈕或已按enter，總值為字框裡的值
            {
                total = Double.Parse(result.Text);
            }
            else if (multiOperation == true) // 先前已按過運算鈕，計算前次的值
            {
                switch (operation)
                {
                    case "+":
                        total +=  Double.Parse(result.Text);
                        break;
                    case "-":
                        total -=  Double.Parse(result.Text);
                        break;
                    case "*":
                        total *=  Double.Parse(result.Text);
                        break;
                    case "/":
                        total /=  Double.Parse(result.Text);
                        break;
                    default:
                        break;
                }
            }
            operationBtn_pressed = true;
            enterBtn_pressed = false; 
            multiOperation = true; // 已按過運算鈕
            Button btn = (Button)sender;
            operation = btn.Text; // 儲存當前的運算鈕供下次使用
            equation.Text += result.Text + btn.Text;
        }

        private void getResult(object sender, EventArgs e)
        {
            if (removeBtn_pressed == true && result.Text.Length == 0) // remove當前全部的值
            {
                result.Text = total.ToString();
            }
            else if (enterBtn_pressed == false) // 重複按enter，不會改變值
            {
                enterBtn_pressed = true;
                switch (operation)
                {
                    case "+":
                        total += Double.Parse(result.Text);
                        break;
                    case "-":
                        total -= Double.Parse(result.Text);
                        break;
                    case "*":
                        total *= Double.Parse(result.Text);
                        break;
                    case "/":
                        total /= Double.Parse(result.Text);
                        break;
                    default:
                        break;
                }
            }
            result.Text = total.ToString();
            equation.Text = "";
            operation = "";
        }

        private void removeNum(object sender, EventArgs e)
        {
            if (result.Text.Length != 0)　// 從字尾刪除數字
            {
                result.Text = result.Text.Remove(result.Text.Length - 1);
            }
            if (result.Text.Length == 0)
            {
                result.Text = "0"; // 全部數字刪除後，將值設為０
            }
            removeBtn_pressed = true;
        }
    }
}
