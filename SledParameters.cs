using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MelonLoader;
using UnityEngine;

namespace SimpleModMenu
{
    internal class SledParameters
    {
        private GameObject body;
        private GameObject sled;

        private MeshInterpretter meshInterpretter;

        public SledData sledData;

        public bool isInitialized = false;

        /// <summary>
        /// Initializes the sled parameters by finding the body and sled GameObjects.
        /// </summary>
        /// <returns>The IEnumerator</returns>
        public IEnumerator Initialize()
        {
            while (body == null)
            {
                FindBody();
                yield return null;
            }

            FindSled();
            if (sled == null)
            {
                MelonLogger.Warning("Sled was not found after body initialized.");
            }

            MelonLogger.Msg("Body found!");
            isInitialized = true;
        }

        /// <summary>
        /// Finds the body GameObject in the scene.
        /// </summary>
        public void FindBody()
        {
            this.body = GameObject.Find("Snowmobile(Clone)/Body");
        }

        /// <summary>
        /// Finds the sled GameObject by searching for its parent for the CharacterControlPoints class.
        /// </summary>
        public void FindSled()
        {
            if (body == null) return;

            foreach (Transform parent in body.transform)
            {
                if (parent.Find("CharacterControlPoints"))
                {
                    Melon<Core>.Logger.Msg("Found parent object: " + parent.gameObject.name);
                    this.sled = parent.gameObject;
                }
            }
        }

        /// <summary>
        /// Retrieves the sled data from the sled.
        /// </summary>
        public void GetSledData()
        {
            if (meshInterpretter == null)
            {
                Melon<Core>.Logger.Error("MeshInterpretter component not found on sled.");
                return;
            }
            this.sledData = new SledData();
            SledData.CopyValues(meshInterpretter, sledData.originalValues);
            SledData.CopyValues(meshInterpretter, sledData.newValues);
        }

        /// <summary>
        /// Applies the new sled parameters to the sled.
        /// </summary>
        public void Apply()
        {
            if (meshInterpretter == null)
            {
                Melon<Core>.Logger.Error("MeshInterpretter component not found on sled.");
                return;
            }
            SledData.CopyValues(sledData.newValues, meshInterpretter);
        }

        /// <summary>
        /// Retrieves the MeshInterpretter component from the sled's body GameObject.
        /// </summary>
        public void GetMeshInterpretter()
        {
            if (body == null)
            {
                Melon<Core>.Logger.Error("Body is null, cannot get MeshInterpretter.");
                return;
            }
            this.meshInterpretter = body.GetComponent<MeshInterpretter>();
            if (meshInterpretter == null)
            {
                Melon<Core>.Logger.Error("MeshInterpretter component not found on sled.");
            }
        }

        /// <summary>
        /// Reloads the sled parameters by finding the body and sled GameObjects again.
        /// </summary>
        public void Reload()
        {
            FindBody();
            if (body == null) { Melon<Core>.Logger.Error("Body not found during reload"); }
            FindSled();
            if (sled == null) { Melon<Core>.Logger.Error("Sled not found during reload"); }
        }

        /// <summary>
        /// Checks if the sled or body has changed since the last initialization.
        /// </summary>
        public void CheckIfSledChanged()
        {
            if (body == null || sled == null && isInitialized)
            {
                FindBody();
                FindSled();
                GetMeshInterpretter();
                GetSledData();
            }
        }

        /// <summary>
        /// Gets the sled GameObject.
        /// </summary>
        /// <returns>The gameobject</returns>
        public GameObject GetSled()
        {
            return sled;
        }

        /// <summary>
        /// Gets the body GameObject.
        /// </summary>
        /// <returns>The gameobject</returns>
        public GameObject GetBody()
        {
            return body;
        }
    }
}
