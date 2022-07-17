public class Account
{
    public int AccountId { get; set; }
    //First Name
    public string FirstName {get; set;}
    //Last Name
    public string? LastName {get; set;}
    //Email
    public string Email {get; set;}
    //Password
    public string Password {get; set;}

    //Credit Card
    public long CardNum {get; set;}
    //Expiration Date
    public string ExpDate {get; set;}
    //CSV Number
    public int SecurityNum {get; set;}
    //Name
    public string? NameOnCard {get; set;}

    //Address
    //Street
    public string Street {get;set;}
    //Street 2
    public string? Apartment {get;set;}
    //City
    public string City {get;set;}
    //State
    public string State {get;set;}
    //ZipCode
    public int ZipCode {get; set;}

}