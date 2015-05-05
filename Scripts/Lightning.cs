using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {

	protected LineRenderer lineRenderer;
	protected float maxY = 12f;
	protected int numOfSegments = 12;
	protected Color colour = Color.white;
	protected float posRange = 0.5f;
	protected float radius = 1f;
	protected Vector2 midPoint;
	protected float offset = 7f;

	protected Vector3 _targetPosition;

	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.SetVertexCount (numOfSegments);
		for(int index = 1; index < numOfSegments - 1; ++index){
			float y =  offset - ((float)index) * (maxY)/(float)(numOfSegments-1);
			lineRenderer.SetPosition(index, new Vector3(Random.Range(-posRange, posRange), y, -1));
		}
		lineRenderer.SetPosition(0, new Vector3(0f, 7f, -1f));
		float endPosition = offset - maxY;
		lineRenderer.SetPosition(numOfSegments-1, new Vector3(0f, endPosition, -1f));
	}


	public void targetPosition(Vector3 targetPos){
		_targetPosition = targetPos;
	}

	void Update () {
		colour.a -= 10f * Time.deltaTime;
		lineRenderer.SetColors (colour, colour);
		if (colour.a <= 0f) {
			colour = Color.white;
			colour.a = 1f;
			this.colour.a = 1f;
			this.gameObject.SetActive (false);
		}
	}

	void OnDestroy(){
		Debug.Log ("Lightning is destroyed");
	}
}
