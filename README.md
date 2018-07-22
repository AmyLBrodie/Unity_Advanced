# Unity_Advanced

This game was created in unity for a third year games development course

Player Movement
	up arrow = move forward in world coordinates
	down arrow = move backwards in world coordinates
	left arrow = move left in world coordinates
	right arrow = move right in world coordinates
	"e" key = shoots bullet and move weapon (magic staff)

	The movement is a bit weird, but didn't really have time to fix it. Used 3d text to 
	indicate which direction character is moving in

Cameras implemented
	3rd person - use the "1" key to select
	orbiting - use the "2" key to select
	1st person - use the "3" key to select
	

	"1" key = 3rd person camera
	"2" key = orbiting camera
	"3" key = 1st person camera
	"7" key = decrease camera height
	"8" key = increase camera height
	"9" key = move camera further
	"0" key = move camera closer

Environment
	flattened cube in xz axis is the floor
	random objects (spheres and cubes) placed randomly on the floor
	player is able to collide with the objects and the walls
	The walls sometimes might block half of the camera view, didn't have time to fix

Ray casting
	Implemented to detect collisions between bullets and objects and then used to send a visible bullet to the object 

Visual Effects
	Lights - used a directional light and an area light (which has a halo that acts as the sun in the game world)
	Texturing - different textures/ materials used for the targets, the particle effect, the floor and the bullets
	Particle effects - Used to depict the impact of a bullet on the targets (explosion)
	3D text - used to indicate to player which direction in world space they are moving

Sounds
	Used sound effects for shooting bullets and when the targets explode. Also have background music.

Randomness
	There are two types of targets (cubes and spheres) which each have a random number of spawns and are 
	spawned in random locations with random materials/textures
