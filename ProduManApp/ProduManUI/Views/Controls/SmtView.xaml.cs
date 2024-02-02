using ProduManUI.Core.ViewModels;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProduManUI.Views;

/// <summary>
/// Interaction logic for SmtView.xaml
/// </summary>
public partial class SmtView : UserControl
{
    public SmtView()
    {
        InitializeComponent();
    }

    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    private void UserControl_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            if (DataContext is SmtViewModel viewModel)
            {
                viewModel.LoadOrders();
            }
        }
    }
}