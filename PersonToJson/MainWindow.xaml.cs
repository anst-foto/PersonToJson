using System.Windows;
using PersonToJson.Models;
using Microsoft.Win32;

namespace PersonToJson;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
    {
        Input_LastName.Clear();
        Input_FirstName.Clear();
        Input_Patronymic.Clear();
        
        Input_Phone.Clear();
        Input_Email.Clear();
        
        Input_Region.Clear();
        Input_District.Clear();
        Input_Locality.Clear();
    }

    private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
    {
        var path = Input_Path.Text;
        if (string.IsNullOrWhiteSpace(path)) return;
        
        var personalInfo = new PersonalInfo()
        {
            Person = new Person()
            {
                LastName = Input_LastName.Text,
                FirstName = Input_FirstName.Text,
                Patronymic = Input_Patronymic.Text
            },
            Contacts = new Contacts()
            {
                Phone = Input_Phone.Text,
                Email = Input_Email.Text,
                Address = new Address()
                {
                    Region = Input_Region.Text,
                    District = Input_District.Text,
                    Locality = Input_Locality.Text
                }
            }
        };
        PersonalInfo.UnLoad(personalInfo, path);
    }

    private void ButtonPath_OnClick(object sender, RoutedEventArgs e)
    {
        var dlg = new SaveFileDialog
        {
            FileName = "PERSONAL_INFO",
            DefaultExt = ".json",
            Filter = "JSON (.json)|*.json"
        };
        
        var result = dlg.ShowDialog();

        switch (result)
        {
            case null:
                return;
            case true:
                Input_Path.Text = dlg.FileName;
                break;
        }
    }
}