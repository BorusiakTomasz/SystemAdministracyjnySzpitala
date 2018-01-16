using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemAdministracyjnySzpitala
{
    public partial class Form2 : Form
    {
        private Lekarz lekarz;
        private Pielegniarka pielegniarka;
        private Form1 form1;

        public Form2(Form1 form1, Lekarz lekarz, List<Lekarz> listaLekarzy, List<Pielegniarka> listaPielegniarek)
        {
            InitializeComponent();

            this.form1 = form1;
            this.lekarz = lekarz;
            pielegniarka = null;

            listBox1.DataSource = listaLekarzy;
            listBox2.DataSource = listaPielegniarek;

            listBox1.SelectedItem = lekarz;
            listBox2.SelectedItem = null;

            monthCalendar1.MonthlyBoldedDates = lekarz.Dyzury.ToArray();
        }

        public Form2(Form1 form1, Pielegniarka pielegniarka, List<Lekarz> listaLekarzy, List<Pielegniarka> listaPielegniarek)
        {
            InitializeComponent();

            this.form1 = form1;
            lekarz = null;
            this.pielegniarka = pielegniarka;

            listBox1.DataSource = listaLekarzy;
            listBox2.DataSource = listaPielegniarek;

            listBox1.SelectedItem = null;
            listBox2.SelectedItem = pielegniarka;

            monthCalendar1.MonthlyBoldedDates = pielegniarka.Dyzury.ToArray();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox2.SelectedItem = null;
                lekarz = listBox1.SelectedItem as Lekarz;
                monthCalendar1.MonthlyBoldedDates = lekarz.Dyzury.ToArray();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox1.SelectedItem = null;
                pielegniarka = listBox2.SelectedItem as Pielegniarka;
                monthCalendar1.MonthlyBoldedDates = pielegniarka.Dyzury.ToArray();
            }
        }

        private void Wroc_Click(object sender, EventArgs e)
        {
            form1.Visible = true;
            Close();
        }

        private void Zamknij_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
