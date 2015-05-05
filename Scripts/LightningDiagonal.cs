using UnityEngine;
using System.Collections;


public class LightningDiagonal : Lightning {
	/*
	private LineRenderer lineRenderer;
	private float maxY = 12f;
	private int numOfSegments = 12;
	private Color colour = Color.white;
	private float posRange = 0.5f;
	private float radius = 1f;
	private Vector2 midPoint;
	private float offset = 7f;
	*/


	Vector2 firstPoint;
	Vector2 endPoint;

	float slope(Vector2 start, Vector2 end){
		float yDelta = end.y - start.y;
		float xDelta = end.x - start.x;
		return yDelta / xDelta;
	}

	float yIntercept(float slope, Vector2 point){
		return (point.y - (slope * point.x));
	}

	void Start () {

	}


	void FixedUpdate(){
		if (gameObject.activeInHierarchy) {

			lineRenderer = GetComponent<LineRenderer> ();
			lineRenderer.SetVertexCount (numOfSegments);

			
			firstPoint.x = 0f;
			firstPoint.y = offset;

			endPoint.x = _targetPosition.x - transform.position.x;
			endPoint.y = _targetPosition.y;

			maxY = firstPoint.y - endPoint.y;
			//endPoint.y = offset - maxY;
			
			float slopeValue = slope (firstPoint, endPoint);
			float yInterceptValue = yIntercept (slopeValue, endPoint);
			
			for(int index = 1; index < numOfSegments - 1; ++index){
				float y =  offset - ((float)index) * (maxY)/(float)(numOfSegments-1);
				float x = (y - yInterceptValue)/slopeValue + Random.Range(-posRange, posRange);

				lineRenderer.SetPosition(index, new Vector3(x, y, -1));
			}
			
			lineRenderer.SetPosition(0, new Vector3(firstPoint.x, firstPoint.y, -1f));
			lineRenderer.SetPosition(numOfSegments-1, new Vector3(endPoint.x, endPoint.y, -1f));

			this.colour = Color.white;
			this.colour.a = 1f;
		}
	}

	void Update () {
		colour.a -= 10f * Time.deltaTime;
		lineRenderer.SetColors (colour, colour);
		if (colour.a <= 0f) {

			this.gameObject.SetActive (false);
		}
	}
}