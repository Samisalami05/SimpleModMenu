using UnityEngine;

namespace SimpleModMenu.Tabs
{
    internal class SettingsTab : Tab
    {
        public SettingsTab(Vector2 size, Vector2 position) : base("Settings", size, position)
        {
            // Initialize any settings-specific data here
        }
        // Override the DrawTab method to implement the settings tab UI
        public override void DrawTab()
        {
            base.DrawTab();
            GUILayout.Label("Settings Tab");
            GUILayout.Label("This is where you can adjust settings for the mod.");
        }
    }
}

