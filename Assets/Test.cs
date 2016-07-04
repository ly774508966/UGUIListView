using UnityEngine;
using System.Collections;

public class Test:MonoBehaviour
{

	void Start ()
	{
	
		ListView lv =	new ListView (this);

		ArrayList arr =	new ArrayList ();
		for (int i = 0; i < 100; i++) {
		
			arr.Add (i+"项");
		}

		lv.SetAdapter (new BaseAdapter (arr));

		lv.SetOnClickListener (delegate(GameObject item) {

			Destroy(item);

			Debug.Log(":"+item.name);
		});
		lv.SetOnLongClickListener (delegate(GameObject item) {
		

			Debug.Log ("长按"+item.name);
		});

	}
}
