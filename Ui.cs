using SimpleModMenu.Tabs;   
using UnityEngine;

namespace SimpleModMenu
{
    internal class Ui
    {
        public bool menuOpen;
        public Vector2 menuSize;
        public Vector2 menuPos;
        public Color themeColor;

        private Rect menuRect;

        private int selectedTab = 0;
        private List<Tab> tabs = new List<Tab>();

        private SledParameters sledParams;

        public Ui()
        {
            this.menuOpen = false;
            this.menuSize = new Vector2(800, 600);
            this.menuPos = new Vector2(Screen.width / 2 - menuSize.x / 2, Screen.height / 2 - menuSize.y / 2);
            this.menuRect = new Rect(menuPos.x, menuPos.y, menuSize.x, menuSize.y);
            this.themeColor = new Vector4(1f, 0f, 0f, 1f); // Red

            initTabs();

        }

        private void initTabs()
        {
            tabs.Add(new SledParamenterTab(new Vector2(800, 600), new Vector2(0, 0), sledParams));
            tabs.Add(new EnvironmentTab(new Vector2(800, 600), new Vector2(0, 0)));
            tabs.Add(new FunTab(new Vector2(800, 600), new Vector2(0, 0)));
            tabs.Add(new SettingsTab(new Vector2(800, 600), new Vector2(0, 0)));
        }

        public void DrawMenu()
        {
            if (!menuOpen) return;

            menuRect = GUI.Window(1, menuRect, DrawMenuWindow, "Simple Mod Menu");
        }

        private void DrawMenuWindow(int windowID)
        {
            GUIStyle centeredStyle = new GUIStyle(GUI.skin.label);
            centeredStyle.alignment = TextAnchor.MiddleCenter;

            DrawTabs();

            GUI.Label(new Rect(menuSize.x / 2 - 100, menuSize.y - 40, 200, 20), "Made by Samisalami", centeredStyle);

            // Make the window draggable
            GUI.DragWindow(new Rect(0, 0, menuSize.x, 20));
        }

        private void DrawTabs()
        {
            GUILayoutOption gUILayoutOption = GUILayout.MinHeight(40);

            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.fontSize = 20;


            GUILayout.BeginHorizontal();
            for (int i = 0; i < tabs.Count; i++)
            {
                if (GUILayout.Button(tabs[i].title, buttonStyle, gUILayoutOption))
                {
                    selectedTab = i;
                }
            }
            GUILayout.EndHorizontal();

            DrawTabContent();
        }

        private void DrawTabContent()
        {
            Rect tabContentRect = new Rect(0, 40, menuSize.x, menuSize.y - 40);
            GUI.BeginGroup(tabContentRect);
            
            // Draw the content of the selected tab
            if (selectedTab >= 0 && selectedTab < tabs.Count)
            {
                tabs[selectedTab].DrawTab();
            }
            GUI.EndGroup();
        }

        public void setSledParams(SledParameters sledParams)
        {
            this.sledParams = sledParams;
            this.tabs[tabs.FindIndex(tab => tab.title == "SledParameters")] = new SledParamenterTab(new Vector2(800, 600), new Vector2(0, 0), sledParams);
        }
    }
}
