using Harmony;
using MelonLoader;
using SimpleModMenu;
using SimpleModMenu.Tabs;
using Unity.VisualScripting;
using UnityEngine;

[assembly: MelonInfo(typeof(SimpleModMenu.Core), "SimpleModMenu", "2.0.0", "Samisalami", null)]
[assembly: MelonGame("Hanki Games", "Sledders")]

namespace SimpleModMenu
{
    public class Core : MelonMod
    {
        private SledParameters sledParams;
        private Ui ui;

        private string sceneName = "";

        public static int selectedTab = 0;

        public override void OnApplicationStart()
        {
            ui = new Ui();
            InitTabs();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            this.sceneName = sceneName;
            if (IsGarageScene()) return;

            sledParams = new SledParameters();
            MelonCoroutines.Start(sledParams.Initialize());
        }

        public override void OnUpdate()
        {
            // 
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                ui.menuOpen = !ui.menuOpen;
                if (!IsGarageScene())
                {
                    Cursor.visible = ui.menuOpen;
                }
            }
            
            if (IsGarageScene()) return;

            if (sledParams != null && sledParams.sledData != null)
            {
                sledParams.CheckIfSledChanged();
            }

            if (sledParams != null && sledParams.isInitialized && sledParams.sledData == null)
            {
                MelonLogger.Msg("Sled Parameters initialized, fetching sled data...");
                sledParams.GetMeshInterpretter();
                sledParams.GetSledData();

                if (sledParams.sledData != null) 
                    UpdateSledParams();
            }
        }

        private bool IsGarageScene()
        {
            return sceneName == "TitleScreen" || sceneName == "Garage" || sceneName == "LoadingScene";
        }

        private void InitTabs()
        {
            Rect menuRect = Ui.GetMenuRect();
            API.RegisterTab(new SledParamenterTab(sledParams));
            API.RegisterTab(new EnvironmentTab());
            API.RegisterTab(new FunTab());
            API.RegisterTab(new SettingsTab());
        }

        private void UpdateSledParams()
        {
            int i = 0;
            foreach (Tab tab in new List<Tab>(API.GetTabs()))
            {
                if (tab.title == "SledParameters")
                {
                    API.ReplaceTab(i, new SledParamenterTab(sledParams));
                }
                i++;
            }
        }

        public override void OnInitializeMelon()
        {
            MelonEvents.OnGUI.Subscribe(ui.DrawMenu, 100);
        }
    }
}