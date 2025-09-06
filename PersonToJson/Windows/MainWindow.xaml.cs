using System.Windows;
using Microsoft.Win32;
using PersonToJson.Models;

namespace PersonToJson.Windows;

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
        var path = Input_Path.Input.Text;
        if (string.IsNullOrWhiteSpace(path)) return;
        
        var personalInfo = PersonalInfo.Load(path);
        if (personalInfo is null) return;
        
        Input_LastName.Input.Text = personalInfo.Person.LastName;
        Input_FirstName.Input.Text = personalInfo.Person.FirstName;
        Input_Patronymic.Input.Text = personalInfo.Person.Patronymic ?? string.Empty;
        
        Input_Phone.Input.Text = personalInfo.Contacts.Phone;
        Input_Email.Input.Text = personalInfo.Contacts.Email;
        
        Input_Region.Input.Text = personalInfo.Contacts.Address.Region ?? string.Empty;
        Input_District.Input.Text = personalInfo.Contacts.Address.District ?? string.Empty;
        Input_Locality.Input.Text = personalInfo.Contacts.Address.Locality;
    }

    private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
    {
        var path = Input_Path.Input.Text;
        if (string.IsNullOrWhiteSpace(path)) return;
        
        var personalInfo = new PersonalInfo()
        {
            Person = new Person()
            {
                LastName = Input_LastName.Input.Text,
                FirstName = Input_FirstName.Input.Text,
                Patronymic = Input_Patronymic.Input.Text
            },
            Contacts = new Contacts()
            {
                Phone = Input_Phone.Input.Text,
                Email = Input_Email.Input.Text,
                Address = new Address()
                {
                    Region = Input_Region.Input.Text,
                    District = Input_District.Input.Text,
                    Locality = Input_Locality.Input.Text
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
                Input_Path.Input.Text = dlg.FileName;
                break;
        }
    }
}