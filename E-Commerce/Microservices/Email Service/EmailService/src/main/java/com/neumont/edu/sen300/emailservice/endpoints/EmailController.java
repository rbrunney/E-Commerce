package com.neumont.edu.sen300.emailservice.endpoints;

import com.neumont.edu.sen300.emailservice.models.Email;
import org.springframework.web.bind.annotation.*;
import com.neumont.edu.sen300.emailservice.models.SendMail;

@RestController
@RequestMapping("/email")
public class EmailController {

    @GetMapping("/check")
    public String checkEndPoint() {
        return "Email is working";
    }

    @PostMapping("/send")
    public String sendEmail(@RequestBody Email email) {
        new SendMail(email.getReceiverEmail(), email.getEmailSubject(), email.getEmailBody());
        return email.toString();
    }
}
