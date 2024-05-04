using System.Windows;
using System.Windows.Input;
using SubjectTracker.Command;

namespace SubjectTracker.ViewModel;

public class ViewModelVisibility : ViewModelBase
{
    Visibility addPanelVisibility;

    ICommand? changeAddPanelVisibility;

    ICommand? changeUpdatePanelVisibility;

    ICommand? changeWorkPanelVisibility;

    Visibility updatePanelVisibility;

    GridLength workPanel;

    Visibility workPanelVisibility;

    public ViewModelVisibility()
    {
        updatePanelVisibility = Visibility.Collapsed;
        workPanel = new(0, GridUnitType.Pixel);
        workPanelVisibility = Visibility.Collapsed;
    }

    public GridLength WorkPanel
    {
        get => workPanel;
        set => SetProperty(ref workPanel, value);
    }

    public Visibility UpdatePanelVisibility
    {
        get => updatePanelVisibility;
        set => SetProperty(ref updatePanelVisibility, value);
    }

    public Visibility AddPanelVisibility
    {
        get => addPanelVisibility;
        set => SetProperty(ref addPanelVisibility, value);
    }

    public Visibility WorkPanelVisibility
    {
        get => workPanelVisibility;
        set => SetProperty(ref workPanelVisibility, value);
    }

    public ICommand ChangeAddPanelVisibility
    {
        get
        {
            return changeAddPanelVisibility ??= new RelayCommand(obj =>
            {
                if (addPanelVisibility == Visibility.Collapsed)
                {
                    AddPanelVisibility = Visibility.Visible;
                }
                else
                {
                    AddPanelVisibility = Visibility.Collapsed;
                }
            });
        }
    }

    public ICommand ChangeUpdatePanelVisibility
    {
        get
        {
            return changeUpdatePanelVisibility ??= new RelayCommand(obj =>
            {
                UpdatePanelVisibility = Visibility.Collapsed;
            });
        }
    }

    public ICommand ChangeWorkPanelVisibility
    {
        get
        {
            return changeWorkPanelVisibility ??=
                new RelayCommand(obj =>
                {
                    WorkPanelVisibility = Visibility.Collapsed;
                    WorkPanel = new(0, GridUnitType.Pixel);
                });
        }
    }
}