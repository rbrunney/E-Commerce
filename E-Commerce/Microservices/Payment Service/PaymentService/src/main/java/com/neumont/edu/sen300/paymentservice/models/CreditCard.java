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
