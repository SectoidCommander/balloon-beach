Contact e-mail: 	mitfreid@barebulbstudios.com


Methodology: 
	3D: I've written each function to be as simple to use as possible. I figured that with many of the 3D rotations people would be using Quaternions for a 
	majority of their rotation needs. This is great even if you are not using Quaternions as Unity3D supports ways of transforming cartesian rotaions and 
	vectors into quaternions. (In the scripting reference: Quaternions.Euler() and Quaternion.LookRotation()). Other 3D functions do not have Quaternions as their 
	rotation, like the DrawArrow function, because I figured most people would be plugging in vectors a lot of the time.
	2D: The rotations of the 2D functions are a single dimension as I didn't think people would be rotating along an axis that wasn't perpindicular to 
	the camera. The 2D DrawArrow function's rotation is the dame reason as the 3D function. To use the rotation of an 
	object 1) Get the euler Z rotation 2) multiply it by the Deg2Rad constant in the Mathf class.


The reason that the 2D and 3D functions were split in to two different classes was because I didn't think that
 people would be switching between 2D and 3D workflows inside the same project. Just to reduce confusion over whether a 2D or 3D function was being used.


How to use: You use it just like you would the Debug.DrawLine or Debug.DrawRay function.


The scripts inside the "Visualization Scripts" are easy drag-n-drop style scripts for when you don't want to code a script to view 
a collider. These are not very fast scripts(relatively speaking), so I don't recommend using them a whole lot, but with that said you could probably put a couple 
thousand of these in the scene and still not notice a difference in framerate. 

DebugViz3D drawing functions:
	DrawCube
	DrawCuboid
	DrawSphere
	DrawEllipsoid
	DrawCapsule
	DrawCone
	DrawCylinder
	DrawMarker  (a 3 line point)
	DrawHemisphere
	DrawHemiellipsoid
	DrawFOV     (Field of View)
	DrawPlane
	DrawArrow
	DrawPath

DebugViz2D drawing functions:
	DrawSquare
	DrawRectangle
	DrawCircle
	DrawEllipse
	DrawHemicircle
	DrawHemiellipse
	DrawMarker  (a 2 line point)
	DrawArrow
	DrawCapsule
	DrawFOV
	DrawPath