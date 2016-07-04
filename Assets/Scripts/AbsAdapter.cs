using UnityEngine;
using System.Collections;
public interface IAdapter {

	int getCount();   

	/**
     * Get the data item associated with the specified position in the data set.
     * 
     * @param position Position of the item whose data we want within the adapter's 
     * data set.
     * @return The data at the specified position.
     */
	object getItem(int position);

	/**
     * Get the row id associated with the specified position in the list.
     * 
     * @param position The position of the item within the adapter's data set whose row id we want.
     * @return The id of the item at the specified position.
     */
	long getItemId(int position);


	/**
     * Get a View that displays the data at the specified position in the data set. You can either
     * create a View manually or inflate it from an XML layout file. When the View is inflated, the
     * parent View (GridView, ListView...) will apply default layout parameters unless you use
     * {@link android.view.LayoutInflater#inflate(int, android.view.ViewGroup, boolean)}
     * to specify a root view and to prevent attachment to the root.
     * 
     * @param position The position of the item within the adapter's data set of the item whose view
     *        we want.
     * @param convertView The old view to reuse, if possible. Note: You should check that this view
     *        is non-null and of an appropriate type before using. If it is not possible to convert
     *        this view to display the correct data, this method can create a new view.
     *        Heterogeneous lists can specify their number of view types, so that this View is
     *        always of the right type (see {@link #getViewTypeCount()} and
     *        {@link #getItemViewType(int)}).
     * @param parent The parent that this view will eventually be attached to
     * @return A View corresponding to the data at the specified position.
     */
	GameObject getView(int position, GameObject convertView,ListView listView);




	/**
      * @return true if this adapter doesn't contain any data.  This is used to determine
      * whether the empty view should be displayed.  A typical implementation will return
      * getCount() == 0 but since getCount() includes the headers and footers, specialized
      * adapters might want a different behavior.
      */
	bool isEmpty();
}

public abstract class AbsAdapter :IAdapter {


	public abstract int getCount ();

	public abstract object getItem (int position);

	public abstract long getItemId (int position);
	public GameObject getView (int position, GameObject convertView, ListView listView)
	{

		return null;
	}

	public abstract bool isEmpty ();
	
}