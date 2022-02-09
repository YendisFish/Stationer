using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DSharpPlus;
using DSharpPlus.Entities;
using Stationer.Types;

namespace Stationer.Controllers
{
    public class StartupInfo
    {
        public ProgramData? programdata { get; set; }

        public StartupInfo(ProgramData? data)
        {
            this.programdata = data;
        }
    }

    internal class StartupController
    {
        public static async Task<StartupInfo> StartupWorker()
        {
            if(!Directory.Exists(Path.Join(Environment.CurrentDirectory + "/Statitoner/")))
            {
                Directory.CreateDirectory(Path.Join(Environment.CurrentDirectory + "/Statitoner/"));
            }

            return new StartupInfo(await GetProgramData());
        }

        public async static Task<ProgramData?> GetProgramData()
        {
            if(Directory.Exists(Path.Join(Environment.CurrentDirectory + "/Statitoner/")))
            {
                DirectoryInfo dir = new DirectoryInfo(Path.Join(Environment.CurrentDirectory + "/Statitoner/"));
                foreach(FileInfo file in dir.GetFiles())
                {
                    if(file.Name == "Appsettings.json")
                    {
                        ProgramData? ret = JsonConvert.DeserializeObject<ProgramData?>(await File.ReadAllTextAsync(file.FullName));
                        return ret;
                    }
                }
            }

            return null;
        }
    }
}
