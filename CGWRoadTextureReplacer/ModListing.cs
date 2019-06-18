using ColossalFramework.UI;
using ICities;
using System;
using UnityEngine;

namespace CGWRoadTextureReplacer
{
    public class ModListing : IUserMod
    {
        public string Name
        {
            get { return "CGW Road Texture Replacer"; }
        }

        public string Description
        {
            get { return "Replace Textures for CGW Roads"; }
        }


        private static readonly string[] OptionLabels =
        {
            "Default",
            "American",
            "European"
        };

        private static readonly string[] OptionValues =
 {
            "default",
            "american",
            "european"
        };

        public void OnSettingsUI(UIHelperBase helper)
        {
            // Load the configuration
            ModConfiguration config = Configuration<ModConfiguration>.Load();
            ModLoading loadinginstuc = new ModLoading();

            // Small Roads
            int roadtexture = GetSelectedOptionIndex(config.RoadTheme);
            helper.AddDropdown("Texture Theme", OptionLabels, roadtexture, sel =>
            {
                // Change config value and save config
                config.RoadTheme = OptionValues[sel];
                Configuration<ModConfiguration>.Save();
                loadinginstuc.replaceRoadTextures(config.RoadTheme);
            });


        }

        // Returns the index number of the option that is currently selected
        private int GetSelectedOptionIndex(string value)
        {
            int index = Array.IndexOf(OptionValues, value);
            if (index < 0) index = 0;

            return index;
        }





        public void OnEnabled()
        {

            Debug.Log($"Testmod enabled. Version");
            if (UIView.GetAView() != null)
            {
                ExceptionPanel panel = UIView.library.ShowModal<ExceptionPanel>("ExceptionPanel");
                panel.SetMessage("Reminder", "Be sure to change the road texture in the settings!", false);
            }
            else
            {
                Debug.Log($"elseload");
            }



        }

    }

    }

