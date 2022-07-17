function getItems(){
    var url = 'http://localhost:80/ecommerce/getallitems';

    let request = new XMLHttpRequest();
    request.open("GET", url);
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.send();
    request.onload = () => {
        console.log(request.responseText);
        var items = JSON.parse(request.responseText);
        items.forEach(element => {
            console.log(element);
            addRow(element['name'], element['description'], element['unitPrice'], null, 'catalog');
        });
    };

    let cartRequest = new XMLHttpRequest();
    cartRequest.open("GET", 'http://localhost:80/cart/allitems');
    cartRequest.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    cartRequest.send();
    cartRequest.onload = () => {
        console.log(cartRequest.responseText);
        if(cartRequest.responseText === '[]') {
            document.getElementById('accountForm').style.display = 'none';
            document.getElementById('checkOutBtn').style.display = 'none';
        } else {
            var items = JSON.parse(cartRequest.responseText);
            items.forEach(element => {
                console.log(element);
                addRow(element['name'], element['description'], element['unitPrice'], element['quantity'], 'cart');
            });
            document.getElementById('accountForm').style.display = 'block';
            document.getElementById('checkOutBtn').style.display = 'block';
        }
    };
}

function search() {
    var url = 'http://localhost:80/ecommerce/getbyname/' + document.getElementById("searchCatalog").value;

    let request = new XMLHttpRequest();
    request.open("GET", url);
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.setRequestHeader("Access-Control-Allow-Origin", "*");
    request.send();
    request.onload = () => {
        alert(request.responseText)
    };  
}

function addToCart(name, quantity) {
    var url = 'http://localhost:80/cart'

    let request = new XMLHttpRequest();
    request.open("POST", url);
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.send(JSON.stringify({"Name": name, "quantity": quantity}))
    request.onload = () => {
        location.reload();
    };
}

function checkOut() {
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

    var creditCard = {
        "cardNumber": newAccount['cardNum'],
        "expirationDate": newAccount['expDate'],
        "cvv": newAccount['securityNum']
    }

    let paymentRequest = new XMLHttpRequest();
    paymentRequest.open("POST", "http://localhost:80/payment/checkValidation");
    paymentRequest.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    paymentRequest.send(JSON.stringify(creditCard));
    paymentRequest.onload = () => {
        if (paymentRequest.responseText === 'false') {
            alert('Credit Card Information is not Valid')
        } else {
            let expirationRequest = new XMLHttpRequest();
            expirationRequest.open("POST", "http://localhost:80/payment/isExpired")
            expirationRequest.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
            expirationRequest.send(JSON.stringify(creditCard));
            expirationRequest.onload = () => {
                if(expirationRequest.responseText === 'true') {
                    alert('Credit Card is Expired')
                } else {
                        let cartItems = {
                            "items": {
                                "itemList": document.getElementById('cart').value
                            }
                        }

                        let newOrderRequest = new XMLHttpRequest();
                        newOrderRequest.open("POST", "http://localhost:80/order/newOrder/" + newAccount['accountId']);
                        newOrderRequest.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
                        newOrderRequest.send(JSON.stringify(cartItems));
                        newOrderRequest.onload = () => {
                            let accountRequest = new XMLHttpRequest();
                            accountRequest.open("POST", "http://localhost:80/account");
                            accountRequest.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
                            accountRequest.send(JSON.stringify(newAccount));
                            accountRequest.onload = () => {
                                alert('Account has been Created')
                            };
                            let checkOutRequest = new XMLHttpRequest();
                            checkOutRequest.open("DELETE", "http://localhost:80/cart/checkout");
                            checkOutRequest.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
                            checkOutRequest.send(JSON.stringify(newAccount));
                            checkOutRequest.onload = () => {
                                    var email = {
                                        "receiverEmail": document.getElementById('email').value,
                                        "emailSubject": "Order Placed",
                                        "emailBody": "This is a test"
                                    }

                                    try { 
                                        let request = new XMLHttpRequest();
                                        request.open("POST", "http://localhost:80/payment/startPayment/" + document.getElementById('email').value);
                                        request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
                                        request.send(JSON.stringify(creditCard));
                                        request.onload = () => {
                                            alert(request.responseText);
                                        };
                                    } catch (error) {
                                        console.log(error);
                                    }
                                alert('Checkout Completed')
                                location.reload();
                            }
                        };
                }
            }
        }
    };
}

function addRow(Name, Description, UnitPrice, quantity, table) {
    var table = document.getElementById(table);
 
    var rowCount = table.rows.length;
    var row = table.insertRow(rowCount);
 
    row.insertCell(0).innerHTML= Name;
    if (table.id === 'catalog') {
        row.insertCell(1).innerHTML= Description;
        row.insertCell(2).innerHTML= UnitPrice; 
        row.insertCell(3).innerHTML = `<button type='button' onclick='addToCart("${Name}", ${1})'>Add to Cart</button>`
    } else if (table.id === 'cart') {
        row.insertCell(1).innerHTML = quantity;
    }
}

getItems();