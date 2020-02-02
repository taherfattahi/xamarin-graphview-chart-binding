using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Jjoe64.Graphview;
using Com.Jjoe64.Graphview.Series;

namespace XamarinGaphViewChartBinding.Droid.Activities
{
    [Activity(Label = "GraphViewActivity")]
    public class GraphViewActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GraphViewLayout);

            ActionBar.Hide();

            //.RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;
            this.RequestedOrientation = ScreenOrientation.SensorLandscape;

            GraphView graph = FindViewById<GraphView>(Resource.Id.graph);


            // first series is a line
            DataPoint[] points = new DataPoint[100];
            Random rand = new Random();

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new DataPoint(i, Math.Sin(i * 0.5) * 20 * (rand.NextDouble() * 10 + 1));
            }

            LineGraphSeries series = new LineGraphSeries(points);

            //series.Color = Resource.Color.colorPrimary;
            //series.Color = Resource.Color.testColor;

            DataPoint[] points1 = new DataPoint[200];
            Random rand1 = new Random();

            for (int i = 0; i < points1.Length; i++)
            {
                points1[i] = new DataPoint(i, Math.Sin(i * 0.5) * 10 * (rand1.NextDouble() * 2 + 1));
            }

            LineGraphSeries series1 = new LineGraphSeries(points1);

            series1.Color = Resource.Color.launcher_background;

            //graph.Viewport.BackgroundColor = Resource.Color.abc_background_cache_hint_selector_material_dark;

            // set manual X
            graph.Viewport.YAxisBoundsManual = true;
            graph.Viewport.SetMinY(-150);
            graph.Viewport.SetMaxY(150);

            graph.Viewport.XAxisBoundsManual = true;
            graph.Viewport.SetMinX(4);
            graph.Viewport.SetMaxX(80);

            // enable scaling
            graph.Viewport.Scalable = true;
            graph.Viewport.SetScalableY(true);


            series.Title = "Random Curve";
            //series.setTitle("Random Curve 1");
            series.Color = unchecked((int)0xFF00FF00);
            series.DrawDataPoints = true;
            //series.DataPointsRadius = 10;
            //series.setDrawDataPoints(true);
            //series.setDataPointsRadius(10);
            //series.setThickness(8);

            series1.Title = "Random1 Curve";
            series1.Color = unchecked((int)0xFFFF0000);
            series1.DrawDataPoints = true;


            graph.AddSeries(series);
            graph.AddSeries(series1);


            graph.LegendRenderer.Visible = true;
            graph.LegendRenderer.Align = LegendRenderer.LegendAlign.Top;

        }
    }
}
