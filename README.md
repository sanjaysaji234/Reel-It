# Hook Line

**Hook Line** is a 3D fishing simulation developed in Unity. The project emphasizes physics-based gameplay, a polished user interface, and clean software architecture. This was developed as a technical assessment for the KALP Studio internship.

---

## 🛠 Technical Architecture

### 1. State-Driven Gameplay
The game logic is managed via a modular **State Machine** (Idle, Waiting, Bite, Reeling, Result). This architecture ensures high stability by preventing input conflicts and ensuring physics only activate when the player has successfully hooked a fish.

### 2. Event-Based UI (Decoupling)
I utilized a decoupled architecture using **C# Events** (`OnFishCaught`). 
* The `Fishing.cs` script handles the heavy lifting of physics and rarity logic.
* The `FishCounter.cs` listens for events to update the UI.
This minimizes dependencies and makes the codebase easier to scale and maintain.

### 3. Universal Audio & Data Persistence
To ensure a consistent experience across scenes:
* **Audio Mixer:** Implemented a global Audio Mixer with exposed parameters. Volume is controlled via a logarithmic formula (`Mathf.Log10`) to match human auditory perception.
* **PlayerPrefs:** User preferences (Volume, Graphics Quality) and gameplay statistics (Fish Counts) are saved to the system registry, ensuring settings persist between game sessions.

### 4. Asynchronous Loading
Smooth transitions are handled via `SceneManager.LoadSceneAsync`. A custom Coroutine manages a loading bar that normalizes Unity's internal loading progress, providing a seamless transition from the Menu to the Game scene.

---

## 🎣 Mechanics & Physics

* **Tension Reeling:** A physics-driven "Sweet Spot" mechanic where players must balance upward force against gravity. The needle’s "slippery" feel is achieved by tuning Rigidbody mass and linear damping.
* **Rarity Logic:** Fish are categorized into Common, Uncommon, and Rare pools. Each rarity dynamically adjusts the difficulty timers for rod breakage and fish escape.

---

## 🎨 Assets & Tools
* **3D Models:** Self made in Blender
* **Water:** https://assetstore.unity.com/packages/vfx/shaders/urp-stylized-water-shader-proto-series-187485
* **UI:** https://assetstore.unity.com/packages/2d/gui/icons/2d-casual-ui-hd-82080
* **Audio:** [[Sourced sound effects routed through a centralized Master Mixer.](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116)](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116)
* **Version Control:** Managed via Git and GitHub Desktop.

---

## 🚀 Future Roadmap
If given more time, I would focus on:
* **Progression System:** A shop where players can use caught fish to upgrade their rod's durability and reel speed.
* **Visual Polish:** Adding 3D particle effects for water splashes and haptic feedback during the "Bite" state. 

---

## 🎮 How to Run
1. Clone the repository.
2. Open the project in **Unity 2022.3** or higher.
3. Open the `MainMenu` scene.
4. Ensure both `MainMenu` and `FishingScene` are included in the **Build Settings**.
5. Press **Play** to start.

---

## 🎮 How to Run Game Directly
https://drive.google.com/file/d/1rKGvg273LgehSvs6tdJBpbou8FyQPj54/view?usp=sharing
Download the Zip File and rune the exe file.

---

**Developed by:** Sanjay Saji  
*4th Semester CS Student | Delhi Technical Campus*
