using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using Android.Views;
using Android.Widget;

namespace swipe
{
    class RVItemTouchHelper : ItemTouchHelper.SimpleCallback
    {
        private float previousDx = 0;


        private RVItemTouchHelperListener _listener;

        public RVItemTouchHelper(int dragDirs, int swipeDirs, RVItemTouchHelperListener listener) : base(dragDirs, swipeDirs)
        {

            _listener = listener;
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            return false;
        
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {

            if (_listener != null) {
                _listener.onSwiped(viewHolder,direction,viewHolder.AdapterPosition);
            }
            previousDx = 0;

        }


        public override void ClearView(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
            View fg = ((recyclarAdapter.ViewHolder)viewHolder).fg;
            DefaultUIUtil.ClearView(fg);  
        }

        public override void OnSelectedChanged(RecyclerView.ViewHolder viewHolder, int actionState)
        {
            if (viewHolder != null) {
                View fg = ((recyclarAdapter.ViewHolder)viewHolder).fg;
                DefaultUIUtil.OnSelected(fg);
            }
        }
        public override int ConvertToAbsoluteDirection(int flags, int layoutDirection)
        {
            return base.ConvertToAbsoluteDirection(flags, layoutDirection);
        }
        public override void OnChildDraw(Canvas c, RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState, bool isCurrentlyActive)
        {


            View fg = ((recyclarAdapter.ViewHolder)viewHolder).fg;

            if (dX > 0)
                {
                    ((recyclarAdapter.ViewHolder)viewHolder).bg.Visibility= ViewStates.Visible;
                ((recyclarAdapter.ViewHolder)viewHolder).bg_left.Visibility = ViewStates.Gone; 
                }
                else
            {
                ((recyclarAdapter.ViewHolder)viewHolder).bg.Visibility = ViewStates.Gone;
                ((recyclarAdapter.ViewHolder)viewHolder).bg_left.Visibility = ViewStates.Visible;
            }
             




            DefaultUIUtil.OnDraw(c, recyclerView, fg, dX, dY, actionState, isCurrentlyActive);

            previousDx = dX;


        }

        public override void OnChildDrawOver(Canvas c, RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState, bool isCurrentlyActive)
        {
            View fg = ((recyclarAdapter.ViewHolder)viewHolder).fg;
            DefaultUIUtil.OnDrawOver(c, recyclerView, fg, dX, dY, actionState, isCurrentlyActive);
        }




    }
}