using MelonLoader;
using TestMod;
using UnityEngine;

[assembly: MelonInfo(typeof(SimpleModMenu.Core), "SimpleModMenu", "1.0.0", "Samisalami", null)]
[assembly: MelonGame("Hanki Games", "Sledders")]

namespace SimpleModMenu
{
    public class Core : MelonMod
    {
        private SledData sledData = new SledData();
        private Ui ui;

        public override void OnApplicationStart()
        {
            ui = new Ui(sledData);
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                ui.menuOpen = !ui.menuOpen;
                MelonLogger.Msg("Right Shift pressed, toggling menu: " + ui.menuOpen);
            }
        }

        public override void OnInitializeMelon()
        {
            MelonEvents.OnGUI.Subscribe(ui.DrawMenu, 100);
        }
    }
}