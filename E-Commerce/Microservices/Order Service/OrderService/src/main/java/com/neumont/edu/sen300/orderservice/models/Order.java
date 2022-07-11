package com.neumont.edu.sen300.orderservice.models;

import org.json.JSONObject;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import java.util.Map;

@Document(collection="Orders")
public class Order {
    @Id
    private String id;
    private String accountId;
    private Map<String, Object> items;

    public Order() {}

    public Order(String accountId, Map<String, Object> items) {
        this.accountId = accountId;
        this.items = items;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getAccountId() {
        return accountId;
    }

    public void setAccountId(String accountId) {
        this.accountId = accountId;
    }

    public Map<String, Object> getItems() {
        return items;
    }

    public void setItems(Map<String, Object> items) {
        this.items = items;
    }
}
