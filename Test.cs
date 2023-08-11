using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Data.SQLite;
using System.Net;
using GMap.NET.MapProviders;
using GMap.NET;
using System.Device.Location;
namespace SAMPRO__SANTIAGO_MINES_PROJECT_
{
    public partial class Test : Form
    {
        string dbURL = "";
        string PathDB = @"C:\Temp\Minas.db";
        string tableName = "FST";
        double lat0 = 0;
        double lon0 = 0;
        double lat = 19.453720;
        double lon = -70.699986;
        
        DataTable dataTable=new DataTable();
        CDatabase dataBase=new CDatabase();
        private GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            //watcher.TryStart(false, TimeSpan.FromMilliseconds(5000.0));
            //GeoCoordinate location = watcher.Position.Location;
            //webBrowser1.ScriptErrorsSuppressed = true;
            dataBase = new CDatabase(PathDB);
            if (!Directory.Exists(@"C:\Temp"))
            {
                Directory.CreateDirectory(@"C:\Temp");
            }
            if (File.Exists(PathDB))
            {
                //if (true)
                //{
                //    File.Delete(PathDB);
                //}
                
            }
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");
            client.Headers.Add("method", "POST");
            client.Headers.Add("cookie", "{cookie}");
            try
            {
                client.DownloadFile(dbURL, @"C:\Temp\Minas.db");
            }
            catch (Exception)
            {
                MessageBox.Show("Ha Ocurrido un error al descargar la base de datos");
            }
            
            if (File.Exists(PathDB))
            {
                dataTable = dataBase.Select($"SELECT * FROM {tableName}");
            }
            if (dataTable.Rows.Count>0)
            {
                dataGridView1.DataSource = dataTable;
            }
            if (dataGridView1.Columns.Count>0)
            {
                foreach (DataGridViewColumn dc in dataGridView1.Columns)
                {
                    if (dc.Name != "Nombre")
                    {
                        dc.Visible = false;
                    }
                    else
                    {
                        dc.AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            watcher.TryStart(false, TimeSpan.FromMilliseconds(5000.0));
            GeoCoordinate location = watcher.Position.Location;
            label1.Text = $"Su ubicación es:{location.Latitude},{location.Longitude}";
            lat0 = location.Latitude;
            lon0= location.Longitude;
            //lat = location.Latitude;
            //lon = location.Longitude;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(lat0, lon0);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 50;
            gMapControl1.Zoom = 20;
            gMapControl1.AutoScroll = true;
            label2.Text = gMapControl1.Position.ToString();
        }
        private void filt()
        {
            DataView dv = dataTable.DefaultView;

            string query = "";
            string x1 = " '%";
            string x2 = "%'";
           
            if (txtFilter.Text.Length == 0)
            {
                foreach (DataColumn DTC in dataTable.Columns)
                {

                    if (DTC == dataTable.Columns[dataTable.Columns.Count - 1])
                    {
                        query += DTC.ColumnName + " " + "LIKE" + x1 + txtFilter.Text + x2;
                    }
                    else
                    {
                        query += DTC.ColumnName + " " + "LIKE" + x1 + txtFilter.Text + x2 + "  or ";
                    }

                }
            }
            dv.RowFilter = query;
            
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            filt();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value!=null)
            {

                if (dataGridView1.CurrentRow.Cells[0].Value.ToString().Length>0)
                {
                    
                    dataGridView2.Rows.Clear();
                    dataGridView2.Columns.Clear();
                    dataGridView2.Columns.Add("CPropiedad", "Propiedad");
                    dataGridView2.Columns.Add("CValor", "Valor");
                    dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    foreach (DataGridViewColumn dataGridViewColumn in dataGridView1.Columns)
                    {
                        dataGridView2.Rows.Add(dataGridViewColumn.Name, dataGridView1.CurrentRow.Cells[dataGridViewColumn.Index].Value);
                        if (dataGridViewColumn.Name=="Latitud")
                        {
                            if (double.TryParse(dataGridView1.CurrentRow.Cells[dataGridViewColumn.Index].Value.ToString(),out double d))
                            {
                                lat = d;
                            }
                        }
                        else if (dataGridViewColumn.Name == "Longitud")
                        {
                            if (double.TryParse(dataGridView1.CurrentRow.Cells[dataGridViewColumn.Index].Value.ToString(), out double d))
                            {
                                lon = d;
                            }
                        }
                    }
                    if (lat!=0&&lon!=0)
                    {
                        tabControl1.SelectedTab = tabPage2;
                        gMCMina.DragButton = MouseButtons.Left;
                        gMCMina.CanDragMap = false;
                        gMCMina.MapProvider = GMapProviders.GoogleMap;
                        gMCMina.Position = new PointLatLng(lat, lon);
                        gMCMina.MinZoom = 0;
                        gMCMina.MaxZoom = 50;
                        gMCMina.Zoom = 20;
                        gMCMina.AutoScroll = true;
                    }
                }
            }
        }

        private void btnComoLlegar_Click(object sender, EventArgs e)
        {
            if (false)
            {
                //webBrowser1.Navigate(new Uri($"https://www.google.com/maps/dir/'{lat0},{lon0}'/'{lat},{lon}'"));
            }
            else
            {
                System.Diagnostics.Process.Start($"https://www.google.com/maps/dir/'{lat0},{lon0}'/'{lat},{lon}'");
            }
            
        }

        private void gMapControl1_OnMapDrag()
        {
            label2.Text=gMapControl1.Position.ToString();
            comboBox1.Text = "Personalizada";
        }
    }
    class CDatabase
    {
        //Local Database
        static SQLiteConnection conn;
        static SQLiteDataReader dr;
        static SQLiteCommand cmd;
        static System.Data.DataTable dt;
        public string DataSource = (@"C:\Temp\Minas.db");


        public CDatabase(string dataSource)
        {
            DataSource = dataSource;
        }

        public CDatabase()
        {
        }


        //Functions Local Database
        public void Connect()
        {
            try
            {
                string Coneccion = ("Data Source = " + DataSource);
                conn = new SQLiteConnection(Coneccion);
                conn.Open();
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Error al conectar con la base de datos= " + Ex.ToString());
            }
        }

        public void Save(string commd)
        {
            Connect();

            cmd = new SQLiteCommand(commd, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }


        public void eliminar(string commd)
        {
            Connect();

            cmd = new SQLiteCommand(commd, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }


        public void Update(string commd)
        {
            Connect();

            cmd = new SQLiteCommand(commd, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

        }

        public System.Data.DataTable Select(string commd)
        {
            Connect();

            cmd = new SQLiteCommand(commd, conn);
            dr = cmd.ExecuteReader();

            dt = new System.Data.DataTable();

            dt.Load(dr);

            conn.Close();

            return dt;
        }

        public Boolean Existe(string commd)
        {
            try
            {
                int q = 0;
                Connect();
                cmd = new SQLiteCommand(commd, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    q++;
                }

                if (q == 0)
                    return false;
                else
                    return true;
            }

            catch (Exception Ex)
            {
                
                return false;
            }

            finally
            {
                conn.Close();
            }
        }
    }
}
