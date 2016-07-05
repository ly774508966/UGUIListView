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

		GameObject tagbtn =	new GameObject (position + "").AddComponent<Image> ().gameObject;

		Image timage = tagbtn.GetComponent<Image> ();

		Button tbtn = tagbtn.AddComponent<Button> ();
		timage.color = Color.blue;

		tbtn.onClick.AddListener (delegate() {
		
			timage.enabled = false;
		});

		tagbtn.transform.parent = item.transform;

		RectTransform rt=(RectTransform)tagbtn.transform;

		rt.anchorMin = new Vector2 (1, rt.anchorMin.y);

		rt.anchorMax = new Vector2 (1, rt.anchorMax.y);
		rt.anchoredPosition3D = new Vector3 (-rt.sizeDelta.x / 2, 0, 0);
		rt.name="tagbtn";
		timage.enabled = false;



		item.transform.parent =	convertView.transform;
		text.transform.localPosition = new Vector3 (item.transform.localPosition.x+((RectTransform)text.transform).sizeDelta.x/2,0, 0);

		return item;
	}



	public override bool isEmpty ()
	{

		return null == data || data.Count == 0;

	}



}
