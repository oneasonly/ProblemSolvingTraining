using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace Week1Task3
{
    public class ViewModel : PropertyChangedBase
    {
        #region props
        public string Folder { get => _folder; set => Set(ref _folder, value); }
        private string _folder;
        public uint Depth { get => _depth; set => Set(ref _depth, value); }
        private uint _depth;
        public BindableCollection<string> Content { get; } = new BindableCollection<string>();
        #endregion

        #region Recursion
        public async void ShowByRecursion()
        {
            if (!Directory.Exists(Folder))
            {
                MessageBox.Show($"This folder doesnt exist: {Folder}");
                return;
            }
            Content.Clear();
            var tempAccumulator = new List<string>();
            await SelfRecurs(tempAccumulator, Folder, 0);

            tempAccumulator.Sort();
            Content.AddRange(tempAccumulator);
        }
        private async Task SelfRecurs(List<string> accumulator, string incPath, int currDepth)
        {
            if (currDepth >= Depth) return;
            currDepth++;
            var folders = await Task.Run(() =>
            {
                var entries = Directory.GetFileSystemEntries(incPath).Select(x => x.Replace(Folder, "").Trim('\\'));
                accumulator.AddRange(entries);
                return Directory.GetDirectories(incPath);
            });
            
            foreach (var folder in folders)
            {
                await SelfRecurs(accumulator, folder, currDepth);
            }
        }
        #endregion

        #region Iteration
        public async void ShowByIteration()
        {
            if (!Directory.Exists(Folder))
            {
                MessageBox.Show($"This folder doesnt exist: {Folder}");
                return;
            }
            Content.Clear();
            var tempAccumulator = new List<string>();

            var FoldersByDepth = new List<IEnumerable<string>>((int)Depth);
            IEnumerable<string> folders = new string[] { Folder };
            for (int i = 0; i < Depth; i++)
            {
                AccumulateEntries(tempAccumulator, folders);
                FoldersByDepth.Add(await GetFoldersNextLevel(folders));
                if (FoldersByDepth.Count > 0)
                {
                    folders = FoldersByDepth.LastOrDefault();
                }                                
            }

            tempAccumulator.Sort();
            Content.AddRange(tempAccumulator);
        }
        private async Task<IList<string>> GetFoldersNextLevel(IEnumerable<string> folders)
        {
            return await Task.Run(() =>
            {
                var result = new List<string>();
                foreach (var folder in folders)
                {
                    result.AddRange(Directory.GetDirectories(folder));
                }
                return result;
            });
        }
        private void AccumulateEntries(List<string> entriesAccumulator, IEnumerable<string> folders)
        {
            foreach (var folder in folders)
            {
                var entries = Directory.GetFileSystemEntries(folder).Select(x => x.Replace(Folder, "").Trim('\\'));
                entriesAccumulator.AddRange(entries);
            }
        }
        #endregion
    }
}
