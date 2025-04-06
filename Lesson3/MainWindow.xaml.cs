using System.Windows;
using System.Windows.Controls;

namespace Lesson3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private int index = 1;
    private void Button_Click(object sender, RoutedEventArgs e) //инкремент кнопки
    {
        Button button = (Button)sender;
        index++;  
        button.Content = $"Кнопка {index}";
    }

    private void Button_Click_1(object sender, RoutedEventArgs e) // невидимка
    {

        if (ink_button.Visibility == Visibility.Visible)
            ink_button.Visibility = Visibility.Hidden;
        else
            ink_button.Visibility = Visibility.Visible;

    }
}