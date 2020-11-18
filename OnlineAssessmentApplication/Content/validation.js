function GeneratePasscode() {
    document.getElementById('Passcode').value = Math.floor((Math.random() * 99999) + 10000);
}