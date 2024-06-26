# Visual Effects

* Visual Effects for Unity games
* Unity minimum version: **2020.3**
* Current version: **1.1.0**
* License: **MIT**
* Dependencies:
	- [com.actioncode.physics : 0.2.0](https://github.com/HyagoOliveira/Physics/tree/0.2.0)
	- [com.unity.shadergraph : 12.0.0](https://docs.unity3d.com/Packages/com.unity.shadergraph@12.0/changelog/CHANGELOG.html)

## Summary

Shaders, interfaces and components used for Visual Effects.

## How To Use

### Lit Highlighter Shader

This shader was created using Shader Graph. On your Material Inspector window, click on Shader and select Shader Graphs > Lit Highlighter.

You can set the Highlighted Color and Power at runtime using the [LitHighlighter](/Runtime/MaterialControllers/LitHighlighter.cs) component.

![Lit Highlighter Shader](/Docs~/LitHighlighterShader.png "Lit Highlighter Shader")

### Outline Shader

There are two versions for this shader: a Simple Lit and Unlit. All of them were created using HLSL and should be used only in the URP. On your Material Inspector window, click on Shader and select ActionCode > Outline > Simple Lit or Unlit.

You can set the Outlined Color and Thickness at runtime using the [Outline](/Runtime/MaterialControllers/Outline.cs) component.

![Outline Shader](/Docs~/OutlineShader.png "Outline Shader")

### Highlightable Detector

Use the [HighlightableDetector](/Runtime/HighlightableDetector.cs) component with [any implementation of a Caster](https://github.com/HyagoOliveira/Physics/tree/main/Runtime/Casters) to automatically highlight components implementing the [IHighlightable](/Runtime/IHighlightable.cs) interface, such as the LitHighlighter or Outline components.

### Sprite Scrolling Shader

Add a scrolling into your Sprites!

Create a Material and apply the `ActionCode/2D/Sprite-Unlit-Scrolling` or `ActionCode/2D/Sprite-Lit-Scrolling` Shader on it:

![Sprite Unlit Scrolling Material](/Docs~/SpriteUnlitScrolling_Material.png "Sprite Unlit Scrolling Material")

Set the Horizontal or/and Vertical Speed and use this Material into a Sprite Renderer or any Mesh Renderer. 

> It is necessary that your Source Texture **Wrap Mode** is set to **Repeat**.

![Scrolling Clouds](/Docs~/ScrollingClouds.gif "Scrolling Clouds")

### Sprite Distortion Shader

Add distortion into your Sprites similar to heat!

Create a Material and apply the `Shader Graph/Sprite-Distortion` Shader on it. Play with its properties.

To use it into the entire screen, add a Sprite Renderer using this Material as a child of your Camera:

![Heat Distortion](/Docs~/HeatDistortion.png "Heat Distortion Game Object")

![Volcano Entry](/Docs~/VolcanoEntry.gif "Volcano Entry")

### Sprite Emissive Shader

Add emissive properties into your Sprites!

Create a Material and apply the `Shader Graph/Sprite-Emissive` Shader on it.

![Cyber Space](/Docs~/CyberSpace.gif "Cyber Space")

_The emissive color on the highlighted background is changing using an Animation component_

## Installation

### Using the Package Registry Server

Follow the instructions inside [here](https://cutt.ly/ukvj1c8) and the package **ActionCode-VisualEffects** 
will be available for you to install using the **Package Manager** windows.

### Using the Git URL

You will need a **Git client** installed on your computer with the Path variable already set. 

- Use the **Package Manager** "Add package from git URL..." feature and paste this URL: `https://github.com/HyagoOliveira/VisualEffects.git`

- You can also manually modify you `Packages/manifest.json` file and add this line inside `dependencies` attribute: 

```json
"com.actioncode.visual-effects":"https://github.com/HyagoOliveira/VisualEffects.git"
```

---

**Hyago Oliveira**

[GitHub](https://github.com/HyagoOliveira) -
[BitBucket](https://bitbucket.org/HyagoGow/) -
[LinkedIn](https://www.linkedin.com/in/hyago-oliveira/) -
<hyagogow@gmail.com>