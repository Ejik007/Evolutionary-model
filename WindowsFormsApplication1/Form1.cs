using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int num = Convert.ToInt32(textBox1.Text);
			int gamma = Convert.ToInt32(textBox2.Text);
			int T0 = Convert.ToInt32(textBox3.Text);
			int b2 = Convert.ToInt32(textBox4.Text);
			int b1 = Convert.ToInt32(textBox5.Text);
			int a = Convert.ToInt32(textBox6.Text);
			double sgm = Convert.ToDouble(textBox7.Text);
			label8.Text = "";
			label9.Text = "";
			if ((b1 >= a) ||
				((T0 + gamma) >= b2) ||
				((a + 10 * (T0 + gamma)) >= (b1 + 10 * b2)) ||
				((a + T0) <= (b1 + b2)))
				MessageBox.Show("Введённые данные не удовлетворяют условию задачи");
			else
			{
				Random r = new Random();

				List<double> x = new List<double>();
				x.Add(r.NextDouble());
				int i = 0;
				int p = 1;
				double x_isk = 0;
				double i_isk = 0;
				while (p<2)
				{
					double px = (a - b1) / (b2 - T0 - gamma * Math.Pow(x[i], 4));
					double xp = 1 / px;
					i++;
					x.Add(xp);
					if ((x[i]-x[i-1])<sgm)
					{
						p = 2;
						x_isk = Math.Round(100 * x[i]) / 100;
						i_isk = i+1;
					}
					label8.Text = x_isk.ToString();
					label9.Text = i_isk.ToString();
				}
			}
  //p, num, gamma, T0, b1, b2, a, i, i_isk : integer;
  //sgm, px, xp, x_isk : double;
  //x:array of double;
			//	  Randomize;
			//	  Setlength(x,1);
			//	  x[0]:=Random;
			//	  i:=0;
			//	  p:=1;
			//	  x_isk:=0;
			//	  i_isk:=0;
			//		while (p<2) do begin
			//		  px:=(a-b1)/(b2-T0-gamma*exp(4*ln(x[i])));
			//		  xp:=1/px;
			//		  i:=i+1;
			//		  Setlength(x,i+1);
			//		  x[i]:=xp;
			//			if (x[i]-x[i-1])<sgm then begin
			//			  p:=2;
			//			  x_isk:=(Round(100*(x[i])))/100;
			//			  i_isk:=i+1;
			//			end;
			//		end;
			//	  Label8.Caption:=FloatToStr(x_isk);
			//	  Label9.Caption:=IntToStr(i_isk);
			//	end;
			//end;
		}
	}
}
