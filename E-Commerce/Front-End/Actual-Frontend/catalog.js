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
            addRow(element['name'], element['description'], element['unitPrice']);
        });
    };
}

function makeItem(){
    var url = 'http://localhost:80/ecommerce/makeitem';
    var item = {
        "id": "",
        "name": document.getElementById("Name").value,
        "description": document.getElementById('Description').value,
        "unitPrice": document.getElementById('UnitPrice').value
    };
    console.log(item);
    let request = new XMLHttpRequest();
    request.open("POST", url);
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.send(JSON.stringify(item));
    request.onload = () => {
        location.reload();
    };    
}

function editItem(){
    var url = 'http://localhost:80/ecommerce/' + document.getElementById("editName").value;
    var item = {
        "id": "",
        "name": document.getElementById("editName").value,
        "description": document.getElementById('editDescription').value,
        "unitPrice": document.getElementById('editUnitPrice').value
    };
    console.log(item);
    let request = new XMLHttpRequest();
    request.open("PUT", url);
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.setRequestHeader("Access-Control-Allow-Origin", "*");
    request.send(JSON.stringify(item));
    request.onload = () => {
        location.reload();
    };    
}

function deleteItem(){
    var url = 'http://localhost:80/ecommerce/' + document.getElementById("deleteName").value;

    let request = new XMLHttpRequest();
    request.open("DELETE", url);
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.setRequestHeader("Access-Control-Allow-Origin", "*");
    request.send();
    request.onload = () => {
        location.reload();
    };    
}

function addRow(Name, Description, UnitPrice) {
    var table = document.getElementById("shoppingCart");
 
    var rowCount = table.rows.length;
    var row = table.insertRow(rowCount);
 
    row.insertCell(0).innerHTML= Name;
    row.insertCell(1).innerHTML= Description;
    row.insertCell(2).innerHTML= UnitPrice; 
}

getItems();