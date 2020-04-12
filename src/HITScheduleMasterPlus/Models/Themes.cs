using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HITScheduleMasterPlus.Models
{
    public static class Themes
    {
        public enum ThemeEnum
        {
            bootstrap,
            cerulean,
            cyborg,
            flatly,
            litera,
            lux,
            minty,
            sandstone,
            sketchy,
            solar,
            superhero,
            yeti,
            cosmo,
            darkly,
            journal,
            lumen,
            materia,
            pulse,
            simplex,
            slate,
            spacelab,
            united
        }
        public static string GetThemeCss(this ThemeEnum theme)
            => $"/lib/bootswatch/dist/{theme}/bootstrap.min.css";
    }
}
