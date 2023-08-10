using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace SAMPRO__SANTIAGO_MINES_PROJECT_
{
    public partial class MAPA : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        DataTable dt;
        int filaseleccionada = 0;
        double Latinicial = 19.560350855918234;
        double Longinicial = -70.82065137703945;
        public MAPA()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng (Latinicial,Longinicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 50;
            gMapControl1.Zoom = 20;
            gMapControl1.AutoScroll = true; 
        }
    }
}
