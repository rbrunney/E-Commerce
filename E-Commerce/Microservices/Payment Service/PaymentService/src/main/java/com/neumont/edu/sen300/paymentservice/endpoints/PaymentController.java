package com.neumont.edu.sen300.paymentservice.endpoints;

import com.neumont.edu.sen300.paymentservice.models.CreditCard;
import org.springframework.web.bind.annotation.*;

import java.io.IOException;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.time.LocalDate;

@RestController
@RequestMapping("/payment")
public class PaymentController {

    /**
     * End-point to check to see if /payment is running
     * @return A string to validate this endpoint is working
     */
    @GetMapping("/check")
    public String checkPayment() {
        return "Payment is working";
    }

    /**
     * End-point to check if a credit card has not yet expired
     * @param creditCard CreditCard object used to check its date if it is valid
     * @return ture if the card is expired
     */
    @PostMapping("/isExpired")
    public boolean checkIsExpired(@RequestBody CreditCard creditCard) {
        // If the credit card date is after or equal to the current date its good
        if (creditCard.getExpirationDate().isAfter(LocalDate.now()) || creditCard.getExpirationDate().isEqual(LocalDate.now())) {
            return false;
        }

        return true;
    }

    /**
     * End-point to check if the credit cards number is valid
     * @param creditCard CreditCard object used to check its number and CVV if it is valid
     * @return true if the card number and CVV are valid
     */
    @PostMapping("/checkValidation")
    public boolean checkIfValid(@RequestBody CreditCard creditCard) {
        //Checking to see if the CreditCard Number is 16 long and checking each number if it's a digit
        if(creditCard.getCardNumber().length() == 16) {
            for(char number : creditCard.getCardNumber().toCharArray()) {
                if(!Character.isDigit(number)) {
                    return false;
                }
            }
        }
        else {
            return false;
        }

        // Checking to see if CVV is 3 long and checking each number if it's a digit
        if(creditCard.getCVV().length() == 3)
            for(char number : creditCard.getCVV().toCharArray()) {
                if(!Character.isDigit(number)) {
                    return false;
                }
            }
        else {
            return false;
        }

        return true;
    }

    /**
     * End-point to start payment process
     * @param creditCard RequestBody of a CreditCard object used to start payment
     * @param email A Path Variable of the users email
     * @return String stating the state of the payment
     */
    @PostMapping("/startPayment/{email}")
    public String startPayment(@RequestBody CreditCard creditCard, @PathVariable String email) {

        //Creating email information
        String emailSubject = "Order Payment Process Started";
        String emailBody = "Your current order has begun its payment process!" +
                "\nUsing this Credit Card\n" +
                "Number " + creditCard.getCardNumber() + "\n" +
                "CVV " + creditCard.getCVV() + "\n" +
                "Expiration Date " + creditCard.getExpirationDate();

        // Making a request to Email Service to Send Email
        try {
            URL url = new URL("http://localhost:8080/email/send");
            HttpURLConnection con = (HttpURLConnection) url.openConnection();
            con.setRequestMethod("POST");
            con.setRequestProperty("Content-Type", "application/json");
            con.setRequestProperty("Accept", "application/json");
            con.setDoOutput(true);

            // Turning Email information into JSON
            String requestBodyInformation = "{'receiverEmail':" + email + "," +
                                            "'emailSubject':" + emailSubject + "," +
                                            "'emailBody':" + emailBody + "," +
                                            "}";

            //Sending Email Information
            try(OutputStream os = con.getOutputStream()) {
                byte[] input = requestBodyInformation.getBytes("utf-8");
                os.write(input, 0, input.length);
            }
        } catch(IOException ioe) {
            System.out.println("");
        }

        return "Payment Started";
    }

}
