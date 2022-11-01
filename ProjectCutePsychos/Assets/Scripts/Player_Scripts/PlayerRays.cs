using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public class PlayerRays : MonoBehaviour {

	public LayerMask collisionMask;
	
	public const float skinWidth = .015f;
	const float _dstBetweenRays = .25f;
	[HideInInspector]
	public int horizontalRayCount;
	[HideInInspector]
	public int verticalRayCount;

	[HideInInspector]
	public float horizontalRaySpacing;
	[HideInInspector]
	public float verticalRaySpacing;

	[HideInInspector]
	public BoxCollider2D boxCollider;
	public RaycastOrigins raycastOrigins;

	public virtual void Awake() {
		boxCollider = GetComponent<BoxCollider2D> ();
	}

	public virtual void Start() {
		CalculateRaySpacing ();
	}

	public void UpdateRaycastOrigins() {
		Bounds bounds = boxCollider.bounds;
		bounds.Expand (skinWidth * -2);//"expand" by skinwidth * -2 in order to SHRINK the bounds of the box by skinwidth 
		
		raycastOrigins.bottomLeft = new Vector2 (bounds.min.x, bounds.min.y);
		raycastOrigins.bottomRight = new Vector2 (bounds.max.x, bounds.min.y);
		raycastOrigins.topLeft = new Vector2 (bounds.min.x, bounds.max.y);
		raycastOrigins.topRight = new Vector2 (bounds.max.x, bounds.max.y);
	}
	
    //method for calculating ray spacing
	public void CalculateRaySpacing() {
		Bounds bounds = boxCollider.bounds;
		bounds.Expand (skinWidth * -2);

		float boundsWidth = bounds.size.x;
		float boundsHeight = bounds.size.y;
		
		horizontalRayCount = Mathf.RoundToInt (boundsHeight / _dstBetweenRays);
		verticalRayCount = Mathf.RoundToInt (boundsWidth / _dstBetweenRays);
		
		horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
		verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
	}
	
    //Struct for all the vector2 positions which will be where the rays originate from
	public struct RaycastOrigins {
		public Vector2 topLeft, topRight;//dont even think we'll necessary need these, but theyre good to have around anyways
		public Vector2 bottomLeft, bottomRight;
	}
}