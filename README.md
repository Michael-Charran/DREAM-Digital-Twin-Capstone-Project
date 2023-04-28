"# DREAM-Digital-Twin-Capstone-Project" 

        1) Action-Based Continuous Turn Provider script
This script provides a continuous turn locomotion feature for XR rigs that allows the user to smoothly rotate the rig over time. It uses input actions from the Unity Input System to determine the desired turn direction and speed.

Usage
Attach the ActionBasedContinuousTurnProvider component to the XR rig game object.
Assign the InputAction for the left hand turn control and the InputAction for the right hand turn control in the inspector.
Ensure that both InputActions are Value Vector2 controls.
When the InputActions are triggered, this script reads the values and adds them together to determine the desired turn direction and speed.
Code Overview
The ActionBasedContinuousTurnProvider script inherits from ContinuousTurnProviderBase to implement the continuous turn locomotion. It also uses the Unity Input System to read input values.

The leftHandTurnAction and rightHandTurnAction properties are InputActionProperty objects that are used to read input values from the left and right hand controllers.

The ReadInput() method reads the input values from both controllers and adds them together to determine the desired turn direction and speed.

The SetInputActionProperty() method is used to set the InputActionProperty objects and enable/disable them when needed.

      
        2) ActionBasedContinuousMoveProvider script
This is a locomotion provider for Unity's XR Interaction Toolkit that allows the user to move their rig smoothly using a specified input action. It is designed to work with the Input System package in Unity.

Installation
Import the Input System package into your Unity project.
Import the XR Interaction Toolkit package into your Unity project.
Add the ActionBasedContinuousMoveProvider script to a GameObject in your scene.
Usage
Create an Input Action asset in Unity's Input System package that uses a Value Vector2 Control to represent the desired move direction. You can assign this action to the leftHandMoveAction and rightHandMoveAction properties in the inspector of the ActionBasedContinuousMoveProvider script.
Assign the ActionBasedContinuousMoveProvider script to a GameObject in your scene.
Use the assigned input action to move your rig smoothly in the desired direction.
Properties
leftHandMoveAction: The Input System Action that Unity uses to read move data from the left hand controller. Must be a Value Vector2 Control.
rightHandMoveAction: The Input System Action that Unity uses to read move data from the right hand controller. Must be a Value Vector2 Control.
Methods
OnEnable(): Called when the script becomes enabled. Enables the left and right hand input actions.
OnDisable(): Called when the script becomes disabled. Disables the left and right hand input actions.
ReadInput(): Reads the input from the left and right hand input actions and returns the combined direction vector.
SetInputActionProperty(): Helper method to set the input action properties and enable/disable the actions as needed.
Additional Information
This script is based on the ContinuousMoveProviderBase class in the XR Interaction Toolkit.
This script is compatible with Unity version 2019.4 or higher.

  
                                                                HANDS (just until script 4)
        3) AnimateHandOnInput script
The AnimateHandOnInput script is a simple script that allows you to animate a hand model in Unity based on input from an input device such as a gamepad, joystick or a keyboard. The script is designed to be attached to a hand model in your Unity scene and requires an Animator component to be present on the hand model.

Usage
Attach the AnimateHandOnInput script to a hand model in your Unity scene.
Drag and drop an Animator component onto the handAnimator field in the AnimateHandOnInput script in the Inspector.
Create two Input System Actions (one for pinch animation and one for grip animation) and assign them to the pinchAnimationAction and gripAnimationAction fields in the AnimateHandOnInput script in the Inspector.
Set up the Animator Controller for the hand model to use the Trigger and Grip parameters to control the appropriate animations.
Code
The AnimateHandOnInput script uses the InputActionProperty class to allow you to easily assign the input actions for pinch and grip animations to the script through the Inspector. In the Update() method, the script reads the values of the input actions and sets the appropriate float parameters on the Animator component to control the animations.

Requirements
This script requires the Input System package to be installed in your Unity project. You can install it through the Unity Package Manager.

        4) XRPokeInteractor script
XRPokeInteractor is an XRBaseInteractor that can be used to interact with interactables through poking. This interactor can evaluate the depth and width of an interaction to determine if it should be considered a poke, poke select, or poke hover.

This component implements IUIInteractor, allowing it to be used for UI interaction. It also has a requirePokeFilter flag that can be used to only include objects with a XRPokeFilter.

Setup
Attach the XRPokeInteractor component to a GameObject.
Set the desired parameters in the inspector.
Properties
Poke Parameters
pokeDepth: The depth threshold within which an interaction can begin to be evaluated as a poke. Default value is 0.1.
pokeWidth: The width threshold within which an interaction can begin to be evaluated as a poke. Default value is 0.0075.
pokeSelectWidth: The width threshold within which an interaction can be evaluated as a poke select. Default value is 0.015.
pokeHoverRadius: The radius threshold within which an interaction can be evaluated as a poke hover. Default value is 0.015.
pokeInteractionOffset: Distance along the poke interactable interaction axis that allows for a poke to be triggered sooner/with less precision. Default value is 0.005.
Physics Parameters
physicsLayerMask: Physics layer mask used for limiting poke sphere overlap. Default value is Physics.AllLayers.
physicsTriggerInteraction: Determines whether the poke sphere overlap will hit triggers. Default value is QueryTriggerInteraction.Ignore.
Poke Filter
requirePokeFilter: Denotes whether or not valid targets will only include objects with a poke filter. Default value is true.
UI Interaction
enableUIInteraction: When enabled, this allows the poke interactor to hover and select UI elements. Default value is true.
Debug Visualization
debugVisualizationsEnabled: Denotes whether or not debug visuals are enabled for this poke interactor. Debug visuals include two spheres to display whether or not hover and select colliders have collided. Default value is false.

       5) Lamp2 script
This code is a script for a lamp in the Unity game engine.

Setup
To use this script, you will need to create a GameObject in your Unity scene and attach the Lamp2 script to it. The LampLight, DomeOff, and DomeOn variables should be assigned to the appropriate game objects in your scene.

Functionality
The Lamp2 script provides two ways to turn the lamp on and off. The first is by calling the OnButtonClick method, which sets the TurnOn boolean to true, turning the lamp on. The second is by calling the TurnOnLamp method, which toggles the value of TurnOn, turning the lamp on if it was off and turning it off if it was on.

When the Update method is called, the script checks the value of TurnOn. If it is true, the LampLight GameObject is set to active, while the DomeOff and DomeOn GameObjects are set to inactive and active, respectively. If TurnOn is false, the LampLight GameObject is set to inactive, while the DomeOff and DomeOn GameObjects are set to active and inactive, respectively.

Conclusion
This Lamp2 script provides a simple way to add lamp functionality to a Unity game object. With the ability to turn the lamp on and off through two different methods, you can easily create an interactive scene with lighting effects.

        6) LampController script 
IFTTT Event Trigger
This is a simple Unity script that sends a web request to trigger an event in IFTTT when the space bar is pressed.

Requirements
This script requires Unity version 2018.3 or higher.

Setup
Before using the script, you need to create an applet in IFTTT with a webhook trigger and an action of your choice. Replace the placeholders in the script with your actual IFTTT key and event name.

Usage
Attach the script to a game object in your Unity scene. Press the space bar to trigger the IFTTT event. You can also call the TriggerIFTTTEvent() function from other scripts to trigger the event programmatically.

        7)SceneScript script
SceneScript is a simple script for loading scenes in Unity. It contains a single method LoadScene that takes in a string parameter sceneName which is the name of the scene you want to load.

Installation
Download the SceneScript.cs file.
Open your Unity project.
In the project window, navigate to the Assets folder and create a new folder called Scripts.
Drag and drop the downloaded SceneScript.cs file into the Scripts folder.
Usage
Attach the SceneScript to a GameObject in your scene.
In the inspector, add the name of the scene you want to load to the sceneName parameter of the LoadScene method.
Create a button in your UI and add an OnClick event to it.
Drag and drop the GameObject with the SceneScript attached to the OnClick event.
Select the LoadScene method from the dropdown menu.
Enter the name of the scene you want to load in the sceneName parameter.
Example
Suppose you have two scenes in your project: MainMenu and Game. You want to create a button in the MainMenu scene that loads the Game scene when clicked.

Create a new GameObject in the MainMenu scene and name it SceneLoader.
Attach the SceneScript to the SceneLoader GameObject.
In the inspector, set the sceneName parameter of the LoadScene method to "Game".
Create a UI button in your MainMenu scene.
Add an OnClick event to the button.
Drag and drop the SceneLoader GameObject to the OnClick event.
Select the LoadScene method from the dropdown menu.
Save your scene and run the game.
Click the button and the Game scene should load.

        8)SceneSelector script
SceneSelector is a script for a Unity project that allows the user to select a scene to load from a dropdown menu and then load it by clicking a button.

How to Use
Attach the SceneSelector script to a GameObject in your Unity scene.

Create a Dropdown object in your scene and assign it to the sceneDropdown variable of the SceneSelector script.

Create a Button object in your scene and assign it to the loadButton variable of the SceneSelector script.

Add the names of the scenes you want to load to the options of the dropdown menu.

Click the load button to load the selected scene.

Dependencies
UnityEngine
UnityEngine.SceneManagement
UnityEngine.UI

        9) StartScreenUI script
This script is used for managing the start screen UI of a game. It consists of a dropdown menu that allows the user to select a level, and a button that starts the game with the selected level.

Dependencies
This script requires the following dependencies:

UnityEngine
UnityEngine.UI
UnityEngine.SceneManagement
Public Variables
This script contains two public variables:

levelDropdown: a dropdown UI element that lists the available levels for the game.
startButton: a button UI element that starts the game when clicked.
Private Methods
Start(): Populates the dropdown with the available scenes and adds a listener to the start button.
StartGame(): Loads the selected scene from the dropdown and starts the game.
Usage
Attach this script to a UI game object that represents the start screen of the game.
Add a dropdown UI element to the game object and assign it to the levelDropdown variable of this script.
Add a button UI element to the game object and assign it to the startButton variable of this script.
Build the scenes of the game and ensure that they are added to the build settings in Unity.
Run the game and the start screen should show up.

        10) ButtonFollowVisual script
This script is a component for Unity's XR Interaction Toolkit that allows a button to follow the movement of a poking interactor in virtual reality. It is useful for creating interactive objects that can be pushed, prodded, and manipulated by the user.

Dependencies
Unity's XR Interaction Toolkit
A poking interactor (such as an XRController or XRDirectInteractor)
Usage
Attach this script as a component to a GameObject containing a child transform that will represent the button's visual.
Assign the visualTarget variable to the transform of the child visual.
Assign the localAxis variable to the axis along which the button should move (e.g. Vector3.up for a button that moves vertically).
Attach an XRBaseInteractable component to the GameObject.
Add listeners to the XRBaseInteractable's events for hoverEntered, hoverExited, and selectEntered that call the Follow, Reset, and Freeze methods respectively.
Methods
Follow(BaseInteractionEventArgs hover)
This method is called when the poking interactor begins hovering over the button. It sets the isFollowing flag to true and sets the pokeAttachTransform and offset variables.

Reset(BaseInteractionEventArgs hover)
This method is called when the poking interactor stops hovering over the button. It sets the isFollowing flag to false.

Freeze(BaseInteractionEventArgs hover)
This method is called when the poking interactor selects the button. It sets the freeze flag to true, which prevents the button from moving.

Update()
This method is called once per frame and moves the button's visual towards the poking interactor if it is being followed. If it is not being followed, it smoothly resets the button's position to its initial position.

*******************
Save Load Subsystem 

Script:Assets/Scripts/LevelFileManager.cs
** IMPORTANT **
if there is a lot of errors you might need to rebuild the assetbundles, Menue option to click is Assets/BuildAssetBundles, must be done every time you create a new asset bundle or edit an existing asset bundle.
AssetBundles should be able to properly load everything, may want to look at doing some actual dependency management, but building the assetBundle automatically includes all dependencies including scripts/ materials/ etc.

ALSO, Right now the save load methods are only being called in the void start method linked to the level file manager object that exists in some scenes, This should be relatively easy to link those method calls to anywhere else I believe.
****
Feature Description:
objects that can be saved and loaded have the following prerequisites:
1. Be a prefab
2. Be included in an AssetBundle
3. Be tagged with the roomObject tag in the scene
#may need to be added? include a component to store AssetBundle name if needed
#not all important assets are prefabs yet so if something doesn't load check that first

saveToFile(@param LevelName): calls find roomObjects, populates arrays of necessary data to store for loading, writes arrays to a new levelData object, uses JSONUtility to write the levelData object to a json file named levelName.
# Saves Rotation, Position, AssetName, and a right now hardcoded AssetBundleName
# Does not save asset scale modifiers out of the transform
# Loads the original prefab meaning duplicates with a different material must be made into a new prefab
#currently uses persistent filepath so saved level JSON files are not included in the project directory, so you won't be able to load anything without saving it yourself first, my apologies.

#LevelName is right now defaulted to the current scene name when saving a level.

loadFromFile(@param LevelName) loads a levelData object from the JSON file in the persistentfilepath folder named LevelName.json, then calls populateScene method to begin instantiating prefabs to rebuild the room. First looking through the list and loading Every AssetBundle that is included in the list exactly once. 
#Loads all saved data out of the file, will need to be modified to save more data potentially
#some stuff I didn't make into a prefab yet like buttons, lighting objects, and the xr origin & hands
#Load method onny properly works with objects that meet the prerequisites.
#AssetBundle Memory Management code within the populateScene method is not tested very well and I don't think unloads assetBundles currently when moving to a new scene, Memory management with assetbunds has to be done manually in the script.

Relevant Documentation Links:
https://docs.unity3d.com/Manual/AssetBundlesIntro.html
https://docs.unity3d.com/Manual/InstantiatingPrefabs.html