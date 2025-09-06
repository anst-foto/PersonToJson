using System.Windows.Controls;

namespace PersonToJson.Components;

public partial class InputComponent : UserControl
{
    public string Label { get; set; }
    public InputComponent()
    {
        InitializeComponent();
        
        Loaded += (_, _) => LabelText.Text = Label;
    }
    
    public void Clear() => Input.Text = string.Empty;
}