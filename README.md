# AWSServelessDemo - Simple Demo 

This simple project aims to demonstrate how to create an api serveless (c#) in AWS, with AWS Lambda and AWS API Gateway 

# Pre requisites
Install AWS Toolkit for Visual Studio ([click here to download](https://aws.amazon.com/pt/visualstudio/)) Im using VS Community 2019 Preview, Version 16.2.0 Preview 3.0
Download the Toolkit that match your VS version

You need an AWS Account. 
In the first deploys you may see an error about permissions.  You need to configure the right permissions in AWS IAM.

# API's
## /GetAll
this endpoint will generate 100 random GUID's
Demo: https://ea9vompxnc.execute-api.sa-east-1.amazonaws.com/Prod/getall

## /GetOne
this endpoint will generate 1 random GUID's
Demo: https://ea9vompxnc.execute-api.sa-east-1.amazonaws.com/Prod/getone
## /coupon?size=
This one will generate one random string code with the size you pass in parameter
If you pass an value smaller or equal zero, will return Bad Request(400)
If yu pass an not a number parameter, will return Bad Request(400) 

Demo: https://ea9vompxnc.execute-api.sa-east-1.amazonaws.com/Prod/coupon?size=5

# Roadmap

 - Detail the installation steps and permissions
 - Save the generated code in AWS RDS 
 - Create registrations users and associate the generated codes to the user

