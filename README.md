# 🧩 SimpleModMenu
A in-game mod menu for Sledders using [MelonLoader](https://melonwiki.xyz/#/). Easily toggle, configure, and alter the game with the inbuilt features.

# 📦 Features
* 🧭 **In-Game UI** – Opens with a single key, no need to alt-tab.
* 🔘 **Toggle Mods On/Off** – Quickly enable or disable features.
* 🛠️ **Custom Actions** – Hook your mod’s functions into the menu.
* 🪶 **Lightweight** – Minimal performance impact.

# 🖥️ Requirements
* A working installation of [MelonLoader](https://melonwiki.xyz/#/) onto sledders
* .NET Framework compatibility

# 📂 Installation
1. Download the latest ```SimpleModMenu.dll``` from the Releases tab (or build it yourself).
2. Place the DLL into your game's ```mods/``` folder.
3. Launch the game – the menu will open with Right shift.

# 🎮 Usage
* Right shift – Open/close menu.
* Explore the different tabs that the menu has to offer.
* SimpleModMenu can be extended from other mods by using its static API.

# 🔧 Integration Example (C#)
To integrate your own mod, use the Simple mod menu API. Reference ```SimpleModMenu.dll``` in your mod and you are good to go.

Example of how to create a tab.
```cs
namespace SimpleModMenu;

class NewTab : Tab
{
    private float ExampleValue = 50f;
    public NewTab() : base("Tab name")
    {
        // Initialize the tab with any specific settings or UI elements.
    }
    public override void DrawTab()
    {
        // Implement the drawing logic for this tab.
        // Both GUILayout and inbuilt SimpleModMenu methods can be used here.

        base.DrawTab(); // Call the base method to ensure the tab is drawn correctly.

        GUILayout.Label("This is a new tab!");

        // Example button
        DrawButton("Click Me", () =>
        {
            MelonLogger.Msg("Button clicked in NewTab!");
        });

        // Example slider
        DrawSlider("Example Slider", ref ExampleValue, 0f, 100f);
    }
}
```

Example of how to register the created tab.
```cs
namespace SimpleModMenu;

class TestMod : MelonMod
{
    public override void OnApplicationStart()
    {
        API.RegisterTab(new NewTab());
    }
}
```

See the SimpleModMenu.API class for more integration options.

# 🧪 Development & Building
1. Clone the repository.
2. Reference ```MelonLoader.dll```, ```UnityEngine.dll```, and your game's assemblies.
3. Build using Visual Studio or your favorite IDE.
4. Output goes to your mods/ folder for testing.

# 🤝 Contributing
Pull requests are welcome! Feel free to fork the project and submit changes. For major changes, open an issue first to discuss what you’d like to change.

# 📄 License
MIT License – Do whatever you want, but please give credit.
