# 2-D-Platformer
Uploaded The Project files. Download the zip file and open the "Game Club Assignment" folder with your Unity editor to view the project. The editor version used is 2022.3.2f1. The starting scene is _Mainmenu scene in the "Scenes" folder.
Features of the project:
Added a main character who can shoot projectiles. 

Added a health system.

Added traps : 
1) A Saw trap which follows waypoints.
2) A Spike Trap, which damages the player on collision.
3) An Arrow Trap, which shoots arrows at the player.
4) A Fire Trap, which activates after some time on collision with it.
5) A spike head Trap, which follows the player when he comes in its range.

Added enemies :
There are two types of enemies
1) A patrolling melee enemy.
2) A patrolling ranged enemy.

Added Collectibles:
1) Health Collectibles: which increases health.
2) Item Collectibles: which increases the score.

Added Sound: Background music and other sounds.

Added Start Screen and End Screen.

Added Pause Menu.

Added Game Over Menu.

# Answers to the questions.

## High-speed rendering:
We may achieve high-speed rendering without compromising on graphics by some of the methods below:
  1) We may reduce objects' detail level as they move farther away from the camera. This means less detailed models with fewer polygons may be used for distant objects. However, modern LOD systems are designed to transition smoothly between different levels of detail, ensuring that the visual downgrade is not noticeable to the player. The LOD system aims to balance performance and visual fidelity, so the impact on graphics quality should be minimal if implemented effectively.

  2) Occlusion culling techniques aim to avoid rendering objects that are not visible or are obstructed by other objects. This optimization does not directly affect the graphics quality of visible objects. Instead, it helps improve performance by reducing unnecessary rendering work. By selectively rendering only what is visible, occlusion culling can enhance the game's overall performance without compromising graphics quality.

  3) Batching and instancing techniques optimize rendering by reducing the number of draw calls and minimizing the overhead of switching between objects. These techniques primarily focus on improving rendering efficiency rather than altering graphics quality. Combining similar objects into batches and using instancing to duplicate objects efficiently can achieve performance gains without sacrificing visual fidelity.


## See Through the World:
The phenomenon you describe, where you can see through the world or objects in a game, is commonly called "clipping" or "z-fighting." It is a graphical glitch that occurs due to precision limitations in the rendering pipeline. There are a few possible causes for this glitch:

  1) Insufficient Depth Buffer Precision: In a 3D rendering pipeline, a depth buffer (also known as a z-buffer) is used to determine which objects are closer to the camera and should be rendered in front of others. The depth buffer stores depth values for each pixel on the screen. However, if the precision of the depth buffer is not sufficient, it can lead to z-fighting issues. When two objects or surfaces are very close to each other in terms of depth, the limited precision of the depth buffer can cause flickering or swapping between the two objects, resulting in the appearance of seeing through the world.

  2) Floating-Point Precision: Modern rendering engines and graphics hardware use floating-point numbers to represent positions and calculations. Floating-point precision limitations can also contribute to z-fighting issues. When two surfaces or polygons have extremely close or overlapping vertices in 3D space, the limited precision of floating-point numbers can result in visual artefacts, causing parts of the geometry to flicker or disappear.

  3) Incorrect Mesh or Collision Geometry: Another potential cause of seeing through the world is incorrect mesh or collision geometry. If the geometry of the game world or objects is not properly aligned or configured, it can create gaps or holes in the surfaces. This can lead to unintended visibility and allow you to see through the world.

Addressing and mitigating these issues often requires a combination of techniques and optimizations:

Increasing the depth buffer precision or using alternative depth buffer techniques can reduce z-fighting.
Adjusting the near and far clipping planes or the overall scene scale can alleviate precision issues.
Ensuring the game's meshes and collision geometry are properly constructed and aligned can help prevent unintended gaps or holes.


## Coyote Time:
"Coyote Time" is a game design concept that provides a brief grace period for players to execute a jump after they have technically left a platform. It allows players to correct mistimed jumps and adds a level of forgiveness to platforming mechanics. Here's how its implementation influences game mechanics, player experience, and game design:

  1) Game Mechanics: Coyote Time extends the window of opportunity for players to jump, even if their character's feet have already left the platform. This means that players can press the jump button slightly after leaving a platform and still successfully execute a jump. It reduces the frustration of narrowly missed jumps and gives players more control over their character's movement in platforming challenges.

  2) Player Experience: Coyote Time enhances the player experience by providing a more forgiving and fluid platforming feel. It prevents players from feeling punished for minor mistimings, which can be particularly frustrating in fast-paced or precision-based platformers. It promotes a smoother flow of movement and allows players to focus more on the overall gameplay experience rather than worrying about precise timing on every jump.

  3) Overall Game Design: Incorporating Coyote Time into a game design involves considering factors such as jump animation, level design, and pacing. The animation should visually reflect the additional grace period, giving the player a clear indication of when the character is no longer grounded. Level design should take into account the extended jump window, allowing for platform layouts that provide reasonable challenges without relying solely on precise timing. Pacing can be adjusted to ensure the game maintains an appropriate level of challenge while still providing a satisfying and accessible experience.

Technical considerations for implementing Coyote Time include:

  1) Input Handling: The game's input system needs to detect the jump button press both when the character is on the ground and during the grace period after leaving a platform. This may involve monitoring input states and properly timing the jump activation.

  2) Physics and Collision Detection: The game's physics and collision detection systems must account for the grace period and ensure that the character can jump while no longer in contact with the platform. Collision detection should be extended to allow the character to trigger the jump action even if their collision with the platform has ended.

An example of a game that uses the Coyote Time principle is "Super Mario Bros." In many of the Mario platforming games, players have a small window of time after leaving a platform where they can still execute a jump. This implementation contributes to the game's accessible and enjoyable platforming experience.

By incorporating Coyote Time, we can create a more forgiving and player-friendly platforming experience, reducing frustration and enhancing the overall enjoyment of the game.


>## Review of Celeste:
Celeste is an exceptional platformer game that offers tight and precise controls, as detailed in the video review. The protagonist, Madeline, exhibits responsive movement with well-defined mechanics. The run mechanic can be divided into three parts: acceleration, top speed, and deceleration. Celeste implements short acceleration and deceleration curves, allowing for precise movement and reducing the likelihood of slipping off platforms. The jump mechanic is balanced, enabling Madeline to jump approximately three times her own height, which feels appropriate and contributes to the overall gameplay experience.

The video also emphasizes the smoothness of turns, as there is no skidding when changing direction. With the addition of air friction, Madeline falls straight down with minimal drift, allowing players to land precisely where intended. The camera perspective, which is zoomed out, enhances the precision of jumps and runs.

Celeste introduces extra moves such as wall climbing, springy wall jumps, and controlled wall sliding. These mechanics add depth to the gameplay, creating a management puzzle aspect. The dash ability enables mid-air dashes that can be replenished by touching surfaces or collecting crystals. Importantly, the dash mechanic only briefly interrupts control, lasting for a mere 0.15 seconds, which allows players to cancel the dash if necessary, particularly to avoid hazards like spikes. This level of control adds to the strategic and satisfying nature of the game.

The art style of Celeste contributes to its immersive experience. Visual elements, such as squash and stretch animations upon jumping, dust particles kicked up while running, controller vibrations when touching the ground, and microscopic screen shakes during dashing, all enhance the overall aesthetics. Additionally, features like the trail of shadows indicating the direction of a dash, along with accompanying animations and sound effects, further enhance the gameplay and provide a cohesive visual and auditory experience.

The review mentions some code hacks that make Celeste less punishing, such as the implementation of the "coyote time" effect, where characters are given a brief grace period after leaving a platform before falling. This design choice increases the forgiving nature of the game. Moreover, the game offers advanced techniques like dash cancelling, allowing players to convert a dash into jump momentum or perform wall bounces, catering to pro players seeking additional challenges and depth.

Celeste is highly praised for its precise controls, strategic gameplay mechanics, immersive art style, and thoughtful design choices. It offers an enjoyable and challenging platforming experience while providing options for different skill levels through accessibility features and advanced techniques for experienced players.
