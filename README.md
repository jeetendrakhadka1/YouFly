# YouFly

## sp17-final-g1

### Team member availability

You can put your availability on this [Google Sheet](https://docs.google.com/a/selu.edu/spreadsheets/d/1Urh66VrqoI2p3o7P7yi1AEXekmWGMp_FHtRQglJkfbI/edit?usp=sharing) so we can all have an idea of good times to meet.

## Requirements (copy/pasted from pdf)

### Description

You will be creating a solution for a fledgling domestic airline. They have a small fleet of
planes and contracts with existing airports in place but no web presence at all.

### Some background on the client:

* They are called “YouFly”
* Their 2-letter IATA designation is “YF”
* They are a U.S. based airline offering only domestic flights

### Has requested the following features:

#### 1. An admin-only area where admins may:

* a. Quickly add routes between two airports by their IATA 3-letter designation

* * i. List of airport codes you can use [this](https://raw.githubusercontent.com/jpatokal/openflights/master/data/airports.dat)

* * 1. “MSY” -> "Louis Armstrong New Orleans International Airport","New Orleans","United States"

* * ii. Only include domestic (US) airports

* * iii. Admin will enter: Day of week / Time of Day

* * 1. E.g. Wednesday 9 PM
* * 2. E.g. Sunday 3:15 AM

* * iv. Specify number of seats of each type

* * 1. “First Class” and “Business” are the two seat types
* * 2. E.g. (12/40) - for “First Class” / “Business”

* * v. Specify travel time and travel distance

* * 1. E.g. 3.25 hrs, 400 mi
* * 2. E.g. 0.75 hrs, 150 mi

* * vi. Each route has a different price for each seat - All our prices include all taxes / fees / etc

* * 1. E.g. MSY->COS 9AM Monday First Class seat is $500
* * 2. E.g. MSY->COS 9AM Monday Business seat is $300
* * 3. E.g. MSY->DAL 11PM Wednesday First Class is only $375

* * vii. There will be ~300 of these to enter, so make this easy, keyboard/hotkey friendly input for a data entry team

* * viii. Overall, a route represents:

* * 1. MSY->COS 9AM Monday, 4.25 hrs 1000 mi ($500/$300) (12/40)
* * 2. In english this would represent:

* * * a. A flight from MSY to COS
* * * b. Departs 9AM Monday from MSY
* * * c. A flight time of 4.25 hours
* * * d. A flight distance of 1000 mi
* * * e. With First Class tickets being $500
* * * f. 12 First Class tickets are available
* * * g. With Business tickets being $300
* * * h. 40 Business tickets are available

* * b. Add Admins

* * * i. Provide a starting admin of admin@selu.edu with password “password”

* * c. View all Purchases (see below section on how a user makes these)

#### 2. A public facing website where users may:

* a. Register an account using an email and password

* * i. Only one email per user

* b. Search our available flights

* * i. This is available to everyone (signed in or not)
* * ii. Allow them to search by “airport name”, IATA 3-letter designation, or City name

* * 1. E.g. “Louis Armstrong” / “MSY” / “New Orleans” are all valid to find IATA 3-letter “MSY”

* * * a. Allow for partial matches / show closest 5 matches here

* * iii. User provides a “FROM” and “TO” airport

* * 1. Let them know if there are no matching flights

* * * a. Wishlist: suggest nearby alternative airports

* * * * i. E.g. If there is no BTR->COS, then suggest MSY->COS as an alternative since BR is close to NO

* c. Purchase seats on a selected flight

* * i. User must be signed in for this feature

* * 1. Prompt them to make an account / sign in here (assuming they were not signed in)

* * ii. User specifies the date they want that flight

* * 1. E.g. “MSY->COS 9AM Monday” - could be 13th, 20th, or 27th of March 2017. But NOT the 14th of March (as that is a Tuesday)

* * iii. User selects the number of seats of each class they want

* * 1. Cannot buy more seats than the number available for a given class of seat
* * 2. User should see the totals add up as they increase / decrease the number of seats
* * 3. Just a reminder: our prices include all taxes / fees / etc

* * iv. User “Checks Out” that purchase

* * 1. User provides First Name / Last Name for each seat
* * 2. User provides CC number / CC expiration
* * 3. User provides Phone Number

* * v. User “Completes Checkout” after providing the info above

* * 1. User’s CC is charged
* * 2. Confirmation number is generated:

* * * a. Format should be YF#1234567

* * * * i. You can pick any number you want, but one purchase should be a unique confirmation number

* * 3. User is emailed a receipt

* * * a. Should include a confirmation number (this system should generate this), list of passengers (first/last name), total price, flight date,flight time
* * * b. Doesn’t need to be pretty, just needs to be easily understood - attachments are OK (NOT REQUIRED) as long as they are text or PDF

* * 4. User is redirected to a “thank you” page with the same info as the receipt email above and a link to our mobile app (more on that below)

#### 3. A new Mobile application

* a. Allows Users to sign in or create account

* * i. Email and password used
* * ii. Must tie into the same user list as the website

* b. Once signed in, a User should be able to see all Purchases they have made
* c. A user should be able to see Purchase details (same as the receipt email data)
* d. A user should be able to pull up their Virtual Boarding pass(es) for a Purchase

* * i. This should include Flight details (flight, date, time, seat type)
* * ii. This should include Passenger details (First Name, Last Name)
* * iii. This should include the confirmation number
* * iv. A QR code that contains all this information in a CSV format

* * 1. From,To,Date,Time (24-hour time),FirstName,LastName,Seat,Confirmation
* * 2. E.g. MSY,COS,2017/3/13,17:30,Matthew,Person,First Class,YF#1234567

* * * a. ![QR Code](res/qr_code.png) 
* * * b. This represents From MSY To COS, Monday March 13th, at 5:40PM - passenger Matthew Person flying First Class, confirmation YF#1234567

* * 3. This barcode must be readable by any standard QR reader

* * v. There should be exactly one Virtual Boarding Pass per passenger!
* * vi. Swipe left or right to change passenger

### Technology Needed

* Node
* Angular 2
* Angular CLI
* VS Code
* Xamarin
* Visual Studio 2017

### Technical Requirements

* Notes on Visual Studio 2017:

* * Visual Studio 2015 and 2017 install SIDE BY SIDE - installing 2017 will change nothing of 2015 if you have issues
* * Remember that there is a mobile application involved in this phase and it is recommended you use the intel emulator with GPU acceleration for this as Kyle showed on 3/14 if using Mac (Windows emulator for android by default in 7.0 is fast)
* *     ■ So be sure to install Xamarin as part of the 2017 install
* * Please note that Visual Studio 2017 converts “project.json” to a “.csproj” in .NET Core - so mixing 2015 and 2017 is a bad idea

* You should generate your customer facing website project with Angular CLI like in phase 3
* The API that your customer facing website and mobile application use should be a ASP.NET Core web api that you create
* To avoid CORS issues (from last phase) have the customer facing website and web api be all in the same project - this will make it easy to share code (which you should strive for)

* Your database should be a SQL Server database managed and accessed with Entity Framework Core with migrations

* * Code First
* * You can handle the airport seed a number of ways, the only requirement is that if we pull down your repository fresh the airports should be present for use
* * Seed a initial “admin@selu.edu” / “password” ADMIN user to log into the backend
* * User emails must be enforced unique at the database level
* * Confirmation numbers on purchase must be enforced unique at the database level

* Your mobile app should be built using Xamarin

* * You may use Xamarin native or Xamarin forms
* * You may target android or iOS (or both)

* The admin data entry side is likely easiest to implement in ASP.NET core MVC - though if you want that to be an angular 2 site, then have at it. Either option is valid.
