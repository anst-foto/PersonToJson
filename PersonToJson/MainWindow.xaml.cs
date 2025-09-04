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

    private void Clear()
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

    private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
    {
        Clear();
    }

    private void ButtonLoad_OnClick(object sender, RoutedEventArgs e)
    {
        var path = Input_Path.Text;
        if (string.IsNullOrWhiteSpace(path)) return;
        
        var personalInfo = PersonalInfo.Load(path);
        if (personalInfo is null) return;
        
        Input_LastName.Text = personalInfo.Person.LastName;
        Input_FirstName.Text = personalInfo.Person.FirstName;
        Input_Patronymic.Text = personalInfo.Person.Patronymic ?? string.Empty;
        
        Input_Phone.Text = personalInfo.Contacts.Phone;
        Input_Email.Text = personalInfo.Contacts.Email;
        
        Input_Region.Text = personalInfo.Contacts.Address.Region ?? string.Empty;
        Input_District.Text = personalInfo.Contacts.Address.District ?? string.Empty;
        Input_Locality.Text = personalInfo.Contacts.Address.Locality;
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
        
        Clear();
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