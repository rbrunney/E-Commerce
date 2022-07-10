package com.neumont.edu.sen300.paymentservice.util;

import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;

public class URLRequestsUtil {

    /**
     * A method to send a request to the given URLLink and request body information
     * @param urlLink A string containing the link to send the POST request
     * @param requestBody A JSONObject containing information for the request body
     */
    public static void sendPostRequest(String urlLink, JSONObject requestBody) throws IOException {

        // Setting up Connection & opening connection
        URL url = new URL (urlLink);
        HttpURLConnection con = (HttpURLConnection)url.openConnection();
        con.setRequestMethod("POST");

        // Setting up request and response information
        con.setRequestProperty("Content-Type", "application/json");
        con.setRequestProperty("Accept", "application/json");

        // Allowing Request Body
        con.setDoOutput(true);

        // Creating request body
        try(OutputStream os = con.getOutputStream()) {
            byte[] input = requestBody.toString().getBytes("utf-8");
            os.write(input, 0, input.length);
        }

        // Reading the response from request
        try(BufferedReader br = new BufferedReader(
                new InputStreamReader(con.getInputStream(), "utf-8"))) {
            StringBuilder response = new StringBuilder();
            String responseLine = null;
            while ((responseLine = br.readLine()) != null) {
                response.append(responseLine.trim());
            }
            System.out.println(response.toString());
        }
    }

}
