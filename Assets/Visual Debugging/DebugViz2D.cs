//#define DEBUG
#undef DEBUG

using UnityEngine;
using System.Collections;

/// <summary>
/// Debug class for drawing 2D shapes.
/// </summary>
public static class DebugViz2D {
	#region Constants
	/*
	 * Change this if you want a shape to be more/less round.
	 * Larger numbers mean more roundness. 
	 * Smaller numbers mean less roundness
	 */
	/// <summary>
	/// The number of sides to use for round shapes.
	/// </summary>
	private const int SIDES = 40; //should divde in to 4 for best look
	/// <summary>
	/// Twice the value of Pi.
	/// </summary>
	private const float TWOPI = 2f * Mathf.PI;
	#endregion

	#region 2D Visual Debugging
	/// <summary>
	/// Draws a 2D Axis-Aligned square.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="uniformScale">Uniform Scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawSquare(Vector2 position, float uniformScale, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		float radius = uniformScale / 2f;
		Vector2 offset = new Vector2(-radius, radius); //start offset at the upper left
		Vector2[] corner = new Vector2[4];
		
		//get the four corner points
		corner[0] = position + offset; //upper left
		offset.x = radius;
		corner[1] = position + offset; //upper right
		offset.y = -radius;
		corner[2] = position + offset; //lower right
		offset.x = -radius;
		corner[3] = position + offset; //lower left
		
		//draw each edge
		Debug.DrawLine(corner[0], corner[1], color, duration, depthTest); //upper left to upper right
		Debug.DrawLine(corner[1], corner[2], color, duration, depthTest); //upper right to lower right
		Debug.DrawLine(corner[2], corner[3], color, duration, depthTest); //lower right to lower left
		Debug.DrawLine(corner[3], corner[0], color, duration, depthTest); //lower left to upper left
	}
	/// <summary>
	/// Draws a 2D square.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="rotation">Rotation in radians.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawSquare(Vector2 position, float uniformScale, float rotation, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		float radius = uniformScale / 2f;
		Vector2 offset = new Vector2(-radius, radius); //start offset at the upper left
		Vector2[] corner = new Vector2[4];
		
		//get the four corner points
		corner[0] = position + Rotate2DPoint(offset, rotation); //upper left
		offset.x = radius;
		corner[1] = position + Rotate2DPoint(offset, rotation); //upper right
		offset.y = -radius;
		corner[2] = position + Rotate2DPoint(offset, rotation); //lower right
		offset.x = -radius;
		corner[3] = position + Rotate2DPoint(offset, rotation); //lower left
		
		//draw each edge
		Debug.DrawLine(corner[0], corner[1], color, duration, depthTest); //upper left to upper right
		Debug.DrawLine(corner[1], corner[2], color, duration, depthTest); //upper right to lower right
		Debug.DrawLine(corner[2], corner[3], color, duration, depthTest); //lower right to lower left
		Debug.DrawLine(corner[3], corner[0], color, duration, depthTest); //lower left to upper left
	}
	/// <summary>
	/// Draws a 2D Axis-Aligned rectangle.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="nonuniformScale">Non-uniform Scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawRectangle(Vector2 position, Vector2 nonuniformScale, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		Vector2 radii = nonuniformScale / 2f;
		Vector2 offset = new Vector2(-radii.x, radii.y);
		//get the four corner points
		Vector2[] corner = new Vector2[4];
		
		corner[0] = position + offset; //upper left
		offset.x = radii.x;
		corner[1] = position + offset; //upper right
		offset.y = -radii.y;
		corner[2] = position + offset; //lower right
		offset.x = -radii.x;
		corner[3] = position + offset; //lower left
		
		//draw each edge
		Debug.DrawLine(corner[0], corner[1], color, duration, depthTest);
		Debug.DrawLine(corner[1], corner[2], color, duration, depthTest);
		Debug.DrawLine(corner[2], corner[3], color, duration, depthTest);
		Debug.DrawLine(corner[3], corner[0], color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 2D rectangle.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="nonuniformScale">Nonuniform scale.</param>
	/// <param name="rotation">Rotation in radians.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawRectangle(Vector2 position, Vector2 nonuniformScale, float rotation, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		Vector2 radii = nonuniformScale / 2f;
		Vector2 offset = new Vector2(-radii.x, radii.y);
		//get the four corner points
		Vector2[] corner = new Vector2[4];
		
		corner[0] = position + Rotate2DPoint(offset, rotation); //upper left
		offset.x = radii.x;
		corner[1] = position + Rotate2DPoint(offset, rotation); //upper right
		offset.y = -radii.y;
		corner[2] = position + Rotate2DPoint(offset, rotation); //lower right
		offset.x = -radii.x;
		corner[3] = position + Rotate2DPoint(offset, rotation); //lower left
		
		//draw each edge
		Debug.DrawLine(corner[0], corner[1], color, duration, depthTest);
		Debug.DrawLine(corner[1], corner[2], color, duration, depthTest);
		Debug.DrawLine(corner[2], corner[3], color, duration, depthTest);
		Debug.DrawLine(corner[3], corner[0], color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 2D circle.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="uniformScale">Uniform Scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawCircle(Vector2 position, float uniformScale, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i;
		float theta;
		float radius = uniformScale / 2f;
		Vector2[] corner = new Vector2[SIDES];
		Vector2 offset = new Vector2();
		
		//get the points for each edge
		for(i = 0; i < SIDES; i++) {
			theta = TWOPI * (i / (float)SIDES);
			offset = FindPointOnCircle(radius, theta);
			corner[i] = position + offset;
		}
		
		//draw each edge
		for(i = 0; i < SIDES; i++) {
			Debug.DrawLine(corner[i], corner[(i+1)%SIDES], color,duration,depthTest);
		}
		Debug.DrawLine(corner[0], corner[SIDES/2], color, duration, depthTest);
		Debug.DrawLine(corner[SIDES/4], corner[(3*SIDES)/4], color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 2D circle.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="rotation">Rotation in radians.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawCircle(Vector2 position, float uniformScale, float rotation, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i;
		float theta;
		float radius = uniformScale / 2f;
		Vector2[] corner = new Vector2[SIDES];
		Vector2 offset = new Vector2();
		
		//get the points for each edge
		for(i = 0; i < SIDES; i++) {
			theta = TWOPI * (i / (float)SIDES);
			offset = FindPointOnCircle(radius, theta);
			corner[i] = position + Rotate2DPoint(offset, rotation);
		}
		
		//draw each edge
		for(i = 0; i < SIDES; i++) {
			Debug.DrawLine(corner[i], corner[(i+1)%SIDES], color,duration,depthTest);
		}
		Debug.DrawLine(corner[0], corner[SIDES/2], color, duration, depthTest);
		Debug.DrawLine(corner[SIDES/4], corner[(3*SIDES)/4], color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 2D ellipse.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="nonuniformScale">Non-uniform Scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawEllipse(Vector2 position, Vector2 nonuniformScale, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i;
		float theta;
		Vector2 radii = nonuniformScale / 2f;
		Vector2[] corner = new Vector2[SIDES];
		Vector2 offset = new Vector2();
		
		//get the points for each edge
		for(i = 0; i < SIDES; i++) {
			theta = TWOPI * (i / (float)SIDES);
			offset = FindPointOnEllipse(radii, theta);
			corner[i] = position + offset;
		}
		
		//draw each edge
		for(i = 0; i < SIDES; i++) {
			Debug.DrawLine(corner[i], corner[(i+1)%SIDES], color,duration,depthTest);
		}
		Debug.DrawLine(corner[0], corner[SIDES/2], color, duration, depthTest);
		Debug.DrawLine(corner[SIDES/4], corner[(3*SIDES)/4], color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 2D ellipse.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="nonuniformScale">Non-uniform scale.</param>
	/// <param name="rotation">Rotation in radians.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawEllipse(Vector2 position, Vector2 nonuniformScale, float rotation, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i;
		float theta;
		Vector2 radii = nonuniformScale / 2f;
		Vector2[] corner = new Vector2[SIDES];
		Vector2 offset = new Vector2();
		
		//get the points for each edge
		for(i = 0; i < SIDES; i++) {
			theta = TWOPI * (i / (float)SIDES);
			offset = FindPointOnEllipse(radii, theta);
			corner[i] = position + Rotate2DPoint(offset, rotation);
		}
		
		//draw each edge
		for(i = 0; i < SIDES; i++) {
			Debug.DrawLine(corner[i], corner[(i+1)%SIDES], color,duration,depthTest);
		}
		Debug.DrawLine(corner[0], corner[SIDES/2], color, duration, depthTest);
		Debug.DrawLine(corner[SIDES/4], corner[(3*SIDES)/4], color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 2D hemicircle.
	/// </summary>
	/// <param name="position">Position.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawHemicircle(Vector2 position, float uniformScale, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i;
		float theta;
		float radius = uniformScale / 2f;
		Vector2[] corner = new Vector2[SIDES];
		Vector2 offset = new Vector2();
		
		//get the points for each edge
		for(i = 0; i < SIDES; i++) {
			theta = (Mathf.PI + (Mathf.PI / (SIDES-1))) * (i / (float)SIDES);
			offset = FindPointOnCircle(radius, theta);
			corner[i] = position + offset;
		}
		
		//draw each edge
		for(i = 0; i < SIDES; i++) {
			Debug.DrawLine(corner[i], corner[(i+1)%SIDES], color,duration,depthTest);
		}
		offset.Set(0, radius);
		Debug.DrawLine(position, position + offset, color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 2D hemicircle.
	/// </summary>
	/// <param name="position">Position.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="rotation">Rotation in radians.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawHemicircle(Vector2 position, float uniformScale, float rotation, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i;
		float theta;
		float radius = uniformScale / 2f;
		Vector2[] corner = new Vector2[SIDES];
		Vector2 offset = new Vector2();
		
		//get the points for each edge
		for(i = 0; i < SIDES; i++) {
			theta = (Mathf.PI + (Mathf.PI / (SIDES-1))) * (i / (float)SIDES);
			offset = FindPointOnCircle(radius, theta);
			corner[i] = position + Rotate2DPoint(offset, rotation);
		}
		
		//draw each edge
		for(i = 0; i < SIDES; i++) {
			Debug.DrawLine(corner[i], corner[(i+1)%SIDES], color,duration,depthTest);
		}
		offset.Set(0, radius);
		Debug.DrawLine(position, position + Rotate2DPoint(offset, rotation), color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 2D hemiellipse.
	/// </summary>
	/// <param name="position">Position.</param>
	/// <param name="nonuniformScale">Non-uniform scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawHemiellipse(Vector2 position, Vector2 nonuniformScale, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i;
		float theta;
		Vector2 radii = nonuniformScale / 2f;
		Vector2[] corner = new Vector2[SIDES];
		Vector2 offset = new Vector2();
		
		//get the points for each edge
		for(i = 0; i < SIDES; i++) {
			theta = (Mathf.PI + (Mathf.PI / (SIDES-1))) * (i / (float)SIDES);
			offset = FindPointOnEllipse(radii, theta);
			corner[i] = position + offset;
		}
		
		//draw each edge
		for(i = 0; i < SIDES; i++) {
			Debug.DrawLine(corner[i], corner[(i+1)%SIDES], color, duration, depthTest);
		}
		offset.Set(0, radii.y);
		Debug.DrawLine(position, position + offset, color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 2D hemiellipse.
	/// </summary>
	/// <param name="position">Position.</param>
	/// <param name="nonuniformScale">Non-uniform scale.</param>
	/// <param name="rotation">Rotation in radians.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawHemiellipse(Vector2 position, Vector2 nonuniformScale, float rotation, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i;
		float theta;
		Vector2 radii = nonuniformScale / 2f;
		Vector2[] corner = new Vector2[SIDES];
		Vector2 offset = new Vector2();
		
		//get the points for each edge
		for(i = 0; i < SIDES; i++) {
			theta = (Mathf.PI + (Mathf.PI / (SIDES-1))) * (i / (float)SIDES);
			offset = FindPointOnEllipse(radii, theta);
			corner[i] = position + Rotate2DPoint(offset, rotation);
		}
		
		//draw each edge
		for(i = 0; i < SIDES; i++) {
			Debug.DrawLine(corner[i], corner[(i+1)%SIDES], color, duration, depthTest);
		}
		offset.Set(0, radii.y);
		Debug.DrawLine(position, position + Rotate2DPoint(offset, rotation), color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 2D point.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="scale">Scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawMarker(Vector2 position, float scale, Color color = default(Color), float duration = 0f, bool depthTest = true){
		float radius  = scale / 2f;
		Vector2 up 	  = new Vector2(0f, radius);
		Vector2 right = new Vector2(radius, 0f);
		
		Debug.DrawLine(position + right, position - right, color, duration, depthTest);
		Debug.DrawLine(position + up, position - up, color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 2D pointer that points at things.
	/// </summary>
	/// <param name="position">Position.</param>
	/// <param name="direction">Direction.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawArrow(Vector2 position, Vector2 direction, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		//draw initial line
		Debug.DrawRay(position, direction, color, duration, depthTest);
		//draw tip of the line
		float radius = Mathf.Clamp(direction.magnitude, 0f, 0.2f);
		float theta = Mathf.Atan(direction.y/direction.x);
		Vector2 tipPoint = position + direction;
		Vector2 offset = new Vector2(0f, radius);
		Vector2 pointerBase = tipPoint - (direction * (radius/direction.magnitude));
		Vector2[] point = new Vector2[2];
		
		point[0] = pointerBase + Rotate2DPoint(offset, theta);
		point[1] = pointerBase - Rotate2DPoint(offset, theta);
		
		Debug.DrawLine(point[0], point[1], color, duration, depthTest);
		Debug.DrawLine(point[0], tipPoint, color, duration, depthTest);
		Debug.DrawLine(point[1], tipPoint, color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 2D Capsule.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="height">Height.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawCapsule(Vector2 position, float uniformScale, float height, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		float radius = uniformScale / 2f;
		Vector2 hemiOffset  = new Vector2(0f, (height/2f)-radius);
		Vector2 rightOffset = new Vector2(radius, hemiOffset.y);
		Vector2 leftOffset  = new Vector2(-radius, hemiOffset.y);
//		Vector2 right 		= new Vector2(radius, 0f);
		
		//draw
		DrawHemicircle(position+hemiOffset,  uniformScale, color, duration, depthTest);
		DrawHemicircle(position-hemiOffset, -uniformScale, color, duration, depthTest);
		
		Debug.DrawLine(position+rightOffset, position-leftOffset, color, duration, depthTest);
		Debug.DrawLine(position-rightOffset, position+leftOffset, color, duration, depthTest);
//		Debug.DrawLine(position+hemiOffset,  position-hemiOffset, color, duration, depthTest);
//		Debug.DrawLine(position+right, position-right, color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 2D Capsule.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="height">Height.</param>
	/// <param name="rotation">Rotation in radians.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawCapsule(Vector2 position, float uniformScale, float height, float rotation, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		float radius = uniformScale / 2f;
		Vector2 hemiOffset  = Rotate2DPoint(new Vector2(0f, (height/2f)-radius), rotation);
		Vector2 rightOffset = Rotate2DPoint(new Vector2(radius, hemiOffset.y), rotation);
		Vector2 leftOffset  = Rotate2DPoint(new Vector2(-radius, hemiOffset.y), rotation);
//		Vector2 right 		= Rotate2DPoint(new Vector2(radius, 0f), rotation);
		
		//draw
		DrawHemicircle(position+hemiOffset,  uniformScale, color, duration, depthTest);
		DrawHemicircle(position-hemiOffset, -uniformScale, color, duration, depthTest);
		
		Debug.DrawLine(position+rightOffset, position-leftOffset, color, duration, depthTest);
		Debug.DrawLine(position-rightOffset, position+leftOffset, color, duration, depthTest);
//		Debug.DrawLine(position+hemiOffset,  position-hemiOffset, color, duration, depthTest);
//		Debug.DrawLine(position+right, position-right, color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 2D Field of View.
	/// </summary>
	/// <param name="position">Anchor position.</param>
	/// <param name="direction">Direction.</param>
	/// <param name="viewAngle">View angle in radians.</param>
	/// <param name="distance">Distance.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawFOV(Vector2 position, Vector2 direction, float viewAngle, float distance, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		if (distance == 0f || direction == Vector2.zero) return;

		float theta = Mathf.Atan(direction.y/direction.x);
		float radius = (Mathf.Tan(viewAngle/2f))*distance;
		Vector2 extent = position + (direction.normalized*distance);
		Vector2 offset = new Vector2(0f, radius);

		Vector2 pointUp   = extent + Rotate2DPoint(offset, theta);
		Vector2 pointDown = extent - Rotate2DPoint(offset, theta);

		Debug.DrawLine(position, pointUp, color, duration, depthTest);
		Debug.DrawLine(position, pointDown, color, duration, depthTest);
		Debug.DrawLine(pointUp, pointDown, color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 2D path.
	/// </summary>
	/// <param name="path">The points along the path.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawPath(Vector2[] path, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int pathEnd = path.Length - 1;
		
		for(int i = 0; i < pathEnd; i++) {
			Debug.DrawLine(path[i], path[i+1], color, duration, depthTest);
		}
	}
	#endregion

	#region Math Functions
	/// <summary>
	/// Finds the point on a circle.
	/// </summary>
	/// <returns>The point on circle.</returns>
	/// <param name="radius">Radius.</param>
	/// <param name="theta">Angle in radians.</param>
	private static Vector2 FindPointOnCircle(float radius, float theta) {
		//theta's range is [0, 2PI]
		return new Vector2(
			radius * Mathf.Cos(theta),	//left/right
			radius * Mathf.Sin(theta)	//up/down
			);
	}
	/// <summary>
	/// Finds the point on an ellipse.
	/// </summary>
	/// <returns>The point on ellipse.</returns>
	/// <param name="radii">Radii.</param>
	/// <param name="theta">Angle in radians.</param>
	private static Vector2 FindPointOnEllipse(Vector2 radii, float theta) {
		//theta's range is [0, 2PI]
		return new Vector2(
			radii.x * Mathf.Cos(theta),	//left/right
			radii.y * Mathf.Sin(theta)	//up/down
			);
	}
	/// <summary>
	/// Rotates a 2D point counter-clockwise.
	/// </summary>
	/// <returns>The 2D point.</returns>
	/// <param name="point">Point.</param>
	/// <param name="theta">Angle in Radians.</param>
	private static Vector2 Rotate2DPoint(Vector2 point, float theta) {
		//This assumes that the anchor of the point is (0,0,0)
		float sinT = Mathf.Sin(theta); float cosT = Mathf.Cos(theta);
		point.Set(
			point.x*cosT - point.y*sinT,
			point.x*sinT + point.y*cosT
			);
		return point;
	}
	#endregion
}
