using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Save
{
    public class Save
    {
        private string _saveName;
        private string _levelName;
        private int _checkPoint;

        public string SaveName { get => _saveName; set => _saveName = value; }
        public string LevelName { get => _levelName; set => _levelName = value; }
        public int CheckPoint { get => _checkPoint; set => _checkPoint = value; }

        public Save(string saveName, string levelName, int checkpoint)
        {
            _saveName = saveName;
            _levelName = levelName;
            _checkPoint = checkpoint;

        }

        public Save()
        {

        }

        public Save Store()
        {
            SaveUtils.Save(this);
            return this;
        }
    }
}
