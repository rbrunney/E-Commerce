function createAccount() {
    var newAccount = {
        "accountId": "1",
        "firstName": document.getElementById("firstName").value,
        "lastName": document.getElementById("lastName").value,
        "email": document.getElementById("email").value,
        "password": document.getElementById("password").value,
        "cardNum": document.getElementById("cardNum").value,
        "expDate": document.getElementById("expYear").value + "-" + document.getElementById("expMonth").value + "-" + document.getElementById("expDay").value,
        "securityNum": document.getElementById("securityNum").value,
        "street": document.getElementById("street").value,
        "city": document.getElementById("city").value,
        "state": document.getElementById("state").value,
        "zipCode": document.getElementById("zipCode").value
    }

    // // Checking to see if credit card is valid
    var createAccount = "http://localhost:80/account"

    var creditCard = {
        "cardNumber": newAccount['cardNum'],
        "cvv": newAccount['securityNum'],
        "expirationDate": newAccount['expDate']
    }

    console.log(creditCard);
    console.log(newAccount)

    let request = new XMLHttpRequest();
    request.open("POST", createAccount);
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.setRequestHeader("Allow-Control-Allow-Origin", "*");
    request.send(JSON.stringify(newAccount));
    request.onload = () => {
        alert('What the nut')
    };
}