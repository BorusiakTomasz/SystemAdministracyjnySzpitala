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
    public partial class Form3 : Form
    {
        private Form1 form1;
        private Administrator administrator;

        public Form3(Form1 form1, Administrator administrator, List<Administrator> listaAdministratorow, List<Lekarz> listaLekarzy, List<Pielegniarka> listaPielegniarek)
        {
            InitializeComponent();

            this.form1 = form1;
            this.administrator = administrator;

            listBox1.DataSource = listaAdministratorow;
            listBox2.DataSource = listaLekarzy;
            listBox3.DataSource = listaPielegniarek;

            listBox1.SelectedItem = administrator;
            listBox2.ClearSelected();
            listBox3.ClearSelected();

            monthCalendar1.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox2.ClearSelected();
                listBox3.ClearSelected();
                monthCalendar1.RemoveAllBoldedDates();
                
                groupBox1.Enabled = false;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox1.ClearSelected();
                listBox3.ClearSelected();
                monthCalendar1.MonthlyBoldedDates = (listBox2.SelectedItem as Lekarz).Dyzury.ToArray();
                
                groupBox1.Enabled = true;
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem != null)
            {
                listBox1.ClearSelected();
                listBox2.ClearSelected();
                monthCalendar1.MonthlyBoldedDates = (listBox3.SelectedItem as Pielegniarka).Dyzury.ToArray();
                
                groupBox1.Enabled = true;
            }
        }

        private void DodajPracownika_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4(this);
            f.Show();
            Visible = false;
        }

        private void EdytujPracownika_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Form4 f = new Form4(this, listBox1.SelectedItem as Administrator);
                f.Show();
                Visible = false;
            }

            if (listBox2.SelectedItem != null)
            {
                Form4 f = new Form4(this, listBox2.SelectedItem as Lekarz);
                f.Show();
                Visible = false;
            }

            if (listBox3.SelectedItem != null)
            {
                Form4 f = new Form4(this, listBox3.SelectedItem as Pielegniarka);
                f.Show();
                Visible = false;
            }
        }

        private void UsunPracownika_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Administrator a = listBox1.SelectedItem as Administrator;
                Form1.UsunPracownika(a);
            }

            if (listBox2.SelectedItem != null)
            {
                Lekarz l = listBox2.SelectedItem as Lekarz;
                Form1.UsunPracownika(l);
            }

            if (listBox3.SelectedItem != null)
            {
                Pielegniarka p = listBox3.SelectedItem as Pielegniarka;
                Form1.UsunPracownika(p);
            }
        }

        private void DodajDyzur_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                DodajDyzurLekarzowi();
            }

            if (listBox3.SelectedItem != null)
            {
                DodajDyzurPielegniarce();
            }
        }

        private void DodajDyzurLekarzowi()
        {
            Lekarz l = listBox2.SelectedItem as Lekarz;
            List<Lekarz> lekarzeMajacyDyzur = ListaLekarzyMajacychDyzurTegoDnia(dateTimePicker1.Value);
            bool isEqual = false;

            foreach (Lekarz lekarz in lekarzeMajacyDyzur)
            {
                if (l.Specializacja.Equals(lekarz.Specializacja))
                {
                    isEqual = true;
                    break;
                }
            }

            if (isEqual)
            {
                MessageBox.Show("Tego dnia {0} ma juz dyzur.", l.Specializacja.ToString());
            }
            else
            {
                if (CzyMogeWziascDyzur(l))
                {
                    l.Dyzury.Add(dateTimePicker1.Value);
                    monthCalendar1.AddBoldedDate(dateTimePicker1.Value);
                }
            }
        }

        private void DodajDyzurPielegniarce()
        {
            Pielegniarka p = listBox3.SelectedItem as Pielegniarka;

            if (CzyMogeWziascDyzur(p))
            {
                p.Dyzury.Add(dateTimePicker1.Value);
                monthCalendar1.AddBoldedDate(dateTimePicker1.Value);
            }
            else
            {
                MessageBox.Show("Posiada już 10 dyzurów");
            }
        }

        private bool CzyMogeWziascDyzur<T>(T pracownik)
        {
            DateTime data = monthCalendar1.TodayDate;
            int counter = 0;
            
            if (pracownik is Lekarz)
            {
                Lekarz l = pracownik as Lekarz;
                foreach (DateTime element in l.Dyzury)
                {
                    if (data.Month.Equals(element.Month) && data.Year.Equals(element.Year))
                    {
                        counter++;
                    }
                }
            }

            if (pracownik is Pielegniarka)
            {
                Pielegniarka p = pracownik as Pielegniarka;

                foreach (DateTime element in p.Dyzury)
                {
                    if (data.Month.Equals(element.Month) && data.Year.Equals(element.Year))
                    {
                        counter++;
                    }
                }
            }
            
            if (counter < 10) return true;
            return false;
        }

        private List<Lekarz> ListaLekarzyMajacychDyzurTegoDnia(DateTime dzisiaj)
        {
            List<Lekarz> result = null;

            foreach (Lekarz lekarz in listBox2.DataSource as List<Lekarz>)
            {
                foreach (DateTime data in lekarz.Dyzury)
                {
                    if (dzisiaj.ToShortDateString().Equals(data.ToShortDateString()))
                    {
                        result.Add(lekarz);
                    }
                }
            }

            return result;
        }

        private void UsunDyzor_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                Lekarz l = listBox2.SelectedItem as Lekarz;
                l.Dyzury.Remove(dateTimePicker1.Value);
                monthCalendar1.RemoveBoldedDate(dateTimePicker1.Value);
            }

            if (listBox3.SelectedItem != null)
            {
                Pielegniarka p = listBox3.SelectedItem as Pielegniarka;
                p.Dyzury.Remove(dateTimePicker1.Value);
                monthCalendar1.RemoveBoldedDate(dateTimePicker1.Value);
            }
        }

        private void Wroc_Click(object sender, EventArgs e)
        {
            form1.Visible = true;
            Close();
        }
    }
}
