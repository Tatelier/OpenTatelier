using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatelier.SongSelect;

namespace Tatelier
{
    public class ScoreSaveDataDecryptor
    {
        public bool HasDecryptRole = false;

        public string PlayerName = "";

        public void ExecuteFromSaveData(string inputFilePath)
        {
            string outputFilePath = Path.Combine(Path.GetDirectoryName(inputFilePath), Path.GetFileNameWithoutExtension(inputFilePath) + "_Decrypt.json");

            Execute(inputFilePath, outputFilePath);
        }

        void Execute(string inputFilePath, string outputFilePath)
        {
            var mssd = new MusicalScoreSaveData();
            mssd.Load(inputFilePath);
            mssd.Save(outputFilePath, false, Hjson.Stringify.Formatted);
            LogWindow.Singleton.Insert("復号化したセーブデータを作成しました。", LogWindow.UpdateNoticeColor);
            LogWindow.Singleton.Insert($"[{outputFilePath}]", LogWindow.UpdateNoticeColor);
        }

        public void Execute(string tjaFilePath)
        {
            if (HasDecryptRole)
            {
                string inputFilePath = MainConfig.Singleton.GetScoreSaveDataFilePath(PlayerName, tjaFilePath);
                //string inputFilePath = MainConfig.Singleton.GetScoreSaveDataFilePath(MainConfig.Singleton.PlayerInfoList[0].Name, tjaFilePath);
                string outputFilePath = Path.Combine(Path.GetDirectoryName(inputFilePath), Path.GetFileNameWithoutExtension(inputFilePath) + "_Decrypt.json");

                Execute(inputFilePath, outputFilePath);
            }
            else
            {

            }
        }

        public ScoreSaveDataDecryptor()
        {

        }
    }
}
