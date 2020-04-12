using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HITScheduleMasterPlus.Models
{
    public class Settings
    {
        public static Settings CurrentSetting { get; set; }

        internal static async Task Load()
        {
            try
            {
                if (File.Exists("user.settings.json"))
                {
                    CurrentSetting =
                        JsonConvert.DeserializeObject<Settings>(await File.ReadAllTextAsync("user.setting.json"));
                }
                else
                {
                    CurrentSetting = new Settings();
                    await SaveConfig();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        internal static async Task SaveConfig()
        {
            try
            {
                await File.WriteAllTextAsync("user.setting.json",
                    JsonConvert.SerializeObject(CurrentSetting));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Themes.ThemeEnum Theme { get; set; } = Themes.ThemeEnum.cosmo;

    }
}
