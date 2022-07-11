# Setting up the Email Service
FROM tomcat:8-jdk8-openjdk

COPY OrderService-1.0.0.jar /usr/local/lib/OrderService.jar

ENTRYPOINT ["java","-jar","/usr/local/lib/OrderService.jar"]

EXPOSE 8080