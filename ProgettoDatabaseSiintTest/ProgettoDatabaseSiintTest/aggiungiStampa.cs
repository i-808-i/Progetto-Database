using Libreria.AccessoDati;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoDatabaseSiintTest
{
    public partial class aggiungiStampa : Form
    {
        string connection = "Provider=SQLOLEDB.1;Password=sa;Persist Security Info=True;User ID=sa;Initial Catalog=SiintTest";
        DataConnection dc = new DataConnection();

        public aggiungiStampa()
        {
            InitializeComponent();
        }

        private void btn_AddStampa_Click(object sender, EventArgs e)
        {
            string str = null;
            int sql = 0;

            try
            {
                using (OleDbConnection cn = dc.Connect(connection))
                {
                    OleDbDataReader data = dc.ExecuteReader("SELECT TOP(1) scIdStampa FROM StampeCustom ORDER BY scIdStampa DESC", cn);
                    if (data.Read())
                    {
                        str = data.GetValue(0).ToString();
                        sql = Int32.Parse(str) + 1;
                    }

                    dc.Execute("INSERT INTO StampeCustom(scIdStampa, scNome, scDescrizione, scModello, scToExcelPrinter, scToExcelWindow, scToExcelFile, scToZedPrinter, scToObjPrinter, scToCsvFile, scToWordPrinter, scToWordWindow, scToWordFile, scToObjWindow) VALUES ('" + sql + "','" + txt_nome.Text + "','" + txt_desc.Text + "','" + txt_mod.Text + "','" + (short)chk_ExcPrint.CheckState + "','" + (short)chk_ExcWindow.CheckState + "','" + (short)chk_ExcFile.CheckState + "','" + (short)chk_ZedPrint.CheckState + "','" + (short)chk_ObjPrint.CheckState + "','" + (short)chk_CsvFile.CheckState + "','" + (short)chk_WordPrint.CheckState + "','" + (short)chk_WordWind.CheckState + "','" + (short)chk_WordFile.CheckState + "','" + (short)chk_ObjWind.CheckState + "')", cn);

                    dc.Disconnect(cn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            
            
        }
    }
}
