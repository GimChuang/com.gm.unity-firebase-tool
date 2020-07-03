using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GM.FirebaseTool
{
    public static class PathUtils
    {
        // This is for URL, which use / (forward slash) but not \ (back slash)
        public static string CombineURL(params string[] _strings)
        {
            // pre-process in case of Path.Combine gives weird result because any path is "absolute" except for the first one
            // https://stackoverflow.com/questions/53102/why-does-path-combine-not-properly-concatenate-filenames-that-start-with-path-di
            for (int i = 1; i < _strings.Length; i++)
            {
                if (Path.IsPathRooted(_strings[i]))
                {
                    _strings[i] = _strings[i].TrimStart(Path.DirectorySeparatorChar);
                    _strings[i] = _strings[i].TrimStart(Path.AltDirectorySeparatorChar);
                }
            }

            string path = Path.Combine(_strings);
            // replace back slashes with forward slashes
            path = path.Replace(@"\", "/");
            //Debug.Log(path);

            return path;
        }
    }
}
