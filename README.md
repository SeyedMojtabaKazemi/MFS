# MFS
Merchant Financial System is a sample project that created with Rest API and Clean Architucture.
In this project used Repository pattern and CQRS

# Documentation

Swagger Url: https://localhost:44384/swagger/index.html

API Url: https://localhost:44384/

Online Document: https://documenter.getpostman.com/view/19206493/UVkpQG1t

# Overview
The business of this project is as follows:

this project contains 3 aggregates:
- Merchant
- Transaction
- Commmission

every merchant can have a number of transactions that in per month they must pay 1% of total transactions in that month as commission.
Declare a percent for merchants that creating in database that shows percent of discount commission.
Furthermore if a merchant has over 20 transactions in month, 10% of commmission is reduced.
Also all of transactions in saturday and sunday dont have any commission.
