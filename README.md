# Curved Keyboard for HoloLens

This repository contains an experimental port of the [Curved VR Keyboard][keyboard-url] for HoloLens.
![image]

## Requirements

* Unity 5.6.2f1
* HoloToolkit 1.5.7

## Usage

* Import HoloToolkit
    * The keyboard depends on the input system of the HoloToolkit. For your convenience, drop the InputManager prefab in your scene.
* Import the .unitypackage (see Releases) into your project
* Drop the Keyboard prefab into your scene

### ColorTheme.cs
Defines the theme for all buttons used in the keyboard. Predefined states are : `Default`, `Focused` and `Pressed`.

### KeyboardCreator.cs
Handles initialization and tap-delegation of keys. 

### KeyboardOutput.cs
Connects the input from the keyboard to a component that can display text.

[image]: ./External/ReadmeImages/keyboard.png 
[keyboard-url]: https://www.assetstore.unity3d.com/en/#!/content/77177