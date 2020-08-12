using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Save
{
    public static class SaveUtils
    {
        public static Save GetLatestSave()
        {
            if(!PlayerPrefs.HasKey(SaveKeys.LAST_SAVE_NAME))
            {
                return null;
            }
            var lastSaveName = PlayerPrefs.GetString(SaveKeys.LAST_SAVE_NAME);
            var checkPoint = PlayerPrefs.GetInt(lastSaveName + SaveKeys.SAVE_CHECKPOINT_SUFFIX);
            var level = PlayerPrefs.GetString(lastSaveName + SaveKeys.SAVE_LEVEL_SUFFIX);
            return new Save(lastSaveName, level, checkPoint);
        }

        public static int GetSaveNumber(string saveName)
        {
            var saveStringNumber = saveName.Replace(string.Format(SaveKeys.SAVE_NAME_TEMPLATE, ""), "");
            return int.Parse(saveStringNumber);
        }

        public static Save Save(Save save)
        {
            PlayerPrefs.SetString(SaveKeys.LAST_SAVE_NAME, save.SaveName);
            PlayerPrefs.SetString(save.SaveName + SaveKeys.SAVE_LEVEL_SUFFIX, save.LevelName);
            PlayerPrefs.SetInt(save.SaveName + SaveKeys.SAVE_CHECKPOINT_SUFFIX, save.CheckPoint);
            PlayerPrefs.Save();
            return save;
        }

        public static Save CreateNew(string sceneName)
        {
            var latest = GetLatestSave();
            var saveNumber = 0;
            if(latest != null)
            {
                saveNumber = GetSaveNumber(latest.SaveName);
                saveNumber++;
            }
            var save = new Save()
            {
                LevelName = sceneName,
                CheckPoint = 0,
                SaveName = string.Format(SaveKeys.SAVE_NAME_TEMPLATE, saveNumber)
            };
            save.Store();
            return save;
        }

    }
}
