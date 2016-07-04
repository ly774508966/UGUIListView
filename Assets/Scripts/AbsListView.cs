using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public delegate void OnItemClick (GameObject item);
public delegate void OnItemLongClick (GameObject item);
public enum ScrollDirection
{

	Horizontal,
Vertical,
Both

}

public interface IListView
{


	void SetScrollDirection (ScreenOrientation Orientation);

	/// <summary>
	/// Sets the adapter.
	/// </summary>
	/// <param name="adapter">Adapter.</param>
	void SetAdapter (AbsAdapter adapter);


	/// <summary>
	/// Adds the header view.
	/// </summary>
	/// <param name="head">Head.</param>
	void AddHeaderView (GameObject head);

	/// <summary>
	/// Adds the footer view.
	/// </summary>
	/// <param name="foot">Foot.</param>
	void AddFooterView (GameObject foot);


	void SetOnClickListener (OnItemClick click);


	void ResetContentHeight (float cellHeight);
	/// <summary>
	/// set cellsize
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	void SetItemInitSize (int x,int y);

	int  ReCalculateItemCount ();

	void ScrollToZeroPoint ();


}

public abstract class AbsListView:IListView
{
	public MonoBehaviour behaviour;
	public GameObject listViewCanvas;
	public GameObject listView;
	public GameObject viewPort;
	public GameObject content;
	private ScrollRect scrollRect;
	public GridLayoutGroup gridLayoutGroup;
	public OnItemClick click;
	public OnItemLongClick longclick;
	public AbsAdapter adapter;
	public AbsListView (MonoBehaviour behaviour)
	{
		this.behaviour = behaviour;
		listViewCanvas = new GameObject ("ListViewCanvas");
		listViewCanvas.AddComponent<EventSystem> ();
		listViewCanvas.AddComponent<StandaloneInputModule> ();
		listViewCanvas.AddComponent<Canvas> ().renderMode = RenderMode.ScreenSpaceOverlay;
		listViewCanvas.AddComponent<CanvasScaler> ();
		listViewCanvas.AddComponent<GraphicRaycaster> ();
		listView = new GameObject ("ListView");
		scrollRect = listView.AddComponent<ScrollRect> ();
		listView.transform.parent = listViewCanvas.transform;
		listView.transform.localPosition = Vector3.zero;
		((RectTransform)listView.transform).sizeDelta = new Vector2 (Screen.width, Screen.height);
		viewPort = new GameObject ("ViewPort");
		viewPort.AddComponent<Mask> ().showMaskGraphic = false;
		viewPort.AddComponent<Image> ();
		viewPort.transform.parent = listView.transform;
		viewPort.transform.localPosition = Vector3.zero;
		((RectTransform)viewPort.transform).sizeDelta = new Vector2 (Screen.width, Screen.height);
		content = new GameObject ("Content");
		gridLayoutGroup = content.AddComponent<GridLayoutGroup> ();
		content.transform.parent = viewPort.transform;
		content.transform.localPosition = Vector3.zero;
	
		scrollRect.content = (RectTransform)content.transform;
		scrollRect.viewport = (RectTransform)viewPort.transform;
		scrollRect.horizontal = false;
		scrollRect.vertical = true;
		gridLayoutGroup.startAxis = GridLayoutGroup.Axis.Horizontal;
		gridLayoutGroup.spacing = new Vector2 (0, 2);
	
	}




	public void AddHeaderView (GameObject head)
	{
		throw new System.NotImplementedException ();
	}

	public void AddFooterView (GameObject foot)
	{
		throw new System.NotImplementedException ();
	}

	public void SetScrollDirection (ScreenOrientation Orientation)
	{
		throw new System.NotImplementedException ();
	}

	public  void SetAdapter (AbsAdapter adapter)
	{
		this.adapter = adapter;
	   
	}

	public void SetItemInitSize (int x, int y)
	{
		gridLayoutGroup.cellSize = new Vector2 (x, y);
	}

	public int ReCalculateItemCount ()
	{

		return content.GetComponentsInChildren<EventHandler> ().Length;
	}

	public void ResetContentHeight (float cellHeight)
	{
		int itemCount = ReCalculateItemCount ();

		((RectTransform)content.transform).sizeDelta = new Vector2 (Screen.width,	gridLayoutGroup.cellSize.y * itemCount + (itemCount - 2) * gridLayoutGroup.spacing.y);
		gridLayoutGroup.cellSize = new Vector2 (Screen.width, cellHeight);

	}

	public void ScrollToZeroPoint ()
	{
		int itemCount = ReCalculateItemCount ();
		((RectTransform)content.transform).anchoredPosition3D = new Vector3 (0,	-gridLayoutGroup.cellSize.y *itemCount / 2, 0);
	}

	 public void SetOnClickListener (OnItemClick click)
	{
		this.click = click;
	}
	public void SetOnLongClickListener (OnItemLongClick longclick)
	{
		this.longclick = longclick;
	}
}


