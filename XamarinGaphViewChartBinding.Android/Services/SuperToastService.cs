using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using DependencyServiceDemos.Droid;
using XamarinGaphViewChartBinding.Services;
using Xamarin.Forms;
using XamarinGaphViewChartBinding.Droid.Activities;
using XamarinGaphViewChartBinding.Droid;

[assembly: Dependency(typeof(SuperToastService))]
namespace DependencyServiceDemos.Droid
{
    public class SuperToastService : ISuperToastsService
    {

        public void ShowSuperToast()
        {

            var context = MainActivity.Instance;

            Intent myIntent = new Intent(context, typeof(GraphViewActivity));
            //myIntent.PutExtra("greeting", "Hello from the Second Activity!");
            myIntent.AddFlags(ActivityFlags.ReorderToFront);
            //context.SetResult(Result.Ok, myIntent);
            //context.Finish();
            context.StartActivity(myIntent);

        }
    }
}
