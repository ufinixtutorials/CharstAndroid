using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Microcharts.Droid;
using System.Collections.Generic;
using Microcharts;
using SkiaSharp;
using Android.Views;

namespace CharstAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        ChartView chartview;
        TextView chartoptionsText;
        ImageView sortImageView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            chartview = (ChartView)FindViewById(Resource.Id.chartView);
            chartoptionsText = (TextView)FindViewById(Resource.Id.chartOptionText);
            sortImageView = (ImageView)FindViewById(Resource.Id.sortdownImage);

            chartoptionsText.Click += ChartoptionsText_Click;
            sortImageView.Click += ChartoptionsText_Click;

            DrawChart("BarChart");
        }

        private void ChartoptionsText_Click(object sender, System.EventArgs e)
        {
            PopupMenu popupMenu = new PopupMenu(this, chartoptionsText);
            popupMenu.MenuItemClick += PopupMenu_MenuItemClick;
            popupMenu.Menu.Add(Menu.None, 1, 1, "PointChart");
            popupMenu.Menu.Add(Menu.None, 2, 2, "LineChart");
            popupMenu.Menu.Add(Menu.None, 3, 3, "DonutChart");
            popupMenu.Menu.Add(Menu.None, 4, 4, "BarChart");
            popupMenu.Menu.Add(Menu.None, 5, 5, "RadarChart");

            popupMenu.Show();
            
        }

        private void PopupMenu_MenuItemClick(object sender, PopupMenu.MenuItemClickEventArgs e)
        {
            string charttype = e.Item.TitleFormatted.ToString();
            DrawChart(charttype);
            chartoptionsText.Text = charttype;
        }

        void DrawChart(string charttype)
        {

            List<Entry> DataList = new List<Entry>();

            DataList.Add(new Entry(200)
            {
                Label = "January",
                ValueLabel = "200",
                Color = SKColor.Parse("#266489")
            }) ;

            DataList.Add(new Entry(300)
            {
                Label = "February",
                ValueLabel = "300",
                Color = SKColor.Parse("#0ccf40")
            });

            DataList.Add(new Entry(100)
            {
                Label = "March",
                ValueLabel = "100",
                Color = SKColor.Parse("#eb0e33")
            });

            DataList.Add(new Entry(400)
            {
                Label = "May",
                ValueLabel = "400",
                Color = SKColor.Parse("#1068eb")
            });

            DataList.Add(new Entry(300)
            {
                Label = "June",
                ValueLabel = "300",
                Color = SKColor.Parse("#10e7eb")
            });

            DataList.Add(new Entry(400)
            {
                Label = "July",
                ValueLabel = "400",
                Color = SKColor.Parse("#e3d320")
            });

            DataList.Add(new Entry(150)
            {
                Label = "August",
                ValueLabel = "150",
                Color = SKColor.Parse("#5430c9")
            });

            if( charttype == "PointChart")
            {
                var chart = new PointChart() { Entries = DataList, LabelTextSize = 30f };
                chartview.Chart = chart;
            }
            else if (charttype == "LineChart")
            {
                var chart = new LineChart() { Entries = DataList, LabelTextSize = 30f };
                chartview.Chart = chart;
            }
            else if (charttype == "DonutChart")
            {
                var chart = new DonutChart() { Entries = DataList, LabelTextSize = 30f };
                chartview.Chart = chart;
            }
            else if (charttype == "BarChart")
            {
                var chart = new BarChart() { Entries = DataList, LabelTextSize = 30f };
                chartview.Chart = chart;
            }
            else if (charttype == "RadarChart")
            {
                var chart = new RadarChart() { Entries = DataList, LabelTextSize = 30f };
                chartview.Chart = chart;
            }



        }

    }
}