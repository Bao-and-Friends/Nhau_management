using System.Collections.ObjectModel;
using RestaurantModern.Models;
using RestaurantModern.Services;
using RestaurantModern.ViewModels.Common;

namespace RestaurantModern.ViewModels;

public class ChatViewModel : ViewModelBase
{
    private readonly IApiService _api;
    private ChatContactModel? _selectedContact;
    private string _inputText = string.Empty;

    public ObservableCollection<ChatContactModel> Contacts { get; } = [];
    public ObservableCollection<ChatMessageModel> Messages { get; } = [];

    public ChatContactModel? SelectedContact
    {
        get => _selectedContact;
        set
        {
            if (SetProperty(ref _selectedContact, value) && value != null)
            {
                LoadMessagesForContact(value);
            }
        }
    }

    public string InputText
    {
        get => _inputText;
        set => SetProperty(ref _inputText, value);
    }

    public RelayCommand SendMessageCommand { get; }

    public ChatViewModel(IApiService api)
    {
        _api = api;

        SendMessageCommand = new RelayCommand(() =>
        {
            if (string.IsNullOrWhiteSpace(InputText)) return;

            var myName = _api.CurrentStaff?.HoTen ?? "Trần Quốc Huy";
            var myRole = _api.CurrentStaff?.VaiTro ?? "Quản lý";

            Messages.Add(new ChatMessageModel
            {
                SenderName = myName,
                SenderRole = myRole,
                Text = InputText.Trim(),
                TimeText = DateTime.Now.ToString("HH:mm"),
                IsMe = true
            });

            InputText = string.Empty;
        });

        InitContacts();
    }

    private void InitContacts()
    {
        Contacts.Clear();
        Contacts.Add(new ChatContactModel { HoTen = "Trần Thị B", VaiTro = "Thu ngân", IsOnline = true });
        Contacts.Add(new ChatContactModel { HoTen = "Nguyễn Văn A", VaiTro = "Phục vụ", IsOnline = true });
        Contacts.Add(new ChatContactModel { HoTen = "Lê Văn C", VaiTro = "Quản lý", IsOnline = true });
        Contacts.Add(new ChatContactModel { HoTen = "Hoàng Văn D", VaiTro = "Bếp trưởng", IsOnline = true });
        Contacts.Add(new ChatContactModel { HoTen = "Vũ Thị E", VaiTro = "Phục vụ", IsOnline = false });

        SelectedContact = Contacts.FirstOrDefault();
    }

    private void LoadMessagesForContact(ChatContactModel contact)
    {
        Messages.Clear();
        Messages.Add(new ChatMessageModel
        {
            SenderName = contact.HoTen,
            SenderRole = contact.VaiTro,
            Text = $"{contact.VaiTro}: Bàn 02 cần kiểm tra lại món tráng miệng nhé!",
            TimeText = "18:24",
            IsMe = false
        });

        Messages.Add(new ChatMessageModel
        {
            SenderName = "Tôi",
            SenderRole = "Phục vụ",
            Text = "Phục vụ: Mình đã cập nhật món rồi nhé!",
            TimeText = "18:26",
            IsMe = true
        });

        Messages.Add(new ChatMessageModel
        {
            SenderName = contact.HoTen,
            SenderRole = contact.VaiTro,
            Text = $"{contact.VaiTro}: OK cảm ơn bạn, bếp đang làm rồi.",
            TimeText = "18:27",
            IsMe = false
        });
    }
}
