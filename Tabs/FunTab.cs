using UnityEngine;

namespace SimpleModMenu.Tabs
{
    internal class FunTab : Tab
    {
        public FunTab() : base("Fun")
        {
            // Initialize any fun-specific data here
        }
        // Override the DrawTab method to implement the fun tab UI
        public override void DrawTab()
        {
            base.DrawTab();
            GUILayout.Label("Fun Tab");
            GUILayout.Label("This is where you can add fun features.");
        }
    }
}
