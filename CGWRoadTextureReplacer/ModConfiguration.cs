using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGWRoadTextureReplacer
{
    [ConfigurationPath("CGWRoadTextureReplacer.xml")]
    public class ModConfiguration
    {
        public string RoadTheme { get; set; } = "default";

    }
}
