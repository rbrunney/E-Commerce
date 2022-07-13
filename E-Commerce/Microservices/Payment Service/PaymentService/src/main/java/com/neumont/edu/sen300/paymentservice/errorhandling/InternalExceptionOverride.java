package com.neumont.edu.sen300.paymentservice.errorhandling;

import com.fasterxml.jackson.core.JsonProcessingException;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.servlet.mvc.method.annotation.ResponseEntityExceptionHandler;

import java.io.IOException;
import java.net.MalformedURLException;

@ControllerAdvice
public class InternalExceptionOverride extends ResponseEntityExceptionHandler {

    /**
     * Exception Handler method if there is a IOException within the REST Service
     * @param ioe A IOException that was caused somewhere within the REST Service
     * @return A ResponseEntity Including an Exception Message, HttpHeaders, and a 400 Bad Request Response
     */
    @ExceptionHandler(IOException.class)
    public final ResponseEntity<ExceptionMessage> entityNotFound(IOException ioe) {
        ExceptionMessage em = new ExceptionMessage(ioe.getMessage(), 400);
        return new ResponseEntity<>(em, new HttpHeaders(), HttpStatus.BAD_REQUEST);
    }

    /**
     * Exception Handler method if there is an NullPointerException within the REST Service
     * @param npe A NullPointerException that was caused somewhere within the REST Service
     * @return A ResponseEntity Including an Exception Message, HttpHeaders, and a 400 Bad Request Response
     */
    @ExceptionHandler(NullPointerException.class)
    public final ResponseEntity<ExceptionMessage> entityNotFound(NullPointerException npe) {
        ExceptionMessage em = new ExceptionMessage(npe.getMessage(), 400);
        return new ResponseEntity<>(em, new HttpHeaders(), HttpStatus.BAD_REQUEST);
    }
}
