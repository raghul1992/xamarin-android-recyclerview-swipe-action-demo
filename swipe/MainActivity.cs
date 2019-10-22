using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Support.V7.Widget.Helper;

namespace swipe
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity , RVItemTouchHelperListener
    {

        List<string> mylist = new List<string>(new string[] { "raul", "thirumal", "abishek" , "vishal","sai","ponvel","subbu","marudhu","gaurav"});


        RecyclerView rv;

        recyclarAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
                   SetContentView(Resource.Layout.activity_main);

            rv = FindViewById<RecyclerView>(Resource.Id.rv);
             adapter = new recyclarAdapter(mylist,this);
            LinearLayoutManager layoutManager = new LinearLayoutManager(this);
            rv.SetLayoutManager(layoutManager);
            rv.SetItemAnimator(new DefaultItemAnimator());
            rv.AddItemDecoration(new DividerItemDecoration(this, DividerItemDecoration.Vertical));
            rv.SetAdapter(adapter);

            ItemTouchHelper.SimpleCallback callback = new RVItemTouchHelper(0, ItemTouchHelper.Left, this);
            ItemTouchHelper.SimpleCallback callback_right = new RVItemTouchHelper(0, ItemTouchHelper.Right, this);
            new ItemTouchHelper(callback).AttachToRecyclerView(rv);
            new ItemTouchHelper(callback_right).AttachToRecyclerView(rv);




        }

        public void onSwiped(RecyclerView.ViewHolder viewHolder, int direction, int position)
        {


            if (direction == ItemTouchHelper.Left)
            {
                Toast.MakeText(this, "archive", ToastLength.Short).Show();

            }
            else {
                Toast.MakeText(this, "delete", ToastLength.Short).Show();
            }
            int index = viewHolder.AdapterPosition;
            adapter.removeItem(index);

        }
    }



}