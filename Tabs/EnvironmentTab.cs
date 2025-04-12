using UnityEngine;

namespace SimpleModMenu.Tabs
{
    internal class EnvironmentTab : Tab
    {
        public EnvironmentTab(string title, Vector2 size, Vector2 position) : base(title, size, position)
        {
            // Initialize any environment-specific data here
        }
        // Override the DrawTab method to implement the environment tab UI
        public override void DrawTab()
        {
            // Draw the environment tab UI here
            // You can use GUILayout and other Unity UI elements to create the environment interface
            GUILayout.Label("Environment Tab");
            GUILayout.Label("This is where you can adjust environment settings.");
        }
    }
}
