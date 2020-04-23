using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Sheet_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        DataSet result, result2;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            cboSheet.Items.Clear();
            
            const string type = "Excel Workbook|*.xlsx; *.xls; *.xlt; *.xlm; *.xlsm; *.xltx; *.xltm; *.xlsb; *.xla; *.xlam; *.xll; *.xlw";
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = type, ValidateNames = true })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs);
                    result = reader.AsDataSet();
                    fs.Close();
                    foreach(DataTable dt in result.Tables)
                    {
                        cboSheet.Items.Add(dt.TableName);
                    }
                    cboSheet.SelectedIndex = 0;
                    reader.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = result.Tables[cboSheet.SelectedIndex];
        }

        private void opnBtn2_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
            cboSheet2.Items.Clear();
            
            const string type = "Excel Workbook|*.xlsx; *.xls; *.xlt; *.xlm; *.xlsm; *.xltx; *.xltm; *.xlsb; *.xla; *.xlam; *.xll; *.xlw";
            using (OpenFileDialog ofd2 = new OpenFileDialog() { Filter = type, ValidateNames = true })
            {
                if (ofd2.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs2 = File.Open(ofd2.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    IExcelDataReader reader2 = ExcelReaderFactory.CreateReader(fs2);
                    result2 = reader2.AsDataSet();
                    fs2.Close();
                    foreach (DataTable dt in result2.Tables)
                    {
                        cboSheet2.Items.Add(dt.TableName);
                    }
                    cboSheet2.SelectedIndex = 0;
                    reader2.Close();
                }
            }
        }

        private void cboSheet2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = result2.Tables[cboSheet2.SelectedIndex];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
