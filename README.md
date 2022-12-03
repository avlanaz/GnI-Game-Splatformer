[![Open in Visual Studio Code](https://classroom.github.com/assets/open-in-vscode-f059dc9a6f8d3a56e377f745f24479a46679e63a5d9fe6f495e02850cd0d8118.svg)](https://classroom.github.com/online_ide?assignment_repo_id=446177&assignment_repo_type=GroupAssignmentRepo)

**The University of Melbourne**

# COMP30019 – Graphics and Interaction

Final Electronic Submission (project): **4pm, November 1**

Do not forget **One member** of your group must submit a text file to the LMS (Canvas) by the due date which includes the commit ID of your final submission.

You can add a link to your Gameplay Video here but you must have already submit it by **4pm, October 17**

# Project-2 README

You must modify this `README.md` that describes your application, specifically what it does, how to use it, and how you evaluated and improved it.

Remember that _"this document"_ should be `well written` and formatted **appropriately**. This is just an example of different formating tools available for you. For help with the format you can find a [guide](https://www.youtube.com/watch?v=dQw4w9WgXcQ) [here](https://docs.github.com/en/github/writing-on-github).

**Get ready to complete all the tasks:**

- [x] Read the handout for Project-2 carefully.

- [x] Brief explanation of the game.

- [x] How to use it (especially the user interface aspects).

- [x] How you designed objects and entities.

- [x] How you handled the graphics pipeline and camera motion.

- [x] The procedural generation technique and/or algorithm used, including a high level description of the implementation details.

- [x] Descriptions of how the custom shaders work (and which two should be marked).

- [x] A description of the particle system you wish to be marked and how to locate it in your Unity project.

- [x] Description of the querying and observational methods used, including a description of the participants (how many, demographics), description of the methodology (which techniques did you use, what did you have participants do, how did you record the data), and feedback gathered.

- [x] Document the changes made to your game based on the information collected during the evaluation.

- [x] References and external resources that you used.

- [x] A description of the contributions made by each member of the group.

## Table of contents
* [Team Members and Contributions](#team-members-and-contributions)
* [Explanation of the game](#explanation-of-the-game)
* [How to Use](#how-to-use)
* [Objects and Entities Design](#objects-and-entities-design)
* [Graphics Pipeline](#graphics-pipeline)
* [Camera Motion](#camera-motion)
* [Procedural Generation](#procedural-generation)
* [Custom Shaders](#custom-shaders)
* [Particle System](#particle-system)
* [Evaluation](#evaluation)
* [Evaluation Discussion](#evaluation-discussion)
* [Changes from Evaluation](#changes-from-evaluation)
* [Technologies](#technologies)
* [Resources Reference List](#resources-reference-list)

## Team Members and Contributions

| Name | Task | ID |
| :--:         |     :---:      |          :--: |
| Brian Hisa  | Colorable Platform Logic; Level Design; Player movement, Moving Platform, and Switch Scripts; Glass Shader; Observational Method | 1182133 |
| Haflan Aziz Muhammad    | Level design; Texture; Camera, Texture, and Background Control Scripts; Aesthetics and themes; Observational method | 1118674 |
| Hualin Zhou    | User Interface; Shooting Script and Mechanism; Character Animation; Procedural Generation and Background Scripts; Querying Method | 1029802 |
| Shoucong Jiao    | Particle Systems; Lava Shader; Video Editing; Sound Effect and Audio Manager Script; Querying Method | 1118907 |

## Explanation of the game
<img src="ReadmeIMG\logo.png" style="zoom:50%;" />

*Splatformer* is a 2.5d sci-fi aesthetic puzzle-platformer game, where you play a role as protagonist mini bot. The task is to shoot painting bullets to the platforms and reach the final goal . Each colored platform grant you different boosts to help you get through the steep and dangerous zone. Look out of any traps like lava, moving spikes which will immediately kill you!

## How to Use
**Game Control:**

<img src="ReadmeIMG\tut.png" style="zoom:50%;" />

- **Basic Movement:** A/D to move left/right, W or Space to jump

- **Grace Time:** Grace time is also implemented allowing players to still jump for a few frames after leaving a platform 

- **Shoot:** Move mouse to aim and left mouse button to shoot. You can shoot the colorable platforms (Which are originally white and have a plainer texture) to paint them different colors and hence give them properties depending on the color of the bullet shot.

  <img src="ReadmeIMG\white.png" style="zoom:30%;" />

- **Switching bullets:** NumPad (Above Alphabet) 
  - Num 1 - Red bullet - This colors the colorable platforms red which makes the platform grant you extra jump height
  - Num 2 - Blue Bullet - This colors the colorable platforms blue which makes the platform grant you extra movement speed
  - Num 3 - Clear Bullet - It will erase any color to the platform, turning it white and removing any special properties
  - *You can also do switching, using middle mouse scrolling*
  
- **Zoom in/out:** Tab

- **Tip**: The dash boost you recieve from the blue platform lingers for a few seconds after leaving the blue platform/switching the color of the platform, therefore it is possible to combine dash and jump boost together by switching between blue and red platforms very quickly/switching to a red platform from a blue platform while standing on it and jumping immediately after.

- **Recommendation**: We recommend you play the game in fullscreen/maximized mode to allow for more precise control over the cursor and hence aiming.

**User Interface:**

**Title scene**

<img src="ReadmeIMG\UI_title.png" style="zoom:50%;" />

In order to show the shooting mechanic of the game, we enable player to freely move and shoot in title scene. Shooting to the platform will trigger the event on the text.

- **New** - Start a new game (The tutorial)
- **Levels** - Enter into the select level page, which is detailed explained in later
- **Quit** - Exit the game

**In game**

<img src="ReadmeIMG\UI_pause.png" style="zoom:50%;" />

1. **Pause button** - Immediately pause the game and show the menu
2. **Bullet status** - Show which bullet you are loading now, the outside circle is the loading bar. You can only shoot once the loading is complete

**Menu**

<img src="ReadmeIMG\UI_menu.png" style="zoom: 50%;" />

- **Continue** - Exit the menu and return back to game
- **Restart** - Restart this level
- **Select Level** - Open the level select interface
- **Settings** - Open the volume adjustment interface
- **Return to Title** - Exit current level and return to the title scene
- **Quit** - Immediately quit the game

**Select Level**

<img src="ReadmeIMG\UI_selectLevel.png" style="zoom:50%;" />

- **1&2:** the name and the thumbnail of the stage you are previewing
- **3:** Level button, click will lead you into the corresponding level, hover will preview the level on 1&2
- **4:** Return to the Menu, works the same way in settings too.

**Settings**

<img src="ReadmeIMG\UI_setting.png" style="zoom:50%;" />

- **BGM slidebar:** Toggle or click to adjust volume of background music, right is max
- **SFX slidebar:** Toggle or click to adjust volume of sound effect e.g shooting and jumping, right is max

**Victory**

*This box only appear if player reach the exit of the level*

<img src="ReadmeIMG\UI_victory.png" style="zoom:50%;" />

- **Next Stage** - enter next stage
- **Select Level** - Enter the level select page
- **Return Title** - Exit current level and return to the title scene

## Objects and Entities Design

Most of the fundamental objects are merely blocks (or Cubes, as they are named by default in Unity), like the platforms and the walls. It is done to make the level design and structuring simple.  It also put constraints to our design such that we cannot make "fancy things" (like from ramps, round things, etc.), which helps keep the design and the building process simple, keep us focused on the challenges, and challenge us to create interesting stuffs out of the limited selection. Most of the entities and textures are imported from either the unity asset store or other sources online (player, switch) to save development time. 



**Textures**

The textures are imported from asset store to save time on the project. Lab and Sci-Fi looking textures are used to match the lab theme of the game. Some textures have been adjusted by us to suit the scenes better and/or to reduce the distracting/unusable complexity of the texture.

To avoid the textures looking stretched or squashed, we added a script ("TextureAutotile") to adjust the tiling of the texture material at runtime. It enables us to adjust the texture tiling of individual platforms and blocks sharing the same material without needing to create copies of it to suit different scaled blocks. The script is given a X and Y scale values of a "standard block" so that the tiling adjustment for the specific block matches that "standard block" being stacked or put together multiple times (e.g. a X and Y scale of (5,1) for a block with its actual X and Y scale being (10,1) will make the block look like two blocks with scale (5,1) put side by side). This also saves time and makes it more tidier compared to manually copy and paste the same blocks to avoid texture stretching.



**Player Model and Bullets**

A robot model is imported from online source as the player model. Its simplicity and techy feels suits our game well. We also chose one with a kind of "shooting mechanism" (i.e., its arms here) that allows the inference that the player shoot colouring bullets. The bullets are simply cylinders, which make them looks like a blob of paint that flies over when they are shot.



**Platforms**

In general we used 2 types of platforms. The white/Colorable platforms, and the grey/Non-Colorable platforms. Both of these have moving and non-moving variants.

The white platforms are intended to be coloured by the player to give them the boosts needed to reach the goal. The white colour is intended so that player can easily recognise the platforms that are colourable. Their texture is also made clean so as to help their visibility. Meanwhile grey platforms have a more metalic texture to imply that they cannot be colored. Both Platforms have variations which move

All moving and colorable platforms have 1 additional trigger collider in addition to the regular box collider. This trigger collider is offset slightly above the platform. This allows scripts to use the OnTriggerEnter/Stay/Exit functions whenever the player lands on top of the function which are then used to trigger boosts and make the player a child of the platform when landing on the platform so player does not slip off it. This was done in place of using OnControllerColliderHit (which must be used in place of OnCollisionEnter/Stay/Exit when using Character Controller component) due to OnControllerColliderHit being significantly more limited. For example OnControllerColliderHit has no OnExit equivalent(such as OnCollisionExit). It also has some other benefits such as only detecting collisions above the platform, preventing player from gettings boosts when hitting from below.



**Traps and Death Triggering Entities**

Basically, these only consist of three main items: lava, spike traps, and out-of-sight death blocks. The lava is used in levels that require the players to watch their steps and/or enable quick restart of the level. We used lava since its saturated reddish colour contrast the typical grey that we use for almost every other objects. It is discussed more in the Shader section. The spike traps are used for their flexible placement compared to lava. The death blocks are the lava alternative where the level needs an "on a high place" feeling, and are put out of sight to give the illusion of "falling from heights" death.



**Switches and Toggleable Platforms/Doors**

These are used not only as part of the challenge, but also to better guide the player to do certain stuff first (e.g., we want them to master a mechanics first before giving them a similar, harder challenge). The switches toggle from orange to green to indicate whether they are off or on, respectively. This is meant to make the status of the switches clearer to the player, while also match the colour theme we have going on. It also makes them generally more visible. Their texture is also adjusted to be more clean to make them and their status colour more noticeable. We decided that the switches are activated by shooting them since this is the most common mode for the player to interact with the objects in the levels.

Some toggleable objects are designed as "doors" to give the player the impression that they have to deactivate these obstacles somewhere and encourage them to look for a switch.



**Level's Building Blocks**

Levels are build from platforms, blocks, and planes. The planes serve as a back wall, since only the upper side is needed to be rendered. The platforms act as moving grounds for the player to traverse through. The blocks are used as the side walls, ceilings, and roofs, since they give off a solid, concrete look. They also serve similarly to platforms where we desired the moving ground to be more "integrated" to the "building" (i.e. where the levels take place).



**Level's Decors and Props**

The decors, similar to the player model, are imported and have simple and sci-fi look. They are added to the scenes to give more life to the gameplay and make the levels to look more like a typical lab people expect in games.



**Background Objects**

The "Cityscape" and "Hills" aesthetic are constructed from individual blocks. This choice is intended to match the simplicity of the actual level objects. Some additional decors are imported from the asset store to give more variety to the background. They are low poly models so as to not clash with the background's aesthetic. More details of the background are covered in the Procedural Generation section.


## Graphics Pipeline
The modifications to the graphics pipeline in our project mainly consisted of using shaders to alter the standard fragment and vertex shaders of the graphics pipeline. This included implementing vertex displacement to create our lava wave effects by altering vertex positions in the vertex shader step, and obtaining and combining the colors of adjacent pixels by modifying the vertex and fragment shader steps to create our glass. For other objects we decided that the standard shader suited our aesthetic best and hence did not feel the need to use different ones.

## Camera Motion
The camera are generally centered on the player, with exception on some levels where the camera moves by itself. This is done by the camera copying the x and y position of the player. The camera is also given boundaries using top-left and bottom-right edge point. These points are used to check whether camera stays within the intended boundary of the level.

In some levels, where the camera does not cover the whole level, zoom can be toggled by holding "Tab". This would move the camera to a point much farther back, where it could cover the whole level. The initial z-position of the camera is stored so that the camera could easily return to the normal view. The zoom function is intended to make it easier for the player to find the exit of some levels.

## Procedural Generation
We use procedural generation to enhance the visual. Including background, title scene, clouds and trees.

We achieve this using perlin noise to generate the landscape & city, plus the trees position and clouds movement by built in random function.

<img src="ReadmeIMG\Procedural_0.png" style="zoom:30%;" />

**Landscape & City**

We treat them as a matrix of cube, where their height is generated using perlin noise. Perlin noise is a gradient greyscale map that simulate realism texture. We randomly map a matrix of vertices to the perlin noise map, extract each vertice's greyscale and interpret them as the height of each cube. To adjust the density we can set mapping matrix to be dense or loosen. To adjust the steep we can multiply a fix value when interpreting the height. We also add random z-axis offset to make them look more natural.

Here is the rough framework:

```c#
float perlinStart = Random.Range(0f, 10f); // randomise start point 
        //so it doesn't keep same every time
		Float cliffiness, heightFix
        Int row, col, offset 
        for (int x = 0; x < row; x++)
        {
            for (int y = 0; y < col; y++)
            {
                Create cube in (x*offset, y*offset, 0);
                Cube.Height = PerlinNoise((perlinStart+ x/row)/cliffiness, (perlinStart+(y / col))/cliffiness))*heightFix;
            }
        }
```

We create several interface that allow DIY of the generation, so that it can vary on each level, but they look different for each entry.

<img src="ReadmeIMG\Procedural_4.png" style="zoom:50%;" />

<img src="ReadmeIMG\Procedural_5.png" style="zoom:50%;" />

<img src="ReadmeIMG\Procedural_6.png" alt="Procedural_6" style="zoom:50%;" />

<img src="ReadmeIMG\Procedural_7.png" alt="Procedural_7" style="zoom:50%;" />

We also applied that to the title scene: every time player enter the title, background will randomize the transition color. Now player won't be too tired with the same title style.

```c#
if (randomizeColor)
{
    BottomC = UnityEngine.Random.ColorHSV();
    TopC = UnityEngine.Random.ColorHSV();
}
```

<img src="ReadmeIMG\Procedural_1.png" style="zoom:30%;" />

<img src="ReadmeIMG\Procedural_2.png" alt="Procedural_2" style="zoom:30%;" />

<img src="ReadmeIMG\Procedural_3.png" alt="Procedural_3" style="zoom:30%;" />

**Clouds & trees**

We use Unity built-in random class to generate clouds and trees. We generate clouds from a certain x point, but vary y and z to make them spread the depth and height. All the clouds are giving random speed to achieve realism. The trees are generated on the top of each terrain cube, giving the possibility that the random generated number is greater than a threshold value, and randomly pick a type of tree in the tree lists. 



## Custom Shaders
**Marking Shader**

- **Lava Shader**
  Location: Assets/Shaders/Lava.shader

  The plane created by unity has very small number of vertices, and this will cause the lava's wave looks too sharp and not natural. So instead of using the unity's plane, we created the new plane with large number of vertices in the blender. 
  
  The Lava shader is used on many levels and it's one of the traps that can kill the player. This shader used 3 different textures to achieve the wave and flowing of the lava. The main texture has the basic colour of lava, the bump texture is used for adding some distortion to the lava since we want to achieve the sticky feeling like the real lava, and the height texture is used for achieving displacement map so the lava has the natural waves or bumps. 
  
  In the vertex shader, we implement a displacement map to adjust the position of the vertex. The process here is to get the colour from the displacement map and use the luminosity method to convert the colour to grayscale as shown in "https://www.johndcook.com/blog/2009/08/24/algorithms-convert-color-grayscale/". We used tex2dlod to get the colour of the displacement map since it's a vertex shader and we used the new UV with time variable to control the speed of the wave. Then we replace the old vertices with new displacement vertices along with the normal vector (This process largely followed this tutorial: "https://en.m.wikibooks.org/wiki/Cg_Programming/Unity/Displacement_Maps"). After this, the wave is achieved, but it's hard to see since the colour is always red for lava, so we add a new parameter colour to the input data. Then change the colour of the input data depending on the height of the vertex. The wave of the lava will become brighter than the other part. 
  There are two parts in the fragment shader. The first part is letting the input UV do the sine wave by time, and based on that, adding the bump texture in the sin function to mix up the UV. There are two variables here to control the distortion caused by bump texture(Noise and BumpIntense), adjusting these two can achieve the different effects that bump texture brings to lava（Learned this process from: https://catlikecoding.com/unity/tutorials/flow/texture-distortion/). Since we just want a little stickiness of lava, the value of these two variables is relatively small. Another part is adding the time value for the x coordinate of UV so the lava can keep flowing, the variable ScrollX here is to control the speed of the flow. 
  
- **Glass Shader**
  Location: Assets/Shaders/GlassShader.shader

  The Glass shader is the shader used for the background glass in most levels. It consists of 3 main parts, obtaining the background texture, the refraction, and the gaussian blur. The process of obtaining the background texture mainly involves the use of grabpass, a standard unity shaderLab command which grabs the current contents of the frame buffer and saves it as a 2d texture (I learned how to use GrabPass from: "http://tinkering.ee/unity/asset-unity-refractive-shader/"). 
  This texture can then be used in the fragment shader to create the refraction effect, which is done by offsetting the current screen position (obtained in the vertex shader) which is then used along with the grabbed background texture to get the color of the pixel at the offset screen position by using the tex2Dproj function, taking the background texture and offset screen position as inputs. The direction and magnitude of offset is calculated using a normal map. The normal map is first transformed in the vertex shader then unpacked in the fragment shader using the uv. Since the normals are in tangent space, they are then converted into object and then screen space before being added as the offset to the screen position (Which I learned how to do here: https://www.fatalerrors.org/a/unity-shader-normal-mapping-for-bump-mapping.html). While this does not produce physically accurate refraction it allows for a convincing implementation by tweaking values (The logic for using the normal map and screen position to get the screen color at a position was inspired by : "https://www.youtube.com/watch?v=inht8WYX-A4&t=2s").
  This refraction is supplemented gaussian blur which used a weighted average to calculate the color of the current pixel where pixels further away weigh less. This is done in 2 seperate passes, a horizontal pass and a vertical pass. In both passes the shader first calculates the screen positions and uv of the pixels 1 and 2 spaces away in the vertex shader, to the left and right for the horizontal pass and up and down for the vertical pass. Afterwards in the fragment shader the color of the pixels is obtained in the same way as described in the refraction section, where an offset (calculated through the normal map) is added to the screenPos and then used in tex2Dproj. However, now instead of just doing it once, the process is repeated for each pair of screen and uv coordinates corresponding to each of the 5 pixels, where the uv is used to obtain the normal (and thus offset) at that screen coordinate. This allows us to get the offset screen coordinates of the background texture the glass is refracting to for all 5 pixels and hence the color at all 5 pixels (after the refraction). The pixel colors are then multiplied by their weights: 0.4026 for the center pixel, 0.2442 for the pixels 1 space away, and 0.0545 for the pixels offset 2 spaces away; which are weights obtained by summing the rows/columns of a normalized 5x5 Gaussian blur convolution kernel into a 1x5 vector. The pixel colors are then added together and returned. This fragment phase is the same for both passes, the only difference being the input uvs and screen coordinates (The Gaussian Blur tutorial I used and the values for the 5x5 Gaussian blur kernel were found here: "https://blog.titanwolf.in/a?ID=01500-3606b309-752d-4891-942a-57b4fe27451a", combining it with the refraction required a lot of modification). While this gaussian blur effect is pretty subtle (mainly because the magnitude was set low to prevent it from blurring the background too much), it helps to smooth out the transition between colors and hide when lines get pixelated due to being warped by refraction.

**Non-Marking Shader**

- None

## Particle System
**Marking Particle System:**

1.  Location: Assets/Prefab/DeathEffect.prefab

   This effect initialized every time when the player died and will destroy itself after it's finished. It's the combination of four particle systems: three of them are the burst of different parts from the robot body and the last one is the explosion effect. 

   The burst of robot gears is achieved by using the meshes from the robot and set emission mode to burst so there are fixed number of gears. The shape of the burst is circle since our game is 2D. To enhance the effect, each burst of robot body has different direction, rotation and lifetime. This is done by setting these variables randomly choose from a range. To make the burst more real, the gravity and collision is also activated.  

   The explosion effect used a material that contained many kinds of dust, the way to use this material need to turn on the Texture Sheet Animation  and choose the grid mode with correct number as the material so it's allowed to use a texture with multiple tiles. The emission of explosion is also burst mode with fixed number of particles since the explosion is quick and shot. To make explosion looks better, the color of the fire faded by time and that is achieved by turn on the color by lifetime and adjusted the alpha value

   <img src="ReadmeIMG\explosion.png" style="zoom:50%;" />

**Non-Marking Particle System**

1. Location: Assets/Prefab/MovingDust.prefab
2. Location: Assets/Prefab/BluePlatform.prefab
3. Location: Assets/Prefab/BlueTrail.prefab
4. Location: Assets/Prefab/Boom.prefab
5. Location: Assets/Prefab/PlaneDestory.prefab
6. Location: Assets/Prefab/RedPad.prefab
7. Location: Assets/Prefab/RedTrail.prefab

## Evaluation
- **Observational Methods**
  The participants in our observational game trail were around 20-21 years of age. Of the 5, 2 played games casually, while the other 3 regularly played a large variety of video games. For our observational methods, we decided that using cooperative evaluation would be best. This was mainly because we feared that the players might get stuck, especially on larger levels. Additionally it was concluded that having the ability to ask about odd behavior in the moment would be very beneficial. In our observational method our focus was mainly on level-design, we wanted to hear what the player thought of every level and hence we had our player play through the entire game, which was only 10 levels long in addition to the tutorial, all of which relatively short, while instructed to specifically voice any thoughts on the levels first and foremost. In addition to the level-design, feedback on movement, shooting, and graphics was also encouraged. While at first a video/audio recording was considered as a method to document feedback, many participants did not wish to be recorded directly. As such relevant feedback was recorded through the use of a text document while players streamed the game over discord. 

  Frequent/Major Feedback:

  - 2 players stated that the controls felt too sensitive. one such quote received from a player was "A & D too sensitive". Another stated "The right and left movement is too acute".
  
  - 4 players stated that the platforms were too small on multiple occasions. One player stated: "Why are the platforms so tiny". Another stated: "The platforms should be bigger", in response to asking for any additional feedback at the end of the session. This was also reinforced by watching the player's gameplay where they would frequently overshoot the platforms, especially when dashing.
  
  - 3 of the players also stated that the controls for switching the types of bullets fired was awkward. One player stated: ”I wish I could just use the scroll wheel”. Another player stated: "I would expect to be able to cycle with right click or mouse scroll". 
  
  - It was noticed that players would sometimes not notice key level-elements such as doors and spikes. However, only 1 of them stated a complaint.
  
  - One player specifically mentioned ”I cant exit on level clear”, which hadn't been thought about beforehand and seems like a good idea to implement.
  
  - 2 players found the tutorial lacking. One player stated: "the number '1' looks confusing" when referring to the instructions in the tutorial. Another player stated: "I didn't know I had to shoot the switch, I think it would have been helpful if you told me in the tutorial".
  
  - All players generally found level-5 annoying. One player stated: ”It's quite annoying”. Another one stated that "the exit wasn't clear". From observing the gameplay is was also quite clear that players had significantly more trouble in the 2nd part of the level than anticipated, having to be helped on multiple occasions.
  
  - 4 players also found level-9 difficult. One player stated "Why does it go up and down really quickly". Another player stated "Maybe add more delay before platform sink/bigger platform". It was also generally observed that players would try to stop in the middle of the level, which would cause them to fail considering the timed nature of the level.
  
  - Another Level Players found difficult was level-10, with 3 of them having complaints on it. One player stated "The obstacles should be clearer". While another stated "It feels like '*Getting Over It*' since every time I f*** up I have to go back to the start". It was also the level which several players elected to skip after spending too much time on.
  
  - The last major level players had issue with was level-11, with 4 players noting similar issues. Here players expressed a general sense of confusion as to where to go. One player stated ”Why do I need to be stuck here? I thought this was where i was supposed to go” after jumping in the wrong direction and getting soft-locked.  Another player stated: ”There's a lot of red herrings”. There also seemed to be issues with object visibility. One player stated: "spikes aren't clear enough" and then later "The red background makes it hard to see since its similar in color to the player".
  
    
  
- **Querying Methods**
  Due to this covid-period, we realized online-questionnaires is the best option. Since answering a questionnaire is rather quick in comparison to an interview, it was decided that it would allow us to query a larger variety of individuals as it would take up less of the participants time. We decide to create it using google form since it's free and easy to use, we send the links along with the game to participants and tell them to complete the form after playing through the game. 

  Firstly we want to know if the difficulty is appropriate because all of our teamates are pro gamers so we can't tell just by ourselves. We wanna know how smooth the control of the player is since we put quite a lots effort on it. We want to make sure the level design is good enough as it may impact the game mechanic. So we design the questionnaires as follow:

  https://docs.google.com/forms/d/15htANVBbzYW-S-_dMQ9Q_3LXzdrbL53lWVWDTi3vTQY/edit?usp=sharing

  **6 participants are envolved, luckily none of them skip the optional questions!**

  The participants are classmates, family and online friends, and each of them has **different gaming experience**. This will make sure the answer will be general enough. We had these participants play through the 10 levels which were finished at the time, then asked them to fill the query.

  <img src="ReadmeIMG\querying_1.png" style="zoom:33%;" />

  Fair enough, though none of them like the graphics. We are still currently working on both shaders after evaluation.

  <img src="ReadmeIMG\querying_2.png" style="zoom:33%;" />

  Good response, we want to make our game a bit hard since challenge will attract more people, we mean to design level that need good thinking skill relating to the game mechanic itself.

  <img src="ReadmeIMG\querying_3.png" style="zoom:30%;" />

  Level 9, 10 are most mentioned. Both levels are weird which is also confirmed by observational method. No just because they are hard, the design need improvement as well.

  <img src="ReadmeIMG\querying_4.png" style="zoom:30%;" />

  <img src="ReadmeIMG\querying_5.png" style="zoom:30%;" />

  Unexpectedly we only get 2.83 average rate of control, and most participants complain about the inertia force, however we didn't implement the inertia system so we should investigate the problem further.

  <img src="ReadmeIMG\querying_7.png" style="zoom:30%;" />

  We got two feedback that are not about the shooting mechanic. One is the bullet can pierce through lava which isn't seems to be rational, the other talks about the UI style.

  <img src="ReadmeIMG\querying_8.png" style="zoom:33%;" />

  <img src="ReadmeIMG\querying_9.png" alt="querying_9" style="zoom:30%;" />
  
  The objects seems to be clear enough to the user and they are quite happy with them. :smiling_face_with_three_hearts: We prepare a final open-end question. It is good to see some positive comments, and some are still the problems previously mentioned.

## Evaluation Discussion

- As stated earlier, several players stated that movement was an issue in both the observational and querying methods. This is likely due to the player's inertia being too prevalent and hence players felt the character would move too much even when only holding the movement keys for a short time
- It was also stated that the platforms were too small in both in the questionnaire and multiple times out loud. This point is likely due in part to the same inertia issue from earlier, however it could also be due to the massive speed difference players experience when using the dash boost, resulting in far less control.
- Another point players mentioned was the difficulty in switching fire modes. While some players were very vocal, others did not seem to mention it in the slightest. This may be because some players were not used to having to take their fingers off the A and D keys to hit the number keys.
- In regards to the issue of players missing key level-elements, it was surmised that players had a hard time as the colors of certain objects, such as doors, were not that dissimilar to the background colors.
- In regards to level-5, it is believed that the main source of difficulty was due to the fact that players found the timing of the moving platforms to be seemingly random and hence were confused about when/where to jump. Additionally, the timings seemed to overlap in a way that meant only 1 path was actually possible to complete, while other seemingly just at viable paths were not.
- In regards to the tutorial, we believe while many players did not express issue with the tutorial immediately, it was clear that there was some confusion when more unintuitive mechanics were introduced which were not in the tutorial. Additionally the images used to convey information in the tutorial might not have been obvious enough what they were conveying, which is especially important as we tried to minimize the use of text.

## Changes from Evaluation

**Level Changes**

- General Level and Object Changes
  - In response to players overshooting and/or running off platforms after landing on them, we decided to increase the size of platforms across all levels.
  - The Material Used for the Door objects was changed from a light gray to cyan. This should be much more eye-catching to the player, and hopefully mean it is noticed far earlier by the player.
  - Although this fix is specific to Level 11, the zoom function is added to some levels where the camera only partially cover the whole level to help player spot the exit more easily.
  - The spikes are given light orange colour to improve their visibility owing to the colour's bright property.
- Level-5 Changes
  - Firstly, the switch (which the player is supposed to hit) was moved from the bottom right corner of the screen
    to the bottom center of the screen, additionally the size of the switch was increased, addressing
    concerns relating to confusion regarding what to do to clear the level
  - Secondly, Players found the 2nd half of the level, where the player is supposed to ascend
    upwards after hitting the switch frustrating. This was likely due to inconsistent and seemingly random
    timings for the moving platforms, as a result the interval and speed of the platforms in the level were adjusted
    to produce a far more regular pattern
- Level-9 Changes
  - The moving platform script is edited such that it allows the platform to move only when the player has touched it, and that it only goes one way. Hence, the platforms in Level 9 can be adjusted such that they simulate "falling" platforms and makes the level easier to traverse.
- Level-10 Changes
  - The moving obstacles have now been replaced by static obstacles and additional platforms. These should lessen the player's confusion on how to ascend to the exit. In addition, the platforms would allow act as safeguards for falling player, to some degree.
  - The obstacle material has also been changed to a bright blue material to help with their visibility.
- Level-11 Changes
  - The level entities was reformed to remove unnecessary platforms and niches and make important objects more visible (such as the switch).
  - The background palette is made more pale and less vibrant to help with the visibility of the player's current position.

**Movement Changes**

- We decided to remove the inertia component of the player movement entirely to allow for better responsiveness and hence address sensitiveness experienced by player

**Control Changes**

- We now allow mouse scrolling to switch the bullet type, besides numkey. Allowing another option for players who find the number keys uncomfortable, but not alienating those who prefer the number keys.
- We now allow use TAB to zoom in or out, for player who need to see the whole stage. This hopefully will help players in the event they get confused where the exit is on larger stages
- Since players felt that the control was slippery we decided to modify the movement code to remove inertia, thus allowing the player to stop instantly. Increasing responsiveness.

**Tutorial Stage**

- We create an additional region teaching the use of switches, teaching the player about switches early.

  <img src="ReadmeIMG\changes_3.png" style="zoom: 67%;" />

- We redraw the switching key-map chart to be more clear that it is related to the number key. This was done due to the additional control scheme, and also to hopefully make it clearer that the numbers reference the number keys.

  *previous*

  <img src="ReadmeIMG\changes_2.png" style="zoom:30%;" />

  *now*

  <img src="ReadmeIMG\changes_1.png" style="zoom:30%;" />

**UI**

- Some participants complain they can't return to the title in the victory scene, so we create a return to title button there.

- To enhance the consistency, we change the texture of cube in title scene to make it match with other UI skin.

- To enhance the aesthetic consistency of the UI we also changed the look of the cursor.

  <img src="ReadmeIMG\changes_4.png" style="zoom:30%;" />



## Technologies
This project is created with:
* **Unity 2021.1.13f1**- Game Development
* **Visual Studio 2020** - Scripts
* **Visual Studio Code 2019**  - Scripts
* **Adobe Photoshop** - Graphic Design
* **Adobe Premiere** - Trailer/Video Editing
* **Blender** - Upscale Plane Creation
* **Google Forms** - Querying & Observational method
* **Google Docs** - Recording Notes for Observational method

## Resources Reference List

**Models, Textures, and Graphics Assets**

* Free Aircraft Pack: by Understone, https://assetstore.unity.com/packages/3d/vehicles/air/free-aircraft-pack-194025
* Sci-Fi Texture Pack 2: by Firebolt Studios, https://assetstore.unity.com/packages/2d/textures-materials/sci-fi-texture-pack-2-42026 
* Futuristic Panel Textures Lite: by TeenZombie Software, https://assetstore.unity.com/packages/2d/textures-materials/futuristic-panel-textures-lite-80176 
* Player Model (Attack Bot): by uiStudio, https://assetstore.unity.com/packages/3d/characters/robots/attack-bot-15120
* Lever Model (Lever Switch): by Sam Feng, https://sketchfab.com/3d-models/lever-power-switch-374608f75c114b8a9bf41dbc02c51c50 
* Spikes Model (Dungeon Traps): by Sugar Asset, https://assetstore.unity.com/packages/3d/environments/dungeons/dungeon-traps-50655
* Snaps Prototype | Sci-Fi / Industrial: by Asset Store Original, https://assetstore.unity.com/packages/3d/environments/sci-fi/snaps-prototype-sci-fi-industrial-136759
* Low Poly Rock Pack: by Broken Vector, https://assetstore.unity.com/packages/3d/environments/low-poly-rock-pack-57874
* Low Poly Tree Pack: by Broken Vector, https://assetstore.unity.com/packages/3d/vegetation/trees/low-poly-tree-pack-57866
* Sci-fi Floor Section KB005: by d880, https://sketchfab.com/3d-models/sci-fi-floor-section-kb005-dae262592f104564bc12ea3705e08810
* Security Cam: by tribalstone, https://www.turbosquid.com/3d-models/3d-model-security-cam/409106
* glass frosted 001: by Katsukagi, https://3dtextures.me/2020/08/27/glass-frosted-001/
* Sci-Fi GUI Skin: by 3d.rina, https://assetstore.unity.com/packages/2d/gui/sci-fi-gui-skin-15606
* Stylize Water Texture(Lava shader's Height map): by LowlyPoly, https://assetstore.unity.com/packages/2d/textures-materials/water/stylize-water-texture-153577#content
* Stylized Lava materials(Lava shader's Bump map): by Rob luo, https://assetstore.unity.com/packages/2d/textures-materials/stylized-lava-materials-180943
* Lava Flowing Shader(Lava shader's texture): by MoonFlower Carnivore, https://assetstore.unity.com/packages/vfx/shaders/lava-flowing-shader-33635#content
* Explosion.tif: by Tvtig, https://github.com/Tvtig/RocketLauncher/blob/main/Assets/Tvtig/Rocket%20Launcher/Art/Textures/Explosion/Explosion.tif
* Rexlia Font: https://www.dafont.com/rexlia.font
* Moai Images: https://www.npr.org/2018/06/07/618087324/how-did-easter-islanders-lift-statues-13-ton-hats-researchers-may-have-the-answe
* Cloud.png: https://www.freeiconspng.com/img/34472

**Sounds**

* Post Apocalypse Guns Demo: by Sound Earth Game Audio, https://assetstore.unity.com/packages/audio/sound-fx/weapons/post-apocalypse-guns-demo-33515
* Sneaky Driver: from Katana ZERO by Bill Kiley, LudoWic, https://www.youtube.com/watch?v=P196hEuA_Xc&t=345s
* Chinatown: from Katana ZERO by Bill Kiley, https://www.youtube.com/watch?v=P196hEuA_Xc&t=345s
* Kill Your TV: from Katana ZERO by Bill Kiley, https://www.youtube.com/watch?v=P196hEuA_Xc&t=345s
* You Will Never Know: from Katana ZERO by Bill Kiley, https://www.youtube.com/watch?v=P196hEuA_Xc&t=345s
* Quick jump arcade game: https://mixkit.co/free-sound-effects/game/
* Arcade space shooter dead notification: https://mixkit.co/free-sound-effects/game

**Tutorials used in creating the game**

- Creating Basic 3D Blast Effect in Unity: https://www.youtube.com/watch?v=SBE41lzlb-4
- How To Create An Explosion Effect In Unity: https://www.youtube.com/watch?v=cvQiQglPI18
- Creating Basic Particle Effects in Unity: https://www.youtube.com/watch?v=7hRWhnL1IVk&t=125s
- Displacement Maps: https://en.m.wikibooks.org/wiki/Cg_Programming/Unity/Displacement_Maps
- Texture Distortion: https://catlikecoding.com/unity/tutorials/flow/texture-distortion/
- Unity Refractive Shader - Creative Tinkering: http://tinkering.ee/unity/asset-unity-refractive-shader/
- Ice Refraction in Unity Shader Graph: https://www.youtube.com/watch?v=inht8WYX-A4&t=2s
- Unity screen effects overview 1 Gaussian blur: https://blog.titanwolf.in/a?ID=01500-3606b309-752d-4891-942a-57b4fe27451a
- unity shader normal mapping for bump mapping: https://www.fatalerrors.org/a/unity-shader-normal-mapping-for-bump-mapping.html

