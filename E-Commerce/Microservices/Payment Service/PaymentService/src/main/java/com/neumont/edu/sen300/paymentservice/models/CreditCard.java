package com.neumont.edu.sen300.paymentservice.models;

import java.time.LocalDate;

public class CreditCard {

    private String cardNumber;
    private String CVV;
    private LocalDate expirationDate;

    public CreditCard() {}

    public CreditCard(String cardNumber, String CVV, LocalDate expirationDate) {
        this.cardNumber = cardNumber;
        this.CVV = CVV;
        this.expirationDate = expirationDate;
    }

    public void setCardNumber(String cardNumber) {
        if (cardNumber.isEmpty()) { throw new NullPointerException("Credit Card Number is Null or Empty"); }
        this.cardNumber = cardNumber;
    }

    public void setCVV(String CVV) {
        if (CVV.isEmpty()) { throw new NullPointerException("Credit Card CVV is Null or Empty"); }
        this.CVV = CVV;
    }

    public void setExpirationDate(LocalDate expirationDate) {
        if(expirationDate == null) { throw new NullPointerException("Credit Card Expiration Date is Null or Empty"); }
        this.expirationDate = expirationDate;
    }

    public String getCardNumber() {
        return cardNumber;
    }

    public String getCVV() {
        return CVV;
    }

    public LocalDate getExpirationDate() {
        return expirationDate;
    }
}
