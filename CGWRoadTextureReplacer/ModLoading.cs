using UnityEngine;
using ICities;
using System.IO;
using System;

namespace CGWRoadTextureReplacer
{
    public class ModLoading : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            ModConfiguration config = Configuration<ModConfiguration>.Load();
            // Load the configuration
            replaceRoadTextures(config.RoadTheme);
            Debug.Log("valuexml: " + config.RoadTheme);
        }

        public void replaceRoadTextures(string roadtheme)
        {
            //string networkName = "Basic Road"; // replace with the one you want to edit
            String[] network_ids = { "1603991971",
                "1603990096",
                "1487570764",
                "1597844928",
            "1518295774"};
            String[] networks = {
                "1603991971.2L Road w/ Turn and Bike Ln (PL)_Data",
                "1603990096.2L Road w/ Turn and Bike Lanes_Data",
                "1487570764.2L Road with Buffered Bike Lane_Data",
                "1597844928.4L Road With Median Bus Lanes_Data",  ///make code to get rid of decals
                "1518295774.2L One-Way Car and Bus Road_Data"
            };

            for (int i =0; i<networks.Length; i++)
            {
                Material segmentMaterial = PrefabCollection<NetInfo>.FindLoaded(networks[i]).m_segments[0].m_segmentMaterial;
                Texture2D texture2D;
                if (File.Exists("tt/" + network_ids[i] + "_" + roadtheme + "_d.png"))
                {
                    texture2D = new Texture2D(1, 1);
                    texture2D.LoadImage(File.ReadAllBytes("tt/" + network_ids[i] + "_" + roadtheme + "_d.png"));
                    texture2D.anisoLevel = 16;
                    //turn on better esolution
                    segmentMaterial.SetTexture("_MainTex", texture2D);
                }
                else
                {
                    Debug.Log("replace failed");

                }
            }
           

            

        }
 

    }
}