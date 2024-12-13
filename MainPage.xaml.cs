using System.Collections.ObjectModel;

namespace EventManagement;

public partial class MainPage : ContentPage
{
    public ObservableCollection<string> Events { get; } = new ObservableCollection<string>();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;

        // Prepopulate with default events
        Events.Add("Event 1: General Meeting. Location: Calgary Downtown. Date: 24th Oct. Time: 4:45 PM");
        Events.Add("Event 2: BirthDay Function. Location: Savana Calgary. Date: 29th Dec. Time: 1:45 PM");
        Events.Add("Event 3: Workshop Attend. Location: EastValley Calgary. Date: 19th Dec. Time: 7:45 AM");
    }

    private void OnAddEventClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(NewEventEntry.Text))
        {
            Events.Add(NewEventEntry.Text);
            NewEventEntry.Text = string.Empty;
        }
    }

    private void OnEditEventClicked(object sender, EventArgs e)
    {
        if (EventsList.SelectedItem != null && !string.IsNullOrWhiteSpace(EditEventEntry.Text))
        {
            int index = Events.IndexOf(EventsList.SelectedItem.ToString());
            if (index >= 0)
            {
                Events[index] = EditEventEntry.Text;
                EditEventEntry.Text = string.Empty;
            }
        }
    }
}
