"# DREAM-Digital-Twin-Capstone-Project" 


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
