using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class BaseAdapter : AbsAdapter
{

	private ArrayList data;

	public BaseAdapter (ArrayList data)
	{
	
		this.data = data;
	}

	public override int getCount ()
	{
		return	data.Count;
	}

	public override object getItem (int position)
	{

		return data [position];

	}

	public override long getItemId (int position)
	{
		return position;

	}

	public GameObject getView (int position, GameObject convertView,ListView listView)
	{
		base.getView (position,  convertView,listView);

		GameObject item =	new GameObject (position + "").AddComponent<Image> ().gameObject;
		GameObject text = new GameObject (position + "");
					Text t=	text.AddComponent<Text> ();
					try {
						t.font = Resources.FindObjectsOfTypeAll<Font> () [0];
					} catch (System.Exception ex) {
						
					}
					t.color = Color.black;
		t.text = data[position].ToString();
					text.transform.parent = item.transform;
		item.transform.parent =	convertView.transform;
		text.transform.localPosition = new Vector3 (item.transform.localPosition.x+((RectTransform)text.transform).sizeDelta.x/2,0, 0);

		return item;
	}



	public override bool isEmpty ()
	{

		return null == data || data.Count == 0;

	}



}
