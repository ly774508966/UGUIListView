using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ListView:AbsListView
{
	public MonoBehaviour behaviour;
	public ListView (MonoBehaviour behaviour) : base (behaviour)
	{
		this.behaviour = behaviour;

	}
	



	public  void SetAdapter (BaseAdapter adapter)
	{
		base.SetAdapter (adapter);
		for (int i = 0; i < adapter.getCount (); i++) {
			GameObject convertView=	adapter.getView (i, content,this);
			Button btn=	convertView.AddComponent<Button> ();

			EventHandler eventHandler=convertView.AddComponent<EventHandler> ();

			eventHandler.longclick = delegate(GameObject item) {

				longclick(convertView);
			};

			btn.onClick.AddListener (() => {
				if(eventHandler.isLongPress){
					return;
				}
				click(convertView);
				ResetContentHeight(gridLayoutGroup.cellSize.y);

			});
		}
		ResetContentHeight (gridLayoutGroup.cellSize.y);
		ScrollToZeroPoint ();
	}

}
