﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SubjectTracker.ViewModel;

namespace SubjectTracker.View;

public partial class MainWindow : Window
{
    readonly ViewModelMain viewModel;

    public MainWindow()
    {
        viewModel = new();
        InitializeComponent();
        DataContext = viewModel;
    }

    void ComboBox_DropDownOpened(object sender, EventArgs e)
    {
        ComboBox comboBox = (ComboBox)sender;
        if (comboBox.Text == "—")
        {
            comboBox.IsDropDownOpen = false;
        }
    }

    void Win_KeyDown(object sender, KeyEventArgs e)
    {
        if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.S)
        {
            viewModel.Git.NewCommit(DateTime.Now.ToString(), viewModel.Changes);
            viewModel.Changes.Clear();
        }
    }


    void OpenSettings_Click(object sender, RoutedEventArgs e)
    {
        if (settings.Visibility == Visibility.Collapsed)
        {
            table.Visibility = Visibility.Collapsed;
            settings.Visibility = Visibility.Visible;
            lines.Visibility = Visibility.Visible;
            UpdateVersionGrid();
        }
        else
        {
            table.Visibility = Visibility.Visible;
            settings.Visibility = Visibility.Collapsed;
            lines.Visibility = Visibility.Collapsed;
            viewModel.ReadingSubjectDB();
        }
    }

    void UpdateVersionGrid()
    {
        viewModel.Git.GitToGrids(settings, lines, ClickGitVersion);
    }

    void ClickGitVersion(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        viewModel.Git.Checkout((int)button.Tag);
        viewModel.UpdateVersion();
        viewModel.Git.GitToGrids(settings, lines, ClickGitVersion);
    }

    void Win_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (settings.Visibility == Visibility.Visible)
        {
            viewModel.Git.UpdateLines(lines);
        }
    }
}