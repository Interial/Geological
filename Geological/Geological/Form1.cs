using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET;

using GMap.NET.WindowsForms.Markers;


namespace Geological
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleHybridMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl1.SetPositionByKeywords("Paris, France");

            gMapControl1.ShowCenter = false;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.AutoScroll = true;

            GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
           // GMap.NET.WindowsForms.GMapMarker marker =
            //    new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
              //      new GMap.NET.PointLatLng(48.8617774, 2.349272),
                //    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin);
          //  markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);



            GMap.NET.WindowsForms.GMapOverlay polygons = new GMap.NET.WindowsForms.GMapOverlay("polygons");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(48.866383, 2.323575));
            points.Add(new PointLatLng(48.863868, 2.321554));
            points.Add(new PointLatLng(48.861017, 2.330030));
            points.Add(new PointLatLng(48.863727, 2.331918));
            GMap.NET.WindowsForms.GMapPolygon polygon = new GMap.NET.WindowsForms.GMapPolygon(points, "Jardin des Tuileries");
            polygons.Polygons.Add(polygon);
            gMapControl1.Overlays.Add(polygons);
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon.Stroke = new Pen(Color.Red, 1);
        }
    }
}
