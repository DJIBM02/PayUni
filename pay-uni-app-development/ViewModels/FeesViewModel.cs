using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PayUni.Models;
using PayUni.Services;

namespace PayUni.ViewModels;

public partial class FeesViewModel : ObservableObject
{
    private readonly IFeeService _feeService;

    [ObservableProperty]
    public ObservableCollection<Fee> fees = [];

    [ObservableProperty]
    public ObservableCollection<Fee> filteredFees = [];

    [ObservableProperty]
    public string searchText = string.Empty;

    [ObservableProperty]
    public string selectedCategory = "All";

    [ObservableProperty]
    public bool isLoading = false;

    public FeesViewModel()
    {
        _feeService = new FeeService();
    }

    [RelayCommand]
    public async Task LoadFees()
    {
        IsLoading = true;

        try
        {
            var fees = await _feeService.GetFeesAsync();
            Fees = new ObservableCollection<Fee>(fees);
            FilterFees();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error loading fees: {ex.Message}");
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    public void FilterFees()
    {
        var query = Fees.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            query = query.Where(f => f.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                                     f.Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
        }

        if (SelectedCategory != "All")
        {
            query = query.Where(f => f.Category == SelectedCategory);
        }

        FilteredFees = new ObservableCollection<Fee>(query);
    }

    partial void OnSearchTextChanged(string value) => FilterFeesCommand.Execute(null);
    partial void OnSelectedCategoryChanged(string value) => FilterFeesCommand.Execute(null);
}
