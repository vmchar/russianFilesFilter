#if UNITY_EDITOR

using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace EditorCommonUtility
{
    /// <summary>
    /// This post-process scripts prohibits adding files to project if
    /// file name or path contains Cyrillic symbols.
    /// If user tries to add such a file in the project, the file itself
    /// and corresponding .meta file will be deleted and error will be shown in
    /// Unity's console.
    /// Existing file will be also deleted while trying to rename it will cyrrilic
    /// symbols present in the new file name, because Unity doen's make difference
    /// between renaming existing file and adding a new file.
    /// -----
    /// Данный постпроцесс запрещает добавление файлов в проект, если в пути или 
    /// имени файла содержатся символы из кириллицы. 
    /// При попытке добавить подобные файлы в проект происходит
    /// их удаление, а также соответствующих им мета файлов.
    /// Удаляет файлы при попытке переименовать их с русскими символами,
    /// в силу того, что юнити не различает переименование и добавление нового файла.
    /// ----
    /// Author: Vladislav Khartanovich, vmchar@outlook.com
    /// </summary>
    public class RussianFilesFilter : AssetPostprocessor
    {
        private static void OnPostprocessAllAssets(
            string[] importedAssets,
            string[] deletedAssets,
            string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            foreach(var file in importedAssets)
            {
                if(!Regex.IsMatch(file, @"\p{IsCyrillic}"))
                    continue;
                Debug.LogError(" You're trying to add file will cyrillic symbols in it's name. File was removed.");
                //Generating meta file name
                var metaFile = $"{file}.meta";
                //Removing file and .meta
                File.Delete(metaFile);
                File.Delete(file);
                AssetDatabase.Refresh();
                Debug.Log($"Files were removed:\n{metaFile}\n{file}");
            }
        }
    }
}


#endif