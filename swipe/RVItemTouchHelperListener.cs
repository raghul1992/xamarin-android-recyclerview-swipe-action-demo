using Android.Support.V7.Widget;

namespace swipe
{
    interface RVItemTouchHelperListener
    {

        void onSwiped(RecyclerView.ViewHolder viewHolder, int direction, int position);
    }
}