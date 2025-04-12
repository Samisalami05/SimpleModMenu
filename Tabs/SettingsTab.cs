using UnityEngine;

namespace SimpleModMenu.Tabs
{
    internal class SettingsTab : Tab
    {
        public SettingsTab(string title, Vector2 size, Vector2 position) : base(title, size, position)
        {
            // Initialize any settings-specific data here
        }
        // Override the DrawTab method to implement the settings tab UI
        public override void DrawTab()
        {
            // Draw the settings tab UI here
            // You can use GUILayout and other Unity UI elements to create the settings interface
            GUILayout.Label("Settings Tab");
            GUILayout.Label("This is where you can adjust settings for the mod.");
        }
    }
}

