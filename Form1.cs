using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba3GUI
{
    public partial class CalcVolume : Form
    {
        public CalcVolume()
        {
            InitializeComponent();
            var measureItems = new string[]
        {
            "куб.м.",
            "мл.",
            "л.",
            "б.",
        };

            comboBox2.DataSource = new List<string>(measureItems);
            comboBox3.DataSource = new List<string>(measureItems);
            comboBox4.DataSource = new List<string>(measureItems);
        }
        private MeasureType GetMeasureType(ComboBox comboBox)
        {
            MeasureType measureType;
            switch (comboBox.Text)
            {
                case "куб.м.":
                    measureType = MeasureType.m;
                    break;
                case "мл.":
                    measureType = MeasureType.ml;
                    break;
                case "л.":
                    measureType = MeasureType.l;
                    break;
                case "б.":
                    measureType = MeasureType.bbls;
                    break;
                default:
                    measureType = MeasureType.l;
                    break;
            }
            return measureType;
        }
        private void Calculate()
        {
            try
            {
                var firstValue = double.Parse(textBox1.Text);
                var secondValue = double.Parse(textBox2.Text);
                MeasureType firstType = GetMeasureType(comboBox2);
                MeasureType secondType = GetMeasureType(comboBox3);
                MeasureType resultType = GetMeasureType(comboBox4);
                var firstVolume = new Volume(firstValue, firstType);
                var secondVolume = new Volume(secondValue, secondType);
                Volume sumVolume;

                switch (comboBox1.Text)
                {
                    case "+":
                        sumVolume = firstVolume + secondVolume;
                        break;
                    case "-":
                        sumVolume = firstVolume - secondVolume;
                        break;
                    case "*":
                        sumVolume = firstVolume * secondVolume;
                        break;
                    case "/":
                        sumVolume = firstVolume / secondVolume;
                        break;
                    case "<=>":
                        double first, second;
                        switch (textBox1.Text)
                        {
                            case "мл.":
                                first = firstValue / 1000000;
                                break;
                            case "л.":
                                first = firstValue / 1000;
                                break;
                            case "бар.":
                                first = firstValue / 6.28982243831257;
                                break;
                            default:
                                first = firstValue;
                                break;
                        }
                        switch (textBox2.Text)
                        {
                            case "мл.":
                                second = secondValue / 1000000;
                                break;
                            case "л.":
                                second = secondValue / 1000;
                                break;
                            case "б.":
                                second = secondValue / 6.28982243831257;
                                break;
                            default:
                                second = secondValue;
                                break;
                        }
                        if (first > second)
                        {
                            sumVolume = firstVolume;
                            label1.Text = "Первое значение больше второго";
                        }
                        else if (first < second)
                        {
                            sumVolume = secondVolume;
                            label1.Text = "Второе значение больше первого";
                        }
                        else
                        {
                            sumVolume = firstVolume;
                            label1.Text = "Значения равны";
                        }
                        break;
                    default:
                        sumVolume = new Volume(0, MeasureType.m);
                        break;
                }
     
                textBox3.Text = sumVolume.To(resultType).Verbose();

            }
            catch (FormatException)
            {
                
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Calculate();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            label1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Мера объема, задаваемая в виде пары (значение, тип),\n допустимые типы: куб.м., миллилитры, литры, баррель"+
                "\n сложение " +
                "\n вычитание " +
                "\n умножение на число " +
                "\n сравнение двух объемов" +
                "\n вывод значения в любом типе");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 44)
            {
                e.Handled = true;
                label1.Text = "Вводите только числа \n" +
                             "Используйте запятую для разделения";
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 44)
            {
                e.Handled = true;
                label1.Text = "Вводите только числа \n" +
                             "Используйте запятую для разделения";
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}
