package com.neumont.edu.sen300.emailservice.endpoints;

import com.neumont.edu.sen300.emailservice.models.Email;
import org.springframework.web.bind.annotation.*;
import com.neumont.edu.sen300.emailservice.models.SendMail;

@RestController
@RequestMapping("/email")
@CrossOrigin()
public class EmailController {

    /**
     * Endpoint to send and email to a user
     * @param email An Email Object containing the receiving users email, email subject, and email body
     * @return A string of the email containing the receiving users email, email subject, and email body
     */
    @PostMapping("/send")
    public String sendEmail(@RequestBody Email email) {
        new SendMail(email.getReceiverEmail(), email.getEmailSubject(), email.getEmailBody());
        return email.toString();
    }
}
