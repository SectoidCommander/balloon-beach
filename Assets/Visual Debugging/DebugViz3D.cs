//#define BENCH
//#define DEBUG
#undef DEBUG

using UnityEngine;
using System.Collections;
#if BENCH
using System.Diagnostics;
#endif

/// <summary>
/// Debug class for drawing 3D shapes.
/// </summary>
public static class DebugViz3D {
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
	/// <summary>
	/// Half the value of Pi.
	/// </summary>
	private const float HALFPI = Mathf.PI / 2f;
	#endregion

	#region 3D Visual Debugging
	#region Cube
	/// <summary>
	/// Draws a 3D Axis-Aligned cube.
	/// </summary>
	/// <param name="position">Center position of the cube.</param>
	/// <param name="uniformScale">Uniform Scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawCube(Vector3 position, float uniformScale, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		float radius = uniformScale / 2f;
		Vector3 offset = new Vector3(-radius, radius, radius);
		Vector3[] corner = new Vector3[8];
		
		//calculate all the points
		//top----
		corner[0] = position + offset; //forward left
		
		offset.x = radius;
		corner[1] = position + offset; //forward right
		
		offset.z = -radius;
		corner[2] = position + offset; //back right
		
		offset.x = -radius;
		corner[3] = position + offset; //back left
		//bottom----
		offset.y = -radius; offset.z = radius;
		corner[4] = position + offset; //forward left
		
		offset.x = radius;
		corner[5] = position + offset; //forward right
		
		offset.z = -radius;
		corner[6] = position + offset; //back right
		
		offset.x = -radius;
		corner[7] = position + offset; //back left
		
		int i, j, k;
		for (i = 0; i < 4; i++) {
			j = i + 4;
			k = (i + 1) % 4;
			//top----
			UnityEngine.Debug.DrawLine(corner[i], corner[k], color, duration, depthTest); //forward/back X to Y
			//bottom----
			UnityEngine.Debug.DrawLine(corner[j], corner[k+4], color, duration, depthTest); //forward/back X to Y
			//sides----
			UnityEngine.Debug.DrawLine(corner[i], corner[j], color, duration, depthTest); //forward/back X to X
		}
	}
	/// <summary>
	/// Draws a 3D cube.
	/// </summary>
	/// <param name="position">Center position of the cube.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="rotation">Rotation.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawCube(Vector3 position, float uniformScale, Quaternion rotation, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		float radius = uniformScale / 2f;
		Vector3 offset = new Vector3(-radius, radius, radius);
		Vector3[] corner = new Vector3[8];
		
		//calculate all the points
		//top----
		corner[0] = position + (rotation * offset); //forward left
		
		offset.x = radius;
		corner[1] = position + (rotation * offset); //forward right
		
		offset.z = -radius;
		corner[2] = position + (rotation * offset); //back right
		
		offset.x = -radius;
		corner[3] = position + (rotation * offset); //back left
		//bottom----
		offset.y = -radius; offset.z = radius;
		corner[4] = position + (rotation * offset); //forward left
		
		offset.x = radius;
		corner[5] = position + (rotation * offset); //forward right
		
		offset.z = -radius;
		corner[6] = position + (rotation * offset); //back right
		
		offset.x = -radius;
		corner[7] = position + (rotation * offset); //back left
		
		int i, j, k;
		for (i = 0; i < 4; i++) {
			j = i + 4;
			k = (i + 1) % 4;
			//top----
			UnityEngine.Debug.DrawLine(corner[i], corner[k], color, duration, depthTest); //forward/back X to Y
			//bottom----
			UnityEngine.Debug.DrawLine(corner[j], corner[k+4], color, duration, depthTest); //forward/back X to Y
			//sides----
			UnityEngine.Debug.DrawLine(corner[i], corner[j], color, duration, depthTest); //forward/back X to X
		}
	}
	#endregion
	#region Cuboid
	/// <summary>
	/// Draws a 3D Axis-Aligned cuboid.
	/// </summary>
	/// <param name="position">Center position of the Cuboid.</param>
	/// <param name="nonuniformScale">Nonuniform scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawCuboid(Vector3 position, Vector3 nonuniformScale, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		Vector3 radii = nonuniformScale / 2f;
		Vector3 offset = new Vector3(-radii.x, radii.y, radii.z);
		Vector3[] corner = new Vector3[8];
		
		//calculate all the points
		//top----
		corner[0] = position + offset; //forward left
		
		offset.x = radii.x;
		corner[1] = position + offset; //forward right
		
		offset.z = -radii.z;
		corner[2] = position + offset; //back right
		
		offset.x = -radii.x;
		corner[3] = position + offset; //back left
		//bottom----
		offset.y = -radii.y; offset.z = radii.z;
		corner[4] = position + offset; //forward left
		
		offset.x = radii.x;
		corner[5] = position + offset; //forward right
		
		offset.z = -radii.z;
		corner[6] = position + offset; //back right
		
		offset.x = -radii.x;
		corner[7] = position + offset; //back left
		
		int i, j, k;
		for (i = 0; i < 4; i++) {
			j = i + 4;
			k = (i + 1) % 4;
			//top----
			UnityEngine.Debug.DrawLine(corner[i], corner[k], color, duration, depthTest); //forward/back X to Y
			//bottom----
			UnityEngine.Debug.DrawLine(corner[j], corner[k+4], color, duration, depthTest); //forward/back X to Y
			//sides----
			UnityEngine.Debug.DrawLine(corner[i], corner[j], color, duration, depthTest); //forward/back X to X
		}
	}
	/// <summary>
	/// Draws a 3D cuboid.
	/// </summary>
	/// <param name="position">Center position of the Cuboid.</param>
	/// <param name="nonuniformScale">Non-uniform scale.</param>
	/// <param name="rotation">Rotation.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawCuboid(Vector3 position, Vector3 nonuniformScale, Quaternion rotation, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		Vector3 radii = nonuniformScale / 2f;
		Vector3 offset = new Vector3(-radii.x, radii.y, radii.z);
		Vector3[] corner = new Vector3[8];
		
		//calculate all the points
		//top----
		corner[0] = position + (rotation * offset); //forward left
		
		offset.x = radii.x;
		corner[1] = position + (rotation * offset); //forward right
		
		offset.z = -radii.z;
		corner[2] = position + (rotation * offset); //back right
		
		offset.x = -radii.x;
		corner[3] = position + (rotation * offset); //back left
		//bottom----
		offset.y = -radii.y; offset.z = radii.z;
		corner[4] = position + (rotation * offset); //forward left
		
		offset.x = radii.x;
		corner[5] = position + (rotation * offset); //forward right
		
		offset.z = -radii.z;
		corner[6] = position + (rotation * offset); //back right
		
		offset.x = -radii.x;
		corner[7] = position + (rotation * offset); //back left
		
		int i, j, k;
		for (i = 0; i < 4; i++) {
			j = i + 4;
			k = (i + 1) % 4;
			//top----
			UnityEngine.Debug.DrawLine(corner[i], corner[k], color, duration, depthTest); //forward/back X to Y
			//bottom----
			UnityEngine.Debug.DrawLine(corner[j], corner[k+4], color, duration, depthTest); //forward/back X to Y
			//sides----
			UnityEngine.Debug.DrawLine(corner[i], corner[j], color, duration, depthTest); //forward/back X to X
		}
	}
	#endregion
	#region Sphere
	/// <summary>
	/// Draws a 3D Axis-Aligned sphere.
	/// </summary>
	/// <param name="position">Center position of the sphere.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawSphere(Vector3 position, float uniformScale, Color color = default(Color), float duration = 0f, bool depthTest = true) {
#if BENCH
		Stopwatch SW = new Stopwatch();
		SW.Start();
#endif

		int i, j;
		float radius = uniformScale / 2f;
		float phi;
		Quaternion yRot = Quaternion.Euler(90f,90f,0f);
		Quaternion xRot = Quaternion.Euler(0f,90f,90f);
		Vector3   offset  = new Vector3();
		Vector3[] xCorner = new Vector3[SIDES];
		Vector3[] yCorner = new Vector3[SIDES];
		Vector3[] zCorner = new Vector3[SIDES];

		//calculate the corners corners
		for(i = 0; i < SIDES; i++) {
			phi = TWOPI * (i / (float)SIDES);
			offset = FindPointOnSphere(radius, 0f, phi);
			zCorner[i] = position + offset;
			
			yCorner[i] = position + (yRot * offset);
			
			xCorner[i] = position + (xRot * offset);
		}
		
		for(i = 0; i < SIDES; i++) {
			j = (i+1)%SIDES;
			UnityEngine.Debug.DrawLine(xCorner[i], xCorner[j], color, duration, depthTest);//X
			UnityEngine.Debug.DrawLine(yCorner[i], yCorner[j], color, duration, depthTest);//Y
			UnityEngine.Debug.DrawLine(zCorner[i], zCorner[j], color, duration, depthTest);//Z
		}
		UnityEngine.Debug.DrawLine(xCorner[0], xCorner[SIDES/2], color, duration, depthTest);//X
		UnityEngine.Debug.DrawLine(yCorner[0], yCorner[SIDES/2], color, duration, depthTest);//Y
		UnityEngine.Debug.DrawLine(zCorner[0], zCorner[SIDES/2], color, duration, depthTest);//Z

#if BENCH
		StopSW(SW, "DrawSphere");
#endif
	}
	/// <summary>
	/// Draws a 3D sphere.
	/// </summary>
	/// <param name="position">Center position of the sphere.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="rotation">Rotation.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawSphere(Vector3 position, float uniformScale, Quaternion rotation, Color color = default(Color), float duration = 0f, bool depthTest = true) {
#if BENCH
		Stopwatch SW = new Stopwatch();
		SW.Start();
#endif

		int i, j;
		float radius = uniformScale / 2f;
		float phi;
		Quaternion yRot = rotation * Quaternion.Euler(90f,90f,0f);
		Quaternion xRot = rotation * Quaternion.Euler(0f,90f,90f);
		Vector3 offset = new Vector3();
		Vector3[] xCorner = new Vector3[SIDES];
		Vector3[] yCorner = new Vector3[SIDES];
		Vector3[] zCorner = new Vector3[SIDES];

		//calculate the corners corners
		for(i = 0; i < SIDES; i++) {
			phi = TWOPI * (i / (float)SIDES);
			offset = FindPointOnSphere(radius, 0f, phi);
			zCorner[i] = position + (rotation * offset);

			yCorner[i] = position + (yRot * offset);

			xCorner[i] = position + (xRot * offset);
		}

		//draw
		for(i = 0; i < SIDES; i++) {
			j = (i+1)%SIDES;
			UnityEngine.Debug.DrawLine(xCorner[i], xCorner[j], color, duration, depthTest);//X
			UnityEngine.Debug.DrawLine(yCorner[i], yCorner[j], color, duration, depthTest);//Y
			UnityEngine.Debug.DrawLine(zCorner[i], zCorner[j], color, duration, depthTest);//Z
		}
		UnityEngine.Debug.DrawLine(xCorner[0], xCorner[SIDES/2], color, duration, depthTest);//X
		UnityEngine.Debug.DrawLine(yCorner[0], yCorner[SIDES/2], color, duration, depthTest);//Y
		UnityEngine.Debug.DrawLine(zCorner[0], zCorner[SIDES/2], color, duration, depthTest);//Z

#if BENCH
		StopSW(SW, "DrawSphere");
#endif
	}
	#endregion
	#region Ellipsoid
	/// <summary>
	/// Draws a 3D Axis-Aligned ellipsoid.
	/// </summary>
	/// <param name="position">Center position of the ellipsoid.</param>
	/// <param name="nonuniformScale">Nonuniform scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawEllipsoid(Vector3 position, Vector3 nonuniformScale, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		if(nonuniformScale.x == nonuniformScale.y &&
		   nonuniformScale.y == nonuniformScale.z) {
			DrawSphere(position, nonuniformScale.x, color, duration, depthTest);
			return;
		}

		int i;
		Vector3 radii = nonuniformScale / 2f;
//		float theta, phi;
		float angle;
		Vector3 offset = new Vector3();
		Vector3[] xCorner = new Vector3[SIDES];
		Vector3[] yCorner = new Vector3[SIDES];
		Vector3[] zCorner = new Vector3[SIDES];

		//calculate corners
		for(i = 0; i < SIDES; i++) {
//			theta = phi = TWOPI * (i / (float)SIDES);
			angle = TWOPI * (i / (float)SIDES);

			offset = FindPointOnEllipsoid(radii, 0f, angle);
			zCorner[i] = position + offset;

			offset = FindPointOnEllipsoid(radii, angle, HALFPI);
			yCorner[i] = position + offset;

			offset = FindPointOnEllipsoid(radii, HALFPI, angle);
			xCorner[i] = position + offset;
		}

		int j;
		//draw the calculated circles
		for(i = 0; i < SIDES; i++) {
			j = (i+1)%SIDES;
			UnityEngine.Debug.DrawLine(xCorner[i], xCorner[j], color, duration, depthTest);//X
			UnityEngine.Debug.DrawLine(yCorner[i], yCorner[j], color, duration, depthTest);//Y
			UnityEngine.Debug.DrawLine(zCorner[i], zCorner[j], color, duration, depthTest);//Z
		}
		//draw the axis inside to help get orientation
		UnityEngine.Debug.DrawLine(xCorner[SIDES/4], xCorner[(SIDES/4)+(SIDES/2)], color, duration, depthTest);//X
		UnityEngine.Debug.DrawLine(yCorner[   0   ], yCorner[      SIDES/2      ], color, duration, depthTest);//Y
		UnityEngine.Debug.DrawLine(zCorner[   0   ], zCorner[      SIDES/2      ], color, duration, depthTest);//Z
	}
	/// <summary>
	/// Draws a 3D ellipsoid.
	/// </summary>
	/// <param name="position">Center position of the ellipsoid.</param>
	/// <param name="nonuniformScale">Non-uniform scale.</param>
	/// <param name="rotation">Rotation.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawEllipsoid(Vector3 position, Vector3 nonuniformScale, Quaternion rotation, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		if(nonuniformScale.x == nonuniformScale.y &&
		   nonuniformScale.y == nonuniformScale.z) {
			DrawSphere(position, nonuniformScale.x, rotation, color, duration, depthTest);
			return;
		}

		int i;
		Vector3 radii = nonuniformScale / 2f;
//		float theta, phi;
		float angle;
		Vector3 offset = new Vector3();
		Vector3[] xCorner = new Vector3[SIDES];
		Vector3[] yCorner = new Vector3[SIDES];
		Vector3[] zCorner = new Vector3[SIDES];

		//calculate corners
		for(i = 0; i < SIDES; i++) {
//			theta = phi = TWOPI * (i / (float)SIDES);
			angle = TWOPI * (i / (float)SIDES);

			offset = FindPointOnEllipsoid(radii, 0f, angle);
			zCorner[i] = position + (rotation * offset);

			offset = FindPointOnEllipsoid(radii, angle, HALFPI);
			yCorner[i] = position + (rotation * offset);

			offset = FindPointOnEllipsoid(radii, HALFPI, angle);
			xCorner[i] = position + (rotation * offset);
		}

		int j;
		for(i = 0; i < SIDES; i++) {
			j = (i+1)%SIDES;
			UnityEngine.Debug.DrawLine(xCorner[i], xCorner[j], color, duration, depthTest);//X
			UnityEngine.Debug.DrawLine(yCorner[i], yCorner[j], color, duration, depthTest);//Y
			UnityEngine.Debug.DrawLine(zCorner[i], zCorner[j], color, duration, depthTest);//Z
		}
		//draw the axis inside to help get orientation
		UnityEngine.Debug.DrawLine(xCorner[SIDES/4], xCorner[(SIDES/4)+(SIDES/2)], color, duration, depthTest);//X
		UnityEngine.Debug.DrawLine(yCorner[   0   ], yCorner[      SIDES/2      ], color, duration, depthTest);//Y
		UnityEngine.Debug.DrawLine(zCorner[   0   ], zCorner[      SIDES/2      ], color, duration, depthTest);//Z
	}
	#endregion
	#region Capsule
	/// <summary>
	/// Draws a 3D Y-Axis-Aligned capsule.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="height">Height.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawCapsule(Vector3 position, float uniformScale, float height, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		if(uniformScale < height) {
			int i = 0;
			float radius = uniformScale / 2f;
			float theta = 0f;
			Vector3 offset;
			Vector3 hemiOffset = new Vector3(0f, (height/2f) - radius, 0f);
			Vector3[] ringPoint = new Vector3[SIDES];
			
			//get the points for the middle ring
			for(i = 0; i < SIDES; i++) {
				theta = TWOPI * (i / (float)SIDES);
				offset = FindPointOnSphere(radius, theta, HALFPI);
				ringPoint[i] = position + offset;
			}
			//draw
			DrawHemisphere(position + hemiOffset, uniformScale, color, duration, depthTest); //top hemisphere
			DrawHemisphere(position - hemiOffset, -uniformScale, color, duration, depthTest); //bottom hemisphere
			for(i = 0; i < SIDES; i++) UnityEngine.Debug.DrawLine(ringPoint[i], ringPoint[(i+1)%SIDES], color, duration, depthTest); //middle ring
			for(i = 0; i < SIDES; i += SIDES/4) UnityEngine.Debug.DrawLine(ringPoint[i]+hemiOffset, ringPoint[i]-hemiOffset, color, duration, depthTest); //side lines
		}
		else DrawSphere(position, uniformScale, color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 3D capsule.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="rotation">Rotation.</param>
	/// <param name="height">Height.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawCapsule(Vector3 position, float uniformScale, Quaternion rotation, float height, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		if(uniformScale < height) {
			int i = 0;
			float radius = uniformScale / 2f;
			float theta = 0f;
			Vector3 offset;
			Vector3 hemiOffset = new Vector3(0f, (height/2f) - radius, 0f);
			Vector3[] ringPoint = new Vector3[SIDES];
			
			//get the points for the middle ring
			for(i = 0; i < SIDES; i++) {
				theta = TWOPI * (i / (float)SIDES);
				offset = FindPointOnSphere(radius, theta, HALFPI);
				ringPoint[i] = position + (rotation * offset);
			}
			//rotate the hemisphere offset
			hemiOffset = rotation * hemiOffset;
			//draw
			DrawHemisphere(position + hemiOffset, uniformScale, rotation, color, duration, depthTest); //top hemisphere
			DrawHemisphere(position - hemiOffset, -uniformScale, rotation, color, duration, depthTest); //bottom hemisphere
			for(i = 0; i < SIDES; i++) UnityEngine.Debug.DrawLine(ringPoint[i], ringPoint[(i+1)%SIDES], color, duration, depthTest); //middle ring
			for(i = 0; i < SIDES; i += SIDES/4) UnityEngine.Debug.DrawLine(ringPoint[i]+hemiOffset, ringPoint[i]-hemiOffset, color, duration, depthTest); //side lines
		}
		else DrawSphere(position, uniformScale, rotation, color, duration, depthTest);
	}
	#endregion
	#region Cone
	/// <summary>
	/// Draws a 3D Axis-Aligned cone.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="nonuniformScale">x is the +Y scale, and y is the -Y scale.</param>
	/// <param name="height">Height.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawCone(Vector3 position, Vector2 nonuniformScale, float height, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i, j;
		float topRadius = nonuniformScale.x / 2f;
		float bottomRadius = nonuniformScale.y / 2f;
		float middleRadius = (topRadius + bottomRadius) / 2f;
		float theta = 0f;
		Vector3 offset;
		Vector3 ringOffset = new Vector3(0f, (height/2f), 0f);
		Vector3[] topRingPoint = new Vector3[SIDES];
		Vector3[] midRingPoint = new Vector3[SIDES];
		Vector3[] botRingPoint = new Vector3[SIDES];
		
		//get the points for the rings
		for(i = 0; i < SIDES; i++) {
			theta = TWOPI * (i / (float)SIDES);
			offset = FindPointOnSphere(middleRadius, theta, HALFPI);
			midRingPoint[i] = position + offset; //middle

			offset = FindPointOnSphere(topRadius, theta, HALFPI);
			topRingPoint[i] = midRingPoint[i] + ringOffset; //top

			offset = FindPointOnSphere(bottomRadius, theta, HALFPI);
			botRingPoint[i] = midRingPoint[i] - ringOffset; //bottom
		}
		//draw
		for(i = 0; i < SIDES; i++) {
			j = (i+1)%SIDES;
			UnityEngine.Debug.DrawLine(topRingPoint[i], topRingPoint[j], color, duration, depthTest); //top
			UnityEngine.Debug.DrawLine(midRingPoint[i], midRingPoint[j], color, duration, depthTest); //middle
			UnityEngine.Debug.DrawLine(botRingPoint[i], botRingPoint[j], color, duration, depthTest); //bottom
		}
		for(i = 0; i < SIDES; i += SIDES/4) 
			UnityEngine.Debug.DrawLine(topRingPoint[i], botRingPoint[i], color, duration, depthTest); //sides
		for(i = 0; i < SIDES/2; i += SIDES/4) {
			UnityEngine.Debug.DrawLine(topRingPoint[i], topRingPoint[i+SIDES/2], color, duration, depthTest); //top cap
			UnityEngine.Debug.DrawLine(midRingPoint[i], midRingPoint[i+SIDES/2], color, duration, depthTest); //middle cap
			UnityEngine.Debug.DrawLine(botRingPoint[i], botRingPoint[i+SIDES/2], color, duration, depthTest); //bottom cap
		}
		UnityEngine.Debug.DrawLine(position+ringOffset, position-ringOffset, color, duration, depthTest); //center line
	}
	/// <summary>
	/// Draws a 3D cone.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="nonuniformScale">x is the +Y scale, and y is the -Y scale.</param>
	/// <param name="rotation">Rotation.</param>
	/// <param name="height">Height.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawCone(Vector3 position, Vector2 nonuniformScale, Quaternion rotation, float height, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i, j;
		float topRadius = nonuniformScale.x / 2f;
		float bottomRadius = nonuniformScale.y / 2f;
		float middleRadius = (topRadius + bottomRadius) / 2f;
		float theta = 0f;
		Vector3 offset;
		Vector3 ringOffset = rotation * new Vector3(0f, (height/2f), 0f);
		Vector3[] topRingPoint = new Vector3[SIDES];
		Vector3[] midRingPoint = new Vector3[SIDES];
		Vector3[] botRingPoint = new Vector3[SIDES];
		
		//get the points for the rings
		for(i = 0; i < SIDES; i++) {
			theta = TWOPI * (i / (float)SIDES);
			offset = FindPointOnSphere(middleRadius, theta, HALFPI);
			midRingPoint[i] = position + (rotation * offset); //middle

			offset = FindPointOnSphere(topRadius, theta, HALFPI);
			topRingPoint[i] = midRingPoint[i] + ringOffset; //top

			offset = FindPointOnSphere(bottomRadius, theta, HALFPI);
			botRingPoint[i] = midRingPoint[i] - ringOffset; //bottom
		}
		//draw
		for(i = 0; i < SIDES; i++) {
			j = (i+1)%SIDES;
			UnityEngine.Debug.DrawLine(topRingPoint[i], topRingPoint[j], color, duration, depthTest); //top
			UnityEngine.Debug.DrawLine(midRingPoint[i], midRingPoint[j], color, duration, depthTest); //middle
			UnityEngine.Debug.DrawLine(botRingPoint[i], botRingPoint[j], color, duration, depthTest); //bottom
		}
		for(i = 0; i < SIDES; i += SIDES/4) 
			UnityEngine.Debug.DrawLine(topRingPoint[i], botRingPoint[i], color, duration, depthTest); //sides
		for(i = 0; i < SIDES/2; i += SIDES/4) {
			UnityEngine.Debug.DrawLine(topRingPoint[i], topRingPoint[i+SIDES/2], color, duration, depthTest); //top cap
			UnityEngine.Debug.DrawLine(midRingPoint[i], midRingPoint[i+SIDES/2], color, duration, depthTest); //middle cap
			UnityEngine.Debug.DrawLine(botRingPoint[i], botRingPoint[i+SIDES/2], color, duration, depthTest); //bottom cap
		}
		UnityEngine.Debug.DrawLine(position+ringOffset, position-ringOffset, color, duration, depthTest); //center line
	}
	#endregion
	#region Cylinder
	/// <summary>
	/// Draws a 3D Y-Axis-Aligned cylinder.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="height">Height.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawCylinder(Vector3 position, float uniformScale, float height, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i;
		float radius = uniformScale / 2f;
		float theta = 0f; float phi = HALFPI;
		Vector3 offset;
		Vector3 ringOffset = new Vector3(0f, (height/2f), 0f);
		Vector3[] ringPoint = new Vector3[SIDES];
		
		//get the points for the middle ring
		for(i = 0; i < SIDES; i++) {
			theta = TWOPI * (i / (float)SIDES);
			offset = FindPointOnSphere(radius, theta, phi);
			ringPoint[i] = position + offset;
		}
		
		//draw
		for(i = 0; i < SIDES; i++) {
			UnityEngine.Debug.DrawLine(ringPoint[i] + ringOffset, ringPoint[(i+1)%SIDES] + ringOffset, color, duration, depthTest); //top ring
			UnityEngine.Debug.DrawLine(ringPoint[i], ringPoint[(i+1)%SIDES], color, duration, depthTest); //middle ring
			UnityEngine.Debug.DrawLine(ringPoint[i] - ringOffset, ringPoint[(i+1)%SIDES] - ringOffset, color, duration, depthTest); //bottom ring
		}
		for(i = 0; i < SIDES; i += SIDES/4) {
			UnityEngine.Debug.DrawLine(ringPoint[i]+ringOffset, ringPoint[i]-ringOffset, color, duration, depthTest); //side lines
		}
		for(i = 0; i < SIDES/2; i += SIDES/4) {
			UnityEngine.Debug.DrawLine(ringPoint[i]+ringOffset, ringPoint[i+SIDES/2]+ringOffset, color, duration, depthTest); //top cap
			UnityEngine.Debug.DrawLine(ringPoint[i], ringPoint[i+SIDES/2], color, duration, depthTest); //middle cap
			UnityEngine.Debug.DrawLine(ringPoint[i]-ringOffset, ringPoint[i+SIDES/2]-ringOffset, color, duration, depthTest); //bottom cap
		}
		UnityEngine.Debug.DrawLine(position+ringOffset, position-ringOffset, color, duration, depthTest); //center line
	}
	/// <summary>
	/// Draws a 3D cylinder.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="rotation">Rotation.</param>
	/// <param name="height">Height.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawCylinder(Vector3 position, float uniformScale, Quaternion rotation, float height, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i = 0;
		float radius = uniformScale / 2f;
		float theta = 0f; float phi = HALFPI;
		Vector3 offset;
		Vector3 ringOffset = rotation * new Vector3(0f, (height/2f), 0f);
		Vector3[] ringPoint = new Vector3[SIDES];
		
		//get the points for the middle ring
		for(i = 0; i < SIDES; i++) {
			theta = TWOPI * (i / (float)SIDES);
			offset = FindPointOnSphere(radius, theta, phi);
			ringPoint[i] = position + (rotation * offset);
		}
		
		//draw
		for(i = 0; i < SIDES; i++) {
			UnityEngine.Debug.DrawLine(ringPoint[i] + ringOffset, ringPoint[(i+1)%SIDES] + ringOffset, color, duration, depthTest); //top ring
			UnityEngine.Debug.DrawLine(ringPoint[i], ringPoint[(i+1)%SIDES], color, duration, depthTest); //middle ring
			UnityEngine.Debug.DrawLine(ringPoint[i] - ringOffset, ringPoint[(i+1)%SIDES] - ringOffset, color, duration, depthTest); //bottom ring
		}
		for(i = 0; i < SIDES; i += SIDES/4) {
			UnityEngine.Debug.DrawLine(ringPoint[i]+ringOffset, ringPoint[i]-ringOffset, color, duration, depthTest); //side lines
		}
		for(i = 0; i < SIDES/2; i += SIDES/4) {
			UnityEngine.Debug.DrawLine(ringPoint[i]+ringOffset, ringPoint[i+SIDES/2]+ringOffset, color, duration, depthTest); //top cap
			UnityEngine.Debug.DrawLine(ringPoint[i], ringPoint[i+SIDES/2], color, duration, depthTest); //middle cap
			UnityEngine.Debug.DrawLine(ringPoint[i]-ringOffset, ringPoint[i+SIDES/2]-ringOffset, color, duration, depthTest); //bottom cap
		}
		UnityEngine.Debug.DrawLine(position+ringOffset, position-ringOffset, color, duration, depthTest); //center line
	}
	#endregion
	#region HemiSphere
	/// <summary>
	/// Draws a 3D hemisphere.
	/// </summary>
	/// <param name="position">Bottom of the hemisphere.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawHemisphere(Vector3 position, float uniformScale, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i, j;
		float phi;
		float theta; float radius = uniformScale / 2f;
		Quaternion xRot = Quaternion.Euler(0f,90f,0f);
		Vector3 offset   = new Vector3();
		Vector3[] xPoint = new Vector3[SIDES];
		Vector3[] yPoint = new Vector3[SIDES];
		Vector3[] zPoint = new Vector3[SIDES];

		for(i = 0; i < SIDES; i++) {
			phi = ((Mathf.PI + (Mathf.PI/(SIDES-1))) * (i / (float)SIDES)) - HALFPI;
			offset = FindPointOnSphere(radius, 0f, phi);
			zPoint[i] = position + offset;

			xPoint[i] = position + (xRot * offset);
		}
		//calculate Y points
		for(i = 0; i < SIDES; i++) {
			theta = TWOPI * (i / (float)SIDES);
			offset = FindPointOnSphere(radius, theta, HALFPI);
			yPoint[i] = position + offset;
		}
		
		//draw
		for(i = 0; i < SIDES; i++) {
			j = (i+1)%SIDES;
			UnityEngine.Debug.DrawLine(xPoint[i], xPoint[j], color, duration, depthTest);//X
			UnityEngine.Debug.DrawLine(yPoint[i], yPoint[j], color, duration, depthTest);//Y
			UnityEngine.Debug.DrawLine(zPoint[i], zPoint[j], color, duration, depthTest);//Z
		}
		offset.Set(0f,radius,0f);
		UnityEngine.Debug.DrawLine(position, position + offset, color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 3D hemisphere.
	/// </summary>
	/// <param name="position">Bottom of the hemisphere.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="rotation">Rotation.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawHemisphere(Vector3 position, float uniformScale, Quaternion rotation, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i, j;
		float theta, phi;
		float radius = uniformScale / 2f;
		Quaternion xRot  = rotation * Quaternion.Euler(0f,90f,0f);
		Vector3 offset   = new Vector3();
		Vector3[] xPoint = new Vector3[SIDES];
		Vector3[] yPoint = new Vector3[SIDES];
		Vector3[] zPoint = new Vector3[SIDES];
		
		//calculate points
		for(i = 0; i < SIDES; i++) {
			phi = ((Mathf.PI + (Mathf.PI/(SIDES-1))) * (i / (float)SIDES)) - HALFPI;
			offset = FindPointOnSphere(radius,0f,phi);
			zPoint[i] = position + (rotation * offset);

			xPoint[i] = position + (xRot * offset);
		}
		//calculate Y points
		for(i = 0; i < SIDES; i++) {
			theta = TWOPI * (i / (float)SIDES);
			offset = FindPointOnSphere(radius, theta, HALFPI);
			yPoint[i] = position + (rotation * offset);
		}
		//draw
		for(i = 0; i < SIDES; i++) {
			j = (i+1)%SIDES;
			UnityEngine.Debug.DrawLine(xPoint[i], xPoint[j], color, duration, depthTest);//X
			UnityEngine.Debug.DrawLine(yPoint[i], yPoint[j], color, duration, depthTest);//Y
			UnityEngine.Debug.DrawLine(zPoint[i], zPoint[j], color, duration, depthTest);//Z
		}
		offset.Set(0f,radius,0f);
		UnityEngine.Debug.DrawLine(position, position + (rotation * offset), color, duration, depthTest);
	}
	#endregion
	#region Hemiellipsoid
	/// <summary>
	/// Draws a 3D Axis-Aligned hemiellipsoid.
	/// </summary>
	/// <param name="position">Bottom of the hemisphere.</param>
	/// <param name="nonuniformScale">Non-uniform scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawHemiellipsoid(Vector3 position, Vector3 nonuniformScale, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i, j;
		float theta = HALFPI; float phi = 0f;
		Vector3 radii = nonuniformScale / 2f;
		Vector3 offset   = new Vector3();
		Vector3[] xPoint = new Vector3[SIDES];
		Vector3[] yPoint = new Vector3[SIDES];
		Vector3[] zPoint = new Vector3[SIDES];
		
		//calculate X points
		for(i = 0; i < SIDES; i++) {
			phi = ((Mathf.PI + (Mathf.PI/(SIDES-1))) * (i / (float)SIDES)) - HALFPI;
			offset = FindPointOnEllipsoid(radii,HALFPI,phi);
			xPoint[i] = position + offset;
		}
		//calculate Z points
		for(i = 0; i < SIDES; i++) {
			phi = ((Mathf.PI + (Mathf.PI/(SIDES-1))) * (i / (float)SIDES)) - HALFPI;
			offset = FindPointOnEllipsoid(radii,0f,phi);
			zPoint[i] = position + offset;
		}
		//calculate Y points
		for(i = 0; i < SIDES; i++) {
			theta = TWOPI * (i / (float)SIDES);
			offset = FindPointOnEllipsoid(radii,theta,HALFPI);
			yPoint[i] = position + offset;
		}
		//draw
		for(i = 0; i < SIDES; i++) {
			j = (i+1)%SIDES;
			UnityEngine.Debug.DrawLine(xPoint[i], xPoint[j], color, duration, depthTest);//X
			UnityEngine.Debug.DrawLine(yPoint[i], yPoint[j], color, duration, depthTest);//Y
			UnityEngine.Debug.DrawLine(zPoint[i], zPoint[j], color, duration, depthTest);//Z
		}
		offset.Set(0f,radii.y,0f);
		UnityEngine.Debug.DrawLine(position, position + offset, color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 3D hemiellipsoid.
	/// </summary>
	/// <param name="position">Bottom of the hemisphere.</param>
	/// <param name="nonuniformScale">Non-uniform scale.</param>
	/// <param name="rotation">Rotation.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawHemiellipsoid(Vector3 position, Vector3 nonuniformScale, Quaternion rotation, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i, j;
		float theta = HALFPI; float phi = 0f;
		Vector3 radii = nonuniformScale / 2f;
		Vector3 offset   = new Vector3();
		Vector3[] xPoint = new Vector3[SIDES];
		Vector3[] yPoint = new Vector3[SIDES];
		Vector3[] zPoint = new Vector3[SIDES];
		
		//calculate X points
		for(i = 0; i < SIDES; i++) {
			phi = ((Mathf.PI + (Mathf.PI/(SIDES-1))) * (i / (float)SIDES)) - HALFPI;
			offset = FindPointOnEllipsoid(radii,HALFPI,phi);
			xPoint[i] = position + (rotation * offset);
		}
		//calculate Z points
		for(i = 0; i < SIDES; i++) {
			phi = ((Mathf.PI + (Mathf.PI/(SIDES-1))) * (i / (float)SIDES)) - HALFPI;
			offset = FindPointOnEllipsoid(radii,0f,phi);
			zPoint[i] = position + (rotation * offset);
		}
		//calculate Y points
		for(i = 0; i < SIDES; i++) {
			theta = TWOPI * (i / (float)SIDES);
			offset = FindPointOnEllipsoid(radii,theta,HALFPI);
			yPoint[i] = position + (rotation * offset);
		}
		//draw
		for(i = 0; i < SIDES; i++) {
			j = (i+1)%SIDES;
			UnityEngine.Debug.DrawLine(xPoint[i], xPoint[j], color, duration, depthTest);//X
			UnityEngine.Debug.DrawLine(yPoint[i], yPoint[j], color, duration, depthTest);//Y
			UnityEngine.Debug.DrawLine(zPoint[i], zPoint[j], color, duration, depthTest);//Z
		}
		offset.Set(0f,radii.y,0f);
		UnityEngine.Debug.DrawLine(position, position + (rotation * offset), color, duration, depthTest);
	}
	#endregion
	#region Miscellaneous
	/// <summary>
	/// Draws a Cone to mimick a Field Of View.
	/// </summary>
	/// <param name="position">Position.</param>
	/// <param name="rotation">Rotation.</param>
	/// <param name="viewAngle">View angle in radians (0,PI).</param>
	/// <param name="distance">Distance.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawFOV(Vector3 position, Quaternion rotation, float viewAngle, float distance, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i;
		float radius = (Mathf.Tan(viewAngle/2f))*distance;
		float phi = 0f;
		Vector3 offset;
		Vector3 ringCenter = position + ((rotation*Vector3.forward)*distance);
		Vector3[] ringpoint = new Vector3[SIDES];
		
		//calculate points
		for(i=0;i<SIDES;i++) {
			phi = TWOPI * (i/(float)SIDES);
			offset = FindPointOnSphere(radius, Mathf.PI, phi);
			ringpoint[i] = ringCenter + (rotation*offset);
		}
		//draw
		for(i=0;i<SIDES;i++) {
			UnityEngine.Debug.DrawLine(ringpoint[i],ringpoint[(i+1)%SIDES], color, duration, depthTest);
		}
		for(i=0;i<SIDES;i+=SIDES/4) {
			UnityEngine.Debug.DrawLine(position, ringpoint[i], color, duration, depthTest);
			UnityEngine.Debug.DrawLine(ringpoint[i], ringCenter, color, duration, depthTest);
		}
		UnityEngine.Debug.DrawLine(position, ringCenter, color, duration, depthTest);
	}
	/// <summary>
	/// Draws a point in 3D space.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="uniformScale">Uniform scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawMarker(Vector3 position, float uniformScale, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		float radius = uniformScale / 2f;
		Vector3 offset  = new Vector3(0f, radius, 0f);
		Vector3[] point = new Vector3[6];
		
		point[0] = position + offset; //+Y
		offset.y = -radius;
		point[1] = position + offset; //-Y
		offset.x = radius; offset.y = 0f;
		point[2] = position + offset; //+X
		offset.x = -radius;
		point[3] = position + offset; //-X
		offset.x = 0f; offset.z = radius;
		point[4] = position + offset; //+Z
		offset.z = -radius;
		point[5] = position + offset; //-Z
		
		UnityEngine.Debug.DrawLine(point[2], point[3], color, duration, depthTest);//X Axis
		UnityEngine.Debug.DrawLine(point[0], point[1], color, duration, depthTest);//Y Axis
		UnityEngine.Debug.DrawLine(point[4], point[5], color, duration, depthTest);//Z Axis
	}
	/// <summary>
	/// Draws a 2D plane in 3D space.
	/// </summary>
	/// <param name="position">Center position of the object.</param>
	/// <param name="rotation">Rotation of the plane.</param>
	/// <param name="nonuniformScale">Non-uniform scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawPlane(Vector3 position, Quaternion rotation, Vector2 nonuniformScale, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		Vector2 radii = nonuniformScale / 2f;
		Vector3 rightOffset = 	(rotation * Vector3.right) * radii.x;
		Vector3 upOffset    = 	(rotation * Vector3.up)    * radii.y;
		Vector3[] point = new Vector3[4];
		
		point[0] = (position - rightOffset) + upOffset; //upper left
		point[1] = (position + rightOffset) + upOffset; //upper right
		point[2] = (position + rightOffset) - upOffset; //lower right
		point[3] = (position - rightOffset) - upOffset; //lower left
		
		//draw
		for(int i = 0; i < 4; i++) {
			UnityEngine.Debug.DrawLine(point[i], point[(i+1)%4], color, duration, depthTest);
		}
	}
	/// <summary>
	/// Draws a 2D disk in 3D space.
	/// </summary>
	/// <param name="position">Center of the Ellipse.</param>
	/// <param name="rotation">Rotation.</param>
	/// <param name="nonuniformScale">Nonuniform scale.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawDisk(Vector3 position, Quaternion rotation, Vector2 nonuniformScale, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int i;
		float phi;
		Vector2 radii = nonuniformScale / 2f;
		Vector3 offset;
		Vector3[] point = new Vector3[SIDES];

		for(i = 0; i < SIDES; i++) {
			phi = TWOPI * (i/(float)SIDES);
			offset = FindPointOnEllipsoid(radii, 0f, phi);
			point[i] = position + (rotation*offset);
		}

		for(i = 0; i < SIDES; i++) {
			UnityEngine.Debug.DrawLine(point[i], point[(i+1)%SIDES], color, duration, depthTest);
		}
		UnityEngine.Debug.DrawLine(point[0], point[SIDES/2], color, duration, depthTest);
		UnityEngine.Debug.DrawLine(point[SIDES/4], point[(3*SIDES)/4], color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 3D directional arrow.
	/// </summary>
	/// <param name="position">Start of the arrow.</param>
	/// <param name="direction">Direction of the Arrow.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawArrow(Vector3 position, Vector3 direction, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		if (direction == Vector3.zero) return; //Quaternions don't like zero'd vectors

		UnityEngine.Debug.DrawRay(position, direction, color, duration, depthTest);//pointing line

		int i;
		float phi = 0f;
		float radius = Mathf.Clamp(direction.magnitude/4f, 0f, 0.25f);
		Quaternion rot = Quaternion.LookRotation(direction.normalized);
		Vector3 tipPoint = position + direction;
		Vector3 offset;
		Vector3 ringCenter = tipPoint - (direction * (radius/(direction.magnitude*0.8f)));
		Vector3[] ringPoint = new Vector3[SIDES];
		
		for(i = 0; i < SIDES; i++) {
			phi = TWOPI * (i / (float)SIDES);
			offset = FindPointOnSphere(radius, 0f, phi);
			ringPoint[i] = (ringCenter) + (rot * (offset));
		}
		//draw
		for(i = 0; i < SIDES; i++) {
			UnityEngine.Debug.DrawLine(ringPoint[i],ringPoint[(i+1)%SIDES], color, duration, depthTest);
		}
		for(i = 0; i < SIDES; i += SIDES/4) {
			UnityEngine.Debug.DrawLine(ringPoint[i], tipPoint, color, duration, depthTest);
		}
		UnityEngine.Debug.DrawLine(ringPoint[0], ringPoint[SIDES/2], color, duration, depthTest);
		UnityEngine.Debug.DrawLine(ringPoint[(SIDES/4)], ringPoint[(3*SIDES)/4], color, duration, depthTest);
	}
	/// <summary>
	/// Draws a 3D path.
	/// </summary>
	/// <param name="path">Path.</param>
	/// <param name="color">Color of the shape.</param>
	/// <param name="duration">Duration of the shape.</param>
	/// <param name="depthTest">If set to <c>true</c> depth test.</param>
	public static void DrawPath(Vector3[] path, Color color = default(Color), float duration = 0f, bool depthTest = true) {
		int pathEnd = path.Length - 1;

		for(int i = 0; i < pathEnd; i++) {
			UnityEngine.Debug.DrawLine(path[i], path[i+1], color, duration, depthTest);
		}
	}
	#endregion
	#endregion

	#region Math Functions
	/// <summary>
	/// Finds the point on a sphere.
	/// </summary>
	/// <returns>The point on a sphere.</returns>
	/// <param name="radius">Radius.</param>
	/// <param name="theta">Theta in radians.</param>
	/// <param name="phi">Phi in radians.</param>
	private static Vector3 FindPointOnSphere(float radius, float theta, float phi) {
		//theta's range is [0, 2PI]
		//phi's range is [0, PI]
		float sinPhi = Mathf.Sin(phi);
		return new Vector3(
			radius * Mathf.Cos(theta) * sinPhi, //left/right
			radius * Mathf.Cos(phi), 			//up/down
			radius * Mathf.Sin(theta) * sinPhi 	//forward/backward
			);
	}
	/// <summary>
	/// Finds the point on an ellipsoid.
	/// </summary>
	/// <returns>The point on an ellipsoid.</returns>
	/// <param name="radii">Radii.</param>
	/// <param name="theta">Theta in radians.</param>
	/// <param name="phi">Phi in radians.</param>
	private static Vector3 FindPointOnEllipsoid(Vector3 radii, float theta, float phi) {
		//theta's range is [0, 2PI]
		//phi's range is [0, PI]
		float sinPhi = Mathf.Sin(phi);
		return new Vector3(
			radii.x * Mathf.Cos(theta) * sinPhi, //left/right
			radii.y * Mathf.Cos(phi), 			 //up/down
			radii.z * Mathf.Sin(theta) * sinPhi  //forward/backward
			);
	}
	#endregion

#if BENCH
	static void StopSW(Stopwatch watch, string msg) {
		watch.Stop();
		UnityEngine.Debug.Log(msg + " took: " + watch.Elapsed.TotalMilliseconds + "ms.");
	}
#endif
}
