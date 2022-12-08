using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc2022
{
    public static class Day07
    {

        //public static Regex stackContentRegex = new Regex(@"([A-Z])\]");
        public static Regex cdRegex = new Regex(@"\$ cd (.+)");
        public static Regex lsRegex = new Regex(@"\$ ls");
        public static Regex dirRegex = new Regex(@"dir (.+)");
        public static Regex fileRegex = new Regex(@"^(?!dir|\$)(.+) (.+)$");

        public static int Part1(List<string> input)
        {
            var tree = GetTree(input);
            UpdateDirSizes(tree);
            return GetDirSizeSum(tree, 100000);
        }

        public static int Part2(List<string> input)
        {
            var tree = GetTree(input);
            UpdateDirSizes(tree);
            var diskSize = 70000000;
            var rootSize = (tree as Directorie).Size;
            var freeSpace = diskSize - rootSize;
            var freeSpaceNeededForUpdate = 30000000;
            var minimunSpaceToClear = freeSpaceNeededForUpdate - freeSpace;
            var allFolders = GetAllFolders(tree);
            var folderToDelete = GetFolderToDelete(allFolders, minimunSpaceToClear);
            return folderToDelete.Size;
        }


        private static Directorie GetFolderToDelete(HashSet<Directorie> folders, int minimunSpaceToClear)
        {
            return folders.OrderBy(x => x.Size).First(x => x.Size >= minimunSpaceToClear);
        }

        private static HashSet<Directorie> GetAllFolders(TreeNode tree)
        {
            HashSet<Directorie> folders = new HashSet<Directorie>();
            folders.Add(tree as Directorie);
            tree.OfType<Directorie>().ToList().ForEach(d => folders.UnionWith(GetAllFolders(d)));
            return folders;
        }

        private static int GetDirSizeSum(TreeNode tree, int maxDirSizeToIncludeInSum)
        {
            var sumDirSizes = 0;
            var dir = tree as Directorie;

            if(dir.Size <= maxDirSizeToIncludeInSum)
                sumDirSizes += dir.Size;

            var dirs = tree.OfType<Directorie>().ToList();
            foreach (var d in dirs)
            {
                sumDirSizes += GetDirSizeSum(d, maxDirSizeToIncludeInSum);
            }
            
            return sumDirSizes;
        }

        private static void UpdateDirSizes(TreeNode tree)
        {
            UpdateDirSizesWithFileSize(tree);
            UpdateDirSizesWithSubfolderSize(tree);
        }


        private static void UpdateDirSizesWithSubfolderSize(TreeNode tree)
        {
            var dir = tree as Directorie;
            tree.OfType<Directorie>().ToList().ForEach(d => UpdateDirSizesWithSubfolderSize(d));
            if(dir.Parent != null)
                (dir.Parent as Directorie).Size += dir.Size;
        }


        private static void UpdateDirSizesWithFileSize(TreeNode tree)
        {
            var dir = tree as Directorie;
            dir.Size = tree.OfType<File>().Select(x => x.Size).Sum();
            tree.OfType<Directorie>().ToList().ForEach(d => UpdateDirSizesWithFileSize(d));
        }


        private static TreeNode GetTree(List<string> input)
        {
            var root = new Directorie("/");
            TreeNode currentNode = root;

            foreach (var row in input)
            {
                //cd
                var cdMatch = cdRegex.Match(row);
                if (cdMatch.Success)
                {
                    var dirName = cdMatch.Groups[1].Value;
                    if (dirName == "/")
                    {
                        currentNode = root;
                        continue;
                    }

                    if (dirName == "..")
                    {
                        currentNode = currentNode.Parent;
                        continue;
                    }

                    var child = currentNode.GetChild(dirName);
                    if (child == null)
                    {
                        var newDir = new Directorie(dirName);
                        currentNode.Add(newDir);
                        currentNode = newDir;
                        continue;
                    }
                    currentNode = child;
                    continue;
                }

                //ls
                var lsMatch = lsRegex.Match(row);
                if (lsMatch.Success)
                {
                    continue;
                }

                //dir
                var dirMatch = dirRegex.Match(row);
                if (dirMatch.Success)
                {
                    var dirName = dirMatch.Groups[1].Value;
                    var child = currentNode.GetChild(dirName);
                    if (child == null)
                    {
                        var newDir = new Directorie(dirName);
                        currentNode.Add(newDir);
                        continue;
                    }
                    continue;
                }

                //file
                var fileMatch = fileRegex.Match(row);
                if (fileMatch.Success)
                {
                    var fileSize = int.Parse(fileMatch.Groups[1].Value);
                    var fileName = fileMatch.Groups[2].Value;
                    var child = currentNode.GetChild(fileName);
                    if (child == null)
                    {
                        var newFile = new File(fileName, fileSize);
                        currentNode.Add(newFile);
                        continue;
                    }
                    continue;
                }
            }

            return root;
        }


        private enum FileTypes
        {
            dir,
            file
        }


        private class File : TreeNode
        {
            public File(string id) : base(id)
            {
            }

            public File(string id, int size) : base(id)
            {
                Size = size;
            }

            public int Size { get; set; }
        }


        private class Directorie : TreeNode
        {
            public Directorie(string id) : base(id)
            {
            }

            public Directorie(string id, int size) : base(id)
            {
                Size = size;
            }

            public int Size { get; set; }
        }



    }
}
