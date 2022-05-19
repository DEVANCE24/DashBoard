using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomAppBar;
using Google.Android.Material.BottomNavigation;
using static Google.Android.Material.BottomNavigation.BottomNavigationView;

namespace DashBoard
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme",MainLauncher =true)]
    public class MainActivity : AppCompatActivity, IOnNavigationItemSelectedListener
    {      
        private Dashboard _dashboard;
        private Favourite _favourite;
        private Location _location;
        private Profile _profile;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.tablayout);
           

            BottomAppBar _bottomAppBar = FindViewById<BottomAppBar>(Resource.Id.bottomAppBar);
            BottomNavigationView _bottomNavigationView = FindViewById<BottomNavigationView>(Resource.Id.bottomNavigationView);
            _bottomNavigationView.SetOnNavigationItemSelectedListener(this);

            _dashboard = new Dashboard();
            _favourite = new Favourite();
            _location = new Location();
            _profile = new Profile();
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, _dashboard).Commit();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {   
             switch (item.ItemId)
            {
                case Resource.Id.home:
                   SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, _dashboard).Commit();

                  return true;

                case Resource.Id.favourite:
                 SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, _favourite).Commit();
                 return true;

                case Resource.Id.location:
                   SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, _location).Commit();
                    return true;

               case Resource.Id.profile:
                   SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, _profile).Commit();
                    return true;
            }
            return false;
        }
    }
}