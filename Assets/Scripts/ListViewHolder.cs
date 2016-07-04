using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ListViewHolder : MonoBehaviour {
	void Awake(){
	
		Text t=	gameObject.AddComponent<Text> ();
		t.font = FontData.defaultFontData.font;
		t.text="Test";
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
