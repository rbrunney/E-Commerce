

public class Account
{
    //First Name
    public string FirstName {get; set;}

    //Last Name
    public string? LastName {get; set;}

    //Email
    public string Email {get; set;}

    //Password
    public string Password {get; set;}

    //Credit Card
    public CreditCard PaymentInfo {get; set;}

    //Address
    public Address ShipAddress {get; set;}
}