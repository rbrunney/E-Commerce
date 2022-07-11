package com.neumont.edu.sen300.orderservice.repositories;

import com.neumont.edu.sen300.orderservice.models.Order;
import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface OrderRepository extends MongoRepository<Order, String> {

    // Finding the Order that matches both the account if and order id
    Order findOrderByAccountIdAndId(String accountId, String orderId);

    // Finding the order that matches the order id
    Order findOrderById(String orderId);
}
