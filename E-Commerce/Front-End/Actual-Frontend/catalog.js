function getItems(){
    var url = 'http://localhost:9000/ecommerce/getallitems';

    let request = new XMLHttpRequest();
    request.open("GET", url);
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.setRequestHeader('Access-Control-Allow-Origin', '*');
    request.send();
    request.onload = () => {
        console.log(request);
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