# User Manual
Hot Desk is a workplace management web application for enterprises. It allows employees to reserve workplaces for a single day and select additional devices based on personal needs. Administrators can register new users, add workplaces, manage roles, and current reservations.

![login_screen](https://i.imgur.com/Bh3uzrj.jpg)

For convenience, this manual will be separated into two parts: employee UI manual and admin UI manual.

## Admin UI

Once you input your credentials, you’ll be redirected to the Admin page with a navigation bar that lets you access all entities in the database:

![admin_panel](https://i.imgur.com/Upu2bCO.jpg)

In Manage Roles, Manage Users, Manage Workplaces and Manage Devices you can add entries to databases via pop-up forms on each respective page. Here’s an example of adding a new device to the database:

![add_device](https://media.giphy.com/media/ttEIxD6Jb5uRGTxz4P/giphy.gif)

**Note: you can’t remove admin and employee, as they are base roles for the application.*

As Admin, you can’t make new reservations, but you can cancel active reservations and edit devices that employees reserved for the workplace. To do that, go to Manage Reservations and click on Edit Devices:

![edit_devices](https://media.giphy.com/media/SdM4NEckRdppNtSjZR/giphy.gif)

## Employee UI

As employee you have access to workplace reservation interface. Upon successful authentication you’ll be directed to Home page where you’ll be able to select a reservation date.

![employee_panel](https://i.imgur.com/sL6sRMk.jpg)

Click on the date input field to select a desired date. If there are available places for that date, you’ll see a list of workplaces. To make a reservation, click on Book Workplace. After that, you’ll be directed to reservation confirmation page, where you’ll need to select additional devices for your workplace:

![res_confirmation](https://i.imgur.com/R4ckxj0.jpg)

Upon confirmation, you’ll be able to review your reservations on My Reservations page.

# Architecture description

Hot Desk application is using Repository-Service design pattern with Entity Framework Core as object-relational mapper. Six primary entities are defined in the app:

1)	**User** – application user, user login and password are required for authentication;
2)	**Role** – entity used for authorization, each user has a role;
3)	**Workplace** – entity that describes workplaces;
4)	**Device** – available devices that can be included to reservation;
5)	**Reservation** – entity that describes reservations made by user, includes workplace and devices;
6)  **Status** - entity that describes possible statuses of a reservation. By design, there are 3 statuses: active, complete and cancelled;

Data access layer is represented by Repository.cs class which includes 4 generic methods to work with database entities:

Business logic layer includes two services: AdminService.cs and EmployeeService.cs. These services are injected into Admin and Home Controllers respectively.

As Admins have almost unlimited access to the database, AdminService mostly serves as a pass-through for methods defined in Repository.cs class. However, there are two methods that are different from the ones in Repository.cs:

1)	**UpdateDevices(int[] deviceIds)** – updates a set of devices based on their Ids;
2)	**private bool CantRemoveRole(Role role)** – this private method is used to prevent admins from removing admin and employee roles from the database.

In EmployeeService functions are more restrictive and don’t include any generic methods:

1)	**GetAvailableWorkplaces(DateTime preferredDate)** – returns a collection of all workplaces that are available for a given date;
2)	**GetAllDevices** – returns a collection of all available devices from the database;
3)	**BookDevices(int[] deviceIds)** – this method is used to 
4)	**MakeReservation(Reservation reservation)** – adds a reservation to the database;
