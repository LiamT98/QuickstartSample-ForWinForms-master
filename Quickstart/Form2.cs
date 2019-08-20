using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThinkGeo.MapSuite;
using ThinkGeo.MapSuite.Drawing;
using ThinkGeo.MapSuite.Layers;
using ThinkGeo.MapSuite.Shapes;
using ThinkGeo.MapSuite.Styles;
using ThinkGeo.MapSuite.WinForms;

namespace Quickstart
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //ShapeFile path name
            String path = @"..\..\Data\Countries02.shp";

            //World map colour
            GeoColor mapcol;
            mapcol = new GeoColor(255,130,200,100);

            //Border colour
            GeoColor borderLineCol;
            borderLineCol = new GeoColor(255,118,138,69);



            //Set the unit to be used for the map element. This must be set!
            winformsMap1.MapUnit = GeographyUnit.DecimalDegree;

            //Creates a new layer referencing a shapefile which is a parameter accepted in its constructor
            ShapeFileFeatureLayer worldLayer = new ShapeFileFeatureLayer(path);
            //A style instance to style the appearence of the shapefile
            AreaStyle areaStyle = new AreaStyle();
            //Area style accepts GeoSolidBrush in one of its constructors
            //GeoSolidBrush accepts GeoColor
            //GeoColor accepts a range of signatures one being 4 integer values
            //1:Alpha 2:red 3:green 4:blue
            areaStyle.FillSolidBrush = new GeoSolidBrush(mapcol);
            //Another accepted signature is GeoPen
            //GeoPen then accepts Geocolor and a Single data type value representing the width of the line
            areaStyle.OutlinePen = new GeoPen(borderLineCol, 2);
            areaStyle.OutlinePen.DashStyle = LineDashStyle.Solid;

            //Set the worldLayer with a preset style
            worldLayer.ZoomLevelSet.ZoomLevel01.DefaultAreaStyle = areaStyle;
            //The line below applies the style define above to all default zoom levels (1 through 20)
            worldLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            //We now have all the require elements to store the layer in a Layer Overlay object
            //Create a new Layer Overlay object to store the layer defined above
            LayerOverlay layer1;
            layer1 = new LayerOverlay();

            //Add the shapefile referenced above
            layer1.Layers.Add(worldLayer);

            //Add the layer overlay to the map
            //This is our first layer
            winformsMap1.Overlays.Add(layer1);

            //Set a proper extent for the map
            //From this a scale is generated
            winformsMap1.CurrentExtent = new RectangleShape(-134,70,-56,7);

            //The Refresh() method in the winformsMap object needs to be called to
            //redraw the map based on the data define above
            winformsMap1.Refresh();




        }
    }
}
