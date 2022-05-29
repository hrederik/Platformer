using UnityEngine;

namespace CodeBase.Game.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Platform[] _platforms;
        private int _index;

        public bool HasNextPlatform => _index + 1 < _platforms.Length;
        public bool HasPreviousPlatform => _index > 0;

        public Platform GetNextPlatform()
        {
            return _platforms[++_index];
        }

        public Platform GetCurrentPlatform()
        {
            return _platforms[_index];
        }

        public Platform GetPreviousPlatform()
        {
            return _platforms[--_index];
        }
    }
}