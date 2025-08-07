using UnityEngine;

namespace SimpleModMenu.Tabs
{
    internal class SettingsTab : Tab
    {
        public SettingsTab() : base("Settings")
        {
            // Initialize any settings-specific data here
        }
        // Override the DrawTab method to implement the settings tab UI
        public override void DrawTab()
        {
            base.DrawTab();
            GUILayout.Label("Settings Tab");
            GUILayout.Label("This is where you can adjust settings in the menu.");
        }
    }
}

