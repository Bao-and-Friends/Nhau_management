using System.Windows;
using System.Windows.Controls;

namespace RestaurantModern.Dialogs;

public partial class TableActionModal : Window
{
    private bool _isTransferMode = true;
    public string SelectedTargetTable { get; private set; } = string.Empty;
    public string ActionType => _isTransferMode ? "Chuyển bàn" : "Gộp bàn";
    public string Reason => TxtReason.Text.Trim();

    public TableActionModal(string currentTableName, int currentCapacity, bool startInMergeMode = false)
    {
        InitializeComponent();
        TxtSubtitle.Text = $"Phiên phục vụ hiện tại: {currentTableName} • {currentCapacity} khách";

        if (startInMergeMode)
        {
            SetMergeMode();
        }
        else
        {
            SetTransferMode();
        }
    }

    private void SetTransferMode()
    {
        _isTransferMode = true;
        BtnTabTransfer.Style = (Style)FindResource("PrimaryButton");
        BtnTabMerge.Style = (Style)FindResource("SecondaryButton");
        LblTargetTable.Text = "Chọn bàn đích đến (Chuyển sang) *";
        LblReason.Text = "Lý do chuyển bàn";
        BtnSubmit.Content = "Xác nhận chuyển bàn";
        TxtReason.Text = "Khách muốn đổi vị trí bàn";
    }

    private void SetMergeMode()
    {
        _isTransferMode = false;
        BtnTabTransfer.Style = (Style)FindResource("SecondaryButton");
        BtnTabMerge.Style = (Style)FindResource("PrimaryButton");
        LblTargetTable.Text = "Chọn bàn muốn gộp chung vào *";
        LblReason.Text = "Lý do gộp bàn";
        BtnSubmit.Content = "Xác nhận gộp bàn";
        TxtReason.Text = "Gộp hai nhóm khách đi cùng nhau";
    }

    private void TabTransfer_Click(object sender, RoutedEventArgs e) => SetTransferMode();
    private void TabMerge_Click(object sender, RoutedEventArgs e) => SetMergeMode();

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private void Submit_Click(object sender, RoutedEventArgs e)
    {
        SelectedTargetTable = (CmbTargetTable.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Bàn khác";
        MessageBox.Show($"Thực hiện {ActionType} thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        DialogResult = true;
        Close();
    }
}
