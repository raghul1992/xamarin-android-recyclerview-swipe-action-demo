using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

using System.Collections.Generic;

namespace swipe
{
    public class recyclarAdapter : RecyclerView.Adapter
    {
        private List<string> _myList;
        Context _context;
        public recyclarAdapter(List<string> myList, Context context)
        {
            _myList = myList;
            _context = context;
        }

        public void removeItem( int index) {
            _myList.RemoveAt(index);
            NotifyItemRemoved(index);
        }

        public override  void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ViewHolder v = holder as ViewHolder;
            v.tv.Text = _myList[position];
            
        }

        public void OnClick(View v)
        {
            int position = (int)v.Tag;
         
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View v = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item, parent, false);
            ViewHolder holder = new ViewHolder(v);
            return holder;
        }

        internal class ViewHolder : RecyclerView.ViewHolder
        {
            public TextView tv;
            public RelativeLayout bg,fg;

            public ViewHolder(View itemView) : base(itemView)
            {
                tv = itemView.FindViewById<TextView>(Resource.Id.tv);
                bg = itemView.FindViewById<RelativeLayout>(Resource.Id.bg);
                fg = itemView.FindViewById<RelativeLayout>(Resource.Id.fg);

            }
        }

        public override int ItemCount
        {
            get
            {
                return _myList != null ? _myList.Count : 0;
            }
        }        
    }
}