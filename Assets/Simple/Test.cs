using UnityEngine;
using System.Collections;

public class Test:MonoBehaviour
{

	void Start ()
	{
	
		ListView lv =	new ListView (this);

		ArrayList arr =	new ArrayList ();
		for (int i = 0; i < 100; i++) {
		
			arr.Add (i+"个人头tr");
		}

		lv.SetAdapter (new BaseAdapter (arr));

		lv.SetOnClickListener (delegate(GameObject item) {

			Destroy(item);

			Debug.Log(":"+item.name);
		});
		lv.SetOnLongClickListener (delegate(GameObject item) {
		
			Transform[] t=	item.GetComponentsInChildren<Transform>();


			for(int i=0;i<t.Length;i++){

				Debug.Log("i:"+t[i].name);

				if(t[i].name.Equals("tagbtn")){
					t[i].GetComponent<UnityEngine.UI.Image>().enabled=true;

		
					t[i].gameObject.SetActive(true);


					return;
				}

			}

			Debug.Log ("长按"+item.name);
		});

	}
}
