# Setting up the Email Service
FROM tomcat:8-jdk8-openjdk

COPY PaymentService-1.0.0.jar /usr/local/lib/PaymentService.jar

ENTRYPOINT ["java","-jar","/usr/local/lib/PaymentService.jar"]

EXPOSE 8081