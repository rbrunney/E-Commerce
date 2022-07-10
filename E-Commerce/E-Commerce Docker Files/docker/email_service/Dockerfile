# Setting up the Email Service
FROM tomcat:8-jdk8-openjdk

ENV EMAIL=noreply.maineventofutah@gmail.com
ENV EMAIL_PASSWORD=vvfjdocyrnmxhthj

COPY EmailService-1.0.0.jar /usr/local/lib/EmailService.jar

EXPOSE 8080

ENTRYPOINT ["java","-jar","/usr/local/lib/EmailService.jar"]