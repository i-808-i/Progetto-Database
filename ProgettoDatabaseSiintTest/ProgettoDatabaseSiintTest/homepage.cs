using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libreria.AccessoDati;

namespace ProgettoDatabaseSiintTest
{
    public partial class homepage : Form
    {
        List<CheckBoxListItem> list = new List<CheckBoxListItem>();
        string connection = "Provider=SQLOLEDB.1;Password=sa;Persist Security Info=True;User ID=sa;Initial Catalog=SiintTest";
        DataConnection dc = new DataConnection();
        public homepage()
        {
            InitializeComponent();
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            aggiungiStampa agg = new aggiungiStampa();
            agg.Show();
        }

        private void btn_aggiorna_Click(object sender, EventArgs e)
        {
            list_stampe.DisplayMember = "scNome";
            list_stampe.Items.Clear();
            string select = "SELECT scIdStampa, scNome FROM StampeCustom";

            try
            {
                using (OleDbConnection cn = dc.Connect(connection))
                {

                    DataTable dt = dc.Select(select, cn);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        list_stampe.Items.Add(new ListBoxItem(RowUtilities.FieldInt32(dt.Rows[i], "scIdStampa"), RowUtilities.FieldString(dt.Rows[i], "scNome")));
                    }

                    dc.Disconnect(cn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }
        }

        private void homepage_Load(object sender, EventArgs e)
        {
            cmb_GrpUtente.DisplayMember = "agDescr";

            try
            {
                using (OleDbConnection cn = dc.Connect(connection))
                {
                    DataTable dt = dc.Select("SELECT scIdStampa, scNome FROM StampeCustom", cn);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        list_stampe.Items.Add(new ListBoxItem(RowUtilities.FieldInt32(dt.Rows[i], "scIdStampa"), RowUtilities.FieldString(dt.Rows[i], "scNome")));
                    }

                    DataTable dt2 = dc.Select("SELECT agDescr FROM AnaGruppiUtente", cn);
                    cmb_GrpUtente.DataSource = dt2;

                   DataTable dt3 = dc.Select("SELECT amIdAmbiente, amNome FROM AnaAmbienti", cn);

                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        chkList_Ambienti.Items.Add(new CheckBoxListItem(RowUtilities.FieldInt32(dt3.Rows[i], "amIdAmbiente"), RowUtilities.FieldString(dt3.Rows[i], "amNome")));
                    }

                    dc.Disconnect(cn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }
        }

        private void btn_salva_Click(object sender, EventArgs e)
        {
            int i = 0;
            string utente = cmb_GrpUtente.GetItemText(cmb_GrpUtente.SelectedItem).ToString();
            ListBoxItem Stampa = (ListBoxItem)list_stampe.SelectedItem;

            try
            {
                using (OleDbConnection cn = dc.Connect(connection))
                {
                    DataTable dt = dc.Select("SELECT agId, agDescr FROM AnaGruppiUtente", cn);
                    int ut = (from DataRow dr in dt.Rows where (string)dr["agDescr"] == utente select (int)dr["agId"]).FirstOrDefault();

                    dc.Execute("DELETE FROM StampePerGruppiUtenti WHERE suIdGruppoUtente = '" + ut + "' AND suIdStampa = '" + Stampa.scIdStampa + "'", cn);

                    if (chkList_Ambienti.CheckedItems.Count != 0)
                    {
                        list.Clear();
                        foreach (CheckBoxListItem item in chkList_Ambienti.CheckedItems)
                        {
                            list.Add(item);
                        }
                    }

                    while (i < list.Count)
                    {
                        CheckBoxListItem item = list[i];
                        dc.Execute("INSERT INTO StampePerGruppiUtenti(suIdGruppoUtente, suIdStampa, suIndStampa, suIdAmbiente, suShow) VALUES ('" + ut + "','" + Stampa.scIdStampa + "','" + 1 + "','" + item.amIdAmbiente + "','" + 1 + "')", cn);
                        i++;
                    }

                    dt.Dispose();
                    dc.Disconnect(cn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }
        }

        private void list_stampe_SelectedValueChanged(object sender, EventArgs e)
          {
            ShowCheckedItems();
          }

        private void cmb_GrpUtente_SelectedIndexChanged(object sender, EventArgs e)
         {
             ShowCheckedItems();
         }

        private void ShowCheckedItems()
        {
            string utente = cmb_GrpUtente.GetItemText(cmb_GrpUtente.SelectedItem).ToString();
            ListBoxItem Stampa = (ListBoxItem)list_stampe.SelectedItem;

            try
            {
                using (OleDbConnection cn = dc.Connect(connection))
                {
                    if (Stampa != null)
                    {
                        DataTable dt = dc.Select("SELECT agId, agDescr FROM AnaGruppiUtente", cn);
                        int ut = (from DataRow dr in dt.Rows where (string)dr["agDescr"] == utente select (int)dr["agId"]).FirstOrDefault();

                        DataTable dt2 = dc.Select("SELECT suIdAmbiente FROM StampePerGruppiUtenti WHERE suIdGruppoUtente = '" + ut + "' AND suIdStampa = '" + Stampa.scIdStampa + "'", cn);
                        
                        string[] idAmb = dt2.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();

                        for (int i = 0; i < chkList_Ambienti.Items.Count; i++)
                        {
                            chkList_Ambienti.SetItemChecked(i, false);
                        }

                        for (int i = 0; i < idAmb.Length; i++)
                        {
                            chkList_Ambienti.SetItemChecked(short.Parse(idAmb[i]) - 1, true);
                        }

                        Array.Clear(idAmb, 0, idAmb.Length);
                        dt.Dispose();
                        dt2.Dispose();
                        dc.Disconnect(cn);
                    }
                    else
                    {
                        dc.Disconnect(cn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    class ListBoxItem
        {
        public int scIdStampa;
        private string _scNome;
        public ListBoxItem(int scIdStampa, string scNome)
        {
            this.scIdStampa = scIdStampa;
            this._scNome = scNome;
        }

        public override string ToString()
        {
            return _scNome;
        }
    }

    class CheckBoxListItem
    {
        public int amIdAmbiente;
        private string _amNome;
        public CheckBoxListItem(int amIdAmbiente, string amNome)
        {
            this.amIdAmbiente = amIdAmbiente;
            this._amNome = amNome;
        }

        public override string ToString()
        {
            return _amNome;
        }
    }

}
