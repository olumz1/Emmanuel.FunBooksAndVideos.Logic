# Project Title
Fun Books and Videos

## Getting started
Project was built on Visual studio 2019

Unzip the FunBooksAndVideoEmmanuel folder for access to the solution
Load Emmanuel.FunBooksAndVideos.sln solution in Visual studio 2019 to reveal four individual projects

```
Emmanuel.FunBooksAndVideos.Logic
Emmanuel.FunBooksAndVideos.Console
Emmanuel.FunBooksAndVideos.Test
```

## How to build the code

Right click on 'Emmanuel.FunBooksAndVideos.Console' in the Visual Studio - solution explorer and select 'Set as StartUp Project'
In the Visual Studio menu bar, click on IIS Express to run the solution and if the build is successful, this would launch a console.

## How to run the output

The console with request for a customer Id, please provide a number between 1 - 9 and press enter to return the Id to the solution

button. 

## How to run the test
In visual studio, navigate to the 'Emmanuel.FunBooksAndVideos.Test' project and expand.

This project has 4 tests files
```
AccountDetailsTest - This file contains 3 tests;
	 The first test is to verify that when a customer Id is provided, we are able to retrieve the customer's account details.
	 The second test is when given an order request, we are able to determine customers membership.
	 The third test is to ensure we are able to complete the function that updates members account. 
CustomerOrderTest - This test verify's that when given a customer Id, we are able to retrieve the customer's order request.
PurchaseOrderTest - This file has 2 test;
	 The first test is to verify that when given customer Id the ProcessPurchaseOrder task is completed without errors.
	 The second test is to verify that when given an order request we are able to calulate the total amount of the order.
ShippingSlipTest - This file contains a test that verifies out shipping slip method is called and completed without any errors.
```
To run these tests individually right click on the test and click 'Run Test'. 
To run all the tests in this project, right click on Emmanuel.FunBooksAndVideos.Test and click 'Run Test'.

