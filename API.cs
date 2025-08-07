using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleModMenu
{
    /// <summary>
    /// API class for managing custom tabs in the mod menu.
    /// </summary>
    /// <remarks>
    /// This class provides methods to register, unregister, and manage custom tabs in the mod menu.
    /// </remarks>
    internal static class API
    {
        private static readonly List<Tab> customTabs = new List<Tab>();

        /// <summary>
        /// Registers a custom tab to the API.
        /// </summary>
        /// <param name="tab">The tab</param>
        /// <exception cref="ArgumentNullException">Thrown if tab is null</exception>
        public static void RegisterTab(Tab tab)
        {
            if (tab == null)
            {
                throw new ArgumentNullException(nameof(tab), "Tab cannot be null.");
            }
            customTabs.Add(tab);
        }

        /// <summary>
        /// Unregisters a custom tab from the API.
        /// </summary>
        /// <param name="tab"> The tab to unregister.</param>
        /// <exception cref="ArgumentNullException">Thrown if tab is null</exception>
        public static void UnregisterTab(Tab tab)
        {
            if (tab == null)
            {
                throw new ArgumentNullException(nameof(tab), "Tab cannot be null.");
            }
            customTabs.Remove(tab);
        }

        /// <summary>
        /// Unregisters a custom tab from the API.
        /// </summary>
        /// <param name="index"> The index of the tab to unregister.</param>
        /// <exception cref="ArgumentNullException">Thrown if index is out of bounds</exception>
        public static void UnregisterTab(int index)
        {
            if (index < 0 || index >= customTabs.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
            customTabs.RemoveAt(index);
        }

        /// <summary>
        /// Checks if a tab is registered in the API.
        /// </summary>
        /// <param name="tab">The tab</param>
        /// <returns>True if tab is registered, else false.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsTabRegistered(Tab tab)
        {
            if (tab == null)
            {
                throw new ArgumentNullException(nameof(tab), "Tab cannot be null.");
            }
            return customTabs.Contains(tab);
        }

        /// <summary>
        /// Gets all registered tabs in the API.
        /// </summary>
        /// <returns>The tabs as a IEnumerable</returns>
        public static IEnumerable<Tab> GetTabs()
        {
            return customTabs;
        }

        /// <summary>
        /// Gets the count of registered tabs in the API.
        /// </summary>
        /// <returns>The count</returns>
        public static int GetTabCount()
        {
            return customTabs.Count;
        }

        /// <summary>
        /// Gets a tab in the API by its index.
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The tab</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if index is out of bounds</exception>
        public static Tab GetTab(int index)
        {
            if (index < 0 || index >= customTabs.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
            return customTabs[index];
        }

        /// <summary>
        /// Replaces a tab in the API at the specified index with a new tab.
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="newTab">The new tab</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if index is out of bounds</exception>
        /// <exception cref="ArgumentNullException">Thrown if the new tab is null</exception>
        public static void ReplaceTab(int index, Tab newTab)
        {
            if (index < 0 || index >= customTabs.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
            if (newTab == null)
            {
                throw new ArgumentNullException(nameof(newTab), "New tab cannot be null.");
            }
            customTabs[index] = newTab;
        }

        /// <summary>
        /// Clears all registered tabs in the API.
        /// </summary>
        public static void ClearTabs()
        {
            customTabs.Clear();
        }
    }
}
