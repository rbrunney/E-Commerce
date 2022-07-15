
function getItems(){
    var url = 'http://'
}

function addRow(Name, Description, UnitPrice) {
    var table = document.getElementById("shoppingCart");
 
    var rowCount = table.rows.length;
    var row = table.insertRow(rowCount);
 
    row.insertCell(0).innerHTML= Name;
    row.insertCell(1).innerHTML= Description;
    row.insertCell(2).innerHTML= UnitPrice; 
}