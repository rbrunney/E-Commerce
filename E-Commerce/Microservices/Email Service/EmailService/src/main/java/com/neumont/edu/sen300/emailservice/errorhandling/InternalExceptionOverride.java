package com.neumont.edu.sen300.emailservice.errorhandling;

import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.servlet.mvc.method.annotation.ResponseEntityExceptionHandler;

@ControllerAdvice
public class InternalExceptionOverride extends ResponseEntityExceptionHandler {

    @ExceptionHandler(NullPointerException.class)
    public final ResponseEntity<ExceptionMessage> entityNotFound(NullPointerException npe) {
        ExceptionMessage em = new ExceptionMessage(npe.getMessage(), 400);
        return new ResponseEntity<>(em, new HttpHeaders(), HttpStatus.BAD_REQUEST);
    }
}
