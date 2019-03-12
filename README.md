# Unity Cyrillic Files Filter



This post-process scripts prohibits adding files to project if file name or path contains Cyrillic symbols. If user tries to add such a file in the project, the file itself and corresponding .meta file will be deleted and error will be shown in Unity's console. Existing file will be also deleted while trying to rename it will cyrrilic symbols present in the new file name, because Unity doen's make difference between renaming existing file and adding a new file.
-----
Данный постпроцесс запрещает добавление файлов в проект, если в пути или имени файла содержатся символы из кириллицы. При попытке добавить подобные файлы в проект происходит их удаление, а также соответствующих им мета файлов. Удаляет файлы при попытке переименовать их с русскими символами,  в силу того, что юнити не различает переименование и добавление нового файла.
