using SimpleModMenu.Tabs;   
using UnityEngine;

namespace SimpleModMenu
{
    internal class Ui
    {
        public bool menuOpen;
        public Color themeColor;

        private Rect menuRect;

        private int selectedTab = 0;
        private List<Tab> tabs = new List<Tab>();

        private SledParameters sledParams;

        public Ui()
        {
            this.menuOpen = false;

            Vector2 menuSize = new Vector2(800, 600);
            float x = Screen.width / 2 - menuSize.x / 2;
            float y = Screen.height / 2 - menuSize.y / 2;

            this.menuRect = new Rect(x, y, menuSize.x, menuSize.y);
            this.themeColor = new Vector4(1f, 0f, 0f, 1f); // Red

            initTabs();

        }

        private void initTabs()
        {
            tabs.Add(new SledParamenterTab(menuRect.size, new Vector2(0, 0), sledParams));
            tabs.Add(new EnvironmentTab(menuRect.size, new Vector2(0, 0)));
            tabs.Add(new FunTab(menuRect.size, new Vector2(0, 0)));
            tabs.Add(new SettingsTab(menuRect.size, new Vector2(0, 0)));
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

            GUI.Label(new Rect(menuRect.width / 2 - 100, menuRect.height - 40, 200, 20), "Made by Samisalami", centeredStyle);

            // Make the window draggable
            GUI.DragWindow(new Rect(0, 0, menuRect.width, 20));
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
            Rect tabContentRect = new Rect(0, 40, menuRect.width, menuRect.height - 40);
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
            this.tabs[tabs.FindIndex(tab => tab.title == "SledParameters")] = new SledParamenterTab(menuRect.size, new Vector2(0, 0), sledParams);
        }
    }
}
