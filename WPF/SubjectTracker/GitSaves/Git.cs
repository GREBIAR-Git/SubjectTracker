using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SubjectTracker.GitSaves;

public class Git
{
    readonly Dictionary<Commit, List<Branch>> branchs = new();
    readonly Branch First;
    Branch CurrentBranch;
    Commit CurrentCommit;


    public Git(string mainBranch = "master")
    {
        First = new(mainBranch);
        CurrentBranch = First;
        CurrentCommit = First.First;
    }
    /*
    public void Push()
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        path += "\\SubjectTracker";
        if (Directory.Exists(path) == false)
        {
            Directory.CreateDirectory(path);
        }

        string text = "Hello METANIT.COM"; // строка для записи

        // запись в файл
        using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
        {
            // преобразуем строку в байты
            byte[] buffer = Encoding.Default.GetBytes(text);
            // запись массива байтов в файл
            await fstream.WriteAsync(buffer, 0, buffer.Length);
            Console.WriteLine("Текст записан в файл");
        }
    }

    public void Pull()
    {

    }*/

    public void UpdateLines(Grid lines)
    {
        lines.Children.Clear();

        double maxColumns = 0;
        double maxRow = 0;

        List<List<CommitData>> commitDatas = AllCommit();

        foreach (List<CommitData> commits in commitDatas)
        {
            maxColumns += 1;
            if (maxRow < commits.Count)
            {
                maxRow = commits.Count;
            }
        }


        double width = lines.ActualWidth / maxColumns;
        double height = lines.ActualHeight / maxRow;


        int columns = 0;
        VisualizationBranch(ref columns, First, 0);


        void VisualizationBranch(ref int i, Branch branch, int lastBranch)
        {
            List<Branch> branchList = new();
            Commit? commit = branch.First;
            bool firstRow = true;
            int f = branch.CountPrev();
            while (commit != null)
            {
                AddButton(i, f, lines, commit, width, height, ref firstRow, lastBranch);

                if (branchs.TryGetValue(commit, out List<Branch> branchsChild))
                {
                    branchList.AddRange(branchsChild);
                }

                commit = commit.Next;
                f++;
            }

            Branch[] sortBranchs = branchList.ToArray();
            Array.Sort(sortBranchs);

            int lastI = i;
            i++;
            foreach (Branch branch1 in sortBranchs)
            {
                VisualizationBranch(ref i, branch1, lastI);
            }
        }

        void AddButton(int i, int f, Grid lines, Commit commit, double width, double height, ref bool firstRow,
            int lastBranch)
        {
            Color additional = (Color)ColorConverter.ConvertFromString("#335e8f");
            if (!firstRow)
            {
                Line line = new()
                {
                    Visibility = Visibility.Visible,
                    StrokeThickness = 4,

                    Stroke = new SolidColorBrush(additional),
                    X1 = width * i + width / 2,
                    X2 = width * i + width / 2,
                    Y1 = height * f - height / 2,
                    Y2 = height * f + height / 2
                };
                lines.Children.Add(line);
            }
            else
            {
                if (i != 0)
                {
                    Line line = new()
                    {
                        Visibility = Visibility.Visible,
                        StrokeThickness = 4,

                        Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#335e8f")),
                        X1 = width * (lastBranch + 1) - 12,
                        X2 = width * i + width / 2,
                        Y1 = height * (f - 1) + height / 2,
                        Y2 = height * f + 12
                    };
                    lines.Children.Add(line);
                }

                firstRow = false;
            }
        }
    }

    public void GitToGrids(Grid main, Grid lines, RoutedEventHandler clickEventHandler)
    {
        main.Children.Clear();
        main.RowDefinitions.Clear();
        main.ColumnDefinitions.Clear();
        lines.Children.Clear();

        double maxColumns = 0;
        double maxRow = 0;

        List<List<CommitData>> commitDatas = AllCommit();

        foreach (List<CommitData> commits in commitDatas)
        {
            maxColumns += 1;
            if (maxRow < commits.Count)
            {
                maxRow = commits.Count;
            }
        }

        for (int i = 0; i < maxColumns; i++)
        {
            main.ColumnDefinitions.Add(new() { Width = new(100 / maxColumns, GridUnitType.Star) });
        }

        for (int i = 0; i < maxRow; i++)
        {
            main.RowDefinitions.Add(new() { Height = new(100 / maxRow, GridUnitType.Star) });
        }


        double width = lines.ActualWidth / maxColumns;
        double height = lines.ActualHeight / maxRow;


        int columns = 0;
        VisualizationBranch(ref columns, First, 0);


        void VisualizationBranch(ref int i, Branch branch, int lastBranch)
        {
            List<Branch> branchList = new();
            Commit? commit = branch.First;
            bool firstRow = true;
            int f = branch.CountPrev();
            while (commit != null)
            {
                AddButton(i, f, main, lines, commit, width, height, ref firstRow, lastBranch);

                if (branchs.TryGetValue(commit, out List<Branch> branchsChild))
                {
                    branchList.AddRange(branchsChild);
                }

                commit = commit.Next;
                f++;
            }

            Branch[] sortBranchs = branchList.ToArray();
            Array.Sort(sortBranchs);

            int lastI = i;
            i++;
            foreach (Branch branch1 in sortBranchs)
            {
                VisualizationBranch(ref i, branch1, lastI);
            }
        }

        void AddButton(int i, int f, Grid main, Grid lines, Commit commit, double width, double height,
            ref bool firstRow, int lastBranch)
        {
            Color additional = (Color)ColorConverter.ConvertFromString("#335e8f");
            Button button = new()
            {
                Style = Application.Current.FindResource("BuTree") as Style,
                Margin = new(10, 10, 10, 10),
                Tag = commit.GetHashCode(),
                Content = commit.Data.Name,
                Name = "h" + commit.GetHashCode()
            };
            if (commit == CurrentCommit)
            {
                button.Background = Brushes.Tan;
            }

            button.Click += clickEventHandler;
            if (!firstRow)
            {
                Line line = new()
                {
                    Visibility = Visibility.Visible,
                    StrokeThickness = 4,

                    Stroke = new SolidColorBrush(additional),
                    X1 = width * i + width / 2,
                    X2 = width * i + width / 2,
                    Y1 = height * f - height / 2,
                    Y2 = height * f + height / 2
                };
                lines.Children.Add(line);
            }
            else
            {
                if (i != 0)
                {
                    Line line = new()
                    {
                        Visibility = Visibility.Visible,
                        StrokeThickness = 4,

                        Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#335e8f")),
                        X1 = width * (lastBranch + 1) - 12,
                        X2 = width * i + width / 2,
                        Y1 = height * (f - 1) + height / 2,
                        Y2 = height * f + 12
                    };
                    lines.Children.Add(line);
                }

                firstRow = false;
            }

            main.Children.Add(button);
            Grid.SetColumn(button, i);
            Grid.SetRow(button, f);
        }
    }

    List<List<CommitData>> AllCommit()
    {
        List<List<CommitData>> allCommit = new()
        {
            AllCommitBranch(First)
        };

        foreach (List<Branch> branches in branchs.Values)
        {
            foreach (Branch branch in branches)
            {
                allCommit.Add(AllCommitBranch(branch, branch.CountPrev()));
            }
        }

        return allCommit;

        static List<CommitData> AllCommitBranch(Branch branch, int countPrev = 0)
        {
            List<CommitData> commitBranch = new();
            for (int i = 0; i < countPrev; i++)
            {
                commitBranch.Add(new("Empty", new(), DateTime.Now));
            }

            Commit? commit = branch.First;
            while (commit != null)
            {
                commitBranch.Add(commit.Data);
                commit = commit.Next;
            }

            return commitBranch;
        }
    }


    public int NewCommit(string name, List<string> data)
    {
        List<string> copy = new();
        foreach (string item in data)
        {
            copy.Add(item);
        }

        if (CurrentCommit.Next == null)
        {
            CurrentCommit = CurrentCommit.NewCommit(name, copy);
            return CurrentCommit.GetHashCode();
        }

        if (branchs.TryGetValue(CurrentCommit, out List<Branch> old))
        {
            CurrentBranch = new("branch " + name, name, copy, CurrentBranch, CurrentCommit);
            old.Add(CurrentBranch);
            branchs[CurrentCommit] = old;
            CurrentCommit = CurrentBranch.First;
            return CurrentCommit.GetHashCode();
        }

        CurrentBranch = new("branch " + name, name, copy, CurrentBranch, CurrentCommit);
        branchs.Add(CurrentCommit, new() { CurrentBranch });
        CurrentCommit = CurrentBranch.First;
        return CurrentCommit.GetHashCode();
    }


    public List<string> GetHistoryData()
    {
        List<string> history = new();
        Commit? commit = CurrentCommit;
        List<List<string>> temp = new();
        while (commit != null)
        {
            temp.Add(commit.Data.Changes);
            commit = commit.Prev;
        }

        temp.Reverse();
        foreach (List<string> tempHistory in temp)
        {
            history.AddRange(tempHistory);
        }

        return history;
    }

    public void Checkout(int hash)
    {
        FindCommit(First, hash);
        foreach (List<Branch> branches in branchs.Values)
        {
            foreach (Branch branch in branches)
            {
                FindCommit(branch, hash);
            }
        }
    }

    void FindCommit(Branch current, int hash)
    {
        Commit? commit = current.First;
        while (commit != null)
        {
            if (hash == commit.GetHashCode())
            {
                CurrentCommit = commit;
                CurrentBranch = current;
                break;
            }

            commit = commit.Next;
        }
    }

    public void Log(bool p = false)
    {
        Console.WriteLine();
        LogBranch(First, p);
        foreach (List<Branch> branches in branchs.Values)
        {
            foreach (Branch branch in branches)
            {
                LogBranch(branch, p);
            }
        }

        static void LogBranch(Branch current, bool p)
        {
            Commit? commit = current.First;
            while (commit != null)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("commit: " + commit.GetHashCode());
                Console.WriteLine("branch: " + AllPreVBranch(current));
                Console.WriteLine("name: " + commit.Data.Name);
                Console.WriteLine("date: " + commit.Data.Date);
                if (p)
                {
                    Console.WriteLine("DATA:");
                    Console.WriteLine(commit.Data.Changes);
                }

                commit = commit.Next;
            }
        }

        static string AllPreVBranch(Branch current)
        {
            string prevbranch = current.Name;

            while (current.Prev != null)
            {
                prevbranch = current.Prev.Name + "->" + prevbranch;
                current = current.Prev;
            }

            return prevbranch;
        }
    }
    /*
        public List<CommitIdentifier> GetCommitIdentifier()
    {
        List<CommitIdentifier> commitIdentifiers = new();
        CommitsOfBranch(First, ref commitIdentifiers);
        foreach (List<Branch> branches in branchs.Values)
        {
            foreach (Branch branch in branches)
            {
                CommitsOfBranch(branch, ref commitIdentifiers);
            }
        }
        return commitIdentifiers;
    }

    void CommitsOfBranch(Branch current, ref List<CommitIdentifier> commitIdentifiers)
    {
        Commit? commit = current.First;
        while (commit != null)
        {
            commitIdentifiers.Add(new CommitIdentifier(commit.GetHashCode(), commit.Data.Name));
            commit = commit.Next;
        }
    }
    */
}