# The lost reel
This is a unity game made for the  gamejam "Wanna Jam? 2023"<br> 
[5th of August 2023 - 14th of August 2023]

The lost reel is a 3D horror game, where you are being hunted by an un-human like creature. 
Even though you are being hunted, you try to find and collect the lost film reel.

## Team
* Bas, project lead & game developer
* Tatum, game developer & game designer
* Rick, game developer
* Dylan, game artist & game designer
* Mikey, musician & game artist
* Ruud, musician, gametester & game designer

## Bas:
### Monster AI
[Statemachine](Assets/Scripts/Framework/Statemachine/StateMachine.cs)<br>
[Base state](Assets/Scripts/Framework/Statemachine/BaseState.cs)<br>
[Monster statemachine](Assets/Scripts/NPC/MonsterStates/MonsterStateMachine.cs)<br>
[Monster base state](Assets/Scripts/Framework/Statemachine/MonsterBaseState.cs)<br><br>
[Idle state](Assets/Scripts/NPC/MonsterStates/IdleState.cs)<br>
[Wandering state](Assets/Scripts/NPC/MonsterStates/WanderingState.cs)<br>
[Seeking state](Assets/Scripts/NPC/MonsterStates/SeekingState.cs)<br>
[Chasing state](Assets/Scripts/NPC/MonsterStates/ChasingState.cs)<br>
[Killing state](Assets/Scripts/NPC/MonsterStates/KillState.cs)
### Monster spawner
[Chasing state](Assets/Scripts/Framework/MonsterSpawner.cs)

## Tatum
### Player controls
[Player movement](Assets/Scripts/Player/Movement/PlayerMovement.cs)<br>
[Camera controller](Assets/Scripts/Player/Movement/CameraController.cs)
### Menu's
[Menu controller](Assets/Scripts/UI/Menu's/MenuController.cs)<br>
[End animation](Assets/Scripts/UI/Menu's/EndAnimationScript.cs)<br>
[Back to mainmenu](Assets/Scripts/UI/Menu's/BackToMainMenu.cs)
### Music/sounds implementation
[Music system](Assets/Scripts/Framework/Music/MusicController.cs)<br>
[Sound effects system](Assets/Scripts/Framework/Music/SoundEffectsController.cs)
### Gameplay
[Lose condition](Assets/Scripts/UI/Menu's/MenuController.cs)<br>
[Win condition](Assets/Scripts/Framework/WinScreenController.cs)

## Rick
### Player controls
[Player movement](Assets/Scripts/Player/Movement/PlayerMovement.cs)<br>
[Camera controller](Assets/Scripts/Player/Movement/CameraController.cs)
### Collectable
[Collectable](Assets/Scripts/Enviorment/Collectable.cs)<br>
[Pickup](Assets/Scripts/Enviorment/Pickup.cs)<br>
[I pickup collectable](Assets/Scripts/Enviorment/IPickupCollectable.cs)
### UI
[Flashing text warning](Assets/Scripts/UI/TextUI/WarningText.cs)<br>
[Volume slider](Assets/Scripts/UI/Menu's/VolumeSlider.cs)<br>
[Mouse sensitivity](Assets/Scripts/UI/Menu's/VolumeSlider.cs)
### Monster AI
[Ceiling detection](Assets/Scripts/NPC/CeilingDetection/CeilingDetection.cs)

## Dylan
### The monster model & animations.
Image is coming soon.
### The enviorment, the whole cinema.
Image is coming soon.

## Mikey
### Movie tape model
Image is coming soon.
### Music & sound effects
Detailed list coming soon.

## Ruud
### Music & sound effects
Detailed list coming soon.
