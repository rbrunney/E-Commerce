package com.neumont.edu.sen300.orderservice.endpoints;


import com.neumont.edu.sen300.orderservice.models.Order;
import com.neumont.edu.sen300.orderservice.repositories.OrderRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.time.LocalDate;
import java.util.HashMap;
import java.util.Map;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;


@RestController
@RequestMapping("/order")
public class OrderController {
    @Autowired
    private OrderRepository orderRepo;

    /**
     * An End-point to get and Order Object from the database
     * @param orderId A String containing the orderId
     * @return An Order Object containing all the information including OrderId, AccountId, and Items
     */
    @GetMapping("/{orderId}")
    public Order getOrder(@PathVariable String orderId) {
        return orderRepo.findOrderById(orderId);
    }

    /**
     * An End-Point to create a new order and you can send in JSONObject in any form to be saved to the database
     * @param orderInfo JSONObject where the shape and form can come in any shape
     * @param accountId A String which is a PathVariable containing the accountId
     * @return A Map<String, Object> which contains, a message, orderPlaceDate, and orderItems for the response
     */
    @PostMapping ("/newOrder/{accountId}")
    public Map<String, Object> makeOrder(@RequestBody Map<String, Object> orderInfo, @PathVariable String accountId) {

        // Inserting orderInfo into database and grabbing the ID it made for it
        String orderId = orderRepo.save(new Order(accountId, orderInfo)).getId();

        // Creating response Information
        Map<String, Object> response = new HashMap<>();
        response.put("message", "Order has been made");
        response.put("orderId", orderId);
        response.put("orderPlacedDate", LocalDate.now());

        return response;
    }

    /**
     * A end-point to cancel a order and delete it from the database
     * @param orderId A String containing the Orders ID
     * @param accountId A String containing the Account ID
     * @return A Map<String, String> which contains the message for the response
     */
    @DeleteMapping("/cancel/{orderId}/{accountId}")
    public Map<String, String> cancelOrder(@PathVariable String orderId, @PathVariable String accountId) {

        // Deleting Order by finding the order with the same accountId and orderId
        orderRepo.delete(orderRepo.findOrderByAccountIdAndId(accountId, orderId));

        // Creating Response Information
        Map<String, String> response = new HashMap<>();
        response.put("message", "Order has been canceled");

        return response;
    }
}
