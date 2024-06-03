namespace AppMiltonDavia;

public partial class AppMiltonDavila : ContentPage
{
	public AppMiltonDavila()
	{
		InitializeComponent();
	}

    private void OnRechargeAmountChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            var radioButton = sender as RadioButton;
            SelectedRechargeLabel.Text = $"Ha seleccionado una recarga de: {radioButton.Content} d�lares";
        }
    }

    private async void OnRecargarClicked(object sender, EventArgs e)
    {
        var phoneNumber = PhoneNumberEntry.Text;
        var selectedOperator = OperatorPicker.SelectedItem?.ToString();
        var selectedRecharge = GetSelectedRechargeAmount();

        if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(selectedOperator) || selectedRecharge == 0)
        {
            await DisplayAlert("llene el numero de telefono", "Por favor, ingrese un numero de telefono", "OK");
            return;
        }

        var confirm = await DisplayAlert("Confirmaci�n", $"�Desea realizar una recarga de {selectedRecharge} d�lares al n�mero {phoneNumber} con el operador {selectedOperator}?", "S�", "No");

        if (confirm)
        {
            SelectedRechargeLabel.Text = $"Ha seleccionado una recarga de: {selectedRecharge} d�lares";
            await RecargarAsync(phoneNumber, selectedOperator, selectedRecharge);
        }


    }
    private int GetSelectedRechargeAmount()
    {
        if (RadioButton3.IsChecked)
            return 3;
        if (RadioButton5.IsChecked)
            return 5;
        if (RadioButton10.IsChecked)
            return 10;
        return 0;
    }


    private async Task RecargarAsync(string phoneNumber, string _operator, int amount)
    {
        // L�gica para realizar la recarga
        await DisplayAlert("Recarga", $"Recarga de {amount} d�lares realizada con �xito al n�mero {phoneNumber} con el operador {_operator}.", "OK");
    }
}